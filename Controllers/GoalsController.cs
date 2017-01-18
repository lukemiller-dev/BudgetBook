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
    public class GoalsController : Controller
    {
        private GoalsService _service;
        public GoalsController(GoalsService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<GoalDTO> Get()
        {
            return _service.ListGoals(User.Identity.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public GoalDTO Get(int id)
        {
            return _service.GetGoalById(id);
        }

        // POST api/values
        //Add Goals
        [HttpPost]
        public void Post([FromBody]GoalDTO goalDto)
        {
            _service.AddGoal(goalDto, User.Identity.Name);
        }

        //AddToCurrentSubtractSavings
        [HttpPost("amount/{goalId}")]
        public void Post(int goalId, [FromBody]decimal amount)
        {
            _service.AddToCurrentSubtractSavings(goalId, amount, User.Identity.Name);
        }

        //SubtractCurrentAddSavings
        [HttpPut("amount/{goalId}")]
        public void Put(int goalId, [FromBody]decimal amount)
        {
            _service.SubtractCurrentAddSavings(goalId, amount, User.Identity.Name);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteGoal(id);
        }
    }
}
