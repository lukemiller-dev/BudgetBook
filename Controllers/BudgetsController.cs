using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newBudgetBook.Services;
using newBudgetBook.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace newBudgetBook.Controllers
{
    [Route("api/[controller]")]
    public class BudgetsController : Controller
    {
        private BudgetsService _service;
        public BudgetsController(BudgetsService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<BudgetDTO> Get()
        {
            //return _service.ListBudgets();
            return _service.ListBudgets(User.Identity.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public BudgetDTO Get(int id)
        {
            return _service.GetBudgetById(id);
        }

        // POST api/values
        //Add Budgets
        [HttpPost]
        public void Post([FromBody]BudgetDTO budgetDTO)
        {
            _service.AddBudget(budgetDTO, User.Identity.Name);
        }

        //Add to current spending
        [HttpPost("amount/{budgetId}")]
        public void Post(int budgetId, [FromBody]decimal amount)
        {
            _service.AddToCurrentAmount(budgetId, amount);
        }

        //Subtract from current spending
        //[HttpPut("amount/{budgetId}")]
        //public void Put(int budgetId, [FromBody]decimal amount)
        //{
        //    _service.SubtractCurrentAmount(budgetId, amount);
        //}

      
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteBudget(id);
        }
    }
}
