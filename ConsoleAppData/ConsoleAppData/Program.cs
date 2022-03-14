using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppData
{
    internal class Program
    {
        Dictionary<string, string> userip = new Dictionary<string, string>();
        Dictionary<string, string> userie = new Dictionary<string, string>();
        Dictionary<string, string> from = new Dictionary<string, string>();
        Dictionary<string, string> to = new Dictionary<string, string>();
        Dictionary<string, string> via = new Dictionary<string, string>();

        dynamic userid;
        List<string> ports = new List<string>() { "australia", "america", "andaman", "africa", "india", "russia", "uk", "china" };
        //main class start

        static void Main(string[] args)
        { 
            string connStr = "server=localhost;user=admin;database=customer;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            dynamic op;
            Program obj = new Program();
            Console.WriteLine("u are admin or user:(user/admin):");
            op = Console.ReadLine();
            if (op == "user")
            {
                Console.WriteLine("u want to login or signup(login/signup):");
                op = Console.ReadLine();
                if (op == "login")
                {
                    obj.login();
                }
                else if (op == "signup")
                {
                    obj.signup();
                }
            }
            else if (op == "admin")
            {
                obj.admin();
            }

            /*try
            {
                conn.Open();
                string sql = "select * from userlogin";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                Console.WriteLine("Entre Id");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Username");
                string Name = Console.ReadLine();
                string iquery = "INSERT INTO userlogin(Id,Name) VALUES(" + Id + ",'" + Name + "')";
                MySqlCommand insertcommand = new MySqlCommand(iquery, conn);
                insertcommand.ExecuteNonQuery();
            
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + "---" + rdr[1]);
                }
                rdr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();*/
        }
        public void signup()
        {
            string connStr = "server=localhost;user=admin;database=container;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                dynamic username, password, email;
                Program obj = new Program();
                Console.WriteLine("*****signup page****");
                Console.WriteLine("enter user name:");
                username = Console.ReadLine();
                Console.WriteLine("enter email:");
                email = Console.ReadLine();
                Console.WriteLine("enter password:");

                password = Console.ReadLine();
                Console.WriteLine("*****signup success****");
                obj.userip.Add(username, password);
                obj.userie.Add(username, email);
                string iquery = "INSERT INTO user(UserName,Email,password) VALUES('" + username + "','" + email + "','" + password + "')";
                MySqlCommand insertcommand = new MySqlCommand(iquery, conn);
                insertcommand.ExecuteNonQuery();
                
                obj.login();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

        }
        public void login()
        {
            dynamic username, password;
            int flag = 0;
            Program obj = new Program();
            Console.WriteLine("*****login page****");
            Console.WriteLine("enter user name:");
            username = Console.ReadLine();
            Console.WriteLine("enter password:");
            password = Console.ReadLine();
            obj.userid = username;
            foreach (var i in userip)
            {
                if (i.Key == username && i.Value == password)
                {
                    flag++;
                    break;
                }
            }
            if (flag > 0)
            {
                Console.WriteLine("***login success*****");
                obj.emodal_portal(obj.userid);
                flag = 0;
            }
            else
            {
                Console.WriteLine("***login failed*****");
            }
        }
        //login method end
        //portal strat

        public void emodal_portal(string userid)
        {
            dynamic op = " ", id, height, width, price, username, d, length, flag = 1,service;
            Program obj = new Program();
            string connStr = "server=localhost;user=admin;database=container;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);

            while (flag == 1)
            {
                Console.WriteLine("!!!well come to emodal portal!!!");
                Console.WriteLine("u want services (s)//// admin approval status (a) //// services status(st)://// exit(e)");
                op = Console.ReadLine();
                //start loop

                if (op == "s")
                {
                    Console.WriteLine("******list of services*****");
                    Console.WriteLine("cleaning:(c)");
                    Console.WriteLine("paintin:(p)");
                    Console.WriteLine("safety check:(sc):");
                    Console.WriteLine("damage control:(dm)");
                    op = Console.ReadLine();
                    //services if start
                    if (op == "c")
                    {
                        try
                        {
                            conn.Open();
                            username = obj.userid;
                            Random rand = new Random(1000);
                            id = rand.Next();
                            Console.WriteLine("enter height of a cantainer in meters:");
                            height = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter width of a cantainer in meters:");
                            width = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter length of a cantainer in meters:");
                            length = Convert.ToInt32(Console.ReadLine());
                            price = ((height * width * length) * 1);

                            Console.WriteLine("enter date (yyyy/mm/dd):");
                            string date = Console.ReadLine();
                            
                            Console.WriteLine($"total price is:{price}");
                            service = "cleaning";
                            string status = "Pending";
                            string iquery = "INSERT INTO service(Cid,ServiceName,Cheight,Cweight,Clength,Date,Price,Status) VALUES(" + id + ",'" + service + "','" + height + "','" + width + "','" + length + "','" + date + "','" + price + "','" + status + "')";
                            MySqlCommand insertcommand = new MySqlCommand(iquery, conn);
                            insertcommand.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        conn.Close();

                    }
                    else if (op == "p")//painting
                    {
                        try
                        {
                            conn.Open();
                            username = obj.userid;
                            Random rand = new Random(1000);
                            id = rand.Next();
                            Console.WriteLine("enter height of a cantainer in meters:");
                            height = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter width of a cantainer in meters:");
                            width = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter length of a cantainer in meters:");
                            length = Convert.ToInt32(Console.ReadLine());
                            price = ((height * width * length) * 2);

                            Console.WriteLine("enter date (dd/mm/yy):");
                            string date = Console.ReadLine();
                           
                            Console.WriteLine($"total price is:{price}");
                            service = "painting";
                            string status = "Pending";
                            string iquery = "INSERT INTO service(Cid,ServiceName,Cheight,Cweight,Clength,Date,Price,Status) VALUES(" + id + ",'" + service + "','" + height + "','" + width + "','" + length + "','" + date + "','" + price + "','" + status + "')";
                            MySqlCommand insertcommand = new MySqlCommand(iquery, conn);
                            insertcommand.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        conn.Close();


                    }
                    else if (op == "sc")//safety check
                    {
                        try
                        {
                            conn.Open();
                            username = obj.userid;
                            Random rand = new Random(1000);
                            id = rand.Next();
                            Console.WriteLine("enter height of a cantainer in meters:");
                            height = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter width of a cantainer in meters:");
                            width = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter length of a cantainer in meters:");
                            length = Convert.ToInt32(Console.ReadLine());
                            price = ((height * width * length) * 1);

                            Console.WriteLine("enter date (dd/mm/yy):");
                            string date = Console.ReadLine();
                            
                            Console.WriteLine($"total price is:{price}");
                            service = "safty check";
                            string status = "Pending";
                            string iquery = "INSERT INTO service(Cid,ServiceName,Cheight,Cweight,Clength,Date,Price,Status) VALUES(" + id + ",'" + service + "','" + height + "','" + width + "','" + length + "','" + date + "','" + price + "','" + status + "')";
                            MySqlCommand insertcommand = new MySqlCommand(iquery, conn);
                            insertcommand.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        conn.Close();

                    }
                    else if (op == "dm")//damage  control
                    {
                        try
                        {
                            conn.Open();
                            username = obj.userid;
                            Random rand = new Random(1000);
                            id = rand.Next();
                            Console.WriteLine("enter height of a cantainer:");
                            height = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter width of a cantainer:");
                            width = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter length of a cantainer in meters:");
                            length = Convert.ToInt32(Console.ReadLine());
                            price = ((height * width * length)*10 );

                            Console.WriteLine("enter date dd/mm/yy):");
                            string date = Console.ReadLine();
                           
                            service = "damage control";
                            //Console.WriteLine($"total price is:{price}");
                            string status = "Pending";
                            string iquery = "INSERT INTO service(Cid,ServiceName,Cheight,Cweight,Clength,Date,Price,Status) VALUES(" + id + ",'" + service + "','" + height + "','" + width + "','" + length + "','" + date + "','" + price + "','" + status + "')";
                            MySqlCommand insertcommand = new MySqlCommand(iquery, conn);
                            insertcommand.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        conn.Close();

                    }

                    obj.login();

                    //services if end

                }
                else if (op == "a")//admin approve
                {
                    //string connStr = "server=localhost;user=admin;database=container;port=3306;password=root";
                    MySqlConnection conn1 = new MySqlConnection(connStr);
                    try
                    {
                        conn1.Open();
                        string query = "select * from Service";
                        MySqlCommand cmd = new MySqlCommand(query, conn1);
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + "---" + rdr[1] + "---" + rdr[2] + "---" + rdr[3] + "---" + rdr[4] + "---" + rdr[5] + "---" + rdr[6] + "---" + rdr[7]);
                        }
                        rdr.Close();



                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    conn1.Close();


                }
                else if (op == "s")//service status check
                {

                }

                else if (op == "e")//exit
                {
                    flag = 0;
                }
                else//incorrct option select
                {
                    Console.WriteLine("please select correct option!");
                }
                //end loop
            }
        }

        //portal end
        //admin start
        public void admin()
        {

        }

    }
}
