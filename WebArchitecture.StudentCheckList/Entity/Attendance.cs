using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebArchitecture.StudentCheckList.Entity
{
    public class Attendance
    {
        public int Id { get; set; }

        public int StudentCod { get; set; }

        public int ClassCod { get; set; }

        public DateTime CheckDate { get; set; }
    }
}
