using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService service;

        public CategoryController(CategoryService service)
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
        public IActionResult Create(CategoryDTO c)
        {
            var res = service.Create(c);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPut("update")]
        public IActionResult Update(CategoryDTO c)
        {
            var res = service.Update(c);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpGet("all/books")]
        public IActionResult AllWithBooks()
        {
            var res = service.GetWithBooks();
            return Ok(res);
        }
        [HttpGet("search/{name}")]
        public IActionResult FindByName(string name)
        {
            var data = service.FindByName(name);
            return Ok(data);
        }

        [HttpGet("search/{name}/books")]
        public IActionResult FindByNameWithBooks(string name)
        {
            var data = service.FindByNameWithBooks(name);
            return Ok(data);
        }
    }
}
