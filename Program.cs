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


        public string Clone()
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
            return "Clone completed";
        }

        public string UploadChanges()
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
            return "Fin del manual";
        }

        public string ChangeBranch()
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
            return "Change completed";
        }

        public string Manual()
        {
            Console.WriteLine("- The automation git will guide you in your task");
            Console.WriteLine("- This app, let you clone, upload changes and change branches");
            Console.WriteLine("- Remember, when you work in team need make your own branch for work");
            Console.WriteLine("- The main branch is for the final product");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            return "Fin del manual";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            string? result = null;
            while(controller.MenuSelector != 5)
            {
                Console.WriteLine("========    Git Automation    ========");
                Console.WriteLine("|------------------------------------|");
                Console.WriteLine("|1.- Clone                           |");
                Console.WriteLine("|2.- Upload changes                  |");
                Console.WriteLine("|3.- Change branch                   |");
                Console.WriteLine("|4.- Manual                          |");
                Console.WriteLine("|5.- Exit                            |");
                Console.WriteLine("|------------------------------------|");

                controller.MenuSelector = Convert.ToInt32(Console.ReadLine());

                switch (controller.MenuSelector)
                {
                    case 1:
                        result = controller.Clone();
                        Console.WriteLine(result);
                        break;
                    case 2:
                        result = controller.UploadChanges();
                        Console.WriteLine(result);
                        break;
                    case 3:
                        result = controller.ChangeBranch();
                        Console.WriteLine(result);
                        break;
                    case 4:
                        result = controller.Manual();
                        Console.WriteLine(result);
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
