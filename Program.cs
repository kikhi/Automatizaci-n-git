using System.Diagnostics;

static void Clonar()
{
    Process cmd = new Process();
    string? nombreDocumento = null;

    nombreDocumento = Console.ReadLine();

    cmd.StartInfo.FileName = "cmd.exe";
    cmd.StartInfo.CreateNoWindow = true;
    cmd.StartInfo.RedirectStandardInput = true;
    cmd.StartInfo.RedirectStandardOutput = true;
    cmd.StartInfo.UseShellExecute = false;
    cmd.Start();
    cmd.StandardInput.WriteLine("git clone {0}", nombreDocumento);
    cmd.StandardInput.Flush();
    cmd.StandardInput.Close();
    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
    Console.ReadKey();
    Console.Clear();
    Menu();
}

static void subirCambios()
{
    Process cmd = new Process();
    string? comentarioCambios = null;

    Console.WriteLine("Comentarios de los cambios:");
    comentarioCambios = Console.ReadLine();

    cmd.StartInfo.FileName = "cmd.exe";
    cmd.StartInfo.CreateNoWindow = true;
    cmd.StartInfo.RedirectStandardInput = true;
    cmd.StartInfo.RedirectStandardOutput = true;
    cmd.StartInfo.UseShellExecute = false;
    cmd.Start();
    cmd.StandardInput.WriteLine("git add .");
    cmd.StandardInput.WriteLine("git commit -m \"{0}\"", comentarioCambios);
    cmd.StandardInput.WriteLine("git push");
    cmd.StandardInput.Flush();
    cmd.StandardInput.Close();
    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
    Console.ReadKey();
    Console.Clear();
    Menu();
}

static void cambiarRama()
{
    Process cmd = new Process();
    string? comentarioCambios = null;
    string? linkRepositorio = null;

    Console.WriteLine("Comentarios de los cambios");
    comentarioCambios = Console.ReadLine();
    Console.WriteLine("Link del repositorio:");
    linkRepositorio = Console.ReadLine();

    cmd.StartInfo.FileName = "cmd.exe";
    cmd.StartInfo.CreateNoWindow = true;
    cmd.StartInfo.RedirectStandardInput = true;
    cmd.StartInfo.RedirectStandardOutput = true;
    cmd.StartInfo.UseShellExecute = false;
    cmd.Start();
    cmd.StandardInput.WriteLine("git init");
    cmd.StandardInput.WriteLine("git add .");
    cmd.StandardInput.WriteLine("git commit -m \"{0}\"", comentarioCambios);
    cmd.StandardInput.WriteLine("git remote add origin {0}", linkRepositorio);
    cmd.StandardInput.WriteLine("git push -u origin main");
    cmd.StandardInput.WriteLine("git branch -m master main");
    cmd.StandardInput.Flush();
    cmd.StandardInput.Close();
    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
    Console.ReadKey();
    Console.Clear();
    Menu();
}

static void Manual()
{

}

static void Menu()
{
    int menu;

    Console.WriteLine("Bienvenido al git automatico");
    Console.WriteLine("|------------------------------------|");
    Console.WriteLine("|1.- Clonar                          |");
    Console.WriteLine("|2.- Subir cambios                   |");
    Console.WriteLine("|3.- Cambiar a rama                  |");
    Console.WriteLine("|4.- Manual de app                   |");
    Console.WriteLine("|5.- Salir de la app                 |");    
    Console.WriteLine("|------------------------------------|");

    menu = Convert.ToInt32(Console.ReadLine());

    switch(menu)
    {
        case 1:
            Console.WriteLine("Clonar");
            Clonar();
            break;
        case 2:
            Console.WriteLine("Subir cambios");
            subirCambios();
            break;
        case 3:
            Console.WriteLine("Cambiar main");
            cambiarRama();
            break;
        case 4:
            Console.WriteLine("Manual");
            Manual();
            break;
        case 5:
            Console.WriteLine("Adios");
            Environment.Exit(0);
            break;
    }
}

Menu();
Console.ReadKey();