using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeTrailer
    {
        // Constructor of the VibeTrailer class
        public VibeTrailer()
        {
             TraImgPath = "";
             TraLink = "";
        }
        // Members of the VibeTrailer class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTra { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string TraImgPath { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string TraLink { get; set; }
        [ForeignKey("VibeGames")]
        [DisplayName("VibeGames")]
        public int IdGame { get; set; }
        public virtual VibeGames? VibeGames { get; set; }

        [ForeignKey("VibeGall")]
        [DisplayName("VibeGall")]
        public int? IdGall { get; set; }
        public virtual VibeGall? VibeGall { get; set; }
    }
}
