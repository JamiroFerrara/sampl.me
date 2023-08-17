// See https://aka.ms/new-console-template for more information
using Api;

var client = new Client("http://localhost:5280", new HttpClient());

await client.CreateUserAsync(new User()
{
    Email = "email",
    Username = "username",
    Password = "password"
});

await client.CreatePussyAsync(new Pussy
{
    Name = "vagain"
});

var vagain = await client.GetAllPussyAsync();
foreach (var user in vagain)
    Console.WriteLine(user.Name);
