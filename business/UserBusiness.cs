using interfaces;
using models;
using repositories;

namespace business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly UserRepository _userRepository;

        public UserBusiness(UserRepository userRepository)
        {
            _userRepository = userRepository;
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
            // Implement any validation or pre-processing logic here (optional)

            await _userRepository.CreateUserAsync(user);

            // Additional logic after user creation (optional)

            return user;
        }

        public async Task<UserModel> UpdateUserAsync(string id, UserModel user)
        {
            // Implement any validation or pre-processing logic here (optional)

            user.Id = id; // Ensure the ID matches the update target
            await _userRepository.UpdateUserAsync(id, user);

            // Additional logic after user update (optional)

            return user;
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}