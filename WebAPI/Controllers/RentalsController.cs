using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrentdetails")]
        public IActionResult GetRentDetails()
        {
            var result = _rentalService.GetRentDetails();
            if (result.Success)
            {
                var rents = result.Data;
                
                foreach (var rent in rents)
                {
                    return Ok(rent.FirstName + " -- " + rent.LastName + " -- " + rent.CompanyName + " -- " + rent.ReturnDate);
                }

            }
            return BadRequest(result);
        }
    }
}
