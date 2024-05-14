namespace Technical_Test___Deacu_Alexandru_Daniel.Services
{
    public class FindSingleNumberService : IFindSingleNumberService
    {
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
