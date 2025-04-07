using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models // Adjust this namespace to match your project
{
    public class Library
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(200)]
        public string Address { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
