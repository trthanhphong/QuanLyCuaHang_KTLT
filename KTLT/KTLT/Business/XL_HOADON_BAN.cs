using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTLT
{
       public class XL_HOADON_BAN
    {
        
        public static List<HOADON> ReadHOADON(string keyWord )
        {
            return DAL.LT_HOADON_BAN.ReadHOADON(keyWord);
        }
        public static HOADON Search(string keyword)
        {
            List<HOADON> lst = DAL.LT_HOADON_BAN.ReadHOADON("");
            
            foreach (var item in lst)
            {
                if (item.CodeId==keyword|| item.Name.ToLower().Contains(keyword.ToLower()))
                {
                    return item;
                }
            }
            return new HOADON();

        }
        public static HOADON GetbyCodeId(List<HOADON> ListHH, string keyword)
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
            List<HOADON> lst = DAL.LT_HOADON_BAN.ReadHOADON("");

            
            return GetByID(lst,keyword);

        }
        public static List<HOADON> GetbySoHD(string keyword)
        {
            List<HOADON> lst = DAL.LT_HOADON_BAN.ReadHOADON("");
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
            List<HOADON> lst =DAL.LT_HOADON_BAN.ReadHOADON("");
            int maxId = 0;
            foreach (var item in lst)
            {
                if (maxId < item.Id)
                {
                    maxId = item.Id;
                }
                if (prod.CodeId == item.CodeId && prod.masoHD==item.masoHD)
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
            kq = DAL.LT_HOADON_BAN.WriteHOADON(lst);
            return kq;
        }
        public static bool UpdateProduct(HOADON prod)
        {
            bool kq = false;
            List<HOADON> lst = DAL.LT_HOADON_BAN.ReadHOADON("");
            foreach (var item in lst)
            {
                if (prod.Id == item.Id)
                {
                    lst.Remove(item);
                    lst.Add(prod);
                    break;
                }
            }

            kq = DAL.LT_HOADON_BAN.WriteHOADON(lst);
            return kq;
        }
        public static bool Delete(string sohd)
        {
            bool kq = false;
            List<HOADON> lst = DAL.LT_HOADON_BAN.ReadHOADON("");
            List<HOADON> lstNew = new List<HOADON>();
            foreach (var item in lst)
            {
                if (item.masoHD!= sohd)
                {
                    lstNew.Add(item);
                } 
            }
           
           kq= DAL.LT_HOADON_BAN.WriteHOADON(lstNew);
            return kq;
        }
        public static bool DeleteProduct(int ProdId)
        {
            bool kq = false;
            List<HOADON> lst = DAL.LT_HOADON_BAN.ReadHOADON("");
          
            foreach (var item in lst)
            {
                if (item.Id == ProdId)
                {
                   
                    lst.Remove(item);
                    break;
                }
            }

            kq = DAL.LT_HOADON_BAN.WriteHOADON(lst);
            return kq;
        }
    }
}