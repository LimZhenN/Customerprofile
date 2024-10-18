using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    // This DTO (Data Transfer Object) represents the customer information
    // It's used for sending data between the client and the server
    public class CusDtos
    {
        public int Id {get; set;}
        public string FirstName {get; set;} = String.Empty;
        public string LastName {get; set;} = String.Empty;
        public string email {get; set;} = String.Empty;
        public string PhoneNo {get; set;} = String.Empty;

    }
}