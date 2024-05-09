namespace DI.Services.Logger
{
    public class ConsoleLogger : ITransientLogger, IScopedLogger, ISingletonLogger, IDisposable
    {
        public string _guid;

        public ConsoleLogger()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public void LogGuid()
        {
            Console.WriteLine(_guid);    
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
