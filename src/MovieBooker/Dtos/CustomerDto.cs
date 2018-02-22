using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //to get just the membershiptype Id from the membership class/table then we do this below
        public byte MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}