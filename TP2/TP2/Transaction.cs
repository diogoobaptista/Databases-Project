using System;
using System.Transactions;

namespace TP2
{
    public class Transaction
    {

        public static TransactionScope GetTsReadCommitted()
        {
            var option = new TransactionOptions();
            option.IsolationLevel = IsolationLevel.ReadCommitted;
            option.Timeout = TimeSpan.FromMinutes(5);

            return new TransactionScope(TransactionScopeOption.Required, option);
        }

        public static TransactionScope GetTsSerializable()
        {
            var option = new TransactionOptions();
            option.IsolationLevel = IsolationLevel.Serializable;
            option.Timeout = TimeSpan.FromMinutes(5);

            return new TransactionScope(TransactionScopeOption.Required, option);
        }
    
        public static TransactionScope GetTsReadUnCommitted()
        {
            var option = new TransactionOptions();
            option.IsolationLevel = IsolationLevel.ReadUncommitted;
            option.Timeout = TimeSpan.FromMinutes(5);

            return new TransactionScope(TransactionScopeOption.Required, option);
        }
    }
}