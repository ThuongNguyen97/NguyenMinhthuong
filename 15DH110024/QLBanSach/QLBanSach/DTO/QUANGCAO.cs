namespace QLBanSach.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANGCAO")]
    public partial class QUANGCAO
    {
        [Key]
        public int STT { get; set; }

        [Required]
        [StringLength(200)]
        public string TenCty { get; set; }

        [StringLength(20)]
        public string Hinhminhhoa { get; set; }

        [StringLength(100)]
        public string Href { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngaybatdau { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngayhethan { get; set; }


    }
}
