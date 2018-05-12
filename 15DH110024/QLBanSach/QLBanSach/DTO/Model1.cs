namespace QLBanSach.DTO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CHUDE> CHUDEs { get; set; }
        public virtual DbSet<CTDATHANG> CTDATHANGs { get; set; }
        public virtual DbSet<CTTHAMDO> CTTHAMDOes { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<QUANGCAO> QUANGCAOs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<THAMDO> THAMDOes { get; set; }
        public virtual DbSet<VIETSACH> VIETSACHes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.PassAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<CTDATHANG>()
                .Property(e => e.Dongia)
                .HasPrecision(9, 2);

            modelBuilder.Entity<CTDATHANG>()
                .Property(e => e.Thanhtien)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.Trigia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.Tennguoinhan)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.Dienthoainhan)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CTDATHANGs)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienthoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.Hinhminhhoa)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.Href)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.Dongia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SACH>()
                .Property(e => e.Hinhminhhoa)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CTDATHANGs)
                .WithRequired(e => e.SACH)
                .HasForeignKey(e => e.SoDH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.VIETSACHes)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.DienthoaiTG)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.VIETSACHes)
                .WithRequired(e => e.TACGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THAMDO>()
                .HasMany(e => e.CTTHAMDOes)
                .WithRequired(e => e.THAMDO)
                .WillCascadeOnDelete(false);
        }
    }
}
