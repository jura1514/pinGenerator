using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinsGenerator.Repository
{
    public class BaseRepository
    {
        public BaseRepository()
        {
            this.DatabaseFilePath = "Data Source=pinsDB.sqlite;Version=3;";
        }

        public string DatabaseFilePath { get; set; }
    }
}
