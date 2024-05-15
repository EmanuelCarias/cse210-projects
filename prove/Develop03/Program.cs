using System;
using System.Collections.Generic;
using System.Linq;

public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int Verse { get; private set; }
    public int? EndVerse { get; private set; }

    public Reference(string book, int chapter, int verse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse.HasValue ? $"{Book} {Chapter}:{Verse}-{EndVerse}" : $"{Book} {Chapter}:{Verse}";
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void Hide()
    {
        Hidden = true;
    }

    public override string ToString()
    {
        return Hidden ? "_____" : Text;
    }
}

public class Scripture
{
    public Reference Reference { get; private set; }
    public List<Word> Words { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count = 1)
    {
        var visibleWords = Words.Where(word => !word.Hidden).ToList();
        var random = new Random();
        var wordsToHide = visibleWords.OrderBy(x => random.Next()).Take(count).ToList();
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public bool IsFullyHidden()
    {
        return Words.All(word => word.Hidden);
    }

    public override string ToString()
    {
        var wordsStr = string.Join(" ", Words);
        return $"{Reference}\n{wordsStr}";
    }
}

public class Program
{
    private Scripture _scripture;

    public Program()
    {
        var reference = new Reference("John", 3, 16);
        var text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        _scripture = new Scripture(reference, text);
    }

    public void ClearConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            // No se puede limpiar la consola, por ejemplo, si no hay una consola disponible.
            // Manejar este caso si es necesario.
            Console.WriteLine("\n(Unable to clear the console. Running without a console.)\n");
        }
    }

    public void Run()
    {
        while (true)
        {
            ClearConsole();
            Console.WriteLine(_scripture);
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit: ");
            var userInput = Console.ReadLine();
            if (userInput?.ToLower() == "quit")
            {
                break;
            }
            else
            {
                _scripture.HideRandomWords(count: 3);
                if (_scripture.IsFullyHidden())
                {
                    ClearConsole();
                    Console.WriteLine("All words are hidden. Good job!");
                    break;
                }
            }
        }
    }

    public static void Main()
    {
        var program = new Program();
        program.Run();
    }
}
