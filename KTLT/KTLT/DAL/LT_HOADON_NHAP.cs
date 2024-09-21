using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KTLT.DAL
{
    public class LT_HOADON_NHAP : Common
    {

        static string filepath = @"C:\\VB2\\KTLT1\\21880103\\KTLT\\Data\\hdnhap_hang.txt";

        public static HOADON Init(string s)
        {
            HOADON prod = new HOADON();
            string[] m = s.Split(',');
            prod.Id = int.Parse(m[0]);
            prod.CodeId = m[1]; // Mã hàng hóa-->PRODUCT
            prod.Name = m[2];
            prod.Dongia = int.Parse(m[3]);
            prod.Soluong = int.Parse(m[4]);
            prod.Tien = int.Parse(m[5]);
            prod.masoHD = m[6];
            prod.Ngay = m[7];
            prod.LoaiHD = m[8];
            return prod;
        }
        public static List<HOADON> ReadHOADON(string keyWord)
        {
            List<HOADON> lst = new List<HOADON>();
            StreamReader file = new StreamReader(filepath);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                HOADON prod = Init(line);
                if (string.IsNullOrEmpty(keyWord) || prod.masoHD.ToLower() == keyWord.ToLower() || prod.Name.ToLower().Contains(keyWord.ToLower()))
                {
                    lst.Add(prod);
                }
            }
            file.Close();
            return lst;
        }
        public static bool WriteHOADON(List<HOADON> lst)
        {
            bool kq = true;
            try
            {
                StreamWriter file = new StreamWriter(filepath);
                int i = 0;
                foreach (var item in lst)
                {
                    file.Write($"{item.Id},{item.CodeId},{item.Name},{item.Dongia},{item.Soluong},{item.Tien},{item.masoHD},{item.Ngay},{item.LoaiHD}");

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