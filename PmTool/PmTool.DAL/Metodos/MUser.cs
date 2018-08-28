using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmTool.DATA;
using ServiceStack.OrmLite;
using PmTool.DAL.Interfaces;
using System.Net.Mail;

namespace PmTool.DAL.Metodos
{
    public class MUser : MBase, IUser
    {

        public List<Users> ListUsers()
        {
            return _db.Select<Users>();

        }

        public void AddUser(Users user)
        {
            try
            {
                _db.Insert(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public bool UserLogin(int userId, string userPassword)
        {
            var userTOsearch = _db.Select<Users>(x => x.User_id == userId && x.User_password == userPassword).FirstOrDefault();
            if (userTOsearch != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreatedUserAccountSentEmail(string email, string name)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("progra4545@gmail.com", "fidelitas123");
                MailMessage mm = new MailMessage("donotreply@domain.com", email, "Pm tool cuenta creada con exito", "Hola " + name + ", su cuenta fue creada con exito.");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.Send(mm);
            }
            catch (Exception ex)
            {

                throw ex;
            }

 
        }

        public Users SearchUser(int userId)
        {
            try
            {
                return _db.Select<Users>(x => x.User_id == userId).FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EditUser(Users user)
        {
            try
            {
                _db.Update(user);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                _db.Delete<Users>(x => x.User_id == userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }
    }
}
