namespace MyBread.Models;

public class AuthReqBody
{
    private string login;
    private string password;

    public AuthReqBody(string login, string password)
    {
        this.login = login;
        this.password = password;
    }

    public AuthReqBody()
    {
    }

    public string Login
    {
        get => login;
        set => login = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Password
    {
        get => password;
        set => password = value ?? throw new ArgumentNullException(nameof(value));
    }
}