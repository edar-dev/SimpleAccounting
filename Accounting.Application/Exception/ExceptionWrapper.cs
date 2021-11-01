namespace Accounting.Application.Exception
{
    public class ExceptionWrapper : System.Exception
    {
        public string ErrosMessageCode { get; }

        public ExceptionWrapper(string errosMessageCode ,System.Exception exception) : base(exception.Message,exception)
        {
            ErrosMessageCode = errosMessageCode;
        }
    }
}