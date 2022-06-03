using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebArchitecture.StudentCheckList.Dtos;
using WebArchitecture.StudentCheckList.Entity;

namespace WebArchitecture.StudentCheckList.Services
{
    public class AttendanceService
    {
        public StudentCheckListDBContext BD { get; set; }
        public AttendanceService(StudentCheckListDBContext bd)
        {
            BD = bd;
        }

        public AttendanceDto GetAttendanceById(int id)
        {
            Attendance attendanceBD = BD.Attendances.Where(s => s.Id == id).FirstOrDefault();

            if (attendanceBD == null)
                return null;
            AttendanceDto attendance = new AttendanceDto()
            {
                Id = attendanceBD.Id,
                CheckDate = attendanceBD.CheckDate,
                ClassCod = attendanceBD.ClassCod,
                StudentCod = attendanceBD.StudentCod
            };

            return attendance;
        }

        public List<AttendanceDto> GetAttendanceByStudentCod(int cod)
        {
            List<AttendanceDto> results = BD.Attendances.Where(s=>s.StudentCod == cod).Select(s => new AttendanceDto()
            {
                Id = s.Id,
                ClassCod = s.ClassCod,
                StudentCod = s.StudentCod,
                CheckDate = s.CheckDate
            }).ToList();


            return results;
        }

        public List<AttendanceDto> GetAttendanceByClassCod(int cod)
        {
            List<AttendanceDto> results = BD.Attendances.Where(s => s.ClassCod == cod).Select(s => new AttendanceDto()
            {
                Id = s.Id,
                ClassCod = s.ClassCod,
                StudentCod = s.StudentCod,
                CheckDate = s.CheckDate
            }).ToList();


            return results;
        }


        public AttendanceDto AddAttendance(AttendanceRequest checklistItem)
        {

            if(checklistItem.ClassCod <= 0)
                throw new ArgumentException("No ha especificado uno o mas parametros. ClassCod");
            if (checklistItem.StudentCod<= 0)
                throw new ArgumentException("No ha especificado uno o mas parametros. StudentCod");


            Attendance att = new Attendance()
            {
                CheckDate = DateTime.Now,
                ClassCod = checklistItem.ClassCod,
                StudentCod = checklistItem.StudentCod
            };

            BD.Add(att);
            BD.SaveChanges();

            AttendanceDto newItem = new AttendanceDto()
            {
                Id = att.Id,
                CheckDate = att.CheckDate,
                ClassCod = att.ClassCod,
                StudentCod = att.StudentCod
            };
            return newItem;
        }

        public void DeleteAttendance(int id)
        {

            Attendance attendanceToDelete = BD.Attendances.Where(a => a.Id == id).FirstOrDefault();

            if (attendanceToDelete == null)
                return;

            BD.Attendances.Remove(attendanceToDelete);
            BD.SaveChanges();

        }

        public List<AttendanceDto> GetAttendances()
        {
            List<AttendanceDto> results = BD.Attendances.Select(s => new AttendanceDto()
            {
                Id = s.Id,
                ClassCod = s.ClassCod,
                StudentCod = s.StudentCod,
                CheckDate = s.CheckDate
            }).ToList();

            return results;
        }

    }
}
