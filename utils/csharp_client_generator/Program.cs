using NSwag;
using NSwag.CodeGeneration.CSharp;

System.Net.WebClient wclient = new System.Net.WebClient();

var document = await OpenApiDocument.FromJsonAsync(wclient.DownloadString("http://localhost:5280/swagger/v1/swagger.json"));
wclient.Dispose();

var settings = new CSharpClientGeneratorSettings
{
    ClassName = "Client",
    CSharpGeneratorSettings = { Namespace = "Api" }
};

var generator = new CSharpClientGenerator(document, settings);
var code = generator.GenerateFile();

string outputPath = "./frontend/cli";
string fileName = "api.cs";
string fullPath = Path.Combine(outputPath, fileName);
File.WriteAllText(fullPath, code);
