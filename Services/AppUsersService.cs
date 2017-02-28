using newBudgetBook.Infrastructure;
using newBudgetBook.Models;
using newBudgetBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newBudgetBook.Services
{
    public class AppUsersService
    {
        private AppUsersRepository _repo;
        private BudgetsRepository _bRepo;
        public AppUsersService(AppUsersRepository repo, BudgetsRepository bRepo)
        {
            _repo = repo;
            _bRepo = bRepo;
        }

        //Get
        public ApplicationUserDTO ListUserInfo(string userName)
        {
            var user = (from u in _repo.List()
                        where u.UserName == userName
                        select new ApplicationUserDTO
                        {
                            Id = u.Id,
                            MonthlyIncome = u.MonthlyIncome,
                            MonthlyIncomeFixed = u.MonthlyIncomeFixed,
                            //AddedToGoal = u.AddedToGoal,
                           


                            Budgets = (from b in u.Budgets
                                       select new BudgetDTO
                                       {
                                           Id = b.Id,
                                           Amount = b.Amount,
                                           Current = b.Current,
                                           Name = b.Name

                                       }).ToList(),
                            Goals = (from g in u.Goals select new GoalDTO
                            {
                                Id = g.Id,
                                Amount = g.Amount,
                                Current = g.Current,
                                Name = g.Name,
                                EndDate = g.EndDate
                            }).ToList()
                        }).FirstOrDefault();

            user.CurrentTotal = user.MonthlyIncome - user.Budgets.Sum(t => t.Current);
            user.Spent = user.MonthlyIncomeFixed - user.CurrentTotal;

            //user.CurrentTotal = user.MonthlyIncome - user.Budgets.Sum(t => t.Current);
            ////user.Spent = user.Budgets.Sum(s => s.Current + user.AddedToGoal);
            //user.Spent = user.MonthlyIncome - user.CurrentTotal;
            



            return user;
        }

        //Add to Income
        public void EditIncome(decimal amount, string user)
        {
            var thisUser = _repo.GetUserByUserName(user);
            thisUser.MonthlyIncome += amount;
            thisUser.MonthlyIncomeFixed += amount;
            _repo.Update(thisUser);
        }

        //Add New Income
        public void AddIncome(decimal amount, string user)
        {
            var thisUser = _repo.GetUserByUserName(user);
            thisUser.MonthlyIncome = amount;
            thisUser.MonthlyIncomeFixed = thisUser.MonthlyIncome;
            thisUser.AddedToGoal = 0;
            //if(thisUser.Spent > thisUser.MonthlyIncome)
            //{
            //    //alert 
            //}
            _repo.Update(thisUser);
        } 
    }
}
