using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Core.Application.Dtos;
using StudentManagement.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentSubjectController : ControllerBase
    {
        private readonly IStudent_SubjectService _student_SubjectService;
        public StudentSubjectController(IStudent_SubjectService student_SubjectService)
        {
            _student_SubjectService = student_SubjectService;
        }

        //endpoints

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentSubjectRes_Dto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                List<StudentSubjectRes_Dto> studentSubjects = await _student_SubjectService.GetAllWithInclude();

                if (studentSubjects == null || studentSubjects.Count == 0)
                {
                    return NotFound();
                }
                
                return Ok(studentSubjects);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentSubjectRes_Dto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                List<StudentSubjectRes_Dto> studentSubjects = await _student_SubjectService.GetAllWithInclude();

                StudentSubjectRes_Dto studentSubject = new();
                foreach (var item in studentSubjects)
                {
                    if (item.Id == id)
                    {
                        studentSubject = item;
                        break;
                    }
                }

                if (studentSubject == null)
                {
                    return NotFound();
                }

                return Ok(studentSubject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Add(Student_Subject_Dto studentSubject)
        {
            try
            {
                if (studentSubject.StudentId == 0 || studentSubject.StudentId == 0)
                {
                    return BadRequest();
                }
                await _student_SubjectService.AddAsync(studentSubject);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student_Subject_Dto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(int id, Student_Subject_Dto studentSubject)
        {
            try
            {
                if (studentSubject.StudentId == 0 || studentSubject.StudentId == 0)
                {
                    return BadRequest();
                }
                await _student_SubjectService.UpdateAsync(studentSubject, id);
                return Ok(studentSubject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _student_SubjectService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
