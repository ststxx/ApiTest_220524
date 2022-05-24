namespace ApiTest.Models.Dtos
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public UserCreateDto(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
