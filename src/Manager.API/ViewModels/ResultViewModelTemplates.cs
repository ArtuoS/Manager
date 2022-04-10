namespace Manager.API.ViewModels
{
    public static class ResultViewModelTemplates
    {
        public static ResultViewModel CreatedSuccess(object data, string message = "Created.")
        {
            return new ResultViewModel()
            {
                Message = message,
                Data = data,
                Success = true
            };
        }
        
        public static ResultViewModel GetSuccess(object data)
        {
            return new ResultViewModel()
            {
                Data = data,
                Success = true
            };
        }

        public static ResultViewModel CreatedNoSuccess(string errorMessage)
        {
            return new ResultViewModel()
            {
                Message = errorMessage,
                Success = false
            };
        }
    }
}