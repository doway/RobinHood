﻿using log4net;
using log4net.Config;
using System;
using System.IO;

namespace Doway.Tools.Robinhood
{
    class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            GlobalContext.Properties["appname"] = "Robinhood";
            XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));
            try
            {
                Console.WriteLine("**Robinhood**");
                Console.WriteLine(" License: LGPL v3");
                Console.WriteLine(" Author: Tom Tang <tomtang0406@gmail.com>");
                Console.WriteLine("==========================================");
                if (args.Length > 1)
                {
                    var copier = new WebsiteCopier(args[0], args[1]);
                    copier.StartCopy();
                }
                else
                {
                    ShowHelp();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                _logger.Info("END");
                Console.WriteLine("END");
                Console.ReadLine();
            }
        }
        private static void ShowHelp()
        {
            Console.WriteLine("You didn't assign Robinhood arguments.");
            Console.WriteLine("Usage:");
            Console.WriteLine("Robinhood.exe <url> <The folder to save website>");
            Console.WriteLine(" <url>:");
            Console.WriteLine("     Give an url as the start point to begin grabbing.");
            Console.WriteLine(" <The folder to save website>:");
            Console.WriteLine("     Specified the local folder path for saving the grabbed stuff.");
            Console.WriteLine("     If the folder didn't exist, it does creating folder.");
        }
    }
}
