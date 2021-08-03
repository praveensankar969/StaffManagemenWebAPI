using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.DTO;
using StaffManagement.Models;
using Microsoft.EntityFrameworkCore;
using StaffManagement.Interface;
using API.Services;

namespace StaffManagement.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase{
        private readonly StaffContext context;
        private readonly ITokenInterface tokenInterface;

        public AccountController(StaffContext context, TokenService tokenInterface){
            this.context = context;
            this.tokenInterface = tokenInterface;
        }
    
        [HttpPost("logon")]
        public async Task<ActionResult<string>> Login(LogonDTO logon){
            var user = await context.Staffs.FirstOrDefaultAsync(x=> x.UserName == logon.UserName);
            if(user == null){
                return BadRequest("No such User exists..!");
            }

            if(user.Password == logon.Password){
                return tokenInterface.CreateToken(logon);
            }
            else{
                return BadRequest("Incorrect Pasword");
            }     
        }

    }
}