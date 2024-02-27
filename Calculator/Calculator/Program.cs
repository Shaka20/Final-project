class Calculator
{
    static void Main()
    {
        //welcome mesiji
        Console.WriteLine($"\tkalkulatori dziritadi aritmetikuli moqmedebebit");
        Console.WriteLine();
        //gatishvis shemtxvevashi dadastureba an uaryofa
        while (true)
        {
            Calculate();

            Console.Write("namdvilad gsurt kalkulatoris gatishva? (yes/no): ");
            string answer = Console.ReadLine().ToLower();
            if (answer != "no" && answer != "n")
            {
                Console.WriteLine("kalkulatori itisheba...");

                break;
            }

        }

        //menu
        void Calculate()
        {

            while (true)
            {

                Console.WriteLine("amoirchiet mocemuli operaciebidan sasurveli: ");
                Console.WriteLine("1. shekreba");
                Console.WriteLine("2. gamokleba");
                Console.WriteLine("3. gamravleba");
                Console.WriteLine("4. gayofa");
                Console.WriteLine("5. kalkulatoris gatishva");

                Console.Write("\ntqventvis sasurveli operacia [1-5]: ");
                string archevani = Console.ReadLine();
                Console.Clear();
                //archevanis validacia
                if (archevani != "1" && archevani != "2" && archevani != "3" && archevani != "4" && archevani != "5")
                {

                    Console.WriteLine("\t\nsworad airchiet operacia [1-5]");
                    Console.WriteLine();

                    continue;
                }
                if (archevani == "5")
                {
                    return;
                }
                //cifrebis/ricxvebis sheyvana romelzec ganxorcieldeba archeuli operacia
                double shedegi = 0;
                Console.Write("sheiyvanet pirveli cifri/ricxvi: ");
                double num1;
                if (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("sworad sheiyvanet cifri/ricxvi");
                    return;
                }
                Console.Write("sheiyvanet meore cifri/ricxvi: ");
                double num2;
                if (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("sworad sheiyvanet cifri/ricxvi");
                    return;
                }
                //operaciebi
                switch (archevani)
                {
                    case "1":
                        shedegi = num1 + num2;
                        break;
                    case "2":
                        shedegi = num1 - num2;
                        break;
                    case "3":
                        shedegi = num1 * num2;
                        break;
                    case "4":
                        //nulze gayofis exception
                        if (num2 == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("nulze gayofa sheudzlebelia! ");
                            continue;
                        }
                        shedegi = num1 / num2;
                        break;
                    default:
                        Console.WriteLine("sworad sheiyvanet ricxvi!");
                        return;


                }
                //shedegi
                Console.Clear();
                Console.WriteLine($" kalkulaciis shedegi aris {shedegi}\n");
            }

        }

    }
}
