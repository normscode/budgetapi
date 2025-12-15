using BudgetApi.Models;
using BudgetApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBudget()
        {
            return Ok(await _budgetService.GetAllBudgetAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBudgetById(int id)
        {
            var budget = await _budgetService.GetBudgetByIdAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBudget(Budget budget)
        {
            var createdBudget = await _budgetService.CreateBudgetAsync(budget);
            return CreatedAtAction(nameof(GetBudgetById), new { id = createdBudget.Id }, createdBudget);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudget(int id, Budget budget)
        {
            var result = await _budgetService.UpdateBudgetAsync(id, budget);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(int id)
        {
            var result = await _budgetService.DeleteBudgetAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
