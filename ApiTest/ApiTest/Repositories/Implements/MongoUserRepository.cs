using ApiTest.DbConnectors;
using ApiTest.Exceptions;
using ApiTest.Models.Dtos;
using ApiTest.Models.Entities;
using ApiTest.Repositories.Interfaces;
using MongoDB.Driver;

namespace ApiTest.Repositories.Implements
{
    public class MongoUserRepository : UserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;
        public MongoUserRepository(MongoDbConnector mongoDbConnector)
        {
            _usersCollection = mongoDbConnector.UsersCollection;
        }

        public IEnumerable<User> FindAll()
            => _usersCollection.Find(x => true).ToEnumerable();

        public User FindById(string id)
        {
            if (id.Length != 24)
                throw new IdLengthException(id);

            var user = _usersCollection.Find(x => x.Id == id).FirstOrDefault();

            if (user == null)
                throw new IdNotExistException(id);

            return user;
        }

        public User FindByName(string name)
        {
            var user = _usersCollection.Find(x => x.Name == name).FirstOrDefault();

            if (user == null)
                throw new NameNotExistException(name);

            return user;
        }

        public User Create(UserCreateDto userCreateDto)
        {
            var user = new User(userCreateDto.Name, userCreateDto.Password);
            _usersCollection.InsertOne(user);

            return user;
        }

        public User UpdateById(UserCreateDto userCreateDto)
        {
            throw new NotImplementedException();
        }

        public User DeleteById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
