using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class Bank
    {
        private List<Account> _accounts;
        public List<Transaction> _transaction{ get; set; }


        public Bank()
        {

            _accounts = new List<Account>();
            this._transaction = new List<Transaction>();
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);

        }

        

        public Account GetAccount(string name)
        {
            foreach(Account _name in _accounts)
            {
                if (_name.Name == name)
                {
                    return _name;
                }
                
            }
            return null;

            
        }

       
        
        public void ExecuteTransaction(Transaction transaction)
        {
           
            _transaction.Add(transaction);
            transaction.Execute();
        }
       
        public void RollbackTransaction(Transaction transaction)
        {

            transaction.RollBack();
        }

        public void PrintTranscationHistory ()
        {
            
            for (int i = 0; i < _transaction.Count; i++)
            {
                
                Console.WriteLine("Transaction Number {0} :",i);
                _transaction[i].print();
                Console.WriteLine();
                
            }
        }
    }
}
