using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeGames
    {
        // Constructor of the VibeGames class
        public VibeGames() 
        {
            GameName = "";
            GameImgPath = "";
            GamePlatform = "";
        }
        // Members of the VibeGames class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGame { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string GameName { get; set; }
        public float GamePrice { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string GameImgPath { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string GamePlatform { get; set; }
    }
}
