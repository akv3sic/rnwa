using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class User
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
