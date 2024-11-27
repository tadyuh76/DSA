namespace PhoneBook;

using System;
using System.Collections.Generic;
using System.IO;

public class PhoneBook
{
    // Dictionary to store name as the key and phone number as the value
    private Dictionary<string, string> contacts = new Dictionary<string, string>();

    // Method to load contacts from a text file into the dictionary
    public void LoadContacts(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        // Read all lines from the file
        string[] lines = File.ReadAllLines(filePath);

        // Process each line
        foreach (var line in lines)
        {
            // Split the line into name and phone number using the comma as delimiter
            var parts = line.Split(',');

            if (parts.Length == 2)
            {
                string name = parts[0].Trim();
                string phoneNumber = parts[1].Trim();
                // Add to dictionary
                contacts[name] = phoneNumber;
            }
        }

        Console.WriteLine("Contacts loaded successfully.");
    }

    // Method to search for a phone number by name
    public void SearchByName(string name)
    {
        if (contacts.ContainsKey(name))
        {
            Console.WriteLine($"Phone number for {name}: {contacts[name]}");
        }
        else
        {
            Console.WriteLine($"No contact found with the name: {name}");
        }
    }

    // Method to search for a name by phone number
    public void SearchByPhoneNumber(string phoneNumber)
    {
        bool found = false;

        foreach (var contact in contacts)
        {
            if (contact.Value == phoneNumber)
            {
                Console.WriteLine($"Phone number {phoneNumber} belongs to: {contact.Key}");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine($"No contact found with the phone number: {phoneNumber}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of the PhoneBook
        PhoneBook phoneBook = new PhoneBook();

        // Load contacts from a text file
        string filePath = "contacts.txt";  // Ensure this file exists with proper data
        phoneBook.LoadContacts(filePath);

        // Search by name
        phoneBook.SearchByName("Huy");  // Should print the phone number for Jane Smith

        // Search by phone number
        phoneBook.SearchByPhoneNumber("0914804685");  // Should print the name associated with this phone number
    }
}
