using Microsoft.AspNetCore.Mvc;
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
        public string CheckBalancedBrackets([FromBody] string? brackets)
        {
            return balancedBracketsService.CheckBalancedBrackets(brackets);
        }

        [HttpPost("/singleNumber")]
        public int FindSingleNumber(int[] numbers)
        {
            return findSingleNumberService.FindSingleNumber(numbers);
        }
    }
}
