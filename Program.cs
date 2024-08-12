using LINQ_Session_01;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        #region Var and Dynamic
        /*
             * LINQ => Language Integrated Query  , C# 3.0
             * +40 Extension Method Exists in Enumerable Class Categorized under 13 Category
             * Can be used with any type that implements IEnumerable interface => {List , Array , Dictionary  , ETC }
             * Sequence => Collection 
             * 1. Local Sequence  : in memory Objects  , Files  {L2O , L2XML ,...}
             * 2. Remote Sequence : L2E {SQL , MONGO DB , MY SQL  ,ORACLE  ,ETC }
             */

        //List<int> numebrs = new List<int>() { 1, 2, 3 }; // Local Sequence 

        /*        ===========-> Var and Dynamic: <-===========
           Var : is used for implicit typing. The compiler infers the type at compile-time.
           Dynamic : is used for runtime type resolution. The type is determined at runtime.
        */



        Console.WriteLine("Var and Dynamic Examples:");

        // var example
        var number = 10;
        var text = "Hello, LINQ!";
        var employees = new List<Employee>();

        // dynamic example
        dynamic dynamicVar = 100;
        Console.WriteLine($"Dynamic variable: {dynamicVar}");
        dynamicVar = "Now I'm a string";
        Console.WriteLine($"Dynamic variable changed: {dynamicVar}");

        Console.WriteLine();
        #endregion

        #region Extension Methods

        // Extension Methods:
        //We defined extension methods for the int type in the IntExtension class.
        //These methods(Square and IsEven) can be called on any int as if they were instance methods.

        Console.WriteLine("Extension Methods Examples:");

        int num = 5;
        Console.WriteLine($"Square of {num}: {num.Square()}");
        Console.WriteLine($"Is {num} even? {num.IsEven()}");

        Console.WriteLine();
        #endregion

        #region Anonymous Type
        // Anonymous types allow you to create objects without explicitly defining a class.
        // They are useful for projections in LINQ queries.

        Console.WriteLine("Anonymous Type Example:");

        var person = new { Name = "John Doe", Age = 30 };
        Console.WriteLine($"Person: {person.Name}, Age: {person.Age}");

        Console.WriteLine();
        #endregion

        #region LINQ Overview
        // LINQ (Language Integrated Query) allows you to query various data sources using a consistent syntax.
        //In the example, we queried a list of Employee objects to find IT department employees.


        Console.WriteLine("LINQ Overview:");

        List<Employee> employeeList = new List<Employee>
        {
            new Employee(1, "Alice", 30, "HR", 50000),
            new Employee(2, "Bob", 35, "IT", 60000),
            new Employee(3, "Charlie", 25, "Sales", 45000),
            new Employee(4, "David", 40, "IT", 70000),
            new Employee(5, "Eve", 28, "HR", 55000)
        };

        // Simple LINQ query to find employees in IT department
        var itEmployees = employeeList.Where(e => e.Department == "IT");
        Console.WriteLine("IT Employees:");
        foreach (var emp in itEmployees)
        {
            Console.WriteLine($"{emp.Name} - {emp.Department}");
        }

        Console.WriteLine();
        #endregion

        #region LINQ Syntax

        //var lst = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // Local Seq

        //1.Fluent Syntax 
        //  1.1 Calling Static Methods 

        //var result = Enumerable.Where(lst, number => number % 2 == 0);

        //  1.2 Extension Method 

        //var result = lst.Where(number => number % 2 == 0);




        //2. Query Syntax  {Query Expression}
        // starting with "From" => "Range Variable" in "Collection"  Must End With select or Group by 

        //var result = from number in lst
        //             where number % 2 == 0
        //             select number;


        ////3. Hypird Syntax 
        //var result = (from number in lst
        //              where number % 2 == 0
        //              select number).Where(n => n > 4);


        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}


        // Query Syntax: Uses SQL-like syntax (from, where, select).
        // Method Syntax: Uses method calls and lambda expressions.
        // Both syntaxes are equivalent in terms of functionality.


        Console.WriteLine("LINQ Syntax Examples:");

        // Query Syntax
        var youngEmployees = from emp in employeeList
                             where emp.Age < 30
                             select emp.Name;

        Console.WriteLine("Employees under 30 (Query Syntax):");
        foreach (var name in youngEmployees)
        {
            Console.WriteLine(name);
        }

        // Method Syntax
        var highPaidEmployees = employeeList.Where(e => e.Salary > 55000)
                                            .Select(e => e.Name);

        Console.WriteLine("\nHigh paid employees (Method Syntax):");
        foreach (var name in highPaidEmployees)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine();
        #endregion

        #region LINQ Execution Ways

        // Ways if LINQ Execution 

        // 1.Differed Execution =>( latest Update of data between Query Definition and the first use of the Query result)
        // ALL LINQ Operators Except 3 {Element  ,Aggregate , Casting } Operators are Differed 
        //var lst = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }; // Local Seq

        //var result = lst.Where(number => number % 2 == 0);  // Query Definition 


        //lst.AddRange(new List<int> { 15, 16, 17, 18, 19, 20 });

        //lst.RemoveRange(0, 5);



        //foreach (var item in result)
        //{
        //    Console.Write($"{item}, ");
        //}

        //2.Immediate Execution 

        //var lst = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }; // Local Seq

        //List<int> result = lst.Where(number => number % 2 == 0).ToList(); // {2,4,6,8,10,12,14}


        //lst.AddRange(new List<int> { 15, 16, 17, 18, 19, 20 });

        //lst.RemoveRange(0, 5);



        //foreach (var item in result)
        //{
        //    Console.Write($"{item}, ");
        //}



        // Deferred Execution: The query is not executed until the results are iterated over.
        // Immediate Execution: The query is executed immediately when methods like ToList() or Count() are called.

        Console.WriteLine("LINQ Execution Ways:");

        // Deferred Execution
        var deferredQuery = employeeList.Where(e => e.Age > 30);
        employeeList.Add(new Employee(6, "Frank", 45, "Sales", 65000));

        Console.WriteLine("Deferred Execution Results:");
        foreach (var emp in deferredQuery)
        {
            Console.WriteLine($"{emp.Name} - {emp.Age}");
        }

        // Immediate Execution
        var immediateResult = employeeList.Where(e => e.Salary > 60000).ToList();
        employeeList.Add(new Employee(7, "Grace", 50, "IT", 75000));

        Console.WriteLine("\nImmediate Execution Results:");
        foreach (var emp in immediateResult)
        {
            Console.WriteLine($"{emp.Name} - {emp.Salary}");
        }

        #endregion


    }
}