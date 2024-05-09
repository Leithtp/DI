namespace DI.Services.Counter
{
    public class Counter : ICounter
    {
        public int count;
        public Counter()
        {
            count = 0;
        }
        public string Add(int x)
        {
            count += x;
            return $"Count: {count}";
        }
    }
}
