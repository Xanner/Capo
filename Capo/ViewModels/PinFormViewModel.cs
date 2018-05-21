using System.ComponentModel.DataAnnotations;

namespace Capo.ViewModels
{
    public class PinFormViewModel
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

        public PinFormViewModel()
        {
            Id = 0;
        }
    }
}