using DesafioBackend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DesafioBackend.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IOptions<UserDatabaseConfiguration> userConfiguration)
        {
            var mongoClient = new MongoClient(userConfiguration.Value.ConnectionString);

            var desafioBackendDatabase = mongoClient.GetDatabase(userConfiguration.Value.DatabaseName);

            _user = desafioBackendDatabase.GetCollection<User>(userConfiguration.Value.UserCollectionName);
        }

        public User GetById(string id) => _user.Find(x => x.Id == id).FirstOrDefault();

        public List<User> GetAll() => _user.Find(_ => true).ToList();

        public void Create(User user)
        {
            _user.InsertOne(user);
        }

        public void Update(string id, User newUser) => _user.ReplaceOne(x => x.Id == id, newUser);

        public void Delete(string id) => _user.DeleteOne(x => x.Id == id);
    }
}
