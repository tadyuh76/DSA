namespace SpellChecker;

using System;
using System.Collections;

public class SpellChecker
{
    // Hashtable to store IT-related words
    private Hashtable dictionary;

    // Constructor to initialize the dictionary
    public SpellChecker()
    {
        dictionary = new Hashtable();
        LoadDictionary();
    }

    // Method to load IT-related words into the dictionary
    private void LoadDictionary()
    {
        // Add common IT-related words to the hashtable
        dictionary.Add("algorithm", true);
        dictionary.Add("api", true);
        dictionary.Add("architecture", true);
        dictionary.Add("binary", true);
        dictionary.Add("cache", true);
        dictionary.Add("cloud", true);
        dictionary.Add("compiler", true);
        dictionary.Add("database", true);
        dictionary.Add("debug", true);
        dictionary.Add("encryption", true);
        dictionary.Add("framework", true);
        dictionary.Add("hardware", true);
        dictionary.Add("integrated", true);
        dictionary.Add("internet", true);
        dictionary.Add("java", true);
        dictionary.Add("network", true);
        dictionary.Add("protocol", true);
        dictionary.Add("server", true);
        dictionary.Add("software", true);
        dictionary.Add("sql", true);
        dictionary.Add("virtualization", true);
        dictionary.Add("web", true);
        dictionary.Add("xml", true);
        // Add more words as necessary
    }

    // Method to check if a word is in the dictionary
    public bool CheckSpelling(string word)
    {
        // Convert word to lowercase to make the check case-insensitive
        word = word.ToLower();

        // Check if the word exists in the dictionary
        return dictionary.ContainsKey(word);
    }

    // Method to read words from a file and check if they are spelled correctly
    public void CheckFileSpelling(string filePath)
    {
        // Check if the file exists
        if (!System.IO.File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        // Read all lines from the file
        string[] lines = System.IO.File.ReadAllLines(filePath);

        // Process each line in the file
        foreach (var line in lines)
        {
            // Split the line into individual words
            string[] words = line.Split(new[] { ' ', ',', '.', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                // Check if the word is correctly spelled
                if (CheckSpelling(word))
                {
                    Console.WriteLine($"'{word}' is spelled correctly.");
                }
                else
                {
                    Console.WriteLine($"'{word}' is misspelled.");
                }
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of SpellChecker
        SpellChecker spellChecker = new SpellChecker();

        // Path to the text file to check
        string filePath = "document.txt"; // Ensure the file exists and contains words to check

        // Check the spelling of words in the file
        spellChecker.CheckFileSpelling(filePath);
    }
}
