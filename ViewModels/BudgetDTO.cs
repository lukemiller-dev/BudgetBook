using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newBudgetBook.ViewModels
{
    public class BudgetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Current { get; set; }
        public decimal Remaining { get { return Amount - Current; } }
        public ApplicationUserDTO AppUserDTO { get; set; }
    }
}
