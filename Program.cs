using System;

class UniqueQuiz2
{
    static public void Main(String[] args)
    {
        bool isFinished = false;
        char userDecision;

        while (!isFinished)
        {
            string dnaSequence = Console.ReadLine();

            if (IsUniqueSequence(dnaSequence))
            {
                Console.WriteLine("Current DNA sequence: {0}", dnaSequence);
                Console.WriteLine("Would you like to duplicate it? (Y/N): ");

                while (true)
                {
                    char userChoice = char.Parse(Console.ReadLine());

                    if (userChoice == 'Y')
                    {
                        Console.WriteLine("Duplicated DNA sequence: {0}", DuplicateSequence(dnaSequence));
                        break;
                    }
                    else if (userChoice == 'N')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please input Y or N.");
                    }
                }
            }
            else 
            {
                Console.WriteLine("Invalid DNA sequence.");
            }

            Console.WriteLine("Would you like to process another sequence? (Y/N): ");
            isFinished = UserWantsToExit();
        }
    }


    static bool UserWantsToExit()
    {
        char userChoice = char.Parse(Console.ReadLine());

        if (userChoice == 'Y')
        {
            return true;
        }
        else if (userChoice == 'N')
        {
            return false;
        }
        else
        {
            return UserWantsToExit();
        }
    }

    static bool IsUniqueSequence(string dnaSequence)
    {
        foreach (char nucleotide in dnaSequence)
        {
            if (!"ATCG".Contains(nucleotide))
            {
                return false;
            }
        }
        return true;
    }

    static string DuplicateSequence(string dnaSequence)
    {
        string duplicatedSequence = "";

        foreach (char nucleotide in dnaSequence)
        {
            duplicatedSequence += "TAGC"["ATCG".IndexOf(nucleotide)];
        }

        return duplicatedSequence;
    }
}