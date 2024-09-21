using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTLT
{
    public struct THONGKE
    { 
      
        public string CodeId;   // Mã hàng
        public string Name;     // Tên hàng
        
        public int Dongia;      // Đơn giá nhập
        public int SoluongNhap;      // Số lượng
        public int SoluongBan;      // Số lượng
        public int Soluong;      // Số lượng tồn
        public int TienNhap;      // Tiền hàng
        public int TienBan;      // Tiền hàng

        public string Expire; // hạn sử dụng dd/MM/yyyy
        public int NamSX;        // Năm sản xuất
        public string Cty;      // Công ty sản xuất
        public string CateName;      // Tên loại hàng
        public double CateId;      // Loại hàng
        

    }
    public class XL_THONGKE
    {
        public static List<HOADON> ReadHANG_NHAP(string keyWord)
        {
            return DAL.LT_HOADON_NHAP.ReadHOADON(keyWord);
        }
        public static List<HOADON> ReadHANG_BAN(string keyWord)
        {
            return DAL.LT_HOADON_BAN.ReadHOADON(keyWord);
        }
        public static List<THONGKE> NHAP_XUAT()
        {
            List<HOADON> lstNhap = ReadHANG_NHAP("");
            List<HOADON> lstBan = ReadHANG_BAN("");
            List<PRODUCT> prodList = XL_PRODUCT.ReadProduct("");
            List<THONGKE> kq = new List<THONGKE>();
            List<CATEGORY> lstCate = XL_CATEGORY.ReadALlCategory("");
            THONGKE tonkho;
            foreach (PRODUCT prod in prodList)
            {
                tonkho = new THONGKE();
                tonkho.CodeId = prod.CodeId;
                tonkho.Name = prod.Name;
                tonkho.CateId = prod.CateId;
                tonkho.NamSX = prod.NamSX;
                tonkho.Cty = prod.Cty;
                tonkho.Expire = prod.Expire;
                

                foreach (HOADON hNhap in lstNhap)
                {
                    if (prod.CodeId == hNhap.CodeId)
                    {
                        tonkho.SoluongNhap += hNhap.Soluong;
                        tonkho.TienNhap += hNhap.Tien;
                        tonkho.Dongia = hNhap.Dongia;
                    }
                }
                foreach (HOADON hBan in lstBan)
                {
                    if (prod.CodeId == hBan.CodeId)
                    {
                        tonkho.SoluongBan += hBan.Soluong;
                        tonkho.TienBan += hBan.Tien;

                    }
                }
                foreach (CATEGORY item in lstCate)
                {
                    if (tonkho.CateId==item.CateId)
                    {
                        tonkho.CateName = item.CateName;
                        break;
                    }
                }
                tonkho.Soluong = tonkho.SoluongNhap - tonkho.SoluongBan;
                kq.Add(tonkho);
            }
            return kq;
        }

        public static List<THONGKE> TONKHO()
        {

            List<THONGKE> tk = NHAP_XUAT();
            List<THONGKE> kq = new List<THONGKE>();
            
            foreach (THONGKE tonkho in tk)
            {
                if (tonkho.Soluong>0)
                {
                    kq.Add(tonkho);
                }
            }
           
            SAPXEP_THELOAI(ref kq);
            return kq;
        }

        public static List<THONGKE> HANG_HETHAN(DateTime date)
        {
            List<THONGKE> lst = TONKHO();
            List<THONGKE> kq = new List<THONGKE>();
            foreach (THONGKE tonkho in lst)
            {
                if (string.IsNullOrEmpty(tonkho.Expire))
                {
                    continue;
                }
                if (DateTime.ParseExact(tonkho.Expire,DAL.Common.dateFormat2, DAL.Common.provider)< date)
                {
                    kq.Add(tonkho);
                }
            }
            return kq;

        }
        public static void SAPXEP_THELOAI(ref List<THONGKE> dataList)
        {
            THONGKE temp;
            for (int i=0;i<dataList.Count-1;i++)
            {
                for (int j = i+1; j < dataList.Count; j++)
                {
                    if (dataList[i].CateId > dataList[j].CateId)
                    {
                        temp = dataList[i];
                        dataList[i] = dataList[j];
                        dataList[j] = temp;
                    }
                }
               
            }
        }
        public static void SAPXEP_THELOAI(ref List<HOADON> dataList)
        {
            HOADON temp;
            for (int i = 0; i < dataList.Count - 1; i++)
            {
                for (int j = i + 1; j < dataList.Count; j++)
                {
                    if (dataList[i].Id > dataList[j].Id)
                    {
                        temp = dataList[i];
                        dataList[i] = dataList[j];
                        dataList[j] = temp;
                    }
                }

            }
        }
    }
}