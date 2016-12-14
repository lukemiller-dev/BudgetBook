using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newBudgetBook.Services;
using newBudgetBook.ViewModels;
using newBudgetBook.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace newBudgetBook.Controllers
{
    [Route("api/[controller]")]
    public class AppUsersController : Controller
    {
        private AppUsersService _service;
       
        public AppUsersController(AppUsersService service)
        {
            _service = service;
   
        }
        // GET: api/values
        [HttpGet]
        public ApplicationUserDTO Get()
        {
            return _service.ListUserInfo(User.Identity.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] decimal amount)
        {
            _service.AddIncome(amount, User.Identity.Name);
        }


        // PUT api/values/5
        [HttpPut("editAmount")]
        public void Put([FromBody]decimal amount)
        {
            _service.EditIncome(amount, User.Identity.Name);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
