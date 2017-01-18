using newBudgetBook.Infrastructure;
using newBudgetBook.Models;
using newBudgetBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newBudgetBook.Services
{
    public class GoalsService
    {
        private GoalsRepository _repo;
       
       
        public GoalsService(GoalsRepository repo)
        {
            _repo = repo;
        }


        //Get 
        public IEnumerable<GoalDTO> ListGoals(string username)
        {
            var goals = (from g in _repo.List()
                         where g.AppUser.UserName == username
                         select new GoalDTO
                         {
                             Id = g.Id,
                             Name = g.Name,
                             Amount = g.Amount,
                             EndDate = g.EndDate,
                             Current = g.Current
                         }).ToList();
            return goals;
        }

        public ICollection<GoalDTO> GetGoalByAppUserId(string username)
        {
            var goals = (from g in _repo.GetGoalByAppUserId(username)
                         select new GoalDTO
                         {
                             Id = g.Id,
                             Name = g.Name,
                             Amount = g.Amount,
                             Current = g.Amount,
                             EndDate = g.EndDate,
                             AppUser = new ApplicationUserDTO
                             {
                                 Id = g.AppUser.Id,
                                 MonthlyIncome = g.AppUser.MonthlyIncome,
                                 Spent = g.AppUser.Spent,
                                 CurrentTotal = g.AppUser.CurrentTotal
                             }
                         }).ToList();
            return goals;
        }

        public GoalDTO GetGoalById(int id)
        {
            var dbGoal = _repo.GetGoalById(id);
            return new GoalDTO
            {
                Id = dbGoal.Id,
                Name = dbGoal.Name,
                Amount = dbGoal.Amount,
                Current = dbGoal.Current,
                EndDate = dbGoal.EndDate
            };
        }

        //Add Goal
        public void AddGoal(GoalDTO goalDto, string userName)
        {
            var user = _repo.GetUserByUserName(userName);
            var goal = new Goal
            {
                Id = goalDto.Id,
                Name = goalDto.Name,
                Amount = goalDto.Amount,
                Current = goalDto.Current,
                EndDate = goalDto.EndDate,
                UserId = user.Id
            };
            _repo.Add(goal);
        }

        //Add to Current and Subtract from savings
        public void AddToCurrentSubtractSavings(int goalId, decimal amount, string userName)
        {
            var user = _repo.GetUserByUserName(userName);
            var thisGoal = _repo.GetGoalById(goalId);
            thisGoal.Current += amount;
            thisGoal.AppUser.MonthlyIncome -= amount;
                     
           
            thisGoal.AppUser.AddedToGoal += amount;
            _repo.Update(thisGoal);
            
        }

       public void SubtractCurrentAddSavings(int goalId, decimal amount, string userName)
        {
            var user = _repo.GetUserByUserName(userName);
            var thisGoal = _repo.GetGoalById(goalId);
            thisGoal.Current -= amount;
            thisGoal.AppUser.MonthlyIncome += amount;

            thisGoal.AppUser.AddedToGoal -= amount;
            _repo.Update(thisGoal);
        }

        //Delete Goal 
        public void DeleteGoal(int id)
        {
            var goal = _repo.GetGoalById(id);
            _repo.Delete(goal);
        }
    }
}
