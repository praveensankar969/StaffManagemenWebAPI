using StaffManagement.DTO;

namespace StaffManagement.Interface{

public interface ITokenInterface{
    string CreateToken(LogonDTO logon);
 }

}