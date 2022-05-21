using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class CurrentDeptEmp
    {
        public int EmpNo { get; set; }
        public string DeptNo { get; set; } = null!;
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
    }
}
