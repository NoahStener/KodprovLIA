using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace NoahStener_KodprovLIA.Models.Entities
{
    public class CarIssue
    {
        [Key]
        public int CarIssueID { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime IssueReported { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
