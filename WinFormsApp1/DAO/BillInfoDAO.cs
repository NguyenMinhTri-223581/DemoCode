﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DTO;

namespace WinFormsApp1.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
      

        public static BillInfoDAO Instance 
        {
            get { if (instance == null) 
                    instance = new BillInfoDAO(); 
                return instance; }

             
        }

        private BillInfoDAO() { }
         

        public void DeleteBillInfoByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.CTHOADON WHERE IDTHUCDON = " + id);

        }

        
            public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CTHOADON WHERE IDHOADON = "+id );
            Console.WriteLine("Số lượng dòng lấy được:" + data.Rows.Count);
            foreach (DataRow row in data.Rows)
            {
                BillInfo info = new BillInfo(row);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBillInfo @idBill , @idFood , @count", new object[] {idBill, idFood, count });
        }

    }
}

