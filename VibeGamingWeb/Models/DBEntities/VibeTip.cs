using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeTip
    {
        // Constructor of the VibeTip class
        public VibeTip()
        {
            TipGame1 = "";
            TipGame2 = "";
            TipGame3 = "";
            TipGame4 = "";
            TipBannPath = "";
            TipAboutGame = "";
            TipTextGame = "";
        }
        // Members of the VibeTip class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTip { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TipGame1 { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TipGame2 { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TipGame3 { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TipGame4 { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string TipBannPath { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TipAboutGame { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string TipTextGame { get; set; }
        [ForeignKey("VibeGames")]
        [DisplayName("VibeGames")]
        public int IdGame { get; set; }
        public virtual VibeGames? VibeGames { get; set; }

        [ForeignKey("VibeCate")]
        [DisplayName("VibeCate")]
        public int? IdCate { get; set; }
        public virtual VibeCate? VibeCate { get; set; }
    }

}
