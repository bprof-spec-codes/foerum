using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

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
                  throw new NotImplementedException();
            }

            [HttpGet("{id}")]
            public Transaction GetOneTransaction(string id)
            {
                  throw new NotImplementedException();
            }

            [HttpPost]
            public void CreateTransaction(Transaction transaction)
            {
                  throw new NotImplementedException();
            }

            [HttpPut("{id}")]
            public void EditTransaction(string id, [FromBody] Transaction newTransaction)
            {
                  throw new NotImplementedException();
            }

            [HttpDelete("{id}")]
            public Transaction DeleteTransaction(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
