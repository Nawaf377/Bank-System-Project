using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class Account
    {
        private decimal balacne;
        private string name;

        public string Name
        {
            get { return name; }
        }

        public Account(string _name, decimal _balance)
        {
            this.name = _name;
            this.balacne = _balance;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public decimal getBalance()
        {
            return this.balacne;
        }
        public void setBalance(decimal balance)
        {
            this.balacne = balance;
        }


        public void deposite(decimal amount)
        {


          
                
                if (amount > 0)
                {
                    balacne = balacne + amount;
                    Console.WriteLine("Amount has been diposte succeeded");
                }

                else
                {
                throw new InvalidOperationException("Invalid amount");
                }
           




        }

        public void Withdraw(decimal amount)
        {

            
           
                if (amount <= balacne)
                {
                    this.balacne = balacne - amount;
                    Console.WriteLine("withdraw has been succeeded ");
                    //Withdraw(amount);
                }
                else
                {

                 throw new InvalidOperationException("Invalid amount");
                    
                }
           

        }
        public void Transfer()
        {
            decimal amount = 0 ;
            if (amount <= balacne)
            {

            }
        }
        public void print()
        {
            Console.WriteLine();
            Console.WriteLine("your name is:{0} \nyour balance is {1}", name, balacne);
        }
    }
}
