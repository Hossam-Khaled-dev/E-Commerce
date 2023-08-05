using Microsoft.AspNetCore.Http;

namespace Api.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message?? GetDefaultMessageForStatusCode(statusCode);
        }

        int StatusCode { get; set; }
        public string Message { get; set; }

        private string  GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {

                400 => "A bad Request , you have mase",
                401 =>"Authorized you are not ",
                404 => "Response it is not ",
                500=> "server error occured",
                _=> null


            };
        }
    }
}
