# 📈 GPD Optimization Using Genetic Algorithm

## Overview

This project presents a practical implementation of a **Genetic Algorithm (GA)** for optimizing the **GPD (Gross Profit Difference)** of a company based on historical financial data. The algorithm aims to discover better configurations for critical business parameters such as:

- Number of Employees
- Marketing Budget
- Revenue
- Expenses

By combining financial data from two months and applying controlled mutations, the algorithm evolves towards more optimal configurations that improve the company's GPD.

---

## Technologies Used

- **ASP.NET Core MVC 8.0**
- **Entity Framework Core**
- **C# (Genetic Algorithm implementation)**
- **Chart.js** (for visual representation)
- **JavaScript/HTML/CSS** (for interactivity and UI)

---

## Project Structure

- `GeneticService.cs`: Core class that implements the genetic algorithm logic, including population combination, mutation, and selection.
- `FinancialController.cs`: ASP.NET controller that loads financial data from the database and feeds it into the optimizer.
- `Index.cshtml`: Razor view that displays GPD comparison charts and interactive tables.

---

## Algorithm Logic

1. **Initial Population**  
   Two historical financial entries (representing different months) are selected as the base generation.

2. **Combination & Crossover**  
   A new candidate is created by averaging the values of the two parents.

3. **Mutation Phase**  
   Key parameters such as `Revenue`, `Expenses`, `MarketingBudget`, and `EmployeeCount` are randomly mutated within predefined bounds. 

4. **Domain-Specific Constraints**
   - Ideal employee count: **15**
   - Acceptable range: **5 to 20**
   - Marketing budget range: **100,000 to 700,000**
   - Revenue-to-expense ratio must remain within a realistic range (e.g., 1 to 5)

5. **Fitness Evaluation**
   GPD is used as the fitness function. If a mutated candidate has a higher GPD, it replaces the current best.

6. **Optimization Cycle**
   The mutation and evaluation process is repeated for 100 generations, ensuring convergence toward an optimal solution.

---

## Visualization

An interactive line chart is displayed comparing the **Actual GPD** with the **Optimized GPD** over time.

- 🟦 Blue Line: Real data  
- 🟩 Green Dashed Line: Optimized results

### Additional Features

- Click on any chart point to view a **detailed comparison table** showing the actual vs. optimized values for:
  - Revenue
  - Expenses
  - Employee Count
  - Marketing Budget
  - GPD

- Color-coded values in the comparison table indicate improvement (green) or decline (red).

## License

This project is for educational purposes and is shared publicly on GitHub. You are welcome to fork and adapt it for learning, research, or personal use.
