namespace QLBanSach.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("CTTHAMDO")]
    public partial class CTTHAMDO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STT { get; set; }

        [Required]
        [StringLength(255)]
        public string Noidungtraloi { get; set; }

        public int? Solanbinhchon { get; set; }

        public virtual THAMDO THAMDO { get; set; }
        public CTTHAMDO(DataRow row)
        {
            MaCH = (int)row["MaCH"];
            STT = (int)row["STT"];
            Noidungtraloi = (string)row["Noidungtraloi"];
            Solanbinhchon = (int)row["Solanbinhchon"];
        }
    }
}
