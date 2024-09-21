using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace KTLT.DAL
{
    public class LT_PRODUCT : Common
    {
        static string filepath = @"C:\VB2\KTLT1\21880103\KTLT\Data\products.txt";

        public static PRODUCT Init(string s)
        {
            PRODUCT prod;
            string[] m = s.Split(',');
            prod.Id = int.Parse(m[0]);
            prod.CodeId = m[1];
            prod.Name = m[2];
            prod.Expire = m[3];
            prod.Cty = m[4];
            prod.NamSX = int.Parse(m[5]);
            prod.CateId = int.Parse(m[6]);
            return prod;
        }
        public static List<PRODUCT> ReadProduct(string keyWord)
        {
            List<PRODUCT> lst = new List<PRODUCT>();
            StreamReader file = new StreamReader(filepath);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                PRODUCT prod = Init(line);
                if (string.IsNullOrEmpty(keyWord) || prod.CodeId.ToLower().Contains(keyWord.ToLower()) || prod.Name.ToLower().Contains(keyWord.ToLower()))
                {
                    lst.Add(prod);
                }

            }
            file.Close();
            return lst;
        }
        public static bool WriteProduct(List<PRODUCT> lst)
        {
            bool kq = true;
            try
            {
                StreamWriter file = new StreamWriter(filepath);
                int i = 0;
                foreach (var item in lst)
                {
                    file.Write($"{item.Id},{item.CodeId},{item.Name},{item.Expire},{item.Cty},{item.NamSX},{item.CateId}");
                    i++;
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

    }
}