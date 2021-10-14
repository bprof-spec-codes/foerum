using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    /* Every controller needs all the CRUD methods */
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionLogic transactionLogic;

        public TransactionController(ITransactionLogic logic)
        {
            this.transactionLogic = logic;
        }

        [HttpGet]
        public IEnumerable<Transaction> GetAllTransaction()
        {
            return this.transactionLogic.GetAllTransaction();
        }

        [HttpGet("{id}")]
        public Transaction GetOneTransaction(string id)
        {
            return this.transactionLogic.GetOneTransaction(id);
        }

        [HttpPost]
        public void CreateTransaction([FromBody] Transaction transaction)
        {
            this.transactionLogic.CreateTransaction(transaction);
        }

        [HttpPut("{id}")]
        public void EditTransaction(string id, [FromBody] Transaction newTransaction)
        {
            this.transactionLogic.EditTransaction(id, newTransaction);
        }

        [HttpDelete("{id}")]
        public void DeleteTransaction(string id)
        {
            this.transactionLogic.DeleteTransaction(id);
        }
    }
}
