using newBudgetBook.Data;
using newBudgetBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newBudgetBook.Infrastructure
{
    public class AppUsersRepository : GenericRepository<ApplicationUser>
    {
        public AppUsersRepository(ApplicationDbContext db) : base(db)
        {
        }

        //update
        public void Update(ApplicationUser user)
        {
            _db.Set<ApplicationUser>().Update(user);
            _db.SaveChanges();
        }

    }
}
