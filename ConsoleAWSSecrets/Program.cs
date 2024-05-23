using ConsoleAWSSecrets.Helpers;
using ConsoleAWSSecrets.Models;
using Newtonsoft.Json;

Console.WriteLine("Ejemplo secrets manager");
string miSecreto = await HelperSecretManager.GetSecretAsync();
Console.WriteLine(miSecreto);

//PODEMOS DAR FORMATO A NUESTRO SECRET PARA PODER UTILIZARLO COMO CLASE
KeysModel model = JsonConvert.DeserializeObject<KeysModel>(miSecreto);
Console.WriteLine("MySql: " + model.Mysql);

