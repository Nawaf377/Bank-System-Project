using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    public abstract class Transaction
    {

        protected decimal _amount;
        protected bool _success;
        private bool _executed;
        private bool _reversed;
        private DateTime _dateStamp;


        public Boolean Success()
        {
            return this._success;
        }
        public Boolean Executed()
        {
            return this._executed;
        }
        public Boolean Reversed { get => _reversed; set => _reversed = true; }

        public DateTime DateStamp()
        {
            return this._dateStamp;
        }

        public Transaction(decimal amount)
        {
            this._amount = amount;
        }

        public void print()
        {
            Console.Write("Succes: ");
            Console.WriteLine(Success());
            Console.Write("Reversed: ");
            Console.WriteLine(_reversed);
            Console.Write("Excuted: ");
            Console.WriteLine(Executed());
            Console.Write("Amount: ");
            Console.WriteLine(_amount);

            _dateStamp = DateTime.Now;
            Console.WriteLine("Time of transaction: ");
            Console.Write(_dateStamp.ToString());
            Console.WriteLine();
        }

        public virtual void Execute()
        {
            
           if (_executed)
            {
                throw new InvalidOperationException("Already executed");
            }
           else
            {
                _executed = true;
                _success = true;
            }
            _dateStamp = DateTime.Now;
        }
        public virtual void RollBack()
        {
             
            if (_reversed)
            {
                throw new InvalidOperationException("Error: RollBack already done.");
            }
            else if (!_success)
            {
                throw new InvalidOperationException("Error: Transaction faild");
            }
            _dateStamp = DateTime.Now;
        }
    }
}
