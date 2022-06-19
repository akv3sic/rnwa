using System;
using System.Collections.Generic;

namespace Employees.Models
{
    public partial class Salary
    {
        public int EmpNo { get; set; }
        public int Salary1 { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }

        public virtual Employee EmpNoNavigation { get; set; } = null!;
    }
}
