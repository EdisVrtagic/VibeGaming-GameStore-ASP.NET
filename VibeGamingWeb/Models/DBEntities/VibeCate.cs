using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeCate
    {
        // Constructor of the VibeCate class
        public VibeCate()
        {
            CateOfOn = "";
            CateDigKey = "";
            CateGameSupp = "";
            CatePlayer = "";
            CateDev = "";
            CateRevNum = "";
        }
        // Members of the VibeCate class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCate { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CateOfOn { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CateDigKey { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CateGameSupp { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CatePlayer { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CateDev { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CateRevNum { get; set; }
        [ForeignKey("VibeGames")]
        [DisplayName("VibeGames")]
        public int IdGame { get; set; }
        public virtual VibeGames? VibeGames { get; set; }
        [ForeignKey("VibeBuy")]
        [DisplayName("VibeBuy")]
        public int? IdBuy { get; set; }
        public virtual VibeBuy? VibeBuy { get; set; }
    }
}
