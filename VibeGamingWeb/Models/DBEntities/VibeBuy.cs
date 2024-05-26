using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeBuy
    {
        // Constructor of the VibeBuy class
        public VibeBuy()
        {
            BuyWallImgPath = "";
            BuyName = "";
            BuyPlatImgPath = "";
            BuyGameEdition = "";
            BuyStockGame = "";
            BuyAgeRestrict = "";
        }
        // Members of the VibeBuy class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBuy { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string BuyWallImgPath { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string BuyName { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string BuyPlatImgPath { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string BuyGameEdition { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string BuyStockGame { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string BuyAgeRestrict { get; set; }
        public float BuyPrice { get; set; }
        [ForeignKey("VibeGames")]
        [DisplayName("VibeGames")]
        public int IdGame { get; set; }
        public virtual VibeGames? VibeGames { get; set; }

        [ForeignKey("VibeSpec")]
        [DisplayName("VibeSpec")]
        public int? IdSpec { get; set; }
        public virtual VibeSpec? VibeSpec { get; set; }

        [ForeignKey("VibeUsers")]
        [DisplayName("VibeUsers")]
        public int? IdUser { get; set; }
        public virtual VibeUsers? VibeUsers { get; set; }

        [ForeignKey("VibeCart")]
        [DisplayName("VibeCart")]
        public int? IdCart { get; set; }
        public virtual VibeCart? VibeCart { get; set; }
    }
}
