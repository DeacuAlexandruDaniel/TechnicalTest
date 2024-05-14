namespace Technical_Test___Deacu_Alexandru_Daniel.Services
{
    public class BalancedBracketsService : IBalancedBracketsService
    {
        public BalancedBracketsService() { }

        public string CheckBalancedBrackets(string brackets)
        {
            if (brackets == string.Empty || brackets == null)
            {
                throw new ArgumentNullException("Input is null or empty string");
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
                    if (charStack.Count == 0 || !IsMatchingPair(charStack.Pop(), c))
                    {
                        return "Not Balanced";
                    }
                }
            }

            return charStack.Count == 0 ? "Balanced" : "Not Balanced";
        }

        private bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '[' && closing == ']') ||
                   (opening == '{' && closing == '}');
        }
    }
}
