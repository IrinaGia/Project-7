using System;
using System.Diagnostics.Metrics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project__4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string GAME = "hangman";
            const string YES = "y";
            const string NO = "n";
            int attempt = GAME.Length;
            int tryNow = 1;
            int currentIndex = 0;


            Console.WriteLine("Guess the word!");
            string[] words = { "microwave", "blizzard", "strength", "oxygen", "syndrome", "nightclub", "fishhook" };
            string[] explain = { "You can find it in the kitchen", "Long severe snowstorm", "Power to resist force", "chemical element", "A group of signs and symptoms", "Dance and drink party place", "Used while fishing" };
            Random random = new Random();
            int randomIndex = random.Next(words.Length);
            string randomWord = words[randomIndex];
            string[] replacedWord = new string[randomWord.Length];

            for (int i = 0; i < randomWord.Length; i++)
            {
                replacedWord[i] = "_ ";
            }
            string result = string.Join(" ", replacedWord);

            string explanation = explain[randomIndex];
            List<char> matchingChars = new List<char>();
            List<char> allLetters = new List<char>();

            Console.WriteLine("Description: " + explanation);
            Console.WriteLine(result);

            while (true)
            {
                Console.WriteLine("Attemp nr" + tryNow + ". Insert a letter.");
                string userGuess = Console.ReadLine();

                for (int i = 0; i < randomWord.Length; i++)
                {

                    if (userGuess == randomWord[i].ToString())
                    {
                        replacedWord[i] = randomWord[i].ToString();
                        matchingChars.Add(Convert.ToChar(userGuess));

                    }

                }

                if (allLetters.Contains(Convert.ToChar(userGuess)))
                {
                    Console.WriteLine("You have already inserted this letter!");
                }
                allLetters.Add(Convert.ToChar(userGuess));



                char[] wrongGuesses = allLetters.Where(item => !matchingChars.Contains(item)).ToArray();




                if (tryNow >= randomWord.Length || wrongGuesses.Length > attempt)
                {
                    Console.WriteLine("You have last attempt. Do you want to guess the word? y/n");
                    string input = Console.ReadLine();
                    string normalInput = input.ToLower();
                    if (normalInput == YES)
                    {
                        Console.WriteLine("Insert the word:");
                        string input2 = Console.ReadLine();
                        string normalInput2 = input2.ToLower();
                        if (normalInput2 == randomWord)
                        {
                            Console.WriteLine("Correct! You won!");
                        }
                        else
                        {
                            Console.WriteLine("Sorry! You lost :( ");
                        }
                    }
                    if (normalInput == NO)
                    {
                        Console.WriteLine("Sorry! You lost :( ");
                    }
                    break;
                }

                tryNow++;

                Console.WriteLine("Correct guesses: " + string.Join(" ", replacedWord));
                //Console.WriteLine("Wrong guesses:" + string.Join(" ", wrongGuesses));
                Console.WriteLine("All inserted letters: " + string.Join(",", allLetters));


            }



        }
    }
}