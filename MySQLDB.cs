using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

public class MySQLDB
{
 
    public static string dbconnection 
    {
        get
        {
            return ConfigurationManager.AppSettings["connectingString"].ToString(); 
        }
        //set { dbconnection = value;}
    }

    public MySQLDB()
    {
        //construction
    } 

    /// <summary>
    /// insert data into the DataInfo table
    /// </summary>
    /// <param name="mydatainfo">the obj of the MyDataInfo</param>
    /// <returns>bool insert data</returns>
    public static bool InsertDataInfo(MyDataInfo mydata)
    {
        MySqlConnection conn = new MySqlConnection(dbconnection);
        MySqlCommand cmd = new MySqlCommand(GetInsertDataInfoCommandText(mydata), conn);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception e)
        {
            conn.Close();
            Console.WriteLine("error on InsertDataInfo {0}",e.ToString()); 
            return false; 
        }

    }

    /// <summary>
    /// command text of the insert data info
    /// </summary>
    /// <param name="da">MyDataInfo da</param>
    /// <returns>string command text</returns>
    private static string GetInsertDataInfoCommandText(MyDataInfo da)
    {
        return "INSERT INTO DataInfo (ItemID,SKU,ItemCategory,SubCategory,CompanyName,BrandName,ItemName,ItemDescription,ImgPath,ForwardLink,OriginalPrice ,ItemPrice,Promotion,UserRated,PublishDate,ExpireDate,MetaKeyWord,MetaDescription,Others1,Others2)"
                + " VALUES" + "('" + da.ItemID + "','" + da.SKU + "','" + da.ItemCategory + "','" + da.SubCategory + "','" + da.CompanyName + "','"
                + da.BrandName + "','" + da.ItemName + "','" + da.ItemDescription + "','" + da.ImgPath + "','" + da.ForwardLink + "','"
                + da.OriginalPrice + "','" + da.ItemPrice + "','" + da.Promotion + "','" + da.UserRated + "','" + da.PublishDate + "','"
                + da.ExpireDate + "','" + da.MetaKeyWord+"','"+da.MetaDescription+"','"+da.Others1 + "','" + da.Others2 + "')"; 
          
    }

    /// <summary>
    /// get data info by itemid
    /// </summary>
    /// <param name="itemId">itemid</param>
    /// <returns>MyDataInfo obj</returns>
    public static MyDataInfo GetDataInfoByItemId(string itemId)
    {
        MyDataInfo mydata = new MyDataInfo();
        DataSet ds = new DataSet();
        MySqlConnection conn = new MySqlConnection(dbconnection);
        MySqlDataAdapter adapt = new MySqlDataAdapter(GetSelectDataInfoByItemIdCommandText(itemId), conn);  
        try
        { 
            adapt.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                foreach (DataColumn Col in ds.Tables[0].Columns)
                {   
                    mydata.ItemID = row["ItemID"].ToString();
                    mydata.SKU = row["ItemID"].ToString();
                    mydata.ItemCategory = row["ItemCategory"].ToString();
                    mydata.SubCategory = row["SubCategory"].ToString();
                    mydata.CompanyName = row["CompanyName"].ToString();
                    mydata.BrandName = row["BrandName"].ToString();
                    mydata.ItemName = row["ItemName"].ToString();
                    mydata.ItemDescription = row["ItemDescription"].ToString();
                    mydata.ImgPath = row["ImgPath"].ToString();
                    mydata.ForwardLink = row["ForwardLink"].ToString();
                    mydata.OriginalPrice = row["OriginalPrice"].ToString();
                    mydata.ItemPrice = row["ItemPrice"].ToString();
                    mydata.Promotion = row["Promotion"].ToString();
                    mydata.UserRated = row["UserRated"].ToString();
                    mydata.PublishDate = row["PublishDate"].ToString();
                    mydata.ExpireDate = row["ExpireDate"].ToString();
                    mydata.MetaKeyWord = row["MetaKeyWord"].ToString();
                    mydata.MetaDescription = row["MetaDescription"].ToString();
                    mydata.Others1 = row["Others1"].ToString();
                    mydata.Others2 = row["Others2"].ToString();

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("error on GetDataInfoByItemId {0}", e.ToString());
            return null;
        } 

        return mydata;
    }

    /// <summary>
    /// command text of select data info by itemid
    /// </summary>
    /// <param name="itemId">itemid</param>
    /// <returns>string command text</returns>
    public static string GetSelectDataInfoByItemIdCommandText(string itemId)
    {
        return "SELECT ItemID,SKU,ItemCategory,SubCategory,CompanyName,BrandName,ItemName,ItemDescription,ImgPath,ForwardLink,OriginalPrice ,ItemPrice,Promotion,UserRated,PublishDate,ExpireDate,MetaKeyWord,MetaDescription,Others1,Others2"
            + " FROM DataInfo WHERE ItemID = '"+itemId +"'";
    }

    /// <summary>
    /// command text of delete data info by itemid
    /// </summary>
    /// <param name="itemId">itemId</param>
    /// <returns>string command text</returns>
    public static string GetDeleteDataInfoByItemIDCommandText(string itemId)
    {
         return "DELETE FROM DataInfo WHERE ItemID='" + itemId + "' ";
         
    }

    /// <summary>
    /// delete data info by itemid
    /// </summary>
    /// <param name="itemId">itemid</param>
    /// <returns>boolean</returns>
    public static bool DeleteDataInfoByItemID(string itemId)
    {
        //if (IsDataInTable(itemId)) { }

        MySqlConnection conn = new MySqlConnection(dbconnection);
        MySqlCommand cmd = new MySqlCommand(GetDeleteDataInfoByItemIDCommandText(itemId), conn);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception e)
        {
            conn.Close();
            Console.WriteLine("error on DeleteDataInfoByItemID {0}", e.ToString());
            return false;
        }
    } 

    /// <summary>
    /// update data inf field value
    /// </summary>
    /// <param name="itemid">itemid</param>
    /// <param name="filedName">filedName , such as "Company"</param>
    /// <param name="filedValue">filedValue, such as "xxx"</param>
    /// <returns>boolean</returns>
    public static bool UpDateDataInfoField(string itemid, string filedName, string filedValue)
    {
        MySqlConnection conn = new MySqlConnection(dbconnection);
        MySqlCommand cmd = new MySqlCommand(GetUpDateDataInfoFieldByItemIdCommandText(itemid,filedName, filedValue), conn);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception e)
        {
            conn.Close();
            Console.WriteLine("error on UpDateDataInfoField {0}", e.ToString());
            return false;
        }
    }

    /// <summary>
    /// command text of update datainfo talbe filed value by itemid
    /// </summary>
    /// <param name="itemid">itemid</param>
    /// <param name="filedName">such as : "ItemPrice"</param>
    /// <param name="filedValue">such as : "99.01"</param>
    /// <returns>string command text</returns>
    public static string GetUpDateDataInfoFieldByItemIdCommandText(string itemid,string filedName, string filedValue)
    {
        return " UPDATE DataInfo SET " + filedName + "='" + filedValue + "' WHERE ItemId ='" + itemid + "'";
    }

    /// <summary>
    /// Get Test Demo Data
    /// </summary>
    /// <returns>MyDataInfo obj</returns>
    public static MyDataInfo GetTestDemoData()
    {
        return MySQLDB.SetTestDemoData();
    }

    /// <summary>
    /// delete old data which has same itemid before insert it 
    /// </summary>
    /// <param name="mydata">MyDataInfo obj</param>
    /// <returns>boolean return true with no err</returns>
    public static bool InsertDataInfoWithOutDuplicate(MyDataInfo mydata)
    {
        if (DeleteDataInfoByItemID(mydata.ItemID))
        {
            if (InsertDataInfo(mydata))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// SetTestDemoData
    /// </summary>
    /// <returns></returns>
    private static MyDataInfo SetTestDemoData()
    {
        MyDataInfo mydata = new MyDataInfo();
        mydata.ItemID = "20120424114857146";
        //mydata.SKU = "";
        mydata.ItemCategory = "clothing";
        mydata.SubCategory = "clothing kids";
        mydata.CompanyName = "walmart.com";
        mydata.BrandName = "";
        mydata.ItemName = "Faded Glory - Baby Girls 2-Piece Graphic Fleece Set";
        mydata.ItemDescription = "100% polyester. Fleece lining. Full zip front. Long sleeves. Attached hood. Elastic waistband.";
        mydata.ImgPath = "http://askbargains.com/Image/Products/20120424/20120424114857146.jpg";
        mydata.ForwardLink = "http://linksynergy.walmart.com/fs-bin/click?id=CncUtE6QSJg&amp;subid=0&amp;offerid=183959.1&amp;type=10&amp;tmpid=1082&amp;RD_PARM0=http%3A%2F%2Fwww.walmart.com%2Fip%2F17806841&amp;RD_PARM1=http%3A%2F%2Fwww.walmart.com%2Fip%2F17806841";
        mydata.OriginalPrice = "69.99";
        mydata.ItemPrice = "49.99";
        mydata.Promotion = "SAVE 20% OFF";
        mydata.UserRated = "9";
        mydata.PublishDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        mydata.ExpireDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        mydata.MetaKeyWord = "clothing,clothing kids,Faded,Glory,Baby,Girls,2,Piece,Graphic,Fleece,Set";
        mydata.MetaDescription = "100% polyester. Fleece lining. Full zip front. Long sleeves. Attached hood. Elastic waistband.";

        return mydata;             
    }
}


//MyDataInfo  class only hold the data structure;
/// <summary>
/// same as the MySQL database "mydatapool" table ""
/// </summary>
public class MyDataInfo
{
    public MyDataInfo()
    {
    }

    #region properties
    public string ItemID { get; set; }
    public string SKU { get; set; } 
    public string ItemCategory { get; set; }
    public string SubCategory { get; set; }
    public string CompanyName { get; set; }
    public string BrandName { get; set; }
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public string ImgPath { get; set; } 
    public string ForwardLink { get; set; }
    public string ItemPrice { get; set; }
    public string OriginalPrice { get; set; }
    public string Promotion { get; set; }
    public string UserRated { get; set; }
    public string PublishDate { get; set; }
    public string ExpireDate { get; set; }
    public string MetaKeyWord { get; set; }
    public string MetaDescription { get; set; }
    public string Others1 { get; set; }
    public string Others2 { get; set; }
    #endregion

}

