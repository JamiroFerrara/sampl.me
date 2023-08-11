public class User : SurrealTable
{
    public string username { get; set; }
    public string password { get; set; }
    public Profile profile { get; set; }
}

public class Profile
{
    public string profile_picture { get; set; }
    public string description { get; set; }
}
