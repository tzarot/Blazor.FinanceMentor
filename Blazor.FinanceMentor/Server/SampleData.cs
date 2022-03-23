using Blazor.FinanceMentor.Server.Storage;
using Blazor.FinanceMentor.Shared;

namespace Blazor.FinanceMentor.Server
{
    public static class SampleData
    {

        public static void AddEarningsRepository(this IServiceCollection services)
        {
            var today = DateTime.Today;
            var lastMonth = DateTime.Today.AddMonths(-1);
            var previousMonth = DateTime.Today.AddMonths(-2);

            var earningsRepository = new MemoryRepository<Earning>();

            earningsRepository.Add(
                new Earning()
                {
                    Date = new DateTime(previousMonth.Year, previousMonth.Month, 25), Amount = 2480,
                    Category = EarningCategory.Salary, Subject = "Salary",
                });
            earningsRepository.Add(
                new Earning()
                {
                    Date = new DateTime(previousMonth.Year, previousMonth.Month, 12),
                    Amount = 440,
                    Category = EarningCategory.Coaching,
                    Subject = "Tim Johns",
                });
            earningsRepository.Add(
                new Earning()
                {
                    Date = new DateTime(lastMonth.Year, lastMonth.Month, 25),
                    Amount = 2480,
                    Category = EarningCategory.Salary,
                    Subject = "Salary",
                });
            earningsRepository.Add(
                new Earning()
                {
                    Date = new DateTime(lastMonth.Year, lastMonth.Month, 12),
                    Amount = 790,
                    Category = EarningCategory.Freelancing,
                    Subject = "Acme",
                });
            earningsRepository.Add(
                new Earning()
                {
                    Date = new DateTime(lastMonth.Year, lastMonth.Month, 4),
                    Amount = 387,
                    Category = EarningCategory.Other,
                    Subject = "Make A",
                });
            earningsRepository.Add(
                new Earning()
                {
                    Date = new DateTime(today.Year, today.Month, 25),
                    Amount = 2480,
                    Category = EarningCategory.Salary,
                    Subject = "Salary",
                });
            earningsRepository.Add(
                new Earning()
                {
                    Date = new DateTime(today.Year, today.Month, 14),
                    Amount = 680,
                    Category = EarningCategory.Coaching,
                    Subject = "Tim Johns",
                });

            services.AddSingleton<IRepository<Earning>>(earningsRepository);
        }


        public static void AddExpensesRepository(this IServiceCollection services)
        {
            var today = DateTime.Today;
            var lastMonth = DateTime.Today.AddMonths(-1);
            var previousMonth = DateTime.Today.AddMonths(-2);

            var expensesRepository = new MemoryRepository<Expense>();

            expensesRepository.Add(
                new Expense()
                {
                    Date = new DateTime(previousMonth.Year, previousMonth.Month, 2),
                    Amount = 150,
                    Category = ExpenseCategory.Clothing,
                    Subject = "Jacket",
                });
            expensesRepository.Add(
                new Expense()
                {
                    Date = new DateTime(previousMonth.Year, previousMonth.Month, 5),
                    Amount = 280,
                    Category = ExpenseCategory.Utilities,
                    Subject = "Heating"
                });
            expensesRepository.Add(
                new Expense()
                {
                    Date = new DateTime(lastMonth.Year, lastMonth.Month, 17),
                    Amount = 750,
                    Category = ExpenseCategory.Savings,
                    Subject = "Savings",
                });
            expensesRepository.Add(
                new Expense()
                {
                    Date = new DateTime(lastMonth.Year, lastMonth.Month, 24),
                    Amount = 90,
                    Category = ExpenseCategory.Gifts,
                    Subject = "Cat present",
                });
            expensesRepository.Add(
                new Expense()
                {
                    Date = new DateTime(lastMonth.Year, lastMonth.Month, 11),
                    Amount = 387,
                    Category = ExpenseCategory.Education,
                    Subject = "PS Seminars",
                });
            expensesRepository.Add(
                new Expense()
                {
                    Date = new DateTime(today.Year, today.Month, 7),
                    Amount = 600,
                    Category = ExpenseCategory.Food,
                    Subject = "Super Market",
                });
         

            services.AddSingleton<IRepository<Expense>>(expensesRepository);
        }
    }
}
