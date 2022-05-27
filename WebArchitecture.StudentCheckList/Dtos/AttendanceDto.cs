using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebArchitecture.StudentCheckList.Dtos
{
    public class AttendanceDto
    {
        public int Id { get; set; }

        public string StudentCod { get; set; }

        public string ClassCod { get; set; }

        public DateTime CheckDate { get; set; }
    }
}
