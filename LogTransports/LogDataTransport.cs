using System.Globalization;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Reflection.Emit;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Runtime;
using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;
using File = System.IO.File;

namespace LogData;

public class LogDataTransport
{
    public static void Main(string[] args)
    {
        //var format = ".\logger.formatter.js";
        var logData = File.ReadAllText(@".\logData.json");
        var logconfig = File.ReadAllText(@".\logconfig.json");
        string logFile = File.ReadAllText(@".\logfile.log");
        string logMessage = "This is a newer test log message.\n";
        //Console.WriteLine(logMessage);
        //Console.WriteLine(logconfig);
        // Console.WriteLine(logData);
        Console.WriteLine(logMessage);
        static void ToConsole(string logMessage)
        {
            var logData = File.ReadAllText(@".\logData.json");
            var logconfig = File.ReadAllText(@".\logconfig.json");
            string logFile = File.ReadAllText(@".\logfile.json");
            

            if (string.IsNullOrEmpty(logMessage))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Console Log Data: ", logMessage);
            }
        }
        


        void ToFile(string logMessage)
        {
            var logData = File.ReadAllText(@".\logData.json");
            var logconfig = File.ReadAllText(@".\logconfig.json");
            string logFile = File.ReadAllText(@".\logfile.json");
            
            if (!string.IsNullOrEmpty(logMessage))
            {
                Environment.Exit(0);
            }
            else
            {
                // When appendFile is called and logFile.log doesn't exist, the file will be created by the function
                
               
                    using (StreamWriter ReadLogFile = File.AppendText(logFile))
                    {
                        ReadLogFile.Write("END");
                    }
                    string text = File.ReadAllText(logFile);

                    if(text != null)
                    {
                         throw new Exception(text);
                    }
                    Console.WriteLine(text);
            
                    Console.WriteLine("The string was successfully appended to the file!");
                

            }

            /*void ToAPI(string logMessage) 
            { 
            }*/
        }
    }
}
    
