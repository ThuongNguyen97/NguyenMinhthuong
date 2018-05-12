namespace QLBanSach.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("VIETSACH")]
    public partial class VIETSACH
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTG { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Masach { get; set; }

        [StringLength(30)]
        public string Vaitro { get; set; }

        public virtual SACH SACH { get; set; }

        public virtual TACGIA TACGIA { get; set; }
        public VIETSACH(DataRow row)
        {
            MaTG = (int)row["MaTG"];
            Masach = (int)row["Masach"];
            Vaitro = (string)row["Vaitro"];
        }
    }
}