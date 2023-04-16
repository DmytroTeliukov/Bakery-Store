using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace BakeryStore.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

    }
}
