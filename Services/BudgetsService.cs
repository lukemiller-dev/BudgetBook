using newBudgetBook.Infrastructure;
using newBudgetBook.Models;
using newBudgetBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace newBudgetBook.Services
{
    public class BudgetsService { 
    private BudgetsRepository _repo;
    public BudgetsService(BudgetsRepository repo)
    {
        _repo = repo;
    }

    //Get
    public IEnumerable<BudgetDTO> ListBudgets(string username)
    {
        var budgets = (from b in _repo.List()
                       where b.AppUser.UserName == username
                       select new BudgetDTO
                       {
                           Id = b.Id,
                           Name = b.Name,
                           Amount = b.Amount,
                           Current = b.Current
                       }).ToList();
        return budgets;
    }

    public ICollection<BudgetDTO> GetBudgetByAppUserId(string userName)
    {
        var budgets = (from b in _repo.GetBudgetByAppUserId(userName)
                       select new BudgetDTO
                       {
                           Id = b.Id,
                           Name = b.Name,
                           Amount = b.Amount,
                           Current = b.Current,
                           AppUserDTO = new ApplicationUserDTO
                           {
                               Id = b.AppUser.Id,
                               MonthlyIncome = b.AppUser.MonthlyIncome,
                               CurrentTotal = b.AppUser.CurrentTotal,
                               Spent = b.AppUser.Spent
                           }
                       }).ToList();
        return budgets;

    }

    //GetById
    public BudgetDTO GetBudgetById(int id)
    {
        var dbBudget = _repo.GetBudgetById(id);
        return new BudgetDTO
        {
            Id = dbBudget.Id,
            Name = dbBudget.Name,
            Amount = dbBudget.Amount,
            Current = dbBudget.Current
        };
    }

    //Add to Current Amount
    public void AddToCurrentAmount(int budgetId, decimal amount)
        {

            var thisBudget = _repo.GetBudgetById(budgetId);
            thisBudget.Current += amount;
            _repo.Update(thisBudget);
        }

    //Subtract from current Amount
    public void SubtractCurrentAmount(int budgetId, decimal amount)
        {
            var thisBudget = _repo.GetBudgetById(budgetId);
            thisBudget.Current -= amount;
            _repo.Update(thisBudget);
        }

    //AddBudget
    public void AddBudget(BudgetDTO budgetDTO, string userName)
    {
            var user = _repo.GetUserByUserName(userName);
        var budget = new Budget
        {
            Id = budgetDTO.Id,
            Name = budgetDTO.Name,
            Amount = budgetDTO.Amount,
            Current = budgetDTO.Current,
            UserId = user.Id
        };
        _repo.Add(budget);
    }

     //Edit Budget 
     public void EditBudget(int budgetId, string name, decimal amount, decimal current)
        {
            var thisBudget = _repo.GetBudgetById(budgetId);
            thisBudget.Name = name;
            thisBudget.Amount = amount;
            thisBudget.Current = current;
            _repo.Update(thisBudget);
            
        }
    //Delete
    public void DeleteBudget(int id)
    {
        var budget = _repo.GetBudgetById(id);
        _repo.Delete(budget);
        }
    }
}
