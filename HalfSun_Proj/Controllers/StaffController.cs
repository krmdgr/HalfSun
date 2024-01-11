using HalfSun_Proj.IRepo;
using HalfSun_Proj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HalfSun_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepo _service;
        public StaffController(IStaffRepo service)
        {
            _service = service;
        }
        [HttpGet("GetAllStaff")]
        public async Task<IActionResult> GetAllStaff()
        {
            var data = await _service.GetList();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddStaff(StaffModel model)
        {
            var data = await _service.Add(model);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
