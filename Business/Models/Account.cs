using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Account
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
