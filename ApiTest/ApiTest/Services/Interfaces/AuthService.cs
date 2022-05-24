namespace ApiTest.Services.Interfaces
{
    public interface AuthService
    {
        public string Login(string name, string password, HttpContext httpContext);
    }
}
