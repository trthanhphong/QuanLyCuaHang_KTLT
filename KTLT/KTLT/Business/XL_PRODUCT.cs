using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTLT
{
    public class COMPANY
    {
        public int Id;
        public string Name; 
    }
    public  struct PRODUCT
    {
        public int Id;          // chỉ số
        public string CodeId;   // Mã hàng
        public string Name;     // Tên hàng
        public string Expire; // hạn sử dụng dd/MM/yyyy ->yyyy-MM-dd
        public int NamSX;        // Năm sản xuất
        public string Cty;      // Công ty sản xuất
        public int CateId;      // Loại hàng

    }
    public class XL_PRODUCT
    {
        public static List<PRODUCT> ReadProduct(string keyWord )
        {
            return DAL.LT_PRODUCT.ReadProduct(keyWord);
        }
        public static PRODUCT Search(string keyword)
        {
            List<PRODUCT> lst = DAL.LT_PRODUCT.ReadProduct("");
            
            foreach (var item in lst)
            {
                if (item.CodeId==keyword|| item.Name.ToLower().Contains(keyword.ToLower()))
                {
                    return item;
                }
            }
            return new PRODUCT();

        }
        public static PRODUCT GetID(int keyword)
        {
            List<PRODUCT> lst = DAL.LT_PRODUCT.ReadProduct("");

            foreach (var item in lst)
            {
                if (item.Id == keyword)
                {
                    return item;
                }
            }
            return new PRODUCT();

        }
        public static bool AddProduct(PRODUCT prod)
        {
            bool kq = false;
            List<PRODUCT> lst =DAL.LT_PRODUCT.ReadProduct("");
            int maxId = 0;
            foreach (var item in lst)
            {
                if (maxId < item.Id)
                {
                    maxId = item.Id;
                }
                if (prod.CodeId == item.CodeId)
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
            kq = DAL.LT_PRODUCT.WriteProduct(lst);
            return kq;
        }
        public static bool Update(PRODUCT prod)
        {
            bool kq = false;
            List<PRODUCT> lst = DAL.LT_PRODUCT.ReadProduct("");
            foreach (var item in lst)
            {
                if (prod.CodeId == item.CodeId)
                {
                    
                    lst.Remove(item);
                    lst.Add(prod);
                    break;
                }
            }

            kq= DAL.LT_PRODUCT.WriteProduct(lst);
            return kq;
        }
        public static bool Delete(int ProdId)
        {
            bool kq = false;
            List<PRODUCT> lst = DAL.LT_PRODUCT.ReadProduct("");
           
            foreach (var item in lst)
            {
                if (item.Id== ProdId)
                {
                   
                    lst.Remove(item);
                    break;
                }
            }
           
            kq =DAL.LT_PRODUCT.WriteProduct(lst);
            return kq;
        }
    }
}