using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models;

public class LoginResult
{
    public bool Success { get; set; }
    public string? Token { get; set; } // eller annan data
    public string? Error { get; set; }
}