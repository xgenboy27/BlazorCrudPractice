namespace BlazorCrudPractice.Server.Model
{
     public interface IPasswordValidation
    {
        Task<bool> Validate(User pUser, string pPassword);
    }
}
