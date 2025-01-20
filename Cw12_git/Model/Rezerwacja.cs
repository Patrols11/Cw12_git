using System.ComponentModel.DataAnnotations;

namespace Cw12_git.Model
{
    public class Rezerwacja
    {
        
            public int Id { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public short TimeFrom { get; set; }

        [Required]
        public short TimeTo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }

    }

