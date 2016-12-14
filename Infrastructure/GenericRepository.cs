using newBudgetBook.Data;
using newBudgetBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newBudgetBook.Infrastructure
{
     public class GenericRepository<T> where T : class
        {
            public ApplicationDbContext _db;
            public GenericRepository(ApplicationDbContext db)
            {
                _db = db;
            }

            //Get
            public IQueryable<T> List()
            {
                return _db.Set<T>();
            }

            //UserByUserName 

            public ApplicationUser GetUserByUserName(string userName)
            {
            return _db.Users.FirstOrDefault(u => u.UserName == userName);
            }

            //Add

            public void Add(T value)
            {
                _db.Set<T>().Add(value);
                _db.SaveChanges();
            }
      
            //Delete
            public void Delete(T id)
            {
                _db.Set<T>().Remove(id);
                _db.SaveChanges();
            }
        }
    }

