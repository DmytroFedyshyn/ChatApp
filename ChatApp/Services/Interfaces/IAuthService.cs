namespace ChatApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string username, string email, string password);
        Task<string> LoginAsync(string email, string password);
        Task<string> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
        Task<string> ConfirmEmailAsync(string email, string token);
    }
}
