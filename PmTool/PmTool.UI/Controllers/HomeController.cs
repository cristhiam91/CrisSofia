using PmTool.DAL.Interfaces;
using PmTool.DAL.Metodos;
using PmTool.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace PmTool.UI.Controllers
{

    public class HomeController : Controller
    {


        IDataCenter dc;
        IOffice off;
        ILab lab;
        IFactory fac;
        IOtherProject other;
        IPhaseType phaType;
        IProjectType proType;
        ISpeedConnectionType speed;
        public HomeController()
        {
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

        public ActionResult ChooseProjects()
        {
            Session["UserType"] = 0;
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewProjecTypes()
        {
            var projectType = proType.ListProjectTypes();
            ViewBag.projectTypeDll = new SelectList(projectType, "Project_type_id", "Project_type_id");
            return View();
        }

        public ActionResult aaa()
        {

            return View();
        }

        public ActionResult IndexTest()
        {

            return View();
        }


        public ActionResult loginB()
        {

            return View();
        }

        //public ActionResult Mis_Proyectos(int user_id)
        //{

        //    MyProjects myProjects = new MyProjects();
        //    //Factories
        //    var listaFactories = fac.SearchFactoryProjectbypm(user_id);
        //    var LFactories = Mapper.Map<List<Models.Factories>>(listaFactories);
        //    myProjects.Factories = LFactories;

        //    //Labs - MEDIO funcional
        //    var listaLabs = lab.SearchLabProjectbypm(user_id);
        //    var LLabs = Mapper.Map<List<Models.Labs>>(listaLabs);
        //    myProjects.Labs = LLabs;

        //    //DataCenter
        //    var listaDataCenter = dc.SearchDataCenterProjectbypm(user_id);
        //    var LDataCenter = Mapper.Map<List<Models.DataCenters>>(listaDataCenter);
        //    myProjects.DataCenters = LDataCenter;

        //    //Office
        //    var listaOffice = off.SearchOfficeProjectbypm(user_id);
        //    var LOffices = Mapper.Map<List<Models.Offices>>(listaOffice);
        //    myProjects.Offices = LOffices;

        //    //OtherProject
        //    var listaOtherProject = other.SearchOtherProjectbypm(user_id);
        //    var LOPs = Mapper.Map<List<Models.OtherProjects>>(listaOtherProject);
        //    myProjects.OtherProjects = LOPs;

        //    return View(myProjects);
        //}
        //public ActionResult MyPMProjects(int user_id = (Int32)Session["TheUserID"])
        //{
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
        //public ActionResult PageBossPM(int user_id = (Int32)Session["TheUserID"])
        //{
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