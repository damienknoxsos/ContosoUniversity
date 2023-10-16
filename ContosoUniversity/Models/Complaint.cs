using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{    
    public class Complaint
    {
        public int ID { get; set; }
        [StringLength(1000, MinimumLength = 20)]
        public string Details { get; set; }
        public int StudentID { get; set; }            
        public Student Student { get; set; }
    }
}