using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newBudgetBook.ViewModels
{
    public class GoalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Current { get; set; }
        public decimal Remaining { get { return Amount - Current; } }
        public DateTime EndDate { get; set; }
        public ApplicationUserDTO AppUser { get; set; }
    }
}
