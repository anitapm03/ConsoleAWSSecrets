using ConsoleAWSSecrets;
using ConsoleAWSSecrets.Helpers;
using ConsoleAWSSecrets.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

Console.WriteLine("Ejemplo secrets manager");
string miSecreto = await HelperSecretManager.GetSecretAsync();
Console.WriteLine(miSecreto);

//PODEMOS DAR FORMATO A NUESTRO SECRET PARA PODER UTILIZARLO COMO CLASE
KeysModel model = JsonConvert.DeserializeObject<KeysModel>(miSecreto);
Console.WriteLine("MySql: " + model.Mysql);

//almacenamos el objeto keysmodel dentro de DY
var provider = 
    new ServiceCollection()
    .AddTransient<ClaseTest>()
    .AddSingleton<KeysModel>
    (x => model).BuildServiceProvider();

//en cualquier clase podemos recuperar las keys, pej
//en el propio program si necesitamos connection string
//o en cualquier otra clase de inyeccion
var service =  provider.GetService<KeysModel> ();
string connectionString = service.Mysql;
Console.WriteLine(connectionString);


var test = provider.GetService<ClaseTest>();
Console.WriteLine("Api desde clasetest: " + test.GetValue());