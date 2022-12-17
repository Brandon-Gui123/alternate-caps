using System;
using System.CommandLine;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Alternates the captialization of text.");

        var stringArg = new Argument<string>(
            name: "input",
            description: "Oh noes!"
        );

        rootCommand.AddArgument(stringArg);

        return await rootCommand.InvokeAsync(args);
    }

    public static void Main_Old(string[] args)
    {
        Console.Write("Input your sentence: ");
        string? userSentence = Console.ReadLine();

        if (string.IsNullOrEmpty(userSentence))
        {
            Console.WriteLine("No input provided. Doing nothing.");
            return;
        }

        bool startWithCaps = false;
        while (true)
        {
            Console.Write("Start with caps? [y/N]: ");
            string? startCapsChoice = Console.ReadLine();

            if (!string.IsNullOrEmpty(startCapsChoice) && startCapsChoice.ToLower() != "y" && startCapsChoice.ToLower() != "n")
            {
                Console.WriteLine("Unknown input. Please try again.");
            }
            else
            {
                startWithCaps = !(string.IsNullOrEmpty(startCapsChoice) || startCapsChoice.ToLower() == "n");
                break;
            }
        }

        string newString = "";
        for (int i = 0; i < userSentence.Length; i++)
        {
            if (i % 2 == 0)
            {
                if (startWithCaps)
                {
                    newString += char.ToUpper(userSentence[i]);
                }
                else
                {
                    newString += char.ToLower(userSentence[i]);
                }
            }
            else
            {
                if (startWithCaps)
                {
                    newString += char.ToLower(userSentence[i]);
                }
                else
                {
                    newString += char.ToUpper(userSentence[i]);
                }
            }
        }

        Console.WriteLine(newString);
    }

    public static string AlternateCaps(string inputString, bool startWithCaps = false)
    {
        string newString = "";
        for (int i = 0; i < inputString.Length; i++)
        {
            if (i % 2 == 0)
            {
                if (startWithCaps)
                {
                    newString += char.ToUpper(inputString[i]);
                }
                else
                {
                    newString += char.ToLower(inputString[i]);
                }
            }
            else
            {
                if (startWithCaps)
                {
                    newString += char.ToLower(inputString[i]);
                }
                else
                {
                    newString += char.ToUpper(inputString[i]);
                }
            }
        }

        return newString;
    }
}
