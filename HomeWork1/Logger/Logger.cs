using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1.Logger
{
    public class Logger
    {
        private string filePath;
        public Logger(string filePath)
        {
            this.filePath = filePath;
        }

        public void Log(string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging to file: {ex.Message}");
            }
        }
    }
   
}

