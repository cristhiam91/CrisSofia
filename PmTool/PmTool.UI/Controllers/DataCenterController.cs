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
    public class DataCenterController : Controller
    {
        IDataCenter dc;
        IProjectType proType;
        IPhaseType phaseType;
        ISpeedConnectionType speedType;
        IDcScope dcScope;
        public DataCenterController()
        {
            dc = new MDataCenter();
            proType = new MProjectType();
            phaseType = new MPhaseType();
            speedType = new MSpeedConnectionType();
            dcScope = new MDcScope();


        }

        public ActionResult Index()
        {
            var listProjects = dc.ListDataCenters();
            var listOfProjectsShow = Mapper.Map<List<Models.DataCenters>>(listProjects);
            return View(listOfProjectsShow);
        }

        public ActionResult AdminIdex()
        {
            var listProjects = dc.ListDataCenters();
            var listOfProjectsShow = Mapper.Map<List<Models.DataCenters>>(listProjects);
            return View(listOfProjectsShow);
        }

        public ActionResult CreateDataCenterProject()
        {

            var listProjectType = proType.ListProjectTypes();
            ViewBag.listProjectTypeDll = new SelectList(listProjectType, "Project_type_id", "Project_type_name");

            var listPhaseTypes = phaseType.ListPhaseTypes();
            ViewBag.listPhaseTypesDll = new SelectList(listPhaseTypes, "Phase_id", "Phase_name");

            var listSpeedConnectionsTypes = speedType.ListSpeedConnectionTypes();
            ViewBag.listSpeedConnectionsTypesDll = new SelectList(listSpeedConnectionsTypes, "Speed_connection_id", "Speed_connection_name");

            var listDcScopes = dcScope.ListDataCenterScopes();
            ViewBag.listDcScopesDll = new SelectList(listDcScopes, "Dc_scope_id", "Dc_scope_name");

            return View();
        }
        /// <summary>
        /// /Create a laboratory project, it gets a laboratory object and add it in the database
        /// </summary>
        /// <param name="laboratory"></param>
        /// <returns>Returns the CreateLabProject view </returns>
        [HttpPost]
        public ActionResult CreateDataCenterProject(DataCenters dataCenters)
        {
            var listProjectType = proType.ListProjectTypes();
            ViewBag.listProjectTypeDll = new SelectList(listProjectType, "Project_type_id", "Project_type_name");

            var listPhaseTypes = phaseType.ListPhaseTypes();
            ViewBag.listPhaseTypesDll = new SelectList(listPhaseTypes, "Phase_id", "Phase_name");

            var listSpeedConnectionsTypes = speedType.ListSpeedConnectionTypes();
            ViewBag.listSpeedConnectionsTypesDll = new SelectList(listSpeedConnectionsTypes, "Speed_connection_id", "Speed_connection_name");

            var listDcScopes = dcScope.ListDataCenterScopes();
            ViewBag.listDcScopesDll = new SelectList(listDcScopes, "Dc_scope_id", "Dc_scope_name");

            if (dataCenters.DataCenter_requestor_id!=null) {

                    //Changes the lab project null to 4=DataCenter
                    dataCenters.Project_type = 4;
                    try
                    {
                        if (!ModelState.IsValid)
                        {
                            return View();
                        }

                        var dcToAdd = Mapper.Map<DATA.DataCenters>(dataCenters);
                        dc.AddDataCenter(dcToAdd);
                    int x = (Int32)Session["UserType"];
                    switch (x)
                    {
                        case 1:
                            return RedirectToAction("PmProjects", "User");
                        case 2:
                            return RedirectToAction("UserMyProjects", "User");
                        case 3:
                            return RedirectToAction("Index", "DataCenter");
                        case 4:
                            return RedirectToAction("Index", "DataCenter");
                        default:
                            return RedirectToAction("Index", "Home");
                    }
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
        public ActionResult EditDataCenterProject(int id)
        {
            var datac = dc.SearchDataCenterProject(id);
            var datacShow = Mapper.Map<Models.DataCenters>(datac);
            return View(datacShow);
        }
        [HttpPost]
        public ActionResult EditDataCenterProject(DataCenters datac)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var updateDataCenterProject = Mapper.Map<DATA.DataCenters>(datac);
                dc.UpdateDataCenterProject(updateDataCenterProject);
                //return RedirectToAction("Index", "Home");
                int x = (Int32)Session["UserType"];
                switch (x)
                {
                    case 1:
                        return RedirectToAction("PmProjects", "User");
                    case 2:
                        return RedirectToAction("UserMyProjects", "User");
                    case 3:
                        return RedirectToAction("Index", "DataCenter");
                    case 4:
                        return RedirectToAction("Index", "DataCenter");
                    default:
                        return RedirectToAction("Index", "Home");
                }

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            dc.DeleteDataCenterProject(id);
            int x = (Int32)Session["UserType"];
            switch (x)
            {
                case 1:
                    return RedirectToAction("PmProjects", "User");
                case 2:
                    return RedirectToAction("UserMyProjects", "User");
                case 3:
                    return RedirectToAction("Index", "DataCenter");
                case 4:
                    return RedirectToAction("Index", "DataCenter");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DetailsDataCenterProject(int id)
        {
            var datac = dc.SearchDataCenterProject(id);
            var datacShow = Mapper.Map<Models.DataCenters>(datac);
            return View(datacShow);
        }  

        public ActionResult DataCentersData()
        {
            List<Double> ListDataCenterProjectsCost = new List<double>();
            var listDataCenterProjects = dc.ListDataCenters();
            var listOfDataCentersProjectsShow = Mapper.Map<List<Models.DataCenters>>(listDataCenterProjects);
            var cost = listDataCenterProjects.Select(x => x.Project_budget).Distinct();

            foreach (var item in cost)
            {
                ListDataCenterProjectsCost.Add(listDataCenterProjects.Count(x => x.Project_budget == item));

            }

            var rep = ListDataCenterProjectsCost;
            ViewBag.BUDGET = cost;
            ViewBag.REP = ListDataCenterProjectsCost.ToList();
            return View();
        }
    }
}