using System;
using System.Collections.Generic;
using System.IO;

namespace MoSocioAPI.Utils
{
    public class LogFile
    {
        public static void WriteToFile(string msg, bool isError)
        {
            try
            {
                string logFile = AppDomain.CurrentDomain.BaseDirectory + "logs/" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (!File.Exists(logFile))
                {

                    FileStream fileStream = File.Create(logFile);
                    fileStream.Close();
                    //File.Create(logFile);
                }
                //string pth = AppDomain.CurrentDomain.BaseDirectory + "logs/Errorlog.txt";
                using (StreamWriter writetext = new StreamWriter(logFile, true))
                {

                    if (isError)
                        writetext.WriteLine("Date : " + DateTime.Now + " Error : " + msg);
                    else
                        writetext.WriteLine("Date : " + DateTime.Now + " : " + msg);
                }
            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + ex.StackTrace, true);
            }
        }
    }
}
