using Microsoft.AspNetCore.Mvc;

public class User : Table
{
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }

    public bool login([FromBody] LoginRequest req) => Where<User>(x =>
                x.username == req.email &&
                x.password == req.password
                )?.Result?.Count() > 0;
}

public class LoginRequest
{
    public string email { get; set; }
    public string password { get; set; }
}
