using models;

namespace interfaces
{
    public interface IUserBusiness
    {
        Task<List<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserByIdAsync(string id);
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(string id, UserModel user);
        Task DeleteUserAsync(string id);
    }
}