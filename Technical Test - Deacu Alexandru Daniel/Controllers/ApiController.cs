
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Technical_Test___Deacu_Alexandru_Daniel.Services;

namespace Technical_Test___Deacu_Alexandru_Daniel.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ApiController : ControllerBase
    {
        protected readonly IBalancedBracketsService balancedBracketsService;
        protected readonly IFindSingleNumberService findSingleNumberService;

        public ApiController(IBalancedBracketsService balancedBracketsService, 
            IFindSingleNumberService findSingleNumberService)
        {
            this.balancedBracketsService = balancedBracketsService;   
            this.findSingleNumberService = findSingleNumberService;
        }

        [HttpPost("/balancedBrackets")]
        public IActionResult CheckBalancedBrackets([FromBody] string? brackets)
        {
            try
            {
                return Ok(balancedBracketsService.CheckBalancedBrackets(brackets));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("/singleNumber")]
        public IActionResult FindSingleNumber(int[] numbers)
        {
            try
            {
                return Ok(findSingleNumberService.FindSingleNumber(numbers));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
