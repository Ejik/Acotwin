using System;

namespace ACOT.Infrastructure.Interface.Services
{
    public static class DebugService
    {
        public static void PrintException(Exception exception)
        {
            PrintException(exception, "");
        }

        public static void PrintException(Exception exception, string indent)
        {
            string stars = new string('*', 80);
            Console.WriteLine(indent + stars);
            Console.WriteLine(indent + "{0}: \"{1}\"", exception.GetType().Name, exception.Message);
            Console.WriteLine(indent + new string('-', 80));
            if (exception.InnerException != null)
            {
                Console.WriteLine(indent + "InnerException:");
                PrintException(exception.InnerException, indent + "   ");
            }
            foreach (string line in exception.StackTrace.Split(new string[] { " at " }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (string.IsNullOrEmpty(line.Trim())) continue;
                string[] parts;
                parts = line.Trim().Split(new string[] { " in " }, StringSplitOptions.RemoveEmptyEntries);
                string class_info = parts[0];
                if (parts.Length == 2)
                {
                    parts = parts[1].Trim().Split(new string[] { "line" }, StringSplitOptions.RemoveEmptyEntries);
                    string src_file = parts[0];
                    int line_nr = int.Parse(parts[1]);
                    Console.WriteLine(indent + "  {0}({1},1):   {2}", src_file.TrimEnd(':'), line_nr, class_info);
                }
                else
                    Console.WriteLine(indent + "  " + class_info);
            }
            Console.WriteLine(indent + stars);
        }
    } 
}
