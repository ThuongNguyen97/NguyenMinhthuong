namespace QLBanSach.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("CTDATHANG")]
    public partial class CTDATHANG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Masach { get; set; }

        public int? Soluong { get; set; }

        public decimal? Dongia { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Thanhtien { get; set; }

        public virtual DONDATHANG DONDATHANG { get; set; }

        public virtual SACH SACH { get; set; }
        public CTDATHANG() { }
        public CTDATHANG(DataRow row)
        {
            SoDH = (int)row["SoDH"];
            Masach = (int)row["Masach"];
            Soluong = (int)row["Soluong"];
            Dongia = (decimal)row["Dongia"];
            Thanhtien = (decimal)row["Thanhtien"];
        }
    }
}
