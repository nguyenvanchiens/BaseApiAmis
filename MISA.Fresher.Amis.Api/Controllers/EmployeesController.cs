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
        public IActionResult GetAllPaging([FromQuery] PageRequestBase pageRequest)
        {
            try
            {
               var result = _employeeService.GetPaging(pageRequest);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteMulti")]
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
            var result = _employeeService.GetAll();
            var stream = new MemoryStream();

            //Format Ctrl+A -> Home -> Format -> Column(with, height)

            using (var package = new ExcelPackage(stream))
            {
                var sheet = package.Workbook.Worksheets.Add("NhanVien");
                // đổ dữ liệu vào sheet
                sheet.Cells[1, 1].Value = "Mã Nhân Viên";
                sheet.Cells[1, 2].Value = "Tên Nhân Viên";
                sheet.Cells[1, 3].Value = "Ngày Sinh";
                sheet.Cells[1, 4].Value = "Giới Tính";
                sheet.Cells[1, 5].Value = "Căn Cước Công Dân";
                sheet.Cells[1, 6].Value = "Nơi Cấp Chứng Minh Nhân Dân";
                sheet.Cells[1, 7].Value = "Chức Danh";
                sheet.Cells[1, 8].Value = "Địa Chỉ";
                sheet.Cells[1, 9].Value = "Số Tài Khoản Ngân Hàng";
                sheet.Cells[1, 10].Value = "Tên Khoản Ngân Hàng";
                sheet.Cells[1, 11].Value = "Tên Ngân Hàng";
                sheet.Cells[1, 12].Value = "Số điện thoại";
                sheet.Cells[1, 13].Value = "Tên Phòng Ban";
                sheet.Cells[1, 14].Value = "Email";
                int rowId = 2;
                foreach(var row in result)
                {
                    sheet.Cells[rowId, 1].Value = row.EmployeeCode;
                    sheet.Cells[rowId, 2].Value = row.EmployeeName;
                    sheet.Cells[rowId, 3].Value = row.DateOfBirth;
                    sheet.Cells[rowId, 4].Value =row.GenderName;
                    sheet.Cells[rowId, 5].Value = row.IdentityNumber;
                    sheet.Cells[rowId, 6].Value = row.IdentityPlace;
                    sheet.Cells[rowId, 7].Value = row.EmployeePosition;
                    sheet.Cells[rowId, 8].Value = row.Address;
                    sheet.Cells[rowId, 9].Value = row.BankAccountNumber;
                    sheet.Cells[rowId, 10].Value = row.BankName;
                    sheet.Cells[rowId, 11].Value = row.BankBranchName;
                    sheet.Cells[rowId, 12].Value = row.PhoneNumber;
                    sheet.Cells[rowId, 13].Value = row.DepartmentName;
                    sheet.Cells[rowId, 14].Value = row.Email;
                    rowId++;
                }
                //save
                package.Save();
            }

            stream.Position = 0;
            var fileName = $"DanhSachNhanVien_{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
    }
}
