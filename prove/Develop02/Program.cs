using System;
using System.Collections.Generic;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date}: {Prompt}\n{Response}\n";
    }
}

class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        // Implementación para guardar el diario en un archivo
        Console.WriteLine("Diario guardado en el archivo: " + filename);
    }

    public void LoadFromFile(string filename)
    {
        // Implementación para cargar el diario desde un archivo
        Console.WriteLine("Diario cargado desde el archivo: " + filename);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        MainMenu(journal);
    }

    static void MainMenu(Journal journal)
    {
        while (true)
        {
            Console.WriteLine("1. Escribir una nueva entrada");
            Console.WriteLine("2. Mostrar el diario");
            Console.WriteLine("3. Guardar el diario en un archivo");
            Console.WriteLine("4. Cargar el diario desde un archivo");
            Console.WriteLine("5. Salir");

            Console.Write("Ingrese su elección: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    WriteNewEntry(journal);
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    Console.Write("Ingrese el nombre del archivo para guardar: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case 4:
                    Console.Write("Ingrese el nombre del archivo para cargar: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case 5:
                    Console.WriteLine("Saliendo del programa.");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        string[] prompts = {
            "¿Quién fue la persona más interesante con la que interactué hoy?",
            "¿Cuál fue la mejor parte de mi día?",
            "¿Cómo vi la mano del Señor en mi vida hoy?",
            "¿Cuál fue la emoción más fuerte que sentí hoy?",
            "Si pudiera hacer una cosa de nuevo hoy, ¿qué sería?"
        };

        Random rand = new Random();
        string randomPrompt = prompts[rand.Next(prompts.Length)];

        Console.WriteLine($"Pregunta: {randomPrompt}");
        Console.Write("Ingrese su respuesta: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry entry = new Entry(randomPrompt, response, date);
        journal.AddEntry(entry);

        Console.WriteLine("Entrada agregada exitosamente.");
    }
}
