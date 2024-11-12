using models;

namespace interfaces
{
    public interface IUserBusiness
    {
        List<UserModel> GetUsers();
        UserModel GetUserById(string id);
        UserModel CreateUser(UserModel user);
        UserModel UpdateUser(string id, UserModel user);
        void DeleteUser(string id);
    }
}