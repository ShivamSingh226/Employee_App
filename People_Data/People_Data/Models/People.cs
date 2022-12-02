using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People_Data.Models
{
    [Table("People")]
    public class People
    {

        [Key,Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MinLength(2)]
        public string? FirstName { get; set; }


        [Required]
        public string? LastName { get; set; }

        
        [Range(18,60,ErrorMessage ="Invalid Input!")]
        [Required] 
        public int Age { get; set; }
    }
}
