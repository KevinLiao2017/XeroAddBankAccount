using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protractor;
using System.Data.SqlClient;

namespace XeroAutomation
{
    public class SQLServer
    {            
        public static string ConnectionString = "Server=10.41.88.10,1533; Database=CS; User Id=InoV8; Password=Acc3ss4!noV8;";

        public static string[] Query_PreActive_Toll_Account_Login()
        {
            string[] loginDetails = new string[2];
            SqlConnection MySQLConnection = new SqlConnection(ConnectionString);

            try
            {
                MySQLConnection.Open();
                Console.WriteLine("SQL Server is connected.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            SqlCommand myCommend = new SqlCommand();
            myCommend.Connection = MySQLConnection;
            myCommend.CommandText = "select top 1 c.ContractID, c.PasswordWeb " +  
            "from contracts c left join ContractStatus cs on c.ContractStatusCode = cs.ContractStatusCode " +
            "left join ContractPaymentTypes cpt on c.PaymentType = cpt.PaymentType " + 
            "where cpt.Description = 'pre-pay' " +
            "and cs.Description = 'preactive' " +
            "and c.PasswordWeb is NOT null";

            using (SqlDataReader reader = myCommend.ExecuteReader())
            {
                while (reader.Read())
                {                   
                    loginDetails[0] = reader[0].ToString();
                    loginDetails[1] = reader[1].ToString();

                    Console.WriteLine(loginDetails[0]);
                    Console.WriteLine(loginDetails[1]);
                }
            }

            MySQLConnection.Close();
            MySQLConnection.Dispose();

            return loginDetails;
        }

        public static string[] Query_Active_Toll_Account_With_Positive_Balance_Login()
        {
            string[] loginDetails = new string[2];
            SqlConnection MySQLConnection = new SqlConnection(ConnectionString);

            try
            {
                MySQLConnection.Open();
                Console.WriteLine("SQL Server is connected.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            SqlCommand myCommend = new SqlCommand();
            myCommend.Connection = MySQLConnection;
            myCommend.CommandText = "select top 1 c.ContractID, c.PasswordWeb " +
            "from contracts c left join ContractStatus cs on c.ContractStatusCode = cs.ContractStatusCode " +
            "left join ContractPaymentTypes cpt on c.PaymentType = cpt.PaymentType " +
            "where cpt.Description = 'pre-pay' " +
            "and cs.Description = 'active' " +
            "and c.PrepayBalance > 0 " +
            "and c.PasswordWeb is NOT null " +
            "and c.PasswordWeb LIKE '[A-Z][0-9][0-9][A-Z]'" +
            "order by newid()";

            using (SqlDataReader reader = myCommend.ExecuteReader())
            {
                while (reader.Read())
                {
                    loginDetails[0] = reader[0].ToString();
                    loginDetails[1] = reader[1].ToString();

                    Console.WriteLine(loginDetails[0]);
                    Console.WriteLine(loginDetails[1]);
                }
            }

            MySQLConnection.Close();
            MySQLConnection.Dispose();

            return loginDetails;
        }

        public static string[] Query_Account_Holder_Login()
        {
            string[] loginDetails = new string[2];
            SqlConnection MySQLConnection = new SqlConnection(ConnectionString);

            try
            {
                MySQLConnection.Open();
                Console.WriteLine("SQL Server is connected.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            SqlCommand myCommend = new SqlCommand();
            myCommend.Connection = MySQLConnection;
            myCommend.CommandText = "select top 1 c.ClientID, c.Password " +
            "from Clients c " +
            "where c.Password LIKE '[A-Z][0-9][0-9][A-Z]' " +
            "order by newid()";

            using (SqlDataReader reader = myCommend.ExecuteReader())
            {
                while (reader.Read())
                {
                    loginDetails[0] = reader[0].ToString();
                    loginDetails[1] = reader[1].ToString();

                    Console.WriteLine(loginDetails[0]);
                    Console.WriteLine(loginDetails[1]);
                }
            }

            MySQLConnection.Close();
            MySQLConnection.Dispose();

            return loginDetails;
        }

        public static string[] Query_Unpaid_Notice()
        {
            string[] NoticeDetails = new string[3];
            SqlConnection MySQLConnection = new SqlConnection(ConnectionString);

            try
            {
                MySQLConnection.Open();
                Console.WriteLine("SQL Server is connected.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            SqlCommand myCommend = new SqlCommand();
            myCommend.Connection = MySQLConnection;
            myCommend.CommandText = "SELECT TOP 1 id.DocumentType, id.DocumentNumber, iu.LicensePlate " +
            "FROM [CS].[dbo].[InvoicingDocuments] id " +
            "LEFT JOIN [CS].[dbo].paymentreminderstatus ps on id.PaymentReminderStatusCode = ps.PaymentReminderStatusCode " +
            "LEFT JOIN [CS].[dbo].[InvoicingDocumentsInvoicingUnits] idiu on idiu.[DocumentNumber] = id.[DocumentNumber] " +
            "LEFT JOIN [CS].[dbo].[InvoicingUnits] iu on idiu.[InvoicingUnitID] = iu.[InvoicingUnitID] " +
            "WHERE id.PaymentReminderStatusCode = 0 " +
            "AND id.DocumentType IN ( 'VN', 'IN') " +
            "ORDER BY newid()";

            using (SqlDataReader reader = myCommend.ExecuteReader())
            {
                while (reader.Read())
                {
                    NoticeDetails[0] = reader[0].ToString();
                    NoticeDetails[1] = reader[1].ToString();
                    NoticeDetails[2] = reader[2].ToString();

                    Console.WriteLine(NoticeDetails[0]);
                    Console.WriteLine(NoticeDetails[1]);
                    Console.WriteLine(NoticeDetails[2]);
                }
            }
           
            MySQLConnection.Close();
            MySQLConnection.Dispose();

            return NoticeDetails;
        }

        public static string Query_Past_Trip_LPN()
        {
            string LPN = null;
            SqlConnection MySQLConnection = new SqlConnection(ConnectionString);

            try
            {
                MySQLConnection.Open();
                Console.WriteLine("SQL Server is connected.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            SqlCommand myCommend = new SqlCommand();
            myCommend.Connection = MySQLConnection;
            myCommend.CommandText = "SELECT TOP 1 id.LicensePlate " +
            "FROM CS.dbo.TransactionsToVerify_History id " +
            "INNER JOIN CS.dbo.InvoicingUnits iu ON id.InvoicingUnitID = iu.InvoicingUnitID " +
            "AND id.LicensePlate = iu.LicensePlate " +
            "AND id.Status = 140 " +
            "AND id.Datetime > (GETDATE() - 15) " +
            "AND id.Amount <> 0 " +
            "AND iu.StatusID = 2 " +
            "ORDER BY NEWID()";

            using (SqlDataReader reader = myCommend.ExecuteReader())
            {
                while (reader.Read())
                {
                    LPN = reader[0].ToString();

                    Console.WriteLine(LPN);
                }
            }

            MySQLConnection.Close();
            MySQLConnection.Dispose();

            return LPN;
        }


    }  
}
