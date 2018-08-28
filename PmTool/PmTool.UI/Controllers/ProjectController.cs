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
    public class ProjectController : Controller
    {
        // GET: Project
        IDataCenter dc;
        IOffice off;
        ILab lab;
        IFactory fac;
        IOtherProject other;
        IPhaseType phaType;
        IProjectType proType;
        ISpeedConnectionType speed;
        public ProjectController()
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
        public ActionResult NoLoginCreateProject()
        {
            return View();
        }


        public ActionResult Index()
        {
            var projectType = proType.ListProjectTypes();
            ViewBag.projectTypeDll = new SelectList(projectType, "Project_type_id", "Project_type_name");
            return View();
        }


    }
}