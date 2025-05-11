using GeneticAlgorithm.Models;
using System.Linq;

namespace GeneticAlgorithm.Services;

public class GeneticService
{
    private readonly CompanyFinancial parent1;
    private readonly CompanyFinancial parent2;
    private readonly Random _rnd = new Random();

    public GeneticService(CompanyFinancial parent1, CompanyFinancial parent2)
    {
        this.parent1 = parent1;
        this.parent2 = parent2;
    }

    public CompanyFinancial OptimizeGPD()
    {
        var best = GetOffspring(parent1, parent2);

        for (int i = 0; i < 100; i++)
        {
            var mutated = Mutate(best);

            if (Fitness(mutated) > Fitness(best))
            {
                best = mutated;
            }
        }

        var bestInput = Fitness(parent1) >= Fitness(parent2) ? parent1 : parent2;

        if (Fitness(best) < Fitness(bestInput))
        {
            best = bestInput;
        }

        return best;
    }

    private CompanyFinancial GetOffspring(CompanyFinancial a, CompanyFinancial b)
    {
        return new CompanyFinancial
        {
            Revenue = (a.Revenue + b.Revenue) / 2,
            Expense = (a.Expense + b.Expense) / 2,
            MarketingBudget = (a.MarketingBudget + b.MarketingBudget) / 2,
            EmployeeCount = (a.EmployeeCount + b.EmployeeCount) / 2,
            ReportMonth = a.ReportMonth
        };
    }

    private CompanyFinancial Mutate(CompanyFinancial baseData)
    {
        var mutated = new CompanyFinancial
        {
            Revenue = baseData.Revenue + _rnd.Next(-50_000, 50_000),
            Expense = baseData.Expense + _rnd.Next(-30_000, 30_000),
            MarketingBudget = baseData.MarketingBudget + _rnd.Next(-100_000, 100_000),
            EmployeeCount = baseData.EmployeeCount + _rnd.Next(-2, 3), // تغییر کوچکتر
            ReportMonth = baseData.ReportMonth
        };

        mutated.EmployeeCount = Math.Clamp(mutated.EmployeeCount, 5, 20);
        if (mutated.EmployeeCount == 15)
            mutated.Revenue += 20_000;
        else if (mutated.EmployeeCount >= 10 && mutated.EmployeeCount <= 18)
            mutated.Revenue += 5_000;
        else
            mutated.Expense += 10_000;

        mutated.MarketingBudget = Math.Clamp(mutated.MarketingBudget, 50_000, 800_000);
        if (mutated.MarketingBudget >= 100_000 && mutated.MarketingBudget <= 700_000)
            mutated.Revenue += 15_000;
        else
            mutated.Expense += 10_000;

        mutated.Revenue = Math.Clamp(mutated.Revenue, 500_000, 10_000_000);
        mutated.Expense = Math.Clamp(mutated.Expense, 100_000, 5_000_000);

        double ratio = (double)mutated.Revenue / mutated.Expense;
        if (ratio > 5 || ratio < 1)
            mutated.Revenue -= 50_000;

        return mutated;
    }

    private double Fitness(CompanyFinancial data)
    {
        return data.GPD;
    }
}
