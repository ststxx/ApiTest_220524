using ApiTest.Exceptions.Enums;
using ApiTest.Models.Dtos;

namespace ApiTest.Exceptions
{
    public class ApiTestException : Exception
    {
        ApiTestErrorCodes _apiTestErrorCode;
        public ApiTestException(string message, ApiTestErrorCodes apiTestErrorCodes) : base(message)
        {
            _apiTestErrorCode = apiTestErrorCodes;
        }
        public ErrorResponse ToErrorResponse()
        {
            return new ErrorResponse(this.Message, _apiTestErrorCode);
        }
    }

    public class UnknownException : ApiTestException
    {
        public UnknownException()
            : base("Unknown Error...", ApiTestErrorCodes.UNKNOWN) { }
    }
    public class IdNotExistException : ApiTestException
    {
        public IdNotExistException(string id)
            : base($"Id Not Exist... | Id: {id}", ApiTestErrorCodes.IDNOTEXIST) { }
    }
    public class IdLengthException : ApiTestException
    {
        public IdLengthException(string id)
            : base($"Id Length should be 24 digit | Id: {id}", ApiTestErrorCodes.IDLENGTH) { }
    }
    public class NameNotExistException : ApiTestException
    {
        public NameNotExistException(string name)
            : base($"Name Not Exist... | Name: {name}", ApiTestErrorCodes.NAMENOTEXIST) { }
    }
}
