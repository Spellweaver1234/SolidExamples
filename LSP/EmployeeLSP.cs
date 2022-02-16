using System;

namespace SolidExamples.LSP
{
    // Принцип подстановки Лисков (LCP)
    // Данный принцип гласит, что «вы должны иметь возможность использовать любой производный класс вместо родительского класса и вести
    // себя с ним таким же образом без внесения изменений». Этот принцип прост, но очень важен для понимания.
    // Класс Child не должен нарушать определение типа родительского класса и его поведение.
    public abstract class Employee
    {
        public virtual string GetWorkDetails(int id)
        {
            return "Base Work";
        }

        public virtual string GetEmployeeDetails(int id)
        {
            return "Base Employee";
        }
    }

    public class SeniorEmployee : Employee
    {
        public override string GetWorkDetails(int id)
        {
            return "Senior Work";
        }

        public override string GetEmployeeDetails(int id)
        {
            return "Senior Employee";
        }
    }

    // Теперь у нас есть проблема. Для JuniorEmployee невозможно вернуть информацию о работе, поэтому вы получите необработанное исключение,
    // что нарушит принцип LSP. 
    public class JuniorEmployee : Employee
    {
        // Допустим, для Junior’a отсутствует информация
        public override string GetWorkDetails(int id)
        {
            throw new NotImplementedException();
        }


        public override string GetEmployeeDetails(int id)
        {
            return "Junior Employee";
        }
    }

    // Теперь JuniorEmployee требует реализации только IEmployee, а не IWork. При таком подходе будет поддерживаться принцип LSP.
    public interface IEmployee
    {
        string GetEmployeeDetails(int employeeId);
    }

    public interface IWork
    {
        string GetWorkDetails(int employeeId);
    }

    public class SeniorEmployee : IWork, IEmployee
    {
        public string GetWorkDetails(int employeeId)
        {
            return "Senior Work";
        }

        public string GetEmployeeDetails(int employeeId)
        {
            return "Senior Employee";
        }
    }

    public class JuniorEmployee : IEmployee
    {
        public string GetEmployeeDetails(int employeeId)
        {
            return "Junior Employee";
        }
    }
}
