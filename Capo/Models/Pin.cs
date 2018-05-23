using System.ComponentModel.DataAnnotations;

namespace Capo.Models
{
    public class Pin
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public string Description { get; set; }

        public string ApplicationUserId { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
    }
}