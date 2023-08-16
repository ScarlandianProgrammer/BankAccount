using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account account;

        [TestInitialize]
        public void createDefaultAccount()
        {
            account = new("J. Doe");
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.999)]
        [DataRow(999999.99)]
        [DataRow(345.67)]
        public void Deposit_APositiveAmount_AddToBalance(double amountToDeposit)
        {
            account.Deposit(amountToDeposit);

            Assert.AreEqual(amountToDeposit, account.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            double depositAmount = 100;
            double expectedReturn = 100;

            // Act
            double returnAmount = account.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(returnAmount, expectedReturn);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => account.Deposit(invalidDepositAmount));
        }
    }
}