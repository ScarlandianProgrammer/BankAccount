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
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(999999.99)]
        [DataRow(345.67)]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance(double depositAmount)
        {
            double expectedReturn = depositAmount;

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

        [TestMethod]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(999999.99)]
        [DataRow(345.67)]
        public void Withdraw_APositiveAmount_TakeOutOfBalance(double validWithdrawAmount) 
        {
            // adding funds to the balance so that it can be taken away
            account.Deposit(validWithdrawAmount);

            // Act
            account.Withdraw(validWithdrawAmount);

            // Assert
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(999999.99)]
        [DataRow(345.67)]
        public void Withdraw_APositiveNumber_ReturnUpdatedBalance(double validWithdrawAmount)
        {
            account.Deposit(1000000.0);
            double expectedUpdatedBalance = account.Balance - validWithdrawAmount;

            // Act
            account.Withdraw(validWithdrawAmount);

            // Assert
            Assert.AreEqual(expectedUpdatedBalance, account.Balance);
        }

        [TestMethod]
        [DataRow(-100)]
        [DataRow(-.01)]
        [DataRow(-999999.99)]
        [DataRow(-345.67)]
        [DataRow(0)]
        public void Withdraw_ANegativeNumber_ThrowsArgumentException(double invalidWithdrawAmount)
        {
            account.Deposit(1000000.0);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(invalidWithdrawAmount));
        }
    }
}