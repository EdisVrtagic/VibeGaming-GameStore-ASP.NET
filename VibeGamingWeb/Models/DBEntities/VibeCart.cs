using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeCart
    {
        // Constructor of the VibeCart class
        public VibeCart()
        {
            CartEmail = "";
            CartImgPath = "";
            CartGameName = "";
        }
        // Members of the VibeCart class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCart { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CartEmail { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string CartImgPath { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CartGameName { get; set; }
        public int CartGameQty { get; set; }
        public float CartGamePrice { get; set; }
        [ForeignKey("VibeUsers")]
        [DisplayName("VibeUsers")]
        public int IdUser { get; set; }
        public virtual VibeUsers? VibeUsers { get; set; }
        [ForeignKey("VibeGames")]
        [DisplayName("VibeGames")]
        public int IdGame { get; set; }
        public virtual VibeGames? VibeGames { get; set; }
    }
}
