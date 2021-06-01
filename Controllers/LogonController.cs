using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.DTO;
using StaffManagement.Models;
using Microsoft.EntityFrameworkCore;
using StaffManagement.Interface;

namespace StaffManagement.Controllers{
    [ApiController]
    [Route("api/[controller]/logon")]
    public class AccountController : ControllerBase{
        private readonly StaffContext context;
        private readonly ITokenInterface tokenInterface;

        public AccountController(StaffContext context, ITokenInterface tokenInterface){
            this.context = context;
            this.tokenInterface = tokenInterface;
        }
    
        [HttpPost("logon")]
        public async Task<ActionResult<string>> Login(LogonDTO logon){
            var user = await context.Staffs.AnyAsync(x=> x.UserName == logon.UserName);
            if(!user){
                return BadRequest("Invalid Username or Password");
            }
            return tokenInterface.CreateToken(logon);
        }

    }
}