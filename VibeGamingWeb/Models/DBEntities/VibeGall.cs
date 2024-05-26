using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeGall
    {
        // Constructor of the VibeGall class
        public VibeGall()
        {
            GallImgPath = "";
            GallImgTitle = "";
            GallImgDesc = "";
        }
        // Members of the VibeGall class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGall { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string GallImgPath { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string GallImgTitle { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string GallImgDesc { get; set; }
        [ForeignKey("VibeGames")]
        [DisplayName("VibeGames")]
        public int IdGame { get; set; }
        public virtual VibeGames? VibeGames { get; set; }

        [ForeignKey("VibeTip")]
        [DisplayName("VibeTip")]
        public int? IdTip { get; set; }
        public virtual VibeTip? VibeTip { get; set; }
    }
}
