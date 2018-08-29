using PmTool.DAL.Interfaces;
using PmTool.DAL.Metodos;
using PmTool.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Net;

namespace PmTool.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        IUser user;
        IUserType uType;
        IDataCenter dc;
        IOffice off;
        ILab lab;
        IFactory fac;
        IOtherProject other;
        IPhaseType phaType;
        IProjectType proType;
        ISpeedConnectionType speed;
        public UserController()
        {
            user = new MUser();
            uType = new MUserType();
            dc = new MDataCenter();
            off = new MOffice();
            lab = new MLab();
            fac = new MFactory();
            other = new MOtherProject();
            phaType = new MPhaseType();
            proType = new MProjectType();
            speed = new MSpeedConnectionType();
        }
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult PmManagerConsole()
        {
            return View();
        }
        public ActionResult AdminConsole()
        {
            return View();
        }

        public ActionResult UserDetails(int userId)
        {
            var usertoSearch = user.SearchUser(userId);
            var usersToShow = Mapper.Map<Models.Users>(usertoSearch);
            return View(usersToShow);
        }
        public ActionResult MyAccount()
        {
            int userId = (Int32)Session["TheUserID"];
            var usertoSearch = user.SearchUser(userId);
            var usersToShow = Mapper.Map<Models.Users>(usertoSearch);
            return View(usersToShow);
        }
        [HttpPost]
        public ActionResult MyAccount(Users users)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var editMyAccout = Mapper.Map<DATA.Users>(user);
                user.EditUser(editMyAccout);
                return RedirectToAction("MyAccount");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult UserProfileManagement()
        {
            var users = user.ListUsers();
            var usersToShow = Mapper.Map<List<Models.Users>>(users);
            return View(usersToShow);
        }

        public ActionResult UsersId()
        {
            var usuario = user.ListUsers();
            ViewBag.usuarioDll = new SelectList(usuario, "User_id", "User_name");
            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Users users)
        {
            if (users.User_id!=0)
            {
                Session["TheUserID"] = users.User_id;
                var userToValidate = user.UserLogin(users.User_id, users.User_password);

                if (userToValidate == true)
                {
                    var userSearch = user.SearchUser(users.User_id);
                    Session["UserType"] = userSearch.User_type;
                    var userValue = user.SearchUser(users.User_id);
                    switch (userValue.User_type)
                    {
                        case 1:
                            return RedirectToAction("PmProjects");
                        case 2:
                            return RedirectToAction("UserMyProjects");
                        case 3:
                            return RedirectToAction("AdminConsole");
                        case 4:
                            return RedirectToAction("PmManagerConsole");
                        default:
                            return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult CreateMyAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMyAccount(Users users)
        {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return View();
                    }
                    
                    var userToAdd = Mapper.Map<DATA.Users>(users);
                    userToAdd.User_type = 2;
                    user.AddUser(userToAdd);
                    user.CreatedUserAccountSentEmail(users.User_email, users.User_name);
                    return RedirectToAction("Index","Home");
                }
            catch (Exception ex)
                {

                    throw ex;
                }   
        }
        [HttpPost]
        public ActionResult CreateAccount(Users users)
        {
            var listUserTypes = uType.ListUserTypes();
            ViewBag.listUserTypesDll = new SelectList(listUserTypes, "User_type_id", "User_type_name");

            if (users.User_name != null)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return View();
                    }

                    var userToAdd = Mapper.Map<DATA.Users>(users);
                    user.AddUser(userToAdd);
                    //user.CreatedUserAccountSentEmail(users.User_email,users.User_name);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult CreateUserAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserAccount(Users users)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var userToAdd = Mapper.Map<DATA.Users>(users);
                user.AddUser(userToAdd);
                user.CreatedUserAccountSentEmail(users.User_email, users.User_name);
                return RedirectToAction("UserProfileManagement");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult EditUserAccount(int userId)
        {
            var usertoSearch = user.SearchUser(userId);
            var usersToShow = Mapper.Map<Models.Users>(usertoSearch);
            return View(usersToShow);
        }
        [HttpPost]
        public ActionResult EditUserAccount(Users users)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var userToEdit = Mapper.Map<DATA.Users>(user);
                user.EditUser(userToEdit);
                return RedirectToAction("UserProfileManagement");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteUserAccount(int userId)
        {

            try
            {
                user.DeleteUser(userId);
                return RedirectToAction("UserProfileManagement");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult UserMyProjects()
        {
            int user_id = (Int32)Session["TheUserID"];
            MyPMProjects myPMProjects = new MyPMProjects();
            //Factories
            var listaFactories = fac.SearchFactoryByAssignedPm(user_id);
            var LFactories = Mapper.Map<List<Models.Factories>>(listaFactories);
            myPMProjects.Factories = LFactories;

            //Labs - MEDIO funcional
            var listaLabs = lab.SearchLabProjectbypm(user_id);
            var LLabs = Mapper.Map<List<Models.Labs>>(listaLabs);
            myPMProjects.Labs = LLabs;

            //DataCenter
            var listaDataCenter = dc.SearchDataCenterProjectbypm(user_id);
            var LDataCenter = Mapper.Map<List<Models.DataCenters>>(listaDataCenter);
            myPMProjects.DataCenters = LDataCenter;

            //Office
            var listaOffice = off.SearchOfficeProjectbypm(user_id);
            var LOffices = Mapper.Map<List<Models.Offices>>(listaOffice);
            myPMProjects.Offices = LOffices;

            //OtherProject
            var listaOtherProject = other.SearchOtherProjectbypm(user_id);
            var LOPs = Mapper.Map<List<Models.OtherProjects>>(listaOtherProject);
            myPMProjects.OtherProjects = LOPs;

            return View(myPMProjects);
        }

        public ActionResult PmProjects()
        {
            int user_id = (Int32)Session["TheUserID"];

            MyPMProjects myPMProjects = new MyPMProjects();
            //Factories
            var listaFactories = fac.SearchFactoryByAssignedPm(user_id);
            var LFactories = Mapper.Map<List<Models.Factories>>(listaFactories);
            myPMProjects.Factories = LFactories;

            //Labs - MEDIO funcional
            var listaLabs = lab.SearchLabProjectByAssignedPm(user_id);
            var LLabs = Mapper.Map<List<Models.Labs>>(listaLabs);
            myPMProjects.Labs = LLabs;

            //DataCenter
            var listaDataCenter = dc.SearchDataCenterByAssignedPm(user_id);
            var LDataCenter = Mapper.Map<List<Models.DataCenters>>(listaDataCenter);
            myPMProjects.DataCenters = LDataCenter;

            //Office
            var listaOffice = off.SearchOfficeProjectByAssignedPm(user_id);
            var LOffices = Mapper.Map<List<Models.Offices>>(listaOffice);
            myPMProjects.Offices = LOffices;

            //OtherProject
            var listaOtherProject = other.SearchOtherProjectByAssignedPm(user_id);
            var LOPs = Mapper.Map<List<Models.OtherProjects>>(listaOtherProject);
            myPMProjects.OtherProjects = LOPs;

            return View(myPMProjects);
        }
        //public ActionResult MyPMProjects()
        //{
        //    int user_id = (Int32)Session["TheUserID"];
        //    MyPMProjects myPMProjects = new MyPMProjects();
        //    //Factories
        //    var listaFactories = fac.SearchFactoryProjectbypm(user_id);
        //    var LFactories = Mapper.Map<List<Models.Factories>>(listaFactories);
        //    myPMProjects.Factories = LFactories;

        //    //Labs - MEDIO funcional
        //    var listaLabs = lab.SearchLabProjectbypm(user_id);
        //    var LLabs = Mapper.Map<List<Models.Labs>>(listaLabs);
        //    myPMProjects.Labs = LLabs;

        //    //DataCenter
        //    var listaDataCenter = dc.SearchDataCenterProjectbypm(user_id);
        //    var LDataCenter = Mapper.Map<List<Models.DataCenters>>(listaDataCenter);
        //    myPMProjects.DataCenters = LDataCenter;

        //    //Office
        //    var listaOffice = off.SearchOfficeProjectbypm(user_id);
        //    var LOffices = Mapper.Map<List<Models.Offices>>(listaOffice);
        //    myPMProjects.Offices = LOffices;

        //    //OtherProject
        //    var listaOtherProject = other.SearchOtherProjectbypm(user_id);
        //    var LOPs = Mapper.Map<List<Models.OtherProjects>>(listaOtherProject);
        //    myPMProjects.OtherProjects = LOPs;

        //    return View(myPMProjects);
        //}

        //public ActionResult PageBossPM()
        //{
        //    int user_id = (Int32)Session["TheUserID"];
        //    PageBossPM pageBossPM = new PageBossPM();
        //    //Factories
        //    var listaFactories = fac.SearchFactoryProjectbypm(user_id);
        //    var LFactories = Mapper.Map<List<Models.Factories>>(listaFactories);
        //    pageBossPM.Factories = LFactories;

        //    //Labs - MEDIO funcional
        //    var listaLabs = lab.SearchLabProjectbypm(user_id);
        //    var LLabs = Mapper.Map<List<Models.Labs>>(listaLabs);
        //    pageBossPM.Labs = LLabs;

        //    //DataCenter
        //    var listaDataCenter = dc.SearchDataCenterProjectbypm(user_id);
        //    var LDataCenter = Mapper.Map<List<Models.DataCenters>>(listaDataCenter);
        //    pageBossPM.DataCenters = LDataCenter;

        //    //Office
        //    var listaOffice = off.SearchOfficeProjectbypm(user_id);
        //    var LOffices = Mapper.Map<List<Models.Offices>>(listaOffice);
        //    pageBossPM.Offices = LOffices;

        //    //OtherProject
        //    var listaOtherProject = other.SearchOtherProjectbypm(user_id);
        //    var LOPs = Mapper.Map<List<Models.OtherProjects>>(listaOtherProject);
        //    pageBossPM.OtherProjects = LOPs;

        //    return View(pageBossPM);
        //}
    }
}