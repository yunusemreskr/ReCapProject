using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumersController : ControllerBase
    {
        ICostumerService _costumerService;
        public CostumersController(ICostumerService costumerService)
        {
            _costumerService=costumerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _costumerService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getusersbycompanyname")]
        public IActionResult GetUsersByCompanyName(string companyname)
        {
            var result = _costumerService.GetUsersByCompanyName(companyname);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Costumer costumer)
        {
            var result = _costumerService.Add(costumer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
