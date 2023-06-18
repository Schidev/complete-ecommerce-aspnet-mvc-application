using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMoviewVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Movie Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Movie poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Movie start Date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie end Date")]
        [Required(ErrorMessage = "Name is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select category")]
        [Required(ErrorMessage = "Movie category is required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select cinema(s)")]
        [Required(ErrorMessage = "Movie cinema(s) is required")]
        public int CinemaId { get; set; }

        [Display(Name = "Select producer(s)")]
        [Required(ErrorMessage = "Movie producer(s) is required")]
        public int ProducerId { get; set; }

    }
}
