using System;
using System.IO;

namespace textEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Oque você deseja fazer ?");
            Console.WriteLine("1 - Abrir um arquivo");
            Console.WriteLine("2 - Criar um arquivo");
            Console.WriteLine("3 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }

        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo que deseja abrir ?");
            string path = Console.ReadLine();
            using var file = new StreamReader(path);
            string text = file.ReadToEnd();
            Console.WriteLine(text);

        }
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("________________________");
            string text = "";
            do
            {
                text += Console.ReadLine() + "\n";
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Salvar(text);
        }
        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            Console.WriteLine("________________________");
            var path = Console.ReadLine();

            using var file = new StreamWriter(path);
            file.Write(text);

            Console.WriteLine("$ Arquivo salvo com sucesso ! {path}");
            Console.ReadLine();
            Menu();
        }
    }
}
