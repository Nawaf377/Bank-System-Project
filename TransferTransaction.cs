using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class TransferTransaction: Transaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private Boolean _executed;
        private Boolean _reversed;
        private Boolean _success;


        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount):base(amount)
            
        {
            _deposit = new DepositTransaction(toAccount, amount);
            _withdraw = new WithdrawTransaction(fromAccount, amount);
            this._fromAccount = fromAccount;
            this._toAccount = toAccount;
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
        public Boolean Reversed()
        { 
            return this._reversed;
        }
       
        public void print()
        {

            if (_success == true)
            {
                Console.WriteLine("Transferred " + _amount.ToString("c") + " from " + _fromAccount.Name + " to " + _toAccount.Name + " ");
                Console.WriteLine("Balace of " + _fromAccount.Name + " is " + _fromAccount.getBalance() + "\nBalance of "+ _toAccount.Name + " is " + _toAccount.getBalance());
            }
            else
            {
                Console.WriteLine("Transaction has not been succsufully occured");
            }
        }
        public override void Execute()
        {
            base.Execute();

            DepositTransaction deposite = new DepositTransaction(_toAccount, _amount);
            WithdrawTransaction withdraw = new WithdrawTransaction(_fromAccount, _amount);
           

               
                decimal dep = _toAccount.getBalance();
                if (_executed)
                {
                    throw new InvalidOperationException("Already executed");
                }
                else
                {
                    _withdraw.Execute();
                    _deposit.Execute();
                    _success = true;

                    Console.WriteLine("Transfer successful\nNew balance amount of account: " + _fromAccount.getBalance().ToString("c"));
                    _executed = true;

                }
            
        }
        public override void RollBack()
        {
            base.RollBack();
            if (_reversed == true)
            {
                throw new InvalidOperationException("the reverse already occured");
            }
          
            else if(_success == true)
            {
                base.Reversed = true;
                this._withdraw.RollBack();
                this._deposit.RollBack();
            }
        }
    }
}
