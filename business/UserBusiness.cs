using interfaces;
using Microsoft.Extensions.Options;
using models;
using repositories;
using repositories.Settings;
namespace business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly UserRepository _userRepository;

        public UserBusiness(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var settings = mongoDbSettings.Value;
            _userRepository = new UserRepository(settings.ConnectionString!, settings.DatabaseName!,
                settings.CollectionName!);
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            await _userRepository.CreateUserAsync(user);
            
            return user;
        }

        public async Task<UserModel> UpdateUserAsync(string id, UserModel user)
        {
            user.Id = id;
            await _userRepository.UpdateUserAsync(id, user);
            
            return user;
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}