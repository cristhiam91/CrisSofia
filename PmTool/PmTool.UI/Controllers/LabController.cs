using PmTool.DAL.Interfaces;
using PmTool.DAL.Metodos;
using PmTool.UI.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;


namespace PmTool.UI.Controllers
{
    public class LabController : Controller
    {
        // GET: Lab
        ILab lab;
        IProjectType proType;
        IPhaseType phaseType;
        ISpeedConnectionType speedType;
        ILabScope labScop;
        public LabController()
        {
            lab = new MLab();
            proType = new MProjectType();
            phaseType = new MPhaseType();
            speedType = new MSpeedConnectionType();
            labScop = new MLabScope();
        }

        public ActionResult Index()
        {
            int userType = (Int32)Session["UserType"];
            int userId = (Int32)Session["TheUserID"];
            var listProjects = lab.ListLabs();
            var listOfProjectsShow = Mapper.Map<List<Models.Labs>>(listProjects);
            return View(listOfProjectsShow);
        }

        public ActionResult AdminIndex()
        {
            var listProjects = lab.ListLabs();
            var listOfProjectsShow = Mapper.Map<List<Models.Labs>>(listProjects);
            return View(listOfProjectsShow);
        }

        public ActionResult NoLoginCreateProject()
        {
            return View();
        }




        /// <summary>
        /// Add all the dropdown views in CreateLabProject view when the view loads
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult CreateLabProject()
        {
        
            var listProjectType = proType.ListProjectTypes();
            ViewBag.listProjectTypeDll = new SelectList(listProjectType, "Project_type_id", "Project_type_name");

            var listPhaseTypes = phaseType.ListPhaseTypes();
            ViewBag.listPhaseTypesDll = new SelectList(listPhaseTypes, "Phase_id", "Phase_name");

            var listSpeedConnectionsTypes = speedType.ListSpeedConnectionTypes();
            ViewBag.listSpeedConnectionsTypesDll = new SelectList(listSpeedConnectionsTypes, "Speed_connection_id", "Speed_connection_name");

            var listLabScopes = labScop.ListLabScopes();
            ViewBag.listLabScopesDll = new SelectList(listLabScopes, "Lab_scope_id", "Lab_scope_name");


            return View();
        }
        /// <summary>
        /// /Create a laboratory project, it gets a laboratory object and add it in the database
        /// </summary>
        /// <param name="laboratory"></param>
        /// <returns>Returns the CreateLabProject view </returns>
        [HttpPost]
        public ActionResult CreateLabProject(Labs laboratory)
        {

            var listProjectType = proType.ListProjectTypes();
            ViewBag.listProjectTypeDll = new SelectList(listProjectType, "Project_type_id", "Project_type_name");

            var listPhaseTypes = phaseType.ListPhaseTypes();
            ViewBag.listPhaseTypesDll = new SelectList(listPhaseTypes, "Phase_id", "Phase_name");

            var listSpeedConnectionsTypes = speedType.ListSpeedConnectionTypes();
            ViewBag.listSpeedConnectionsTypesDll = new SelectList(listSpeedConnectionsTypes, "Speed_connection_id", "Speed_connection_name");

            var listLabScopes = labScop.ListLabScopes();
            ViewBag.listLabScopesDll = new SelectList(listLabScopes, "Lab_scope_id", "Lab_scope_name");

            if (laboratory.Lab_requestor_id!=null)
            {
                //Changes the lab project null to 2=Laboratory
                laboratory.Project_type = 2;
                try 
                {
                    if (!ModelState.IsValid)
                    {
                        return View();
                    }

                    var labToAdd = Mapper.Map<DATA.Labs>(laboratory);
                    lab.AddLabs(labToAdd);
                    return RedirectToAction("CreateLabProject");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else {

                return View();
            }

        }
        public ActionResult EditLabProject(int id)
        {
            int userType = (Int32)Session["UserType"];
            var labs = lab.SearchLabProject(id);
            var labsShow = Mapper.Map<Models.Labs>(labs);
            return View(labsShow);
        }
        [HttpPost]
        public ActionResult EditLabProject(Labs labs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                int userType=(Int32)Session["UserType"];
                var updateLabProject = Mapper.Map<DATA.Labs>(labs);
                lab.UpdateLabProject(updateLabProject);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            lab.DeleteLabProject(id);
            return View();
        }

        public ActionResult DetailsLabProject(int id)
        {
            var labs = lab.SearchLabProject(id);
            var labsShow = Mapper.Map<Models.Labs>(labs);
            return View(labsShow);
        }

        public ActionResult AssignLabProject(int id)
        {
            var labs = lab.SearchLabProject(id);
            var labsShow = Mapper.Map<Models.Labs>(labs);
            return View(labsShow);
        }
        [HttpPost]
        public ActionResult AssignLabProject(Labs labs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var updateLabProject = Mapper.Map<DATA.Labs>(labs);
                lab.UpdateLabProject(updateLabProject);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LabsData()
        {
            List<Double> ListProjectsCost = new List<double>();
            List<string> LabNames = new List<string>();
            var listProjects = lab.ListLabs();
            var listOfProjectsShow = Mapper.Map<List<Models.Labs>>(listProjects);
            var cost = listProjects.Select(x => x.Project_budget).Distinct();

            foreach (var item in cost)
            {
                ListProjectsCost.Add(listProjects.Count(x => x.Project_budget == item));
          
            }

            var rep = ListProjectsCost;
            ViewBag.BUDGET = cost;
            ViewBag.REP = ListProjectsCost.ToList();
            return View();
        }


    }
}