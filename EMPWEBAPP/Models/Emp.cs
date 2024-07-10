namespace EmpWebApp.Models
{
    public class Emp

    {
        public int id { get; set; } 
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public double salary { get; set; }

        public Emp(int id, string name, string email, string phone, string address, string status, double salary)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.status = status;
            this.salary = salary;
        }
        public Emp(string name, string email, string phone, string address, string status, double salary)
        {
        
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.status = status;
            this.salary = salary;
        }

    }
}
