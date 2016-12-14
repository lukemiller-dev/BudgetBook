using newBudgetBook.Data;
using newBudgetBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newBudgetBook.Infrastructure
{
    public class BudgetsRepository : GenericRepository<Budget>
    {
        public BudgetsRepository(ApplicationDbContext db) : base(db)
        {
        }
        public Budget GetBudgetById(int id)
        {
            return (from b in _db.Budgets where b.Id == id select b).FirstOrDefault();
        }

        public IQueryable<Budget> GetBudgetByAppUserId(string userName)
        {
            return from b in _db.Budgets where b.AppUser.UserName == userName select b;
        }

        public void Update(Budget current)
        {
            _db.Set<Budget>().Update(current);
            _db.SaveChanges();
        }

    }
}

