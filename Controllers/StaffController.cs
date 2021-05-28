using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.DTO;
using StaffManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace StaffManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController{
        private readonly StaffContext _context;

        public StaffController(StaffContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllStaff(){
            return await _context.Staffs.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id){
            return await _context.Staffs.FindAsync(id);
        }
        
    }
}