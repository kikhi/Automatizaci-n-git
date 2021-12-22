using System.Diagnostics;

//int menu = 0;

Console.WriteLine("Bienvenido al git automatico");
Console.WriteLine("|------------------------------------|");
Console.WriteLine("|1.- Clonar                          |");
Console.WriteLine("|2.- Subir cambios                   |");
Console.WriteLine("|3.- Cambiar a main                  |");
Console.WriteLine("|------------------------------------|");



ProcessStartInfo cmd = new ProcessStartInfo();
cmd.FileName = "cmd.exe";