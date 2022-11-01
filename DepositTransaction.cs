using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class DepositTransaction:Transaction
    {
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;
       

        public DepositTransaction(Account account, decimal amount):base(amount)
        {
            this._account = account;
            this._amount = amount;


        }

        public Boolean Executed()
        {
            return this._executed;
        }

        public Boolean Success()
        {
            return this._success;
        }

        public void print()
        {
            if (_success)
            {
                Console.WriteLine("Amount Deposited: " + Convert.ToString(_amount));
                Console.WriteLine("Success");

            }
            else
            {
                Console.WriteLine("Failed");
            }
           
        }

        public Boolean Reversed()
        {
            return this._reversed;
        }

        public override void Execute()
        {
            base.Execute();
            

                decimal bal = _account.getBalance();
                if (_executed)
                {
                    throw new InvalidOperationException("it is already executed");
                }
                else
                {
                     _account.deposite(_amount);
                    _success = true;
                     Console.WriteLine("Deposite successful\nNew balance amount: " + _account.getBalance().ToString("c"));
                    _executed = true;
                     
                }
            
           
        }

        public override void RollBack()
        {
            base.RollBack();
                if (_reversed)
                {
                    throw new InvalidOperationException("Already Reversed");
                }
                else

                {
                    decimal bal = _account.getBalance();
                    bal += _amount;
                    base.Reversed = true;
                }

            
        }
    }
}
