namespace RedStarter.API.DataContract.Authorization
{
    public class LoginUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}