using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class WithdrawTransaction : Transaction
    {
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;

        public WithdrawTransaction(Account account, decimal amount):base(amount)
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
                Console.WriteLine("Amount Withdrawed: " + Convert.ToString(_amount));
                Console.WriteLine("Success");

            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public Boolean Reversed()
        {
            return this._reversed;
        }

        public override void Execute()
        {
            base.Execute();


           
            if (_executed)
            {
                throw new InvalidOperationException("it is already executed");
            }
            else
            {
                if (_amount > 0 & _amount > _account.getBalance())
                {
                    _account.Withdraw(_amount);
                    _success = true;

                    Console.WriteLine("Withdraw successful\nNew balance amount: " + _account.getBalance().ToString("c"));

                    _executed = true;
                }
                else
                {
                    base._success = false;
                    
                    
                }

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
                bal -= _amount;
                base.Reversed = true;
            }


        }


    }

       
    
}
