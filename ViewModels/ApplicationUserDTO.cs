using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newBudgetBook.ViewModels
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal MonthlyIncomeFixed { get; set; }
        public decimal CurrentTotal { get; set; }
        public decimal Spent { get; set; }
        public decimal AddedToGoal { get; set; }
        
        public ICollection<BudgetDTO> Budgets { get; set; }
        public ICollection<GoalDTO> Goals { get; set; }
    }
}
