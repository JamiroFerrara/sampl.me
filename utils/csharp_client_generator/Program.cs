using NSwag;
using NSwag.CodeGeneration.CSharp;

var content = File.ReadAllText("../../backend/api/swagger.json");
var document = await OpenApiDocument.FromJsonAsync(content);

var settings = new CSharpClientGeneratorSettings
{
    ClassName = "Client",
    CSharpGeneratorSettings = { Namespace = "Api" }
};

var generator = new CSharpClientGenerator(document, settings);
var code = generator.GenerateFile();

string outputPath = "../../frontend/cli";
string fileName = "api.cs";
string fullPath = Path.Combine(outputPath, fileName);
File.WriteAllText(fullPath, code);
