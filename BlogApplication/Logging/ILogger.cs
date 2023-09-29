namespace BlogApplication.Logger.Logger
{
    public interface ILogger
    {
        public void WriteEvent(string eventMessage);
        public void WriteError(string errorMessage);
    }
}
