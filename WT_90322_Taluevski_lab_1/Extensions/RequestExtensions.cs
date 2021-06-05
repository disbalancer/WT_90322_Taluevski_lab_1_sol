using Microsoft.AspNetCore.Http;
namespace WT_90322_Taluevski_lab_1.Extensions
{
    public static class RequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request
                       .Headers["x-requested-with"]
                       .Equals("XMLHttpRequest");
        }
    }
}
