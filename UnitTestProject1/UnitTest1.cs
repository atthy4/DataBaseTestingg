using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Data;
using System.Data.SqlClient;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ChromeDriverTest()
        {
            IWebDriver dw = new ChromeDriver();
            dw.Manage().Window.Maximize();
            dw.Navigate().GoToUrl("https://localhost:44361/Home/Index");


            using (SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;"))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("delete from [Tesztelesora].[dbo].[blades]  where [Nb plies] = 'FiberTec Extreme'", con))
                {
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        [TestMethod]
        public void ChromeTest()
        {
            IWebDriver dw = new FirefoxDriver();
            dw.Manage().Window.Maximize();
            /*................*/

            using(SqlConnection con = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database = master; Trusted_Connection = True;"))
            {
                con.Open();

                SqlCommand comm = new SqlCommand("delete from [Tesztelesora].[dbo].[blades] where Model = 'Adidas'", con);

                comm.ExecuteNonQuery();
                con.Close();
            }


        }




            /* [TestMethod]
             public void MozillaTest()
             {
                 IWebDriver dw = new FirefoxDriver();
                 dw.Manage().Window.Maximize();
                 dw.Navigate().GoToUrl("http://atthy4.atspace.cc/register.php");
                 dw.FindElement(By.Name("user")).SendKeys("CserepesVitag");
                 dw.FindElement(By.Name("passw")).SendKeys("avokado");
                 dw.FindElement(By.Name("passw2")).SendKeys("avokado");
                 dw.FindElement(By.Name("email")).SendKeys("avokado@gmail.com");
                 Thread.Sleep(3000);
             }*/
        }

       
}
