using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

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

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result=_carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
                        
            return BadRequest(result);
            
            
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                //!!!Döngü için tekrardan bak!!! Ok ile sadece bir defa dönüyor.

                var cars = result.Data;
                foreach (var car in cars)
                {
                    return Ok(car.CarName + " -- " + car.BrandName + " -- " + car.DailyPrice);
                }

                //return Ok(cars);
                //foreach (var cars in result.Data)
                //{
                //    return Ok(cars.CarName + " -- " + cars.BrandName + " -- " + cars.DailyPrice);
                //}
                
            }
            return BadRequest(result);
        }


    }
}
