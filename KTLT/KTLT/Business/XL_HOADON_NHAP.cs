using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTLT
{
    public  struct HOADON
    {
        public int Id;         
        public string CodeId;   
        public string Name;     
   
        public int Soluong;     
        public int Dongia;    
        public int Tien;  
       
        public string LoaiHD; 
        public string Ngay; 
        public string masoHD;


    }
    public class XL_HOADON_NHAP
    {
        
        public static List<HOADON> ReadHOADON(string keyWord )
        {
            return DAL.LT_HOADON_NHAP.ReadHOADON(keyWord);
        }
        public static HOADON Search(string keyword)
        {
            List<HOADON> lst = DAL.LT_HOADON_NHAP.ReadHOADON("");
            
            foreach (var item in lst)
            {
                if (item.CodeId==keyword|| item.Name.ToLower().Contains(keyword.ToLower()))
                {
                    return item;
                }
            }
            return new HOADON();

        }
        public static HOADON GetByCodeID(List<HOADON> ListHH, string keyword)
        {
            foreach (var item in ListHH)
            {
                if (item.CodeId == keyword)
                {
                    return item;
                }
            }
            return new HOADON();
        }
        public static HOADON GetByID(List<HOADON> lstData ,int keyword)
        {

            foreach (var item in lstData)
            {
                if (item.Id == keyword)
                {
                    return item;
                }
            }
            return new HOADON();

        }
        public static HOADON GetByID(int keyword)
        {
            List<HOADON> lst = DAL.LT_HOADON_NHAP.ReadHOADON("");
           
            return GetByID(lst,keyword);

        }
        public static List<HOADON> GetBySoHD(string keyword)
        {
            List<HOADON> lst = DAL.LT_HOADON_NHAP.ReadHOADON("");
            List<HOADON> kq = new List<HOADON>();
            foreach (var item in lst)
            {
                if (item.masoHD == keyword)
                {
                    kq.Add(item);
                }
            }
            return kq;

        }
        public static bool AddProduct(HOADON prod)
        {
            bool kq = false;
            List<HOADON> lst =DAL.LT_HOADON_NHAP.ReadHOADON("");
            int maxId = 0;
            foreach (var item in lst)
            {
                if (maxId < item.Id)
                {
                    maxId = item.Id;
                }
                if (prod.CodeId == item.CodeId && prod.masoHD == item.masoHD)
                {
                    prod.Id= item.Id;
                    break;
                }
            }

            if (prod.Id > 0)
            {
                return kq;
            }
            prod.Id = maxId + 1;
            lst.Add(prod);
            kq = DAL.LT_HOADON_NHAP.WriteHOADON(lst);
            return kq;
        }
        public static bool UpdateProduct(HOADON prod)
        {
            bool kq = false;
            List<HOADON> lst = DAL.LT_HOADON_NHAP.ReadHOADON("");
            foreach (var item in lst)
            {
                if (prod.Id == item.Id)
                {
                    
                    lst.Remove(item);
                    lst.Add(prod);
                    break;
                }
            }

            kq = DAL.LT_HOADON_NHAP.WriteHOADON(lst);
            return kq;
        }
        public static bool DeleteProduct(int ProdId)
        {
            bool kq = false;
            List<HOADON> lst = DAL.LT_HOADON_NHAP.ReadHOADON("");
           
            foreach (var item in lst)
            {
                if (item.Id== ProdId)
                {

                    lst.Remove(item);
                    break;
                }
            }
           
            kq = DAL.LT_HOADON_NHAP.WriteHOADON(lst);
            return kq;
        }
        public static bool Delete(string Sohoadon)
        {
            bool kq = false;
            List<HOADON> lst = DAL.LT_HOADON_NHAP.ReadHOADON("");
            List<HOADON> lstNew = new List<HOADON>();
            foreach (var item in lst)
            {
                if (item.masoHD != Sohoadon)
                {
                    lstNew.Add (item);
                }
            }

           kq =  DAL.LT_HOADON_NHAP.WriteHOADON(lstNew);
            return kq;
        }
    }
}