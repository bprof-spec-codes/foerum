using Logic.Class;
using Models;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    class TransactionTest
    {
        public Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();

        [Test]
        public void CreateTransactionTest()
        {
            transactionRepository.Setup(comment => comment.Add(It.IsAny<Transaction>()));

            TransactionLogic transactionLogic = new TransactionLogic(transactionRepository.Object);

            Transaction transaction = new Transaction()
            {
                TransactionID = "001"
            };

            transactionLogic.CreateTransaction(transaction);
            transactionRepository.Verify(repo => repo.Add(transaction), Times.Once);
        }

        [Test]
        public void DeleteCommentTest()
        {
            transactionRepository.Setup(comment => comment.Add(It.IsAny<Transaction>()));

            TransactionLogic transactionLogic = new TransactionLogic(transactionRepository.Object);

            Transaction transaction = new Transaction()
            {
                TransactionID = "001"
            };

            transactionLogic.DeleteTransaction(transaction.TransactionID);
            transactionRepository.Verify(repo => repo.Delete(transaction.TransactionID), Times.Once);
        }

        [Test]
        public void EditCommentTest()
        {
            Transaction oldTransaction = new Transaction()
            {
                TransactionID = "001"
            };

            Transaction newTransaction = new Transaction()
            {
                TransactionID = "004"
            };

            transactionRepository.Setup(transaction => transaction.Update(oldTransaction.TransactionID, newTransaction));

            TransactionLogic transactionLogic = new TransactionLogic(transactionRepository.Object);

            transactionLogic.EditTransaction(oldTransaction.TransactionID, newTransaction);
            transactionRepository.Verify(repo => repo.Update(oldTransaction.TransactionID, newTransaction), Times.Once);
        }

        [Test]
        public void GetOneCommentTest()
        {
            TransactionLogic transactionLogic = new TransactionLogic(transactionRepository.Object);

            List<Transaction> transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    TransactionID = "001"
                },
                new Transaction()
                {
                    TransactionID = "002"
                },
                new Transaction()
                {
                  TransactionID = "003"
                },
            };

            transactionRepository.Setup(transaction => transaction.GetOne(transactions[1].TransactionID)).Returns(transactions[1]);

            transactionLogic.GetOneTransaction(transactions[1].TransactionID);
            transactionRepository.Verify(repo => repo.GetOne("002"), Times.Once);
        }

        [Test]
        public void GetAllCommentTest()
        {
            TransactionLogic transactionLogic = new TransactionLogic(transactionRepository.Object);

            List<Transaction> transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    TransactionID = "001"
                },
                new Transaction()
                {
                    TransactionID = "002"
                },
                new Transaction()
                {
                  TransactionID = "003"
                },
            };

            transactionRepository.Setup(transaction => transaction.GetAll()).Returns(transactions.AsQueryable());

            transactionLogic.GetAllTransaction();
            transactionRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}

