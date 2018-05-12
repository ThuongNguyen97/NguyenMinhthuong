namespace QLBanSach.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("NHAXUATBAN")]
    public partial class NHAXUATBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAXUATBAN()
        {
            SACHes = new HashSet<SACH>();
        }

        [Key]
        public int MaNXB { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNXB { get; set; }

        [StringLength(150)]
        public string Diachi { get; set; }

        [StringLength(15)]
        public string DienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }
        public NHAXUATBAN(DataRow row)
        {
            MaNXB = (int)row["MaNXB"];
            TenNXB = (string)row["TenNXB"];
            Diachi = (string)row["Diachi"];
            DienThoai = (string)row["Dienthoai"];
        }
    }
}
