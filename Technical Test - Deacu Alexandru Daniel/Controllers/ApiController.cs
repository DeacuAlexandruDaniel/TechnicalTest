using Microsoft.AspNetCore.Mvc;
using Technical_Test___Deacu_Alexandru_Daniel.Services;

namespace Technical_Test___Deacu_Alexandru_Daniel.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ApiController : ControllerBase
    {
        protected readonly IApiService apiService;
        public ApiController(IApiService apiService)
        {
            this.apiService = apiService;   
        }

        [HttpPost("/balancedBrackets")]
        public string CheckBalancedBrackets([FromBody] string? brackets)
        {
            if (brackets == string.Empty || brackets == null)
            {
                throw new ArgumentNullException("Input null or empty string");
            }

            Stack<char> charStack = new Stack<char>();

            foreach (char c in brackets)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    charStack.Push(c);
                }
                else
                {
                    if (charStack.Count == 0 || !apiService.IsMatchingPair(charStack.Pop(), c))
                    {
                        return "Not Balanced";
                    }
                }
            }

            return charStack.Count == 0 ? "Balanced" : "Not Balanced";
        }

        [HttpPost("/singleNumber")]
        public int FindSingleNumber(int[] numbers)
        {
            HashSet<int> seen = new HashSet<int>();

            foreach (int num in numbers)
            {
                if (seen.Contains(num))
                {
                    seen.Remove(num);
                }
                else
                {
                    seen.Add(num);
                }
            }

            if (seen.Count == 1)
            {
                return seen.FirstOrDefault();
            }

            throw new Exception("Wrong Input");
        }
    }
}
