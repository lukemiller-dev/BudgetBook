using newBudgetBook.Data;
using newBudgetBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newBudgetBook.Infrastructure
{
    public class GoalsRepository : GenericRepository<Goal>
    {
        
        public GoalsRepository(ApplicationDbContext db) : base(db)
        {
        }

        public Goal GetGoalById(int id)
        {
            return (from g in _db.Goals where g.Id == id select g).FirstOrDefault();
        }

        public IQueryable<Goal> GetGoalByAppUserId(string userName)
        {
            return from g in _db.Goals where g.AppUser.UserName == userName select g;
        }

        public void Update(Goal current)
        {
            _db.Set<Goal>().Update(current);
            _db.SaveChanges();
        }
    }
}
