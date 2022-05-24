using ApiTest.Exceptions.Enums;
using System.Text.Json.Serialization;

namespace ApiTest.Models.Dtos
{
    public class ErrorResponse
    {
        public string Message { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ApiTestErrorCodes ErrorCode { get; set; }

        public ErrorResponse(string message, ApiTestErrorCodes errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }
    }
}
