using System.ComponentModel.DataAnnotations;

namespace AIFormHelper.Models
{
    public class Form
    {        
        public string? Firstname { get; set; }
        
        public string? Lastname { get; set; }
        
        public string? Email { get; set; }

        public string? ReasonOfContact { get; set; }
        
        public int? Urgency { get; set; }
    }
}
