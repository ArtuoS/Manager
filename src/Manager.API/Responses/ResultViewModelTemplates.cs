namespace Manager.API.Responses
{
    public static class ResultViewModelTemplates
    {
        public static ResultViewModel Success(object data = null, string message = "") => new ResultViewModel()
        {
            Message = message == null ? string.Empty : message,
            Data = data,
            Success = true
        };

        public static ResultViewModel Exception(string errorMessage) => new ResultViewModel()
        {
            Message = errorMessage,
            Success = false
        };

        public static ResultViewModel DomainError(string errorMessage, IEnumerable<string> errors) => new ResultViewModel()
        {
            Message = errorMessage,
            Data = errors
        };
    }
}