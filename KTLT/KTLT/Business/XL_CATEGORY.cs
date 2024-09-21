using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace KTLT
{
    public struct CATEGORY
    {
        public int CateId;
        public string CateName;

    }
    public class XL_CATEGORY
    {
 
        public static List<CATEGORY> ReadALlCategory(string keyWord)
        {
           return DAL.LT_CATEGORY.ReadCategory(keyWord);
        }
        public static bool AddCategory(CATEGORY cate)
        {
            List<CATEGORY> lst = ReadALlCategory("");
            //CATEGORY cate=new CATEGORY();
            bool kq = false;
            int MaxID = 0; 
            foreach (var item in lst)
            {
                if (MaxID<item.CateId)
                {
                    MaxID = item.CateId;
                }
               if( item.CateName == cate.CateName)
                {
                    cate.CateId = item.CateId;
                    break;
                }
            }
            if (cate.CateId>0)
            {
                return kq;
            }
            cate.CateId = MaxID + 1;
            lst.Add(cate);
            kq = DAL.LT_CATEGORY.WriteCategory(lst);
            return kq;
        }
        public static bool UpdateCategory(CATEGORY cate)
        {
            List<CATEGORY> lst = ReadALlCategory("");
            //CATEGORY cate=new CATEGORY();
            bool kq = false; 
            foreach (var item in lst)
            {
                
                if (item.CateId == cate.CateId)
                {
                    lst.Remove(item);
                    lst.Add(cate);
                    break;
                }
            }
            kq =DAL.LT_CATEGORY.WriteCategory(lst);
            return kq;
        }
        public static bool Delete(int keyword)
        {
            bool kq = false;
            List<CATEGORY> lst =ReadALlCategory("");
            foreach (var item in lst)
            {
                if (item.CateId == keyword)
                {
                    lst.Remove(item);
                    break;
                }
            }
           kq = DAL.LT_CATEGORY.WriteCategory(lst);
            return kq;
        }
        public static CATEGORY Search(string keyword)
        {
            List<CATEGORY> lst = ReadALlCategory(keyword);
            CATEGORY kq=new CATEGORY();
            foreach (var item in lst)
            {
                if (item.CateName == keyword)
                {
                    kq = item;
                    break;
                }
            }
            return kq;
        }
        public static CATEGORY GetID(int keyword)
        {
            List<CATEGORY> lst = ReadALlCategory("");
            CATEGORY kq = new CATEGORY();
            foreach (var item in lst)
            {
                if (item.CateId == keyword)
                {
                    kq = item;
                    break;
                }
            }
            return kq;
        }
    }
}