namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }


        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return statusCode switch
            {
                400 => "A bad request you have made",
                401 => "You're not authorise for this request",
                404 => "Resource for which you have request not found",
                500 => "System reference error is found",
                _ => null
            };
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
