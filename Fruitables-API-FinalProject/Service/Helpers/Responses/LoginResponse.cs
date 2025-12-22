namespace Service.Helpers.Responses
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public string Token { get; set; }
    }
}