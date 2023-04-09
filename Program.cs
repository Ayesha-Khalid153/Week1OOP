using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
111
namespace filehandling
{
    class Program
    {
        static void Main(string[] args)
        {
            //int num1;
            //int num2;
            //int result;
            //Console.Write("Enter the first number to be added: ");
            //num1 = int.Parse(Console.ReadLine());
            //Console.Write("Enter the second number to be added: ");
            //num2 = int.Parse(Console.ReadLine());
            //result = add(num1, num2);
            //Console.Write("The sum of numbers is {0}", result);
            //Console.Read();
            readfile();
        }
        static int add(int n1, int n2)
        {
            return n1 + n2;
        }
        static void readfile()
        {
            string record;
            string path = "C:\\Users\\Feb12\\Desktop\\ayeshak\\ak\\malikk.txt";
            if (File.Exists(path))
            {
                StreamReader fileak = new StreamReader(path);
                while ((record = fileak.ReadLine()) != null)
                {
                    Console.Write(record);
                }
                fileak.Close();
            }
            else
            {
                Console.Write("This  text file doesnot exists.");
            }
            Console.ReadKey();
        }

    }
}