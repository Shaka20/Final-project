using System;
using System.Diagnostics;
using System.Text;


class HangmanGame
{
    static void Main()
    { 
        Console.WriteLine("\tTamashi chamoxrchobana\n");

        //winaswar darezervebuli ramodendime sityva
        string[] words = { "apple", "bike", "mountain", "window", "cat", "music" };
        Random rand = new Random();
        bool playAgain = true;

        //kidev ertxel tamashis shemtxvevashi lupi istarteba tavidan
        while (playAgain)
        {
            string wordToGuess = words[rand.Next(words.Length)];
            StringBuilder guessedword = new StringBuilder(new string('_', wordToGuess.Length));
            int attempts = 6;
            string guessedLetters = "";

            //ushualod gamocnobis lupi
            while (attempts > 0)
            {
                Console.Clear();
                Console.WriteLine($"\t\t\t\tgamosacnobi sityva: {guessedword}\n");
                Console.WriteLine($"sityvis gamosacnobad darchenili mcdelobebi: {attempts}\n");
                Console.WriteLine($"gamocnobili asoebi: {guessedLetters} \n");

                Console.Write($"\nsheiyvanet aso:");
                char guess = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (!char.IsLetter(guess))
                {
                    Console.WriteLine("gtxovt sworad sheiyvanot aso.");
                    continue;
                }

                if (guessedLetters.Contains(guess))
                {
                    Console.WriteLine($"ukve scade es aso '{guess}'.");
                    continue;
                }

                guessedLetters += guess;

                if (wordToGuess.Contains(guess))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess)
                        {
                            guessedword[i] = guess;
                        }
                    }

                    //im shemtxvevashi tu gamoicno sityva sworad da moigo
                    if (guessedword.ToString() == wordToGuess)
                    {
                        Console.WriteLine($"gilocavt, tqven sworad gamoicanit sityva {wordToGuess}");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"sityva ar sheicavs aso '{guess}'.");
                    attempts--;

                    //im shemtxvevashi tu motamashes amoewura mcdelobebi da damarcxda
                    if (attempts == 0)
                    {
                        Console.WriteLine($"samwuxarod amogewurat mcdelobebi. gamosacnobi sityva iyo '{wordToGuess}'.");
                    }
                }

            }

            //motamashes vekitxebit surs tu ara kidev tamashi
            Console.Write("kidev gsurt tamashi? (yes/no):");
            string playAgainInput = Console.ReadLine().ToLower();
            playAgain = (playAgainInput == "yes" || playAgainInput == "y");
            Console.WriteLine();
        }
        Console.WriteLine("madloba rom itamashet");
    }
}

