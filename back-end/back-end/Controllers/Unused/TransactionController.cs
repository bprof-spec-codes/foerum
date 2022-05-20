
using Logic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionLogic transactionLogic;

        public TransactionController(ITransactionLogic logic)
        {
            this.transactionLogic = logic;
        }

        [HttpPost]
        [Authorize]
        public void CreateTransaction([FromBody] TransactionEmailOptions options)
        {
            this.transactionLogic.sendEmailAboutTransaction(options);
        }

        /* [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Transaction> GetAllTransaction()
        {
            return this.transactionLogic.GetAllTransaction();
        }

        [HttpGet("{id}")]
        [Authorize]
        public Transaction GetOneTransaction(string id)
        {
            return this.transactionLogic.GetOneTransaction(id);
        }

        [HttpPost]
        [Authorize]
        public void CreateTransaction([FromBody] Transaction transaction)
        {
            this.transactionLogic.CreateTransaction(transaction);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void EditTransaction(string id, [FromBody] Transaction newTransaction)
        {
            this.transactionLogic.EditTransaction(id, newTransaction);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteTransaction(string id)
        {
            this.transactionLogic.DeleteTransaction(id);
        } */
    }
}