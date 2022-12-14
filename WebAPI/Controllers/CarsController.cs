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
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("getcarsbymodelid")]
        //public IActionResult GetCarsByModelId(int modelId)
        //{
        //    var result = _carService.GetAllCarsByModelId(modelId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpGet("getcarsbycolorid")]
        //public IActionResult GetCarsByColorId(int colorId)
        //{
        //    var result = _carService.GetAllCarsByColorId(colorId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcardetails")]
        public IActionResult GetAllCarDetails()
        {
            var result = _carService.GetAllCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcardetailsbybrandid")]
        public IActionResult GetAllCarDetailsByBrandId(int brandId)
        {
            var result = _carService.GetAllCarDetailsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("getallcardetailsbycolorid")]
        //public IActionResult GetAllCarDetailsByColorId(int colorId)
        //{
        //    var result = _carService.GetAllCarDetailsByColorId(colorId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpGet("getallcardetailsbymodelid")]
        public IActionResult GetAllCarDetailsByModelId(int modelId)
        {
            var result = _carService.GetAllCarDetailsByModelId(modelId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbyid")]
        public IActionResult GetCarDetailsById(int id)
        {
            var result = _carService.GetCarDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("getallcardetailsbybrandidcolorid")]
        //public IActionResult GetAllCarDetailsByBrandIdColorId(int brandId, int colorId)
        //{
        //    var result = _carService.GetAllCarDetailsByBrandIdColorId(brandId, colorId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
                
        //[HttpGet("getallcardetailsbybrandidcoloridmindailypricemaxdailyprice")]
        //public IActionResult GetAllCarDetailsByBrandIdColorIdMinDailyPriceMaxDailyPrice(int brandId, int colorId, int minDailyPrice, int maxDailyPrice)
        //{
        //    var result = _carService.GetAllCarDetailsByBrandIdColorIdMinDailyPriceMaxDailyPrice(brandId, colorId, minDailyPrice, maxDailyPrice);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        
    }
}
