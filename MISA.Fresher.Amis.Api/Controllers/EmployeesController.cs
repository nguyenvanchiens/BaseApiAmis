using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiSA.Fresher.Amis.Core.Common;
using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.InterFace.Service;
using OfficeOpenXml;
using OfficeOpenXml.Style;

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
        public IActionResult GetAllPagings([FromQuery] PagingRequestBase pageRequest)
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
        [HttpGet("NewCodeEmployee")]
        public IActionResult GetNewCode()
        {
            var result = _employeeService.NewCodeEmployee();
            return Ok(result);
        }
        /// <summary>
        /// Xuất file excecl cho danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NVCHien(27/12/2021)
        [HttpGet("Export")]
        public IActionResult Export()
        {

            ////Format Ctrl+A -> Home -> Format -> Column(with, height)

            var stream = new MemoryStream();
            var listEmployee = _employeeService.GetAll();
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
                foreach (var employee in listEmployee)
                {
                    sheet.Cells[rowId, 1].AutoFitColumns(10, 10);
                    for (int i = 1; i <= 9;i++)
                    {
                        // Thêm border cho cột
                        sheet.Cells[rowId, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        // Thêm width vs height cho cột
                        sheet.Cells[rowId, i+1].AutoFitColumns(20,30);
                        sheet.Cells[rowId, i+1].Merge = true;
                    }
                    
                    sheet.Cells[rowId,1].Value = stt;
                    sheet.Cells[rowId, 2].Value = employee.EmployeeCode;
                    sheet.Cells[rowId, 3].Value = employee.EmployeeName;
                    sheet.Cells[rowId, 4].Value = employee.GenderName;
                    sheet.Cells[rowId, 5].Value = employee.DateOfBirth;
                    sheet.Cells[rowId, 6].Value = employee.EmployeePosition;
                    sheet.Cells[rowId, 7].Value = employee.DepartmentName;
                    sheet.Cells[rowId, 8].Value = employee.BankAccountNumber;
                    sheet.Cells[rowId, 9].Value = employee.BankName;
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
