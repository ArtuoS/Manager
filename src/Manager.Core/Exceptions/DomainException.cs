namespace Manager.Core.Exceptions
{
    public class DomainException : Exception
    {
        private IEnumerable<string> _errors;
        public IEnumerable<string> Errors => _errors;

        public DomainException()
        { }

        public DomainException(string message, IEnumerable<string> errors) : base(message)
        {
            _errors = errors;
        }

        public DomainException(string message) : base(message)
        { }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}