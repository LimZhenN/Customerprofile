using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    // This class represents the Customer Information model
    // It defines the structure of the customer data in the database
    public class CusInfo
    {
        // Unique identifier for each customer
        public int Id {get; set;}
        public string FirstName {get; set;} = String.Empty;
        public string LastName {get; set;} = String.Empty;
        public string email {get; set;} = String.Empty;
        public string PhoneNo {get; set;} = String.Empty;
    }
}