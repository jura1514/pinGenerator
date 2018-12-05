using PinsGenerator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinsGenerator
{
    static class Program
    {
        /// <summary>
        /// The application is not fully efficient since
        /// testing results showed that pin generation slows down
        /// when around 6000 - 7000 pins generated,
        /// potential improvement would be to modify generateRandomNumbers() 
        /// and database. For example: instead of one table "pins" devide it into multiple tables
        /// like pins_from_0000_to_1000 and so on, and also have multiple generateRandomNumbers() functions
        /// where each one would generate only numbers from 0 to 1000 and so on. Then we could call them in random order,
        /// for instance on first click generate pin from 0000 to 1000 on second from 7001 to 8000, when number of records 
        /// in all tables reaches the ma amount restart the program.
        /// Thus I believe it would improve the speed of new ping generator.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // create DB table if not created
            PinsRepository pinRepo = new PinsRepository();


            if (!pinRepo.checkIfTableExists("pins"))
            {
                pinRepo.createTable();
            }
            //else
            //{
            //    // for testing
            //    pinRepo.dropTable();
            //    pinRepo.createTable();
            //}

            Application.Run(new MainForm(pinRepo));
        }
    }
}
