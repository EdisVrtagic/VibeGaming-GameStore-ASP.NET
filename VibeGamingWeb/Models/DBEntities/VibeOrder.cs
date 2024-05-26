using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeOrder
    {
        // Constructor of the VibeOrder class
        public VibeOrder()
        {
            OrdImgPath = "";
            OrdGameName = "";
            OrdFirstName = "";
            OrdLastName = "";
            OrdAddress = "";
            OrdPhoneNum = "";
        }

        // Members of the VibeOrder class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrd { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string OrdFirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string OrdLastName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string OrdAddress { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string OrdPhoneNum { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string OrdImgPath { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string OrdGameName { get; set; }

        public int OrdGameQty { get; set; }

        public float OrdGamePrice { get; set; }

        [ForeignKey("VibeUsers")]
        [DisplayName("VibeUsers")]
        public int IdUser { get; set; }
        public virtual VibeUsers? VibeUsers { get; set; }

        [ForeignKey("VibeGames")]
        [DisplayName("VibeGames")]
        public int IdGame { get; set; }
        public virtual VibeGames? VibeGames { get; set; }

        public float OrdTotalNum { get; set; }
    }
}
