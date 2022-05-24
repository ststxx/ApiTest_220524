using ApiTest.Models.Dtos;
using ApiTest.Models.Entities;

namespace ApiTest.Repositories.Interfaces
{
    public interface UserRepository
    {
        public IEnumerable<User> FindAll();
        public User FindById(string id);
        public User FindByName(string name);
        public User Create(UserCreateDto userCreateDto);
        public User UpdateById(UserCreateDto userCreateDto);
        public User DeleteById(string id);
    }
}
