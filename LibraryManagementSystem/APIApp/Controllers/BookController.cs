using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookService service;

        public BookController(BookService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            return Ok(data);
        }

        [HttpPost("create")]
        public IActionResult Create(BookDTO b)
        {
            var res = service.Create(b);
            if (res == true)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpPut("update")]
        public IActionResult Update(BookDTO b)
        {
            var res = service.Update(b);
            if (res == true)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            if (res == true)
                return Ok(res);
            else
                return BadRequest(res);
        }
    }
}
