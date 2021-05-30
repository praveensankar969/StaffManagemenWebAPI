using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using StaffManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using StaffManagement.DTO;

namespace StaffManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly StaffContext _context;

        public TeacherController(StaffContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAllStaff()
        {
            return await _context.Teachers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetStaff(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        [HttpPost("addStaff")]
        public async Task<ActionResult<string>> AddStaffDetails(Teacher userDetail)
        {
            _context.Teachers.Add(userDetail);
            await _context.SaveChangesAsync();
            return "Data add Suceess";
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<string>> UpdateStaffDetail(TeacherUpdateDTO staffDTO)
        {
            var staff = await _context.Teachers.FindAsync(staffDTO.Id);
            if (staff == null)
            {
                return BadRequest();
            }
            switch (staffDTO.Property)
            {
                case "Username":
                    {
                        staff.UserName = staffDTO.PropertyValue;
                        break;
                    }
                case "Password":
                    {
                        staff.Password = staffDTO.PropertyValue;
                        break;
                    }
                case "Subject":
                    {
                        staff.Subject = staffDTO.PropertyValue;
                        break;
                    }
                case "Experience":
                    {
                        staff.Experience = Convert.ToInt32(staffDTO.PropertyValue);
                        break;
                    }
                case "Phone":
                    {
                        staff.PhoneNumber = staffDTO.PropertyValue;
                        break;
                    }
                case "Date of Joining":
                    {
                        staff.DateOfJoining = staffDTO.PropertyValue;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            await _context.SaveChangesAsync();
            return "Update Success";
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteStaff(int id)
        {
            var staff = await _context.Teachers.FindAsync(id);
            if (staff == null)
            {
                return BadRequest("No such ID");
            }
            _context.Teachers.Remove(staff);
            await _context.SaveChangesAsync();
            return "Delete success";

        }

    }
}