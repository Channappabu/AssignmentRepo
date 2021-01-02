using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
   public class UserDetails
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public DateTime? DateOfBirth { get; set; }
       public string Designation { get; set; }
       public string Skills { get; set; }
    }
}
