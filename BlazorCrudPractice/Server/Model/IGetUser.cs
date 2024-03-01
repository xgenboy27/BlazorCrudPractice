namespace BlazorCrudPractice.Server.Model
{
    public interface IGetUser
    {
        Task<User> Get(string pEmailUserName);
    }
}
