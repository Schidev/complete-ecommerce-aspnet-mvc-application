using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile picture")]
        [Required(ErrorMessage = "Profile Picture is required.")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 chars.")]
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required.")]
        public string Bio { get; set; }

        // Realationships
        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}
