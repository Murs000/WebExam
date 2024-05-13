using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;

namespace WebExam.Mappers.Implementations
{
    public class UserMapper : IUserMapper
    {
        public UserModel Map(User entity)
        {
            UserModel model = new UserModel()
            {
                Id = entity.Id,
                Login = entity.Login,
                Name = entity.Name,
                Role = entity.Role,
                Surname = entity.Surname,
                PasswordHash = entity.PasswordHash,
            };
            return model;
        }

        public User Map(UserModel model)
        {
            User entity = new User()
            {
                Id = model.Id,
                Login = model.Login,
                Name = model.Name,
                Role = model.Role,
                Surname = model.Surname,
                PasswordHash = model.PasswordHash,
            };
            return entity;
        }

        public List<UserModel> Map(List<User> entities)
        {
            List<UserModel> models = new List<UserModel>();
            foreach (var entity in entities)
            {
                UserModel model = Map(entity);
                models.Add(model);
            }
            return models;
        }

        public List<User> Map(List<UserModel> models)
        {
            List<User> entities = new List<User>();
            foreach (var model in models)
            {
                User entity = Map(model);
                entities.Add(entity);
            }
            return entities;
        }
    }
}
