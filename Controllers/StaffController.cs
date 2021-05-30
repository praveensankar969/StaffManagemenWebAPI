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
    public class StaffController : ControllerBase
    {
        private readonly StaffContext _context;

        public StaffController(StaffContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllStaff()
        {
            return await _context.Staffs.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            return await _context.Staffs.FindAsync(id);
        }

        [HttpPost("addStaff")]
        public async Task<ActionResult<string>> AddStaffDetails(Staff userDetail)
        {
            _context.Staffs.Add(userDetail);
            await _context.SaveChangesAsync();
            return "Data add Suceess";
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<string>> UpdateStaffDetail(StaffUpdateDTO staffDTO)
        {
            var staff = await _context.Staffs.FindAsync(staffDTO.Id);
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
                default:
                    {
                        break;
                    }
            }

            await _context.SaveChangesAsync();
            return "Update Success";
        }

    }
}