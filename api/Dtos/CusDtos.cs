using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CusDtos
    {
        public int Id {get; set;}
        public string FirstName {get; set;} = String.Empty;
        public string LastName {get; set;} = String.Empty;
        public string email {get; set;} = String.Empty;
        public string PhoneNo {get; set;} = String.Empty;

    }
}