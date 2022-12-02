using People_Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People_Data.HTTP
{
    public class PeopleModel
    {
        [Key,Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MinLength(2)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Range(18,60,ErrorMessage ="Invalid Input!!")]
        public int Age { get; set; }

        public static implicit operator PeopleModel?(People? v)
        {
            throw new NotImplementedException();
        }
    }
}
