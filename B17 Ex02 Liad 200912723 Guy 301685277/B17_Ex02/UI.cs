using System;
using System.Text.RegularExpressions;
namespace B17_Ex02
{
    class UI
    {
        protected const int k_ValidWordLength = 4;
        protected const int k_MinNumberOfGuesses = 4;
        protected const int k_MaxNumberOfGuesses = 10;
        protected const int k_InvaildInput = -1;
        protected const string k_ExitSign = "Q";

        public static int getUserNumberOfGuesses()
        {
            String inputNumberOfGuesses;
            int numberOfGuesees;

            Console.WriteLine("Please type in the number of guesses between 4 to 10");
            inputNumberOfGuesses = Console.ReadLine();
            numberOfGuesees = ValidateAndParseNumberOfGuesses(inputNumberOfGuesses);

            while (numberOfGuesees == k_InvaildInput)
            {
                Console.WriteLine("Invalid input, please try again");
                inputNumberOfGuesses = Console.ReadLine();
                isExitInput(inputNumberOfGuesses);
                numberOfGuesees = ValidateAndParseNumberOfGuesses(inputNumberOfGuesses);
            }
            return numberOfGuesees;
        }

        public static string getUserGuess()
        {
            bool isValidInput = false;
            string userInput = null;
            Console.WriteLine("Please type your next guess (A B C D) or 'Q' to quit");
            while (!isValidInput)
            {
                userInput = Console.ReadLine();
                isValidInput = IsValidGuess(userInput);
            }
            return userInput;
        }

        private static bool IsValidGuess(string i_UserInput)
        {
            isExitInput(i_UserInput);
            if (!isValidSyntax(i_UserInput))
            {
                Console.WriteLine("Invaild input , wrong syntax");
                return false;
            }
            if (!isValidContext(i_UserInput))
            {
                Console.WriteLine("Invaild input char is not in dictinoray");
                return false;
            }
            return true;
        }

        private static bool isValidSyntax(string i_UserInput)
        {
            return (i_UserInput.Length == k_ValidWordLength && Regex.IsMatch(i_UserInput, "^[A-Z]*$"));
        }

        private static bool isValidContext(string i_userInput)
        {
            return Regex.IsMatch(i_userInput, "^[A-H]*$");
        }

        public static int ValidateAndParseNumberOfGuesses(string i_NumOfGuesses)
        {
            int parsedNumOfGuesses;
            bool isNumber = int.TryParse(i_NumOfGuesses, out parsedNumOfGuesses);

            if (isNumber)
            {
                if (parsedNumOfGuesses >= k_MinNumberOfGuesses && parsedNumOfGuesses <= k_MaxNumberOfGuesses)
                {
                    return parsedNumOfGuesses;
                }
            }
            return k_InvaildInput;
        }

        public static void isExitInput(string i_UserInput)
        {
            if (i_UserInput == k_ExitSign)
            {
                Console.WriteLine("Bye Bye , hope to see you again soon");
                Environment.Exit(0);
            }
        }

        public static bool gameRestart()
        {
            Console.WriteLine("Would you like to start a new game? (Y/N)");
            String userInput = Console.ReadLine();
            while (userInput != "N" && userInput != "Y")
            {
                Console.WriteLine("Invalid input. Please type 'Y' or 'N'");
                userInput = Console.ReadLine();
            }
            return userInput == "Y" ? true : false;
        }
    }
}
