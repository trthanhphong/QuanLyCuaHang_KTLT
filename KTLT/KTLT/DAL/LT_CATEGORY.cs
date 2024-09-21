using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace KTLT.DAL
{
    public class LT_CATEGORY
    {

        static string filePath = @"C:\VB2\KTLT1\21880103\KTLT\Data\categorys.txt";

        public static CATEGORY Init(string s) 
        {
            CATEGORY cate;
            string[] m = s.Split(',');
            cate.CateId = int.Parse(m[0]);
            cate.CateName = m[1];
            return cate;
        }
        public static List<CATEGORY> ReadCategory(string keyWord)
        {
            StreamReader file = new StreamReader(filePath);
            List<CATEGORY> lstCate = new List<CATEGORY>();
            CATEGORY cate;
            while (!file.EndOfStream)
            {

                string line = file.ReadLine();
                cate = Init(line);
                if (string.IsNullOrEmpty(keyWord) || cate.CateName.ToLower().Contains(keyWord.ToLower()))
                {
                    lstCate.Add(cate);
                }

            }
            file.Close();
            return lstCate;
        }
        public static bool WriteCategory(List<CATEGORY> lst)
        {
            bool kq = true;
            try
            {
                StreamWriter file = new StreamWriter(filePath);
                int i = 0;
                foreach (var item in lst)
                {
                    i++;
                    file.Write($"{item.CateId},{item.CateName}");
                    if (i < lst.Count)
                    {
                        file.WriteLine();
                    }
                }
                file.Close();
            }
            catch (Exception)
            {
                kq = false;
            }
            return kq;
        }
        public static CATEGORY Search(string keyword)
        {
            CATEGORY kq = new CATEGORY();
            StreamReader file = new StreamReader(filePath);
            List<CATEGORY> lstCate = new List<CATEGORY>();
            CATEGORY cate;
            while (!file.EndOfStream)
            {
                cate = new CATEGORY();
                string line = file.ReadLine();
                cate = Init(line);
                if (cate.CateName.Contains(keyword))
                {
                    kq = cate;
                    break;
                }
            }
            file.Close();
            return kq;
        }

    }
}