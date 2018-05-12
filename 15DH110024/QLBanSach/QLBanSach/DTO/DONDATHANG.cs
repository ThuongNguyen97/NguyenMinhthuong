namespace QLBanSach.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CTDATHANGs = new HashSet<CTDATHANG>();
        }

        [Key]
        public int SoDH { get; set; }

        public int? MaKH { get; set; }

        public DateTime? NgayDH { get; set; }

        [Column(TypeName = "money")]
        public decimal? Trigia { get; set; }

        public bool? Dagiao { get; set; }

        public DateTime? Ngaygiaohang { get; set; }

        [StringLength(50)]
        public string Tennguoinhan { get; set; }

        [StringLength(1)]
        public string Diachinhan { get; set; }

        [StringLength(15)]
        public string Dienthoainhan { get; set; }

        public bool? HTThanhtoan { get; set; }

        public bool? HTGiaohang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDATHANG> CTDATHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
        public DONDATHANG(DataRow row)
        {
            SoDH = (int)row["SoDH"];
            MaKH = (int)row["MaKH"];
            NgayDH = (DateTime)row["NgayDH"];
            Trigia = (decimal)row["Trigia"];
            Dagiao = (bool)row["Dagiao"];
            Ngaygiaohang = (DateTime)row["Ngaygiaohang"];
            Tennguoinhan = (string)row["Tennguoinhan"];
            Diachinhan = (string)row["Diachinhan"];
            Dienthoainhan = (string)row["Dienthoainhan"];
            HTThanhtoan = (bool)row["HTThanhtoan"];
            HTGiaohang = (bool)row["HTGiaohang"];
        }
    }
}
