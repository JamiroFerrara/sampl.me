using Microsoft.AspNetCore.Mvc;

public class User : Table
{
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }

    public async Task<bool> login(string email, string password) =>
        await Count<User>(x =>
                x.username == email &&
                x.password == password
                ) > 0;
}

public class Sample : S3Table
{
    public string name { get; set; }
    public string description { get; set; }
    public List<string> tag { get; set; }

    public async Task<bool> addTag(string tag, string id)
    {
        var res = await Where<Sample>(x => x.Id == id);
        var first = res.FirstOrDefault();
        first.tag.Add(tag);

        await Update<Sample>(first, id);
        return true;
    }
}

public class Alessia : Table
{
    public string name { get; set; }
}
