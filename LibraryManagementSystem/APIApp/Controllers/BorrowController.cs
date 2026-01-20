using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        BorrowService service;

        public BorrowController(BorrowService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Get();
            return Ok(data);
        }

        [HttpPost("borrow")]
        public IActionResult Borrow(BorrowDTO b)
        {
            var res = service.BorrowBook(b);
            if (res == true)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpPost("return/{id}")]
        public IActionResult Return(int id)
        {
            var res = service.ReturnBook(id);
            if (res == true)
                return Ok(res);
            else
                return BadRequest(res);
        }
    }
}
