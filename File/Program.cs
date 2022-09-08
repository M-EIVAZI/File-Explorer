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
            string @path = Console.ReadLine();
            //string @userpath;
            int state=0;
            try
            {
                do
                {
                    if (Directory.Exists(@path))
                    {
                        string[] str = Directory.GetDirectories(@path);
                        foreach (var i in str)
                            Console.WriteLine(i);
                        Setdirectory(ref @path);
                        Console.WriteLine("Do you want to explore directories:\n 1.Yes \n 2.NO \n 3.Explore Files");
                        state = int.Parse(Console.ReadLine());
                        
                    }
                    else
                        Environment.Exit(0);
                } while (state == 1);
            }
            catch(Exception e)
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
        
    }

}

