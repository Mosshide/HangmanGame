using System;
using System.Text;

namespace HangmanGame
{
    public class Hangman
    {
        string[] words;
        int health;
        string chosenWord;
        StringBuilder hiddenWord;
        StringBuilder guessedLetters;

        public Hangman()
        {
            Load();

            while (PlayGame()) { };
        }

        void Load()
        {
            words = System.IO.File.ReadAllLines("words.txt");
        }

        void Setup()
        {
            health = -1;

            Random random = new Random();
            chosenWord = words[random.Next(words.Length - 1)];

            guessedLetters = new StringBuilder();
            hiddenWord = new StringBuilder();
            for (int i = 0; i < chosenWord.Length; i++) hiddenWord.Append("*");
        }

        bool NewGame()
        {
            Render(health, hiddenWord.ToString(), guessedLetters.ToString());
            if (Console.ReadKey().KeyChar == 'n') return false;
            else
            {
                health = 6;
                return true;
            }
        }

        int GuessLetter()
        {
            Render(health, hiddenWord.ToString(), guessedLetters.ToString());

            bool foundLetter = false;
            char input = Console.ReadKey().KeyChar;
            guessedLetters.Append(input + " ");
            for (int i = 0; i < chosenWord.Length; i++)
            {
                if (chosenWord[i] == input)
                {
                    hiddenWord[i] = input;
                    foundLetter = true;
                }
            }

            if (foundLetter)
            {
                if (chosenWord == hiddenWord.ToString()) return 1;
            }
            else
            {
                health--;
                if (health <= 0) return -1;
            }

            return 0;
        }

        bool PlayGame()
        {
            Setup();

            if (NewGame())
            {
                int end = 0;
                while (end == 0) end = GuessLetter();

                if (end == 1) Render(7, chosenWord, guessedLetters.ToString());
                else if (end == -1) Render(0, chosenWord, guessedLetters.ToString());

                if (Console.ReadKey().KeyChar == 'n') return false;
                else return true;
            }
            else return false;
        }

        void Render(int health, string word, string guesses)
        {
            Console.Clear();

            switch (health)
            {
                case -1:
                    Console.WriteLine("################");
                    Console.WriteLine("#              #");
                    Console.WriteLine("# |-----|      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("#==============#");
                    Console.WriteLine("#              #");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                    Console.Write("Are you ready to play hangman? Please enter 'y' or 'n':");
                    break;
                case 0:
                    Console.WriteLine("################");
                    Console.WriteLine("#              #");
                    Console.WriteLine("# |-----|      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |     O      #");
                    Console.WriteLine("# |    /|\\     #");
                    Console.WriteLine("# |    / \\     #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("#==============#");
                    Console.WriteLine("#              #");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                    Console.WriteLine("Oh no! You died! The word was '{0}'.", word);
                    Console.WriteLine("Letters you guessed: {0}", guesses);
                    Console.Write("Would you like to play again? Please enter 'y' or 'n':");
                    break;
                case 1:
                    Console.WriteLine("################");
                    Console.WriteLine("#              #");
                    Console.WriteLine("# |-----|      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |     O      #");
                    Console.WriteLine("# |    /|\\     #");
                    Console.WriteLine("# |    /       #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("#==============#");
                    Console.WriteLine("#              #");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                    Console.WriteLine("Word: {0}", word);
                    Console.WriteLine("Letters you guessed: {0}", guesses);
                    Console.Write("Guess a letter: ");
                    break;
                case 2:
                    Console.WriteLine("################");
                    Console.WriteLine("#              #");
                    Console.WriteLine("# |-----|      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |     O      #");
                    Console.WriteLine("# |    /|\\     #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("#==============#");
                    Console.WriteLine("#              #");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                    Console.WriteLine("Word: {0}", word);
                    Console.WriteLine("Letters you guessed: {0}", guesses);
                    Console.Write("Guess a letter: ");
                    break;
                case 3:
                    Console.WriteLine("################");
                    Console.WriteLine("#              #");
                    Console.WriteLine("# |-----|      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |     O      #");
                    Console.WriteLine("# |    /|      #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("#==============#");
                    Console.WriteLine("#              #");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                    Console.WriteLine("Word: {0}", word);
                    Console.WriteLine("Letters you guessed: {0}", guesses);
                    Console.Write("Guess a letter: ");
                    break;
                case 4:
                    Console.WriteLine("################");
                    Console.WriteLine("#              #");
                    Console.WriteLine("# |-----|      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |     O      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("#==============#");
                    Console.WriteLine("#              #");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                    Console.WriteLine("Word: {0}", word);
                    Console.WriteLine("Letters you guessed: {0}", guesses);
                    Console.Write("Guess a letter: ");
                    break;
                case 5:
                    Console.WriteLine("################");
                    Console.WriteLine("#              #");
                    Console.WriteLine("# |-----|      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |     O      #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("#==============#");
                    Console.WriteLine("#              #");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                    Console.WriteLine("Word: {0}", word);
                    Console.WriteLine("Letters you guessed: {0}", guesses);
                    Console.Write("Guess a letter: ");
                    break;
                case 6:
                    Console.WriteLine("################");
                    Console.WriteLine("#              #");
                    Console.WriteLine("# |-----|      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("#==============#");
                    Console.WriteLine("#              #");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                    Console.WriteLine("Word: {0}", word);
                    Console.WriteLine("Letters you guessed: {0}", guesses);
                    Console.Write("Guess a letter: ");
                    break;
                case 7:
                    Console.WriteLine("################");
                    Console.WriteLine("#              #");
                    Console.WriteLine("# |-----|      #");
                    Console.WriteLine("# |     |      #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("# |            #");
                    Console.WriteLine("#==============#");
                    Console.WriteLine("#              #");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                    Console.WriteLine("Excellent job! The word was '{0}'.", word);
                    Console.WriteLine("Letters you guessed: {0}", guesses);
                    Console.Write("Would you like to play again? Please enter 'y' or 'n':");
                    break;
            }
        }
    }
}