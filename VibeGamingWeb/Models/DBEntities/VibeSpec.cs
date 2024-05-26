using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibeGamingWeb.Models.DBEntities
{
    public class VibeSpec
    {
        // Constructor of the VibeSpec class
        public VibeSpec()
        {
            SpecOSMin = "";
            SpecProcMin = "";
            SpecMemMin = "";
            SpecGrapMin = "";
            SpecStorMin = "";

            SpecOSMax = "";
            SpecProcMax = "";
            SpecMemMax = "";
            SpecGrapMax = "";
            SpecStorMax = "";
        }
        // Members of the VibeSpec class representing the attributes of the class (defined for the database)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSpec { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecOSMin { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecProcMin { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecMemMin { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecGrapMin { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecStorMin { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecOSMax { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecProcMax { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecMemMax { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecGrapMax { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? SpecStorMax { get; set; }
        [ForeignKey("VibeGames")]
        [DisplayName("VibeGames")]
        public int IdGame { get; set; }
        public virtual VibeGames? VibeGames { get; set; }

        [ForeignKey("VibeTrailer")]
        [DisplayName("VibeTrailer")]
        public int? IdTra { get; set; }
        public virtual VibeTrailer? VibeTrailer { get; set; }
    }
}
