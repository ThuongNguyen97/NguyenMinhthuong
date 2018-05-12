namespace QLBanSach.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CTDATHANGs = new HashSet<CTDATHANG>();
            VIETSACHes = new HashSet<VIETSACH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Masach { get; set; }

        [Required]
        [StringLength(100)]
        public string Tensach { get; set; }

        [StringLength(50)]
        public string Donvitinh { get; set; }

        [Column(TypeName = "money")]
        public decimal? Dongia { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [StringLength(50)]
        public string Hinhminhhoa { get; set; }

        public int? MaCD { get; set; }

        public int? MaNXB { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngaycapnhat { get; set; }

        public int? Soluongban { get; set; }

        public int? solanxem { get; set; }

        public int? moi { get; set; }

        public virtual CHUDE CHUDE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDATHANG> CTDATHANGs { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIETSACH> VIETSACHes { get; set; }

        public SACH(DataRow row)
        {
            Masach = (int)row["Masach"];
            Tensach = (string)row["Tensach"];
            Donvitinh = (string)row["Donvitinh"];
            Dongia = (decimal)row["Dongia"];
            Mota = (string)row["Mota"];
            Hinhminhhoa = (string)row["Hinhminhhoa"];
            MaCD = (int)row["MaCD"];
            MaNXB = (int)row["Manxb"];
            Ngaycapnhat = (DateTime)row["Ngaycapnhat"];
            Soluongban = (int)row["Soluongban"];
            solanxem = (int)row["Solanxem"];
            moi = (int)row["Moi"];
        }

    }
}
