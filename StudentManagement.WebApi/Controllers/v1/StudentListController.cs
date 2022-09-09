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
    public class StudentListController : ControllerBase
    {
        private readonly IStudent_ListService _studentListService;
        public StudentListController(IStudent_ListService studentListService)
        {
            _studentListService = studentListService;
        }

        //endpoints

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentListRes_Dto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                List<StudentListRes_Dto> studentList = await _studentListService.GetAllWithInclude();

                if (studentList == null || studentList.Count == 0)
                {
                    return NotFound();
                }

                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentListRes_Dto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                List<StudentListRes_Dto> studentList = await _studentListService.GetAllWithInclude();
                StudentListRes_Dto student = new();

                foreach (var item in studentList)
                {
                    if (item.Id == id)
                    {
                        student = item;
                        break;
                    }
                }

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
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
        public async Task<ActionResult> Add(Student_List_Dto newList)
        {
            try
            {
                if (newList.StudentId == 0)
                {
                    return BadRequest();
                }
                await _studentListService.AddAsync(newList);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student_List_Dto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(int id, Student_List_Dto updateList)
        {
            try
            {
                if (updateList.StudentId == 0)
                {
                    return BadRequest();
                }
                await _studentListService.UpdateAsync(updateList, id);
                return Ok(updateList);
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
                await _studentListService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
