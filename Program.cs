using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twirkling
{
    

    class Program
    {
        public class credentials
        {
            public string names;
            public string password;
        }
        static void Main(string[] args)
        {
            credentials[] s = new credentials[100];

            string path = "C:\\Users\\Feb12\\Desktop\\data.txt";
            int usersCount = 0;
            int userArrSize = 100;

            //List < credentials > s2= new List< credentials >();

            int option;
            readData(path,ref s, ref usersCount);

            do
            {
                Console.Clear();
                option = Menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name : ");
                    string n = Console.ReadLine();
                    bool flag = true;
                    while (flag)
                    {
                        for (int i = 0; i < n.Count(); i++)
                        {
                            if (!((n[i] >= 97 && n[i] <= 122) || (n[i] >= 65 && n[i] <= 90)))
                            {
                                Console.WriteLine("Invalid!! Enter Again : ");
                                n = Console.ReadLine();
                                break;
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                    }
                    Console.WriteLine("Enter Password : ");
                    string p = Console.ReadLine();
                    signUp(path, n, p,ref  s, ref usersCount, ref userArrSize);

                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter Name : ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password : ");
                    string p = Console.ReadLine();

                    Console.ReadKey();
                }
            }
            while (option < 4);
            Console.ReadKey();
        }

        static int Menu()
        {
            int option;
            Console.WriteLine("1.SignUp with you Credential");
            Console.WriteLine("2.SignIn with you Credential");
            Console.WriteLine("3.Exit the Application");
            Console.WriteLine("Enter Your Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static void readData(string path, ref credentials[] s,  ref int usersCount)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    credentials s1 = new credentials();
                    s1.names = parseData(record, 1);
                    s1.password = parseData(record, 2);
                    s[x] = s1;
                    x++;
                    usersCount++;
                    if (usersCount > 10)
                    {
                        break;
                    }
                }

                fileVariable.Close();
            }
            else
            {
                Console.Write("Doesnot Exists");
            }
        }
        static void signIn(string n, string p, credentials[] s)
        {
            bool flag = false;
            for (int x = 0; x < 100; x++)
            {
                if (n == s[x].names && p == s[x].password)
                {
                    flag = true;
                    Console.WriteLine("Congrats! You are verified as a valid User");
                }
            }        
            if(flag==false)
            {
                Console.WriteLine("Sorry! You have Enter the wrong Id");
            }            
            Console.ReadKey();
        }
        static void signUp(string path, string n, string p,ref credentials[] s, ref int usersCount, ref int userArrSize)
        {

            StreamWriter myfile = new StreamWriter(path, true);
            myfile.WriteLine(n + "," + p);
            myfile.Flush();
            myfile.Close();
            if (usersCount < userArrSize)
            {
                s[usersCount] = addUserData(n, p,ref s, ref usersCount);
                usersCount++;
            }

        }
        static credentials addUserData(string n, string p,ref  credentials[] s,  ref int usersCount)
        {
            credentials s1 = new credentials();
               s1.names = n;
               s1.password = p;
            return s1;
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];

                }
            }
            return item;
        }
    }
}