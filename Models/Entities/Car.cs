using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoahStener_KodprovLIA.Models.Entities
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        [Required]
        [StringLength(10)]
        public string RegNumber { get; set; }
        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        public ICollection<CarIssue> CarIssues { get; set; }

    }
}
