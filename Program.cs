using System;
namespace Employee
{
    class Employee
    {
        private string id;
        private string name;
        private string address;
        public Employee(string id,string name,string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine("\nID: " + id);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Address: " + address);
        }
        public virtual bool EmployeeStatus(Employee emp)
        {
            return false;
        }
    }
    class Laborer:Employee
    {
        private static int id = 1;
        private double userRating;
        private int noOfService=0;
        private const double chargePerService = 500;
        public Laborer(string name, string address,double userRating,int noOfService) :base("PL-00"+id++,name,address)
        {
            this.userRating = userRating;
            this.noOfService = noOfService;
        }
        public override bool EmployeeStatus(Employee emp)
        {
            if(emp is Laborer)
            {
                if (70 < userRating&&userRating<=100&& noOfService>=10)
                {
                    return true;
                }
            }
            return false;
        }
        public double getRating()
        {
            return userRating;
        }
        public double TotalEarn()
        {
            if (EmployeeStatus(this))
            {
                return (chargePerService * noOfService);
            }
            return 0;
        }
        public override void ShowInfo()
        { 
            base.ShowInfo();
            Console.WriteLine("Bonus Eligable: " + EmployeeStatus(this));
            Console.WriteLine("User Rating: " + userRating);
            Console.WriteLine("No Of Serive: " + noOfService);
        }

    }
    class Manager:Employee
    {
        private static int id = 1;
        private double yearsOfExperience;
        public Manager(string name, string address,double yearsOfExperience) : base("PM-0"+id++, name, address)
        {
            this.yearsOfExperience = yearsOfExperience;
        }
        public override bool EmployeeStatus(Employee emp)
        {
            if(emp is Manager)
            {
                if (yearsOfExperience >= 2)
                {
                    return true;
                }
            }
            return false;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Bonus Eligable: " + EmployeeStatus(this));
            Console.WriteLine("Yeras Of Experience: " + yearsOfExperience);
        }

    }
    class ServiceProvider
    {
        static int index = 0;
        static Employee[] employees = new Employee[5];
        public static void Inset(Employee employee)
        {
            if (index < employees.Length)
            {
                employees[index] = employee;
                index++;
            }
            else
            {
                Console.WriteLine("Out of Index");
            }
        }
        public static void ProvideDetails()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i].ShowInfo();
            }
        }
        public static void SkilledWorker()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if(employees[i] is Laborer)
                {
                    Laborer l= (Laborer)employees[i];
                    if (l.getRating() > 80)
                    {
                        l.ShowInfo();
                    }
                }    
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider.Inset(new Manager("Shuvo", "Uttara", 5));
            ServiceProvider.Inset(new Manager("Jahid", "Badda", 1));
            ServiceProvider.Inset(new Laborer("Sohan", "Mirpur", 85, 20));
            ServiceProvider.Inset(new Laborer("Jisan", "Kuril", 65, 44));
            ServiceProvider.Inset(new Laborer("Numan", "Banani", 88, 3));
            //Manager(id,name,address,yearsOfExperience)
            //Laborer(id,name,address,userrating,noOfServices)
            ServiceProvider.ProvideDetails();
            Console.WriteLine("\n\n");
            ServiceProvider.SkilledWorker();
        }
    }
}
