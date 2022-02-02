using System.Diagnostics;


Console.WriteLine("Bienvenido al git automatico");
Console.WriteLine("|------------------------------------|");
Console.WriteLine("|1.- Clonar                          |");
Console.WriteLine("|2.- Subir cambios                   |");
Console.WriteLine("|3.- Cambiar a main                  |");
Console.WriteLine("|------------------------------------|");

Process cmd = new Process();
cmd.StartInfo.FileName = "cmd.exe";
cmd.StartInfo.CreateNoWindow = true;
cmd.StartInfo.RedirectStandardInput = true;
cmd.StartInfo.RedirectStandardOutput = true;
cmd.StartInfo.UseShellExecute = false;
cmd.Start();
cmd.StandardInput.Write("echo hello world!");
cmd.StandardInput.Flush();
cmd.StandardInput.Close();
Console.WriteLine(cmd.StandardOutput.ReadToEnd());

Console.ReadKey();
