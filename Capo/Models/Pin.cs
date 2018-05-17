namespace Capo.Models
{
    public class Pin
    {
        public int Id { get; set; }
        public string PinType { get; set; }
        public string Description { get; set; }
        public Place Place { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
    }
}