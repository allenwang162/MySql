using MySql.Data.MySqlClient;
using System;

namespace MySQL
{
    class Program
    {
        static void Main(string[] args)
        {  
            MyDataInfo mydata = new MyDataInfo();  
           
            mydata = MySQLDB.GetTestDemoData(); 

            if (MySQLDB.InsertDataInfoWithOutDuplicate(mydata))
            {
                Console.WriteLine("success on step :  mydata.InsertDataInfoWithOutDuplicate(mydata)");
            }
            else
            {
                Console.WriteLine("error on step :  mydata.InsertDataInfoWithOutDuplicate(mydata)");
                Console.WriteLine("error on mydata.ItemID = {0}", mydata.ItemID);
            }

            if (MySQLDB.DeleteDataInfoByItemID(mydata.ItemID))
            {
                if (MySQLDB.InsertDataInfo(mydata))
                {
                    Console.WriteLine("success on step :  mydb.InsertDataInfo(mydata)");
                }
                else
                {
                    Console.WriteLine("error on step :  mydb.InsertDataInfo(mydata)");
                    Console.WriteLine("error on mydata.ItemID = {0}", mydata.ItemID);
                }
            }
            else
            {
                Console.WriteLine("error on step :  mydb.DeleteDataInfoByItemID(mydata.ItemID)");
                Console.WriteLine("error on mydata.ItemID = {0}", mydata.ItemID);
            }

            mydata = MySQLDB.GetDataInfoByItemId(mydata.ItemID);

            if (MySQLDB.UpDateDataInfoField(mydata.ItemID, "ItemName", "XXX"))
            {
                Console.WriteLine("success on step :  mydb.UpDateDataInfoField(mydata.ItemID, filedName, filedValue)");
            }

            mydata = MySQLDB.GetDataInfoByItemId(mydata.ItemID);

        }

    }
}
