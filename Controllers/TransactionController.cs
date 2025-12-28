using BudgetApi.Contracts;
using BudgetApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTransaction()
            => Ok(await _transactionService.GetAllTransactionAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTransactionById(int id)
        { 
            var trx = await _transactionService.GetTransactionByIdAsync(id);
            if (trx == null)
            {
                return NotFound();
            }

            return Ok(trx);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaction(Transaction transaction)
        {
            var createdTrx = await _transactionService.CreateTransactionAsync(transaction);

            return CreatedAtAction(nameof(GetTransactionById), new {id = new { createdTrx.Id } }, createdTrx);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTransaction(int id, Transaction transaction)
        {
            var result = await _transactionService.UpdateTransactionAsync(id, transaction);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            var existingTrx = await _transactionService.DeleteTransactionAsync(id);
            if (!existingTrx)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
