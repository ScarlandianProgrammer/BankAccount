using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customer's bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Creates an account with a specific owner and 0 dollars
        /// </summary>
        /// <param name="accOwner">The customer's full name that owns this account</param>
        public Account(string accOwner)
        {
            Owner = accOwner;
        }

        /// <summary>
        /// The owner's full name, first and last
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The current amount of money currently in the customer's account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Adds the specified amount of money to the balance, and returns the new balance
        /// </summary>
        /// <param name="amount">The positive amount to be added to the account</param>
        /// <returns>The new account balance after the deposit</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws an exception if
        /// the amount is equal to or less than 0.</exception>
        public double Deposit(double amount) 
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amount)} must be more than 0");
            }
            Balance += amount;
            return Balance;
        }

        /// <summary>
        /// Takes out the specified amount from the account
        /// </summary>
        /// <param name="amount">The positive amount of money to be taken out of the account</param>
        /// <returns>The new account balance after the withdrawx</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws an exception
        /// if the amount is equal to or less than 0</exception>
        public double Withdraw(double amount)
        {
            if (amount <= 0) 
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amount)} must be more than 0");
            }
            Balance -= amount;
            return Balance;
        }
    }
}
