using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Files
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter The Path:");
            string @path = Console.ReadLine();
            int state = 0;
            try
            {
                do
                {
                    if (Directory.Exists(@path))
                    {
                        string[] str = Directory.GetDirectories(@path);
                        foreach (var i in str)
                            Console.WriteLine(i);
                        Console.WriteLine("Do you want to explore directories:\n 1.Yes \n 2.NO \n 3.Explore Files");
                        state = int.Parse(Console.ReadLine());                        
                        switch(state)
                        {
                          case 1:
                            Setdirectory(ref @path);
                            break;

                          case 2:
                            Environment.Exit(0);
                            break;

                          case 3:
                            {
                               string[] arr = SetFiles(@path);
                               foreach (var i in arr)
                                   Console.WriteLine(i);
                               Console.WriteLine("Do You Want to See Files Insides:\n 1.Yes \n 2.No");
                               int state2 = int.Parse(Console.ReadLine());
                               if (state2 == 1)
                                   OpenFile(@path);
                               break;
                            }
                        } 
                    }
                    else
                        Environment.Exit(0);
                } while (state == 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            Console.ReadKey();

        }
        public static void Setdirectory(ref string @upath)
        {
            Console.WriteLine("Enter the folder name:");
            string @userpath = Console.ReadLine();
            string[] str = Directory.GetDirectories(@upath + @userpath);
            /* foreach (var i in str)
                 Console.WriteLine(i);*/
            @upath = @upath + @userpath;
        }
        public static string[] SetFiles(string @filepath)
        {
            string[] str = Directory.GetFiles(@filepath, "*.*", SearchOption.TopDirectoryOnly);
            return str;
        }
        public static void OpenFile(string @filepath)
        {
            Console.WriteLine("Which File You Want To See:");
            string @file = Console.ReadLine();
            string []str = File.ReadAllLines(@filepath+file);
            foreach(var c in str)
                Console.WriteLine(c);
        }

    }
}
