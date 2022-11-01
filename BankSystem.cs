using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    enum MenuOption
    {
        Withdraw = 1,
        Deposite = 2,
        Print = 3,
        Transfer = 4,
        AddAccount = 5,
        PrintHistory = 6,
        Quit = 7
    }


    static class BankSystem
    {
        static MenuOption ReadUserOption()
        {
            int Option = 0;

            do
            {
                Console.WriteLine("**** MENU ****");
                Console.WriteLine("1: Withdraw\n2: Deposite\n3: Print\n4: Transfer\n5: Add Acoount\n6: Print History\n7: Quit");
                try
                {
                    Option = Convert.ToInt32(Console.ReadLine());
                    if (Option < 1 || Option > 7)
                    {
                        Option = 0;
                        Console.WriteLine("");
                        Console.WriteLine("Please Enter A Valid Option");
                        Console.WriteLine("");

                    }
                }
                catch
                {
                    Console.WriteLine("YOU HAVE ENTERED INVALID INPUT!!");

                }

            } while (Option < 1 || Option > 7);

            return (MenuOption)(Option);

        }



        static void DoDeposite(Bank bank)
        {
            try
            {
                var _account = FindAccount(bank);
                if (_account == null) return;
                Console.Write("Enter amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());





                DepositTransaction transaction = new DepositTransaction(_account, amount);
                bank.ExecuteTransaction(transaction);
                transaction.print();
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
                else if (ex is InvalidOperationException)
                {
                    Console.WriteLine("Wrong Input");
                }
                else
                {
                    throw;
                }
            }





        }
        static void DoWithdraw(Bank bank)
        {
            try
            {
                var _account = FindAccount(bank);
                if (_account == null)
                    return;

                Console.WriteLine("Enter Withdrow Amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());


                WithdrawTransaction transaction = new WithdrawTransaction(_account, amount);


                bank.ExecuteTransaction(transaction);
                transaction.print();
            }
            catch(Exception ex)
            {
                if (ex is FormatException)
                {
                    Console.WriteLine("Invalid Input");
                }
                else if (ex is InvalidOperationException)
                {
                    Console.WriteLine("Invalid Input");
                }
                else
                {
                    throw;
                }
            }
            
            
        }

        static void DoRollback(Bank bank)
        {
            try
            {
                bank.PrintTranscationHistory();
                Console.WriteLine("Do you wish to RollBack a specific transaction? yes/no");
                String choose = Convert.ToString(Console.ReadLine().ToLower());
                Console.WriteLine();
                if (choose == "yes")
                {
                    Console.WriteLine("Enter transaction you want to rollback ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 0)
                    {
                        throw new InvalidOperationException("Invalid number");
                    }
                    if (choice > bank._transaction.Count)
                    {
                        throw new InvalidOperationException("Invalid number");
                    }
                    else
                    {

                        bank.RollbackTransaction(bank._transaction[choice]);
                    }

                }
                else if (choose == "no")
                {
                    Console.WriteLine("Ok, See you!");
                }
               
            }
            catch(Exception ex)
            {
                if (ex is FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
                else if (ex is InvalidOperationException)
                {
                    Console.WriteLine("Error: RollBack already done");
                }
                else
                {
                    throw;
                }
            }

        }
        static Account GetAccount()
        {
            Console.Write("Enter account name: ");
            String name = Console.ReadLine();
            Console.Write("Enter starting balance: ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            return new Account(name,balance);
        }
        private static Account FindAccount(Bank bank)
        {
            Console.Write("Enter account name: ");
            String name = Console.ReadLine();
            var _account = bank.GetAccount(name);
            if (_account == null)
                Console.WriteLine($"Account with name {name} not found!");
            return _account;
        }
        static void DoTransfer(Bank bank)
        {
            try
            {
                Console.WriteLine("From account: ");
                var fromAccount = FindAccount(bank);
                Console.WriteLine("To account: ");
                var toAccount = FindAccount(bank);
                if (fromAccount == null || toAccount == null)
                {
                    Console.WriteLine("Unable to find one/both account for the transfer.");
                    return;
                }

                Console.Write("Enter amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                //if (true)
                //{
                //    fromAccount.Withdraw(amount);
                //    toAccount.deposite(amount);
                //}
                
                TransferTransaction trans = new TransferTransaction(fromAccount, toAccount, amount);
                bank.ExecuteTransaction(trans);

            }
            catch (Exception xe)
            {
                Console.WriteLine("Invalid amount");
            }

        }
        
        static void DoPrint(Bank bank)
        {
            var _account = FindAccount(bank);
            if (_account != null)
                _account.print();
            else
                Console.WriteLine("Account not found!");

        }
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Account account = new Account("nawaf  ", 2000);
            
            MenuOption option = 0;


            do
            {
                option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.Withdraw:
                        Console.WriteLine("YOU select Withdraw");
                        DoWithdraw(bank);

                        break;
                    case MenuOption.Deposite:
                        Console.WriteLine("YOU select Diposite");
                        DoDeposite(bank);
                        break;
                    case MenuOption.Print:
                        Console.WriteLine("YOU select Print");
                        DoPrint(bank);
                        break;
                    case MenuOption.Transfer:
                        Console.WriteLine("YOU select Transfer");
                        DoTransfer(bank);
                        break;
                    case MenuOption.AddAccount:
                        Console.WriteLine("YOU select Add Acount");
                        bank.AddAccount(GetAccount());
                        break;
                    case MenuOption.PrintHistory:
                        Console.WriteLine("YOU select Print Hisroty");
                        DoRollback(bank);
                        break;
                    case MenuOption.Quit:

                        Console.WriteLine("YOU select Quit, See you!!");

                        break;
                    default:
                        Console.WriteLine("SORRY INVALID OPTION !!");
                        break;


                }

            } while (option != MenuOption.Quit);



            Console.ReadKey();



        }
    }
}
