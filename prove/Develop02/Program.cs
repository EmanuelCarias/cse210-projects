using System;
using System.Collections.Generic;
//Emanuel Carias, W02 Prove: Developer—Journal
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
        Console.WriteLine("Journal saved in the archive: " + filename);
    }

    public void LoadFromFile(string filename)
    {
        // Implementación para cargar el diario desde un archivo
        Console.WriteLine("Journal loaded from the archive: " + filename);
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
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Show the journal");
            Console.WriteLine("3. Saving the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
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
                    Console.Write("Enter the name of the file to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case 4:
                    Console.Write("Enter the name of the file to upload: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case 5:
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        string[] prompts = {
           "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the Lord's hand in my life today?", "What was the strongest emotion I felt today?",
            "What was the strongest emotion I felt today?", "What was the strongest emotion I felt today?", "What was the strongest emotion I felt today?",
            "If you could do one thing again today, what would it be?"
        };

        Random rand = new Random();
        string randomPrompt = prompts[rand.Next(prompts.Length)];

        Console.WriteLine($"Ask: {randomPrompt}");
        Console.Write("Enter your answer: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry entry = new Entry(randomPrompt, response, date);
        journal.AddEntry(entry);

        Console.WriteLine("Entry successfully added.");
    }
}
