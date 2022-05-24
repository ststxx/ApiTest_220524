using ApiTest.Attributes.Enums;
using ApiTest.Exceptions;
using ApiTest.Models.Dtos;
using ApiTest.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ApiTest.Attributes
{
    public class ApiTestAttribute : Attribute, IActionFilter
    {
        AttributeTypes _attributeType;
        public ApiTestAttribute(AttributeTypes attributeType)
        {
            _attributeType = attributeType;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var httpClientFactory = context.HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("other_server");
            var userRepository = context.HttpContext.RequestServices.GetService<UserRepository>();
            //var skip = int.Parse(context.HttpContext.Request.Query["skip"]);
            //var userEmailClaim = context.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
            //var path = context.HttpContext.Request.Path.ToString().Split('/');
            try 
            {
                if (_attributeType == AttributeTypes.LOGIN)
                {
                    var loginDto = context.ActionArguments["loginDto"] as LoginDto;
                    var user = userRepository.FindByName(loginDto.Name);
                    Console.WriteLine($"Login try user name: {user.Name}...");
                    //if (user == null)
                    //    throw new NameNotExistException(loginDto.Name);
                    //EnsureTreeLicense(0, 0, httpClient);
                }
            }
            catch (Exception e)
            {
                //if (e is NameNotExistException)
                //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //return;
            }
        }

        private void EnsureTreeLicense(int treeManagerCount, int treeWorkerCount, HttpClient httpClient)
        {
            //var licenseRequestDto = new LicenseRequestDto
            //{
            //    TreeManagerCount = treeManagerCount,
            //    TreeWorkerCount = treeWorkerCount,
            //};
            //var httpResponseMessage = httpClient.PostAsJsonAsync("/packages/tree/validation/", licenseRequestDto).Result;
            //httpResponseMessage.EnsureSuccessStatusCode();
            //var responseContentString = httpResponseMessage.Content.ReadAsStringAsync().Result;
            //var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            //var licenseResponseDto = JsonSerializer.Deserialize<LicenseResponseDto>(responseContentString, options);
            //if (licenseResponseDto.Result != true)
            //    throw new TreeLicenseFailException(licenseResponseDto.MaxTreeManager, treeManagerCount, licenseResponseDto.MaxTreeWorker, treeWorkerCount);
        }
    }
}
