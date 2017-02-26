using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace newBudgetBook.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal MonthlyIncomeFixed { get; set; }
        public decimal AddedToGoal { get; set; }
        public decimal Spent {
            get
            {
                var total = 0m;

               
                foreach (var s in Budgets)
                {
                    
                    total += (s.Current + AddedToGoal);
                }

               

                return total;
            }           
        }

        public decimal CurrentTotal
        {
            get
            {
                var total = 0m;
                foreach (var t in Budgets)
                {
                    total = MonthlyIncome - t.Current;
                }
                return total;
            }
        }

       
        public ICollection<Budget> Budgets { get; set; }
        public ICollection<Goal> Goals { get; set; }
    }
}
