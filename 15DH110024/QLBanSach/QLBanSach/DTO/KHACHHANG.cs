namespace QLBanSach.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONDATHANGs = new HashSet<DONDATHANG>();
        }

        [Key]
        public int MaKH { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTenKH { get; set; }

        [StringLength(50)]
        public string DiachiKH { get; set; }

        [StringLength(10)]
        public string DienthoaiKH { get; set; }

        [StringLength(15)]
        public string TenDN { get; set; }

        [Required]
        [StringLength(15)]
        public string Matkhau { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngaysinh { get; set; }

        public bool? Gioitinh { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool? Daduyet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANGs { get; set; }

        public KHACHHANG(DataRow row)
        {
            MaKH = (int)row["MaKH"];
            HoTenKH = (string)row["HoTenKH"];
            DiachiKH = (string)row["DiachiKH"];
            DienthoaiKH = (string)row["DienthoaiKH"];
            TenDN = (string)row["TenDN"];
            Matkhau = (string)row["Matkhau"];
            Ngaysinh = (DateTime)row["Ngaysinh"];
            Gioitinh = (bool)row["Gioitinh"];
            Email = (string)row["Email"];
            Daduyet = (bool)row["Daduyet"];
        }
    }
}
