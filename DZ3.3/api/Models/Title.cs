using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Title
    {
        public int EmpNo { get; set; }
        public string Title1 { get; set; } = null!;
        public DateOnly FromDate { get; set; }
        public DateOnly? ToDate { get; set; }

        public virtual Employee EmpNoNavigation { get; set; } = null!;
    }
}
