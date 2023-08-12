public class User : SurrealTable
{
    public string email { get; set; }
    public string password { get; set; }
    public Picture picture { get; set; }
}

public class Picture : SurrealS3
{
    public string description { get; set; }
}
