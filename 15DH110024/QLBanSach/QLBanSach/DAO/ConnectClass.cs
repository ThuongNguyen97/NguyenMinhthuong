using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DAO;
using QLBanSach.DTO;

namespace QLBanSach.DAO
{
    class ThuVien
    {
        public List<SACH> LoadSach(int count = 0)
        {
            List<SACH> result = new List<SACH>();
            DataTable data = count == 0 ? DataProvider.Instance.ExcuteQuery("Select * from dbo.SACH") : DataProvider.Instance.ExcuteQuery("select top " + count + " * from dbo.SACH order by ngaycapnhat asc");
            foreach (DataRow row in data.Rows)
            {
                SACH temp = new SACH(row);
                result.Add(temp);
            }
            return result;
        }
        public SACH getSach(int id)
        {
            return new SACH(DataProvider.Instance.ExcuteQuery("select * from dbo.SACH where maSach = " + id).Rows[0]);
        }
        public List<CHUDE> LoadChuDe()
        {
            List<CHUDE> result = new List<CHUDE>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.CHUDE");
            foreach (DataRow row in data.Rows)
            {
                CHUDE temp = new CHUDE(row);
                result.Add(temp);
            }
            return result;
        }
        public List<CTDATHANG> LoadCTDatHang()
        {
            List<CTDATHANG> result = new List<CTDATHANG>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.CTDATHANG");
            foreach (DataRow row in data.Rows)
            {
                CTDATHANG temp = new CTDATHANG(row);
                result.Add(temp);
            }
            return result;
        }
        public List<CTTHAMDO> LoadCTTHAMDO()
        {
            List<CTTHAMDO> result = new List<CTTHAMDO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.CTTHAMDO");
            foreach (DataRow row in data.Rows)
            {
                CTTHAMDO temp = new CTTHAMDO(row);
                result.Add(temp);
            }
            return result;
        }
        public List<DONDATHANG> LoadDONDATHANG()
        {
            List<DONDATHANG> result = new List<DONDATHANG>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.DONDATHANG");
            foreach (DataRow row in data.Rows)
            {
                DONDATHANG temp = new DONDATHANG(row);
                result.Add(temp);
            }
            return result;
        }
        public List<KHACHHANG> LoadKHACHHANG()
        {
            List<KHACHHANG> result = new List<KHACHHANG>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.KHACHHANG");
            foreach (DataRow row in data.Rows)
            {
                KHACHHANG temp = new KHACHHANG(row);
                result.Add(temp);
            }
            return result;
        }
        public List<NHAXUATBAN> LoadNHAXUATBAN()
        {
            List<NHAXUATBAN> result = new List<NHAXUATBAN>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.NHAXUATBAN");
            foreach (DataRow row in data.Rows)
            {
                NHAXUATBAN temp = new NHAXUATBAN(row);
                result.Add(temp);
            }
            return result;
        }
        public List<TACGIA> LoadTACGIA()
        {
            List<TACGIA> result = new List<TACGIA>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.TACGIA");
            foreach (DataRow row in data.Rows)
            {
                TACGIA temp = new TACGIA(row);
                result.Add(temp);
            }
            return result;
        }
        public List<VIETSACH> LoadVIETSACH()
        {
            List<VIETSACH> result = new List<VIETSACH>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.VIETSACH");
            foreach (DataRow row in data.Rows)
            {
                VIETSACH temp = new VIETSACH(row);
                result.Add(temp);
            }
            return result;
        }
    }
    namespace _Sach
    {
        public class ConnectClass
        {
            public List<SACH> LoadSachCD(int idcd = 0)
            {
                List<SACH> result = new List<SACH>();

                DataTable data = idcd == 0 ? DataProvider.Instance.ExcuteQuery("select * from dbo.SACH order by macd asc") : DataProvider.Instance.ExcuteQuery("select * from dbo.SACH where macd =" + idcd);
                foreach (DataRow row in data.Rows)
                {
                    SACH temp = new SACH(row);
                    result.Add(temp);
                }
                return result;
            }
            public List<SACH> LoadSachNXB(int idNXB=0)
            {
                List<SACH> result = new List<SACH>();
                DataTable data = idNXB == 0 ? DataProvider.Instance.ExcuteQuery("select * from dbo.SACH order by MaNXB asc") : DataProvider.Instance.ExcuteQuery("select * from dbo.SACH where MaNXB =" + idNXB);
                foreach (DataRow row in data.Rows)
                {
                    SACH temp = new SACH(row);
                    result.Add(temp);
                }
                return result;
            }
            public bool Create(SACH sach)
            {
                return DataProvider.Instance.ExcuteNonQuery("pInsertSach @tenSach , @dongia , @mota , @hinhminhhoa , @macd , @maNXB , @Soluongban , @soLanxem",new object[] { sach.Tensach, sach.Dongia, sach.Mota, sach.Hinhminhhoa, sach.MaCD, sach.MaNXB, sach.Soluongban, sach.solanxem }) > 0;
            }
            public bool Edit(SACH sach)
            {
                return DataProvider.Instance.ExcuteNonQuery("pEditSach @id , @tenSach , @dongia , @mota , @hinhminhhoa , @macd , @maNXB , @Soluongban , @soLanxem", new object[] {sach.Masach, sach.Tensach, sach.Dongia, sach.Mota, sach.Hinhminhhoa, sach.MaCD, sach.MaNXB, sach.Soluongban, sach.solanxem })>0;
            }
            public bool Delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("pDeleteSach @id", new object[] { id }) > 0;
            }
        }
    }
    namespace _Admin
    {
        public class ConnectClass
        {
            public Admin GetAdmin(Admin admin)
            {
                return new Admin(DataProvider.Instance.ExcuteQuery("pLogin @username , @pass ", new object[] { admin.UserAdmin,admin.PassAdmin}).Rows[0]);
            }
        }
    }
    namespace _DonDatHang
    {
        public class ConnectClass
        {
            public bool Create(DONDATHANG ddh)
            {
                return DataProvider.Instance.ExcuteNonQuery("pInsertDonDatHang @MaKH , @triGia , @ngayGiaoHang , @tennguoinhan , @diaChiNhan , @DienThoaiNhan , @HTThanhtoan , @HTGiaoHang ", new object[] { ddh.MaKH, ddh.Trigia, ddh.Ngaygiaohang, ddh.Tennguoinhan, ddh.Diachinhan, ddh.Dienthoainhan, ddh.HTThanhtoan, ddh.HTGiaohang }) > 0;
            }
            public bool ChiTietDatHang (CTDATHANG ctdh)
            {
                return DataProvider.Instance.ExcuteNonQuery("pInsertChiTietDonHang @SoDH , @MaSach , @SoLuong , @donGia ", new object[] { ctdh.SoDH, ctdh.Masach, ctdh.Soluong, ctdh.Dongia }) > 0;
            }
        }
        
    }
    namespace _NguoiDung
    {
        public class ConnectClass
        {
            public bool Create(KHACHHANG khachhang)
            {
                return DataProvider.Instance.ExcuteNonQuery( "pInsertKhachHang  @HoTenKH , @DiaChiKH , @mail , @DienThoai , @Ngaysinh , @tenDangNhap , @matkhau ", new object[] { khachhang.HoTenKH,khachhang.DiachiKH,khachhang.Email,khachhang.DienthoaiKH,khachhang.Ngaysinh,khachhang.TenDN,khachhang.Matkhau}) > 0;
            }
            public KHACHHANG GetKHACHHANG(KHACHHANG khachhang)
            {
                return new KHACHHANG(DataProvider.Instance.ExcuteQuery("pLoginKH @username , @pass ", new object[] { khachhang.TenDN, khachhang.Matkhau}).Rows[0]);
            }
        }
    }
    
}