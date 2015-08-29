using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureMappings.Database
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeesILike = new HashSet<Employee>();
            this.EmployeesThatLikeMe = new HashSet<Employee>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }

        public virtual ICollection<Employee> EmployeesILike { get; set; }

        public virtual ICollection<Employee> EmployeesThatLikeMe { get; set; }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
