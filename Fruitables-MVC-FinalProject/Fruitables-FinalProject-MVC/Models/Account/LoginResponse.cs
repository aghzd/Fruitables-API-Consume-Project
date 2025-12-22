namespace Fruitables_FinalProject_MVC.Models.Account
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public List<string> Errors { get; set; }
    }
}