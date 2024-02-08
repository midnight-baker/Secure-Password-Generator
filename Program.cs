using System.Runtime.CompilerServices;
using System.Text;

namespace Password_Generator
{
    internal class Program
    {
        // Establish constants
        private const string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string numbers = "0123456789";
        private const string specialCharacters = "!@#$%^&*()_+=-?/\\|{}[]<>";

        static void Main(string[] args)
        {
            // Print welcome message
            Console.WriteLine("Welcome to Secure Password Generator");


            // Gather information from user:
            // Ask user if they want their generated password to contain uppercase letters
            var includeCapitalLetters = AskUserChoice("Do you want your password to contain uppercase letters? (Y/N) ");
            // Ask user if they want their generated password to contain numbers
            var includeNumbers = AskUserChoice("Do you want your password to contain numbers? (Y/N) ");
            // Ask user if they want their generated password to contain special characters
            var includeSpecialCharacters = AskUserChoice("Do you want your password to contain special characters? (Y/N) ");


            // Generate password:
            // Establish the minimum acceptable password length
            var minLength = 6;
            // Ask the user what the minimum required password length is in the login form they're using
            Console.Write("What is the minimum required password length for the login you are using? ");
            var input = Console.ReadLine(); // Read user input
            int.TryParse(input, out var passwordLength); // ?? Does this validate user input??
            if (passwordLength < minLength) {
                Console.WriteLine("\nThe password length you input is shorter than what is considered the minimum length for a secure password. The generated password will be 6 characters long.");
                passwordLength = minLength;
            }

            // Build password using String Builder
            var charSet = new StringBuilder(lowercaseLetters);
            if (includeCapitalLetters) {
                charSet.Append(capitalLetters);
            }
            if (includeNumbers) {
                charSet.Append(numbers);
            }
            if (includeSpecialCharacters)
            {
                charSet.Append(specialCharacters);
            }

            var random = new Random();
            var generatedPassword = "";
            for(var i = 0; i < passwordLength; i++)
            {
                var index = random.Next(charSet.Length);
                generatedPassword += charSet[index];
            }

            Console.Write("\nPassword: ");
            Console.WriteLine(generatedPassword);
        }

        public static bool AskUserChoice(string question) {
            Console.Write(question);
            var input = Console.ReadLine();
            return string.IsNullOrEmpty(input) || input == "y" || input == "Y";
        }
    }
}
