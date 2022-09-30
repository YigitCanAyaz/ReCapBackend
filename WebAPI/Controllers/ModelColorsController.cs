using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelColorsController : ControllerBase
    {
        private readonly IModelColorService _modelColorService;

        public ModelColorsController(IModelColorService modelColorService)
        {
            _modelColorService = modelColorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _modelColorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _modelColorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ModelColor modelColor)
        {
            var result = _modelColorService.Add(modelColor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ModelColor modelColor)
        {
            var result = _modelColorService.Update(modelColor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ModelColor modelColor)
        {
            var result = _modelColorService.Delete(modelColor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
