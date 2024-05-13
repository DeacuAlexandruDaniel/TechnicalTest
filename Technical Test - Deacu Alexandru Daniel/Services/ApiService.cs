namespace Technical_Test___Deacu_Alexandru_Daniel.Services
{
    public class ApiService : IApiService
    {
        public ApiService() { }

        public bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '[' && closing == ']') ||
                   (opening == '{' && closing == '}');
        }
    }
}
