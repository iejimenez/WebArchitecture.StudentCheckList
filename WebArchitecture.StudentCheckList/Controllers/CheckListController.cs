using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebArchitecture.StudentCheckList.Dtos;
using WebArchitecture.StudentCheckList.Entity;
using WebArchitecture.StudentCheckList.Services;

namespace WebArchitecture.StudentCheckList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListController : ControllerBase
    {

        private StudentCheckListDBContext db;

        public CheckListController(StudentCheckListDBContext contextDB)
        {
            db = contextDB;
        }

        [HttpGet]
        public IEnumerable<AttendanceDto> Get()
        {
            AttendanceService service = new AttendanceService(db);
            return (IEnumerable<AttendanceDto>)service.GetAttendances();
        }

        // GET 
        [HttpGet("{id}")]
        public AttendanceDto Get(int id)
        {
            AttendanceService service = new AttendanceService(db);
            return service.GetAttendanceById(id);
           
        }

        [HttpGet("StudentCod/{codEstudiante}")]
        public IEnumerable<AttendanceDto> GetByStudentCod(int codEstudiante)
        {
            AttendanceService service = new AttendanceService(db);
            return (IEnumerable<AttendanceDto>)service.GetAttendanceByStudentCod(codEstudiante);

        }

        [HttpGet("ClassCod/{classCod}")]
        public IEnumerable<AttendanceDto> GetByClassCod(int classCod)
        {
            AttendanceService service = new AttendanceService(db);
            return (IEnumerable<AttendanceDto>)service.GetAttendanceByClassCod(classCod);
        }

        // POST 
        [HttpPost]
        public AttendanceDto Post(AttendanceRequest asistencia)
        {
            AttendanceService service = new AttendanceService(db);
            return service.AddAttendance(asistencia);
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AttendanceService service = new AttendanceService(db);
            service.DeleteAttendance(id);
        }

    }
}
