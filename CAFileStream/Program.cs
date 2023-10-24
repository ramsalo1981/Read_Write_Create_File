using System.Net.Http;

namespace CAFileStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Example1();
            Console.WriteLine("===================");
            Example2();
            Console.WriteLine("===================");
            Example3();
            Console.WriteLine("===================");
            Example4();
            Console.WriteLine("===================");
            Example5();
            Console.WriteLine("\n===================");
            Example6();
            Console.WriteLine("\n===================");
            Example7();
            Console.WriteLine("\n===================");
            Example8();
            Console.WriteLine("\n===================");
            Example9();
            Console.WriteLine("\n===================");
            Example10();
            Console.WriteLine("\n===================");
            Console.ReadKey();
        }


        public static void Example1()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream.txt";
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.WriteLine($"Can read: {fs.CanRead}");
                Console.WriteLine($"Can Write: {fs.CanWrite}");
                Console.WriteLine($"Can Seek: {fs.CanSeek}");
                Console.WriteLine($"Can Timeout: {fs.CanTimeout}");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Position: {fs.Position}");
                fs.WriteByte(65);
                Console.WriteLine($"Position: {fs.Position}");
                fs.WriteByte(66);
                Console.WriteLine($"Position: {fs.Position}");
                fs.WriteByte(13);
                Console.WriteLine($"Position: {fs.Position}");
                for (byte i = 65; i < 123; i++)
                {
                    fs.WriteByte(i);
                }
                Console.WriteLine($"Position: {fs.Position}");
            }
        }
        public static void Example2()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream.txt";
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] data = new byte[fs.Length];
                int numBytesToRead = (int)fs.Length;//before read
                int numBytesRead = 0; // after read we start from 0 byte reading and increes
                while (numBytesToRead > 0)
                {
                    int n = fs.Read(data, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesToRead -= n;
                    numBytesRead += n;
                }

                foreach (var b in data)
                {
                    Console.WriteLine(b);
                }
                string newPath = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream1.txt";
                using (var fsw = new FileStream(newPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fsw.Write(data, 0, data.Length);
                }
            }



        }

        public static void Example3()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream2.txt";
            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Seek(20, SeekOrigin.Begin);
                fs.WriteByte(65);
                fs.Position = 0;
                for (int i = 0; i < fs.Length; i++)
                {
                    Console.WriteLine(fs.ReadByte());
                }
            }
        }
        public static void Example4()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream3.txt";
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("This");
                sw.WriteLine("C#");
                sw.WriteLine("\n\n---------------");
                sw.Write("This is C#");
            }
        }
        public static void Example5()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream3.txt";
            using (var sr = new StreamReader(path))
            {
                while (sr.Peek() > 0)
                {
                    //Console.Write(sr.ReadLine());
                    //Console.Write(sr.Read());
                    Console.Write((char)sr.Read());
                }
            }
        }
        public static void Example6()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream3.txt";
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) is not null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        static void Example7()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream4.txt";

            string[] lines =
            {
                "C#",
                "Is",
                "Amazing",
                "Language"
            };

            File.WriteAllLines(path, lines);

        }
        static void Example8()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream5.txt";

            string text = "C# Is Amazing Language";

            File.WriteAllText(path, text);

        }

        static void Example9()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream5.txt";

            var result = File.ReadAllText(path);

            Console.WriteLine(result);
        }

        static void Example10()
        {
            string path = @"C:\Users\ramis\Desktop\dr_atef_c#\dot_net_core\IOStream\CAFileStream\Data\castream4.txt";

            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

    }
}