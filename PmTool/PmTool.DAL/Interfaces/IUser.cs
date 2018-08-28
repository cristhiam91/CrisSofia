using PmTool.DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmTool.DATA;

namespace PmTool.DAL.Interfaces
{
    public interface IUser 
    {
        List<Users> ListUsers();
        void AddUser(Users user);
        void CreatedUserAccountSentEmail(string email, string name);
        Users SearchUser(int userId);

        void EditUser(Users user);
        void DeleteUser(int userId);
        bool UserLogin(int userId, string userPassword);
    }

   
}
