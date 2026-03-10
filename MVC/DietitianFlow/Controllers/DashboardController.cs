
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DietitianFlow.Helpers;
using DietitianFlowManuelMethods;
using DietitianFlow.Views.Dashboard;
using DietitianFlow.Filters;
using DietitianFlow.Services;

namespace DietitianFlow.Controllers
{
    [AdminAuthentication]
    public class DashboardController : Controller
    {
        private readonly DashboardService _dashboardService;
        public DashboardController()
        {
            _dashboardService = new DashboardService();
        }
        public ActionResult Index()
        {
            
            var activeDietitian = SessionHelper.GetActiveDietitian(Session);
            if (activeDietitian ==null)
            {
                return RedirectToAction("Login", "Login");
            }
            var model = _dashboardService.BuildDashboard(activeDietitian.DietitianID);
            return View(model);
        }
    }
}