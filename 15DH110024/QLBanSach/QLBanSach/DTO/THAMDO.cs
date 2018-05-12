namespace QLBanSach.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("THAMDO")]
    public partial class THAMDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THAMDO()
        {
            CTTHAMDOes = new HashSet<CTTHAMDO>();
        }

        [Key]
        public int MaCH { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngaydang { get; set; }

        [Required]
        [StringLength(255)]
        public string Noidungthamdo { get; set; }

        public int? Tongsobinhchon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTHAMDO> CTTHAMDOes { get; set; }
        public THAMDO(DataRow row)
        {
            MaCH = (int)row["MaCH"];
            Ngaydang = (DateTime)row["Ngaydang"];
            Noidungthamdo = (string)row["Noidungthamdo"];
            Tongsobinhchon = (int)row["Tongsobinhchon"];
        }
    }
}
