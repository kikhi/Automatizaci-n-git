using System.Diagnostics;
using System;
namespace MyApp // Note: actual namespace depends on the project name.
{

    class Controller
    {
        private int? menuSelector;
        public int? MenuSelector
        {
            get { return menuSelector; }
            set { menuSelector = value; }
        }
        private string? repositorieLink;
        private string? commentChanges;


        public void Clone()
        {
            Process cmd = new Process();

            repositorieLink = Console.ReadLine();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine("git clone {0}", repositorieLink);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            Console.ReadKey();
            Console.Clear();
        }

        public void UploadChanges()
        {
            Process cmd = new Process();

            Console.WriteLine("Comentarios de los cambios:");
            commentChanges = Console.ReadLine();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine("git add .");
            cmd.StandardInput.WriteLine("git commit -m \"{0}\"", commentChanges);
            cmd.StandardInput.WriteLine("git push");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            Console.ReadKey();
            Console.Clear();
        }

        public void ChangeBranch()
        {
            Process cmd = new Process();

            Console.WriteLine("Comentarios de los cambios");
            commentChanges = Console.ReadLine();
            Console.WriteLine("Link del repositorio:");
            repositorieLink = Console.ReadLine();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine("git init");
            cmd.StandardInput.WriteLine("git add .");
            cmd.StandardInput.WriteLine("git commit -m \"{0}\"", commentChanges);
            cmd.StandardInput.WriteLine("git remote add origin {0}", repositorieLink);
            cmd.StandardInput.WriteLine("git push -u origin main");
            cmd.StandardInput.WriteLine("git branch -m master main");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            Console.ReadKey();
            Console.Clear();
        }

        public void Manual()
        {
            Console.WriteLine("- EL automatizador git es para programadores novatos que hablan español ya que los guiara en los procesos");
            Console.WriteLine("- Clonara subira cambios y permitira cambiar de rama");
            Console.WriteLine("- Recuerda que al trabajar en equipo no se trabaja en la rama principal, cada uno tiene la suya propia");
            Console.WriteLine("- El main es para el producto final");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            
            while(controller.MenuSelector != 5)
            {
                Console.WriteLine("========    Git Automation    ========");
                Console.WriteLine("|------------------------------------|");
                Console.WriteLine("|1.- Clone                           |");
                Console.WriteLine("|2.- Upload changes                   |");
                Console.WriteLine("|3.- Change branch                     |");
                Console.WriteLine("|4.- Manual                          |");
                Console.WriteLine("|5.- Exit                            |");
                Console.WriteLine("|------------------------------------|");

                controller.MenuSelector = Convert.ToInt32(Console.ReadLine());

                switch (controller.MenuSelector)
                {
                    case 1:
                        controller.Clone();
                        break;
                    case 2:
                        controller.UploadChanges();
                        break;
                    case 3:
                        controller.ChangeBranch();
                        break;
                    case 4:
                        controller.Manual();
                        break;
                    case 5:
                        Console.WriteLine("Good bye");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
