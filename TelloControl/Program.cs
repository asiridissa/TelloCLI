using System.Net.Sockets;
using System.Net;
using System.Text;
using Microsoft.VisualBasic.Logging;

namespace TelloControl
{
    internal static class Program
    {
        public static string log = "";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Record());
            Application.Run(new MainForm());
            //Application.Run(new Voice());
        }
    }
}