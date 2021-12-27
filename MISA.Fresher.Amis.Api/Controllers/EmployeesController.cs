using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiSA.Fresher.Amis.Core.Common;
using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.InterFace.Service;
using OfficeOpenXml;

namespace MISA.Fresher.Amis.Api.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService):base(employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetAllPaging")]
        public IActionResult GetAllPagings([FromQuery] PageRequestBase pageRequest)
        {
            try
            {
                var result = _employeeService.GetPaging(pageRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("DeleteMulti")]
        public IActionResult DeleteMulti([FromBody] List<string> listId)
        {
            try
            {
                var result = _employeeService.DeleteMultiRecord(listId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
        [HttpGet("NewCodeEmployee")]
        public IActionResult GetNewCode()
        {
            var result = _employeeService.NewCodeEmployee();
            return Ok(result);
        }
        [HttpGet("Export2")]
        public IActionResult Export2()
        {
            var result = _employeeService.GetAll();
            var stream = new MemoryStream();

            using(var package = new ExcelPackage(stream))
            {
                var sheet = package.Workbook.Worksheets.Add("NhanVien");
                // đổ dữ liệu vào sheet
                sheet.Cells.LoadFromCollection(result, true);
                //save
                package.Save();
            }

            stream.Position = 0;
            var fileName = $"NhanVien_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
        [HttpGet("Export")]
        public IActionResult Export()
        {

            ////Format Ctrl+A -> Home -> Format -> Column(with, height)

            var stream = new MemoryStream();
            var result = _employeeService.GetAll();
            var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\MiSA.Fresher.Amis.Core\ExcelTemplate\Danh_sach_nhan_vien.xlsx"));
            FileInfo existingFile = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet sheet = package.Workbook.Worksheets[0];
                // đổ dữ liệu vào sheet

                int rowId = 4;
                int stt = 1;
                foreach (var row in result)
                {
                    sheet.Cells[rowId,1].Value = stt;
                    sheet.Cells[rowId, 2].Value = row.EmployeeCode;
                    sheet.Cells[rowId, 3].Value = row.EmployeeName;
                    sheet.Cells[rowId, 4].Value = row.GenderName;
                    sheet.Cells[rowId, 5].Value = row.DateOfBirth;
                    sheet.Cells[rowId, 6].Value = row.EmployeePosition;
                    sheet.Cells[rowId, 7].Value = row.DepartmentName;
                    sheet.Cells[rowId, 8].Value = row.BankAccountNumber;
                    sheet.Cells[rowId, 9].Value = row.BankName;
                    stt++;
                    rowId++;
                }
                stream = new MemoryStream(package.GetAsByteArray());
            }
            stream.Position = 0;
            var fileName = $"DanhSachNhanVien_{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
    }
}
