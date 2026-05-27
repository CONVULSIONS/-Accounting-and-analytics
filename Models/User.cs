using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Role { get; private set; } = string.Empty;
        public User(int primaryKey, string firstName, string lastName, string role) 
        {
            Id = primaryKey;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }
}
