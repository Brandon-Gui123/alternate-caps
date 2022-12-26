using System;
using System.CommandLine;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Alternates the captialization of text.");

        var capsFirstOption = new Option<bool>(
            name: "--caps-first",
            description: "Uppercase, then lowercase. Unlike the default, which goes lowercase, then uppercase.",
            getDefaultValue: () => false
        );
        capsFirstOption.AddAlias("-c");

        var stringToProcessArgument = new Argument<string?>(
            name: "stringToProcess",
            description: "The string to give to the program to process and alter the capitalization of.",
            getDefaultValue: () => null
        );

        rootCommand.Add(capsFirstOption);
        rootCommand.Add(stringToProcessArgument);

        rootCommand.SetHandler(
            (isCapsFirst, stringToProcess) =>
            {
                if (stringToProcess == null)
                {
                    string? input = "";
                    while (true)
                    {
                        input = Console.ReadLine();

                        if (input == null)
                        {
                            break;
                        }

                        Console.WriteLine(AlternateCaps(input, isCapsFirst));
                    }
                }
                else
                {
                    Console.WriteLine(AlternateCaps(stringToProcess, isCapsFirst));
                }
            },
            capsFirstOption, stringToProcessArgument
        );

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
