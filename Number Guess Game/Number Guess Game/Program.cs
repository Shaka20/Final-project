using System;

class GuessTheNumberGame
{

    static void Main()
    {
        Console.WriteLine("\tRicxvis Gamocnobis Tamashi");
        Console.WriteLine();
        //mtavari lupi
        while (true)
        {
            //momxmareblisgan diapazonis migeba
            Console.Write("sheiyvanet sasurveli diapazoni (mag: 1-50):");
            string rangeInput = Console.ReadLine();
            string[] rangeValues = rangeInput.Split("-");

            //diapazonis validacia
            if (rangeValues.Length != 2 || !int.TryParse(rangeValues[0], out int min) || !int.TryParse(rangeValues[1], out int max) || min >= max)
            {
                Console.Clear();
                Console.WriteLine("gtxovt sworad sheiyvanot diapazoni ");
                continue;
            }

            //migebuli diapazonidan shemtxvevitad ricxvis dagenerireba
            Random rand = new Random();
            int numberToGuess = rand.Next(min, max + 1);
            int attempts = 0;
            int guess = -1;

            Console.Clear();
            Console.WriteLine($"\tshemtxvevitobis principit shercheulia ricxvi {min} da {max} diapazonshi. cadet misi gamocnoba.\n");
            
            //lupi ushualod dagenerirebuli ricxvis gamosacnobad
            while (guess != numberToGuess)
            {
                Console.Write("sheiyvanet ricxvi gamosacnobad:");
                if (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("gtxovt sworad sheiyvanot ricxvi");
                    continue;
                }
                attempts++;
                //minishnebebis micema gamocnobis shesabamisad
                if (guess < numberToGuess)
                {
                    Console.WriteLine("ufro magali");
                }
                else if (guess > numberToGuess)
                {
                    Console.WriteLine("ufro dabali");
                }
                else
                {
                    Console.WriteLine($"gilocavt! tqven gamoicanit shemtxvevitad shercheuli ricxvi {numberToGuess} sworad {attempts} cdashi.\n");
                }
            }
            Console.Write("kidev gsurt tamashi? (yes/no): ");
            string playAgain = Console.ReadLine().ToLower();
            if (playAgain != "yes" && playAgain != "y")
            {
                Console.WriteLine("madloba rom itamashet.");
                break;
            }
            Console.Clear ();   
            Console.WriteLine();
        }
    }
}
