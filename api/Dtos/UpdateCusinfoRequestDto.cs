using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    // This DTO (Data Transfer Object) is used for updating an existing customer
    // It doesn't include the Id as it's typically passed in the URL for PUT requests
    public class UpdateCusinfoRequestDto
    {
        public string FirstName {get; set;} = String.Empty;
        public string LastName {get; set;} = String.Empty;
        public string email {get; set;} = String.Empty;
        public string PhoneNo {get; set;} = String.Empty;
    }
}