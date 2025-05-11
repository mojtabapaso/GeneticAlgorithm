namespace GeneticAlgorithm.Models
{
    public class CompanyFinancial
    {
        public int Id { get; set; }
        public DateTime ReportMonth { get; set; }
        public int Revenue { get; set; }
        public int Expense { get; set; }
        public int MarketingBudget { get; set; }
        public int EmployeeCount { get; set; }
        public int GPD => Revenue - Expense;
    }
}
