using System;
using System.ComponentModel.DataAnnotations;

namespace NoahStener_KodprovLIA.Models
{
    public class CarIssueViewModel
    {
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime IssueReported {  get; set; }

        [Required]
        public string RegNumber { get; set; }

        [Required]
        public string Model { get; set; }
    }
}
