﻿using AutoMapper;
using System;
using WebApp.API.Context;
using WebApp.API.Interfaces;
using WebApp.API.Models;
using WebApp.API.Repository.DataBase;

namespace WebApp.API.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly WebAppContext _context;
        private readonly IMapper _mapper;

        public ExpenseService(WebAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public (bool, List<Notification>, List<expense>) GetAllExpenses(string email)
        {
            var expensesFromDatabase = _context.expenses.Where(e => e.email == email).ToList();

            var notifications = new List<Notification>();

            if (expensesFromDatabase.Count == 0)
            {
                notifications.Add(new Notification { Message = "No expenses found for the specified email." });
                return (false, notifications, expensesFromDatabase);
            }

            return (true, notifications, expensesFromDatabase);
        }

        public (bool, List<Notification>) CreateExpense(Expense expense)
        {
            var notifications = new List<Notification>();
            var expenseToRegister = _mapper.Map<Expense, expense>(expense);

            notifications.Add(new Notification { Message = "registered expense." });
            _context.expenses.Add(expenseToRegister);
            _context.SaveChanges();
            return (true, notifications);
        }

        public (bool, List<Notification>) UpdateExpense(expense updatedExpense)
        {
            var notifications = new List<Notification>();
            var existingExpense = _context.expenses.FirstOrDefault(e => e.id == updatedExpense.id);

            if (existingExpense == null)
            {
                notifications.Add(new Notification { Message = "expense not found" });
                return (false, notifications);
            }

            existingExpense.email = updatedExpense.email;
            existingExpense.name = updatedExpense.name;
            existingExpense.expenseType = updatedExpense.expenseType;
            existingExpense.price = updatedExpense.price;
            existingExpense.mounth = updatedExpense.mounth;
            existingExpense.year = updatedExpense.year;

            notifications.Add(new Notification { Message = "expense updated" });

            _context.SaveChanges();
            return (true, notifications);
        }

        public (bool, List<Notification>) DeleteExpense(int id)
        {
            var notifications = new List<Notification>();
            var existingExpense = _context.expenses.FirstOrDefault(e => e.id == id);

            if (existingExpense == null)
            {
                notifications.Add(new Notification { Message = "expense not found" });
                return (false, notifications);
            }

            notifications.Add(new Notification { Message = "spent was successfully deleted" });

            _context.expenses.Remove(existingExpense);
            _context.SaveChanges();
            return (true, notifications);
        }
    }
}