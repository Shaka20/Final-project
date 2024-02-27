using System;
using System.Collections.Generic;
using System.IO;

class Translator
{
    // leqsikoni yvela sxvadasxva enebis targmanebis shesanaxad
    static Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();

    static void Main()
    {
        // targmanebis failis path
        string translationsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "translations.txt");

        // targmanebis chatvirtva
        LoadTranslationsFromFile(translationsFilePath);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("console tarjimani!");
            Console.WriteLine("shesadzlo enebis kombinaciebi:");
            Console.WriteLine("1. Georgian to English (ka-en)");
            Console.WriteLine("2. English to Georgian (en-ka)");
            Console.WriteLine("3. Georgian to Russian (ka-ru)");
            Console.WriteLine("4. Russian to Georgian (ru-ka)");
            Console.WriteLine("5. tarjimanis gatishva (akrifet 'exit')");


            // user irchevs shesadzlebeli variantebidan erterts
            Console.Write("airchiet sasurveli leqsikoni chamonatvalidan shemdegnairad (ka-en): ");
            string languagePair = Console.ReadLine().ToLower();

            if(languagePair== "exit")
            {
                break;
            }
            if (translations.ContainsKey(languagePair))
            {
                Console.WriteLine($"tqvens mier archeuli leqsikoni: {languagePair}");
                Translate(languagePair, translationsFilePath); // Start translation loop
            }
            if (!translations.ContainsKey(languagePair))
            {
                Console.Clear();
                Console.WriteLine("\taraswori archevani, gtxovt sworad airchiot.");
            }
            continue;
        }

        //Console.WriteLine("Exiting translator. Goodbye!");
    }

    //ushualod targmnis metodi
    static void Translate(string languagePair, string translationsFilePath)
    {
        Dictionary<string, string> translationDictionary = translations[languagePair];

        while (true)
        {
            Console.Write("sheiyvanet sityva an fraza (an ukan dasabruneblad akrifet 'exit'): ");
            string input = Console.ReadLine().ToLower();

            if (input == "exit")
                break;

            // leqsikonshi sityvis arsebobis shemowmeba
            if (translationDictionary.ContainsKey(input))
            {
                Console.Clear();
                string translation = translationDictionary[input];
                Console.WriteLine($"targmani: {translation}");
            }
            else
            {
                bool translationFound = false;
                foreach (var kvp in translationDictionary)
                {
                    if (input.Contains(kvp.Key))
                    {
                        translationFound = true;
                        input = input.Replace(kvp.Key, kvp.Value);
                    }
                }

                if (translationFound)
                {
                    Console.Clear();
                    Console.WriteLine($"targmani: {input}");
                }
                else
                {
                    // im shemtxvevashi tu targgmani ar moidzebna, momxmarebels sashualeba aqvs daamatos targmani, romelic teqstur failshi chaiwereba
                    Console.WriteLine("targmani ar moidzebna.");
                    Console.Write("gsurt daamatot targmani leqsikonshi? (yes/no): ");
                    string addWord = Console.ReadLine().ToLower();

                    if (addWord == "yes" || addWord == "y")
                    {
                        Console.Write("sheiyvanet targmani: ");
                        string translation = Console.ReadLine();
                        translationDictionary[input] = translation;
                        AddTranslationToFile(languagePair, input, translation, translationsFilePath);
                        Console.WriteLine("sityva daemata leqsikonshi.");
                    }
                }
            }
        }
    }

    // failidan targmanebis chatvirtvis metodi
    static void LoadTranslationsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"leqsikonis faili '{filePath}' ar moidzebna.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            if (parts.Length == 2)
            {
                string languagePair = parts[0].Trim();
                string[] translationParts = parts[1].Split('-');
                if (translationParts.Length == 2)
                {
                    string word = translationParts[0].Trim();
                    string translation = translationParts[1].Trim();

                    if (!translations.ContainsKey(languagePair))
                    {
                        translations[languagePair] = new Dictionary<string, string>();
                    }

                    translations[languagePair][word] = translation;
                }
            }
        }
    }

    // targmanis damateba textur failshi
    static void AddTranslationToFile(string languagePair, string word, string translation, string translationsFilePath)
    {
        using (StreamWriter writer = File.AppendText(translationsFilePath))
        {
            writer.WriteLine($"{languagePair}:{word}-{translation}");
        }
    }
}
