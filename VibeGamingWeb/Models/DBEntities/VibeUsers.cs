using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeUsers
    {
        // Constructor of the VibeUsers class
        public VibeUsers()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Password = "";
        }
        // Members of the VibeUsers class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
