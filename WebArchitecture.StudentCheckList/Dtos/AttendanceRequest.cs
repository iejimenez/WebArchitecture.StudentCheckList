using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebArchitecture.StudentCheckList.Dtos
{
    public class AttendanceRequest
    {
        public string StudentCod { get; set; }

        public string ClassCod { get; set; }
    }
}
