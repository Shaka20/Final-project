using System;
using System.Collections.Generic;
using System.IO;

class BankATM
{

    static Dictionary<int, Account> accounts = new Dictionary<int, Account>();
    //teqsturi failis path
    static string accountsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "accounts.txt");

    static void Main()
    {
        LoadAccounts();

        Console.WriteLine("\tmogesalmebat XBank ATM!");
        Console.WriteLine("gtxovt sheiyvanot tqveni angarishis nomeri.");

        //mtavari menu
        while (true)
        {
            Console.Write("sheiyvanet angarishis nomeri (1, 2, or 3): ");
            int accountNumber;
            if (int.TryParse(Console.ReadLine(), out accountNumber))
            {
                if (accounts.ContainsKey(accountNumber))
                {
                    Account account = accounts[accountNumber];
                    Console.WriteLine($"gamarjoba, {account.Name}!");
                    ShowOptions(account);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("angarishi ar moidzebna gtxovt kidev scadet.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\taraswori angarishis nomeri. gtxovt sworad sheiyvanot angarishis nomeri.");
            }
        }
    }

    //ushualod konkretuli archeuli accountistvis metodi
    static void ShowOptions(Account account)
    {
        while (true)
        {
            Console.WriteLine("\ngtxovt airchiot sasurveli operacia:");
            Console.WriteLine("1. balansis shemowmeba");
            Console.WriteLine("2. tanxis shetana");
            Console.WriteLine("3. tanxis gatana");
            Console.WriteLine("4. gasvla");

            Console.Write("sasurveli operacia (1-4): ");
            string choice = Console.ReadLine();

            //dziritadi sabanko operaciebis lupi
            switch (choice)
            {
                case "1":
                    Console.WriteLine($"xelmisawvdomi balansi: ${account.Balance}");
                    break;
                case "2":
                    Console.Write("sheitanet sasurveli tanxa: ");
                    double depositAmount = GetValidAmount();
                    account.Deposit(depositAmount);
                    Console.WriteLine($"${depositAmount} warmatebit chairicxa.");
                    break;
                case "3":
                    Console.Write("sheiyvanet sasurveli tanxa gatanistvis: ");
                    double withdrawAmount = GetValidAmount();
                    if (account.Withdraw(withdrawAmount))
                        Console.WriteLine($"${withdrawAmount} warmatebit moxda ganagdeba.");
                    else
                        Console.WriteLine("arasakmarisi tanxa angarishze.");
                    break;
                case "4":
                    SaveAccounts();
                    Console.WriteLine("madloba ATM gamoyenebistvis!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("gtxovt sworad airchiot sasurveli operacia  1 - 4.");
                    break;
            }
        }
    }

    //angarishebis wakitxva teqsturi failidan
    static void LoadAccounts()
    {
        string[] lines = File.ReadAllLines(accountsFilePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            int accountNumber = int.Parse(parts[0]);
            string name = parts[1];
            double balance = double.Parse(parts[2]);
            accounts[accountNumber] = new Account(accountNumber, name, balance);
        }
    }

    //angarishebis daseiveba tqstur failshi
    static void SaveAccounts()
    {
        using (StreamWriter writer = new StreamWriter(accountsFilePath))
        {
            foreach (var account in accounts.Values)
            {
                writer.WriteLine($"{account.AccountNumber},{account.Name},{account.Balance}");
            }
        }
    }

    //validacia depositisas
    static double GetValidAmount()
    {
        double amount;
        while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("gtxovd sworad sheiyvanot sasurveli raodenoba.");
            Console.Write("sheiyvanet raodenoba: ");
        }
        return amount;
    }
}
