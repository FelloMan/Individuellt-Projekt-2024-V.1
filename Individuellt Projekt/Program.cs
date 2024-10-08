using System;

namespace Individuellt_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] accounts;
            double[] Newaccounts = new double[3];

            string[,] users = new string[5, 3];
            int index = 0;




            users[0, 0] = "Filip Oldin";
            users[0, 1] = "hemlis123";
            users[0, 2] = "24";

            users[1, 0] = "Anna Holgersson";
            users[1, 1] = "hemlis1234";
            users[1, 2] = "54";

            users[2, 0] = "Tobbe Rikardsson";
            users[2, 1] = "hemlis12345";
            users[2, 2] = "43";

            users[3, 0] = "Kent Käll";
            users[3, 1] = "hemlis123456";
            users[3, 2] = "32";

            users[4, 0] = "Eva Hobert";
            users[4, 1] = "hemlis1234567";
            users[4, 2] = "19";
 
            string userName = "";


            string[][] userAccounts =
            {
                new string [] {"Lönekonto, Sparkonto, Semesterkonto"},
                new string [] {"Lönekonto, Sparkonto,"},
                new string [] {"Lönekonto, Sparkonto, Semesterkonto"},
                new string [] {"Lönekonto, Sparkonto"},
                new string [] {"Lönekonto, Sparkonto, Semesterkonto"},
            };


            int failedLoginAttempts = 0;
            const int loginAttempts = 3;
            bool isLoggedIn = false;


            //Fixa login [Klar]
            //Fixa moneytransfer
            //Fixa så man återvänder till huvudmenyn efter att man loggar ut [Klar]

            while (failedLoginAttempts < loginAttempts)
            {

                Console.WriteLine("Inloggningsmeny");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Skriv in ett ditt användarnamn");
                userName = Console.ReadLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Skriv in ett ditt lösenord");
                string password = Console.ReadLine();


                if (checkLogin(userName, password))
                {
                    Console.Clear();
                    Console.WriteLine("Du är inloggad!");
                   
                    failedLoginAttempts = 0;
                    isLoggedIn = true;
                    accounts = getaccount(userName);


                    bool since = true;
                    while (since)
                    {
                        Console.Clear();
                        int mainAccount;
                        Console.WriteLine("");                      
                        Console.WriteLine(" Skriv in en siffra till den del av kontot du vill till ");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("1. Se dina konton och saldo ");
                        Console.WriteLine("2. Överföring mellan konton ");
                        Console.WriteLine("3. Ta ut pengar ");
                        Console.WriteLine("4. Logga ut  ");
                        Console.WriteLine("5. Stäng ner programmet");
                        Console.WriteLine();


                        mainAccount = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        // int num = int.Parse(Console.ReadLine()); //skriv alternativ
                        switch (mainAccount)

                        {
                            case 1:
                                Console.Write("Saldo på lönekonto: ");
                                Console.WriteLine(accounts[0]);
                                Console.Write("Saldo på sparkonto: ");
                                Console.WriteLine(accounts[1]);
                                Console.Write("Saldo på semesterkonto: ");
                                Console.WriteLine(accounts[2]);
                                Console.WriteLine("");
                                Console.WriteLine("\nTryck enter för att återgå till huvudmenyn");
                                break;

                            case 2:
                                Console.WriteLine("Överföring mellan konton");
                                Console.WriteLine("Välj ett konto att överföra från (" +
                                    "1.Lönekonto" +
                                    "2.Sparkonto" +
                                    "3.Semesterkonto):");
                                int fromUserAccount = int.Parse(Console.ReadLine()) - 1;
                                Console.WriteLine("Välj ett konto att överföra från (" +
                                    "1.Lönekonto" +
                                    "2.Sparkonto" +
                                    "3.Semesterkonto):");
                                int toUserAccount = int.Parse(Console.ReadLine()) - 1;
                                Console.WriteLine("Ange ett belopp att överföra:");


                                if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                                {
                                    TransferMoney(fromUserAccount, toUserAccount, transferAmount, accounts);

                                    Console.WriteLine("\nNytt Saldo");
                                    for (int i = 0; i < accounts.Length; i++)
                                    {
                                        Console.WriteLine($"Konto {i + 1}: {accounts[i]} kr");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ogiltigt belopp angivet.");
                                }
                                Console.WriteLine("\nTryck enter för att återgå till huvudmenyn");
                                break;

                            case 3:

                                Console.WriteLine("Ta ut pengar");
                                accounts[0] = accounts[0] - 1 - 10000;
                                accounts[1] = accounts[1] + 1 - 10000;
                                accounts[0] = accounts[0] - 1 - 1000;
                                accounts[1] = accounts[1] + 1000;
                                Console.WriteLine("Skriv hur mycket du skulle vilja ta ut:");
                                string accounts1 = Console.ReadLine(); // Det är här det buggar///////////////////////////////////
                                Console.WriteLine("");
                                Console.WriteLine("\nTryck enter för att återgå till huvudmenyn");
                                break;

                            case 4:
                                Console.WriteLine("Loggar ut! Välkommen åter");
                                since = false;
                                break;
               
                           default:
                                Console.WriteLine("Ogiltig svar, försök igen");
                                break;
                                continue;
                                 
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                    }

                }
                else
                {
                    failedLoginAttempts++;
                    Console.WriteLine($"Fel inloggning. Försök kvar: {loginAttempts - failedLoginAttempts}");
                }


            }
        }

      
   
        static double[] getaccount(string userName)
        {
            switch (userName)
            {
                case "Filip Oldin":
                    return new double[] { 20000, 45000, 30000 };
                    break;
                case "Anna Holgersson":
                    return new double[] { 100000, 50000, 240000 };
                    break;
                case "Tobbe Rikardsson":
                    return new double[] { 60000, 130000, 300000 };
                    break;
                case "Kent Käll":
                    return new double[] { 33000, 90000, 50000 };
                    break;
                case "Eva Hobert":
                    return new double[] { 10000, 25000, 10000 };
                    break;
                default:
                    return new double[] { };
                    break;

            }
        }

        static bool checkLogin(string userName, string password)
        {

            if (userName == "Filip Oldin" && password == "hemlis123")
            {
                return true;
            }
            else if (userName == "Anna Holgersson" && password == "hemlis1234")
            {
                return true;
            }
            else if (userName == "Tobbe Rikardsson" && password == "hemlis12345")
            {
                return true;
            }
            else if (userName == "Kent Käll" && password == "hemlis123456")
            {
                return true;
            }
            else if (userName == "Eva Hobert" && password == "hemlis1234567")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void TransferMoney(int fromUserAccount, int toUserAccount, decimal amount, decimal[] accounts)
        {
            if (fromUserAccount >= 0 && fromUserAccount < accounts.Length &&
                toUserAccount >= 0 && toUserAccount < accounts.Length)
            {
                if (accounts[fromUserAccount] >= amount)
                {
                    accounts[fromUserAccount] -= amount;
                    accounts[toUserAccount] += amount;
                    Console.WriteLine($"Överföring av {amount} kr från användarkonto {fromUserAccount + 1} till konto {toUserAccount + 1} lyckades");
                }
                else
                {
                    Console.WriteLine("Otillräckligt saldo för överföring");
                }

               
            }
            else
            {
                Console.WriteLine("Ogiltiga kontonummer");
            }



             static void Widraw()
             {

             }
        }
    }
        
}

