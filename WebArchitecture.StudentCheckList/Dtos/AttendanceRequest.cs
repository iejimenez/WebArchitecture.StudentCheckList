using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebArchitecture.StudentCheckList.Dtos
{
    public class AttendanceRequest
    {
        public int StudentCod { get; set; }

        public int ClassCod { get; set; }
    }
}
