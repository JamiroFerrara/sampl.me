using Microsoft.AspNetCore.Mvc;

public class User : Table
{
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }

    public async Task<bool> login([FromBody] LoginRequest req)
    {
        var res = await Where<User>(x => x.username == req.email && x.email == req.email);
        if (res.Count() > 0) return true;
        else return false;
    }

    public async Task<User[]> getjamiro() => await Where<User>(x => x.username == "jamiro");
}

public class LoginRequest
{
    public string email { get; set; }
    public string password { get; set; }
}
