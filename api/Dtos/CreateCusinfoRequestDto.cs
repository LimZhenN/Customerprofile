using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CreateCusinfoRequestDto
    {
        public string FirstName {get; set;} = String.Empty;
        public string LastName {get; set;} = String.Empty;
        public string email {get; set;} = String.Empty;
        public string PhoneNo {get; set;} = String.Empty;
    }
}