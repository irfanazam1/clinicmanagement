using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Persistence
{
    public class DbRecord
    {
        private List<String> columns = new List<string>();
        private List<List<object>> records = new List<List<object>>();
        private int fieldCount;
        private int rowCount;

        public List<List<object>> Records { get => records; set => records = value; }
        public List<string> Columns { get => columns; set => columns = value; }
        public int FieldCount { get => fieldCount; set => fieldCount = value; }
        public int RowCount { get => rowCount; set => rowCount = value; }
    }
}
