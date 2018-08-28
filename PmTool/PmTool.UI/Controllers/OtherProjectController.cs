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
    public class OtherProjectController : Controller
    {
        IOtherProject oProjec;

        public OtherProjectController()
        {
            oProjec = new MOtherProject();
        }

        public ActionResult Index()
        {
            var listProjects = oProjec.ListOtherProjects();
            var listOfProjectsShow = Mapper.Map<List<Models.OtherProjects>>(listProjects);
            return View(listOfProjectsShow);
        }

        public ActionResult AdminIndex()
        {
            var listProjects = oProjec.ListOtherProjects();
            var listOfProjectsShow = Mapper.Map<List<Models.OtherProjects>>(listProjects);
            return View(listOfProjectsShow);
        }




        /// <summary>
        /// Add all the dropdown views in CreateLabProject view when the view loads
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult CreateOtherProject()
        {

            return View();
        }
        /// <summary>
        /// /Create a laboratory project, it gets a laboratory object and add it in the database
        /// </summary>
        /// <param name="laboratory"></param>
        /// <returns>Returns the CreateLabProject view </returns>
        [HttpPost]
        public ActionResult CreateOtherProject(OtherProjects otherProject)
        {
            if (otherProject.Other_requestor_id!= null)
            {
                //Changes the lab project null to 2=Laboratory
                otherProject.Other_projectType = 5;
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return View();
                    }

                    var otherProjectToAdd = Mapper.Map<DATA.OtherProjects>(otherProject);
                    oProjec.AddOtherProject(otherProjectToAdd);
                    return RedirectToAction("CreateOtherProject");
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
        public ActionResult EditOtherProject(int id)
        {
            var other = oProjec.SearchOtherProject(id);
            var otheryShow = Mapper.Map<Models.OtherProjects>(other);
            return View(otheryShow);
        }
        [HttpPost]
        public ActionResult EditOtherProject(OtherProjects other)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var updateOtherProject = Mapper.Map<DATA.OtherProjects>(other);
                oProjec.UpdateOtherProject(updateOtherProject);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            oProjec.DeleteOtherProject(id);
            return View();
        }

        public ActionResult DetailsOtherProject(int id)
        {
            var other = oProjec.SearchOtherProject(id);
            var otheryShow = Mapper.Map<Models.OtherProjects>(other);
            return View(otheryShow);
        }
        public ActionResult AssignOtherProject(int id)
        {
            var other = oProjec.SearchOtherProject(id);
            var otheryShow = Mapper.Map<Models.OtherProjects>(other);
            return View(otheryShow);
        }
        [HttpPost]
        public ActionResult AssignOtherProject(OtherProjects other)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var updateOtherProject = Mapper.Map<DATA.OtherProjects>(other);
                oProjec.UpdateOtherProject(updateOtherProject);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}