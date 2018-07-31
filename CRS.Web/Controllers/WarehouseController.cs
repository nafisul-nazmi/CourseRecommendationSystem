using CRS.BLL.Interfaces;
using CRS.Entity.Models;
using CRS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRS.Web.Controllers
{
    public class WarehouseController : AdminSecuredController
    {
        private IWarehouseService warehouseService;
        private ICourseService courseService;
        private readonly List<string> excludeProperties = new List<string>
        {
            "Id",
            "PerviousCGPA",
            "NextCGPA"
        };

        public WarehouseController(IWarehouseService warehouseService, ICourseService courseService)
        {
            this.warehouseService = warehouseService;
            this.courseService = courseService;
        }

        // GET: Warehouse
        public ActionResult Index()
        {
            List<WarehouseViewModel> warehouseViewModels = new List<WarehouseViewModel>();
            IEnumerable<Warehouse> warehouses = warehouseService.GetAll();

            foreach (Warehouse warehouse in warehouses)
            {
                List<string> allCourseProperties = warehouse.GetType().GetProperties().Select(x => x.Name).Except(excludeProperties).ToList();
                List<string> selectedCourses = new List<string>();
                foreach(string courseName in allCourseProperties)
                {
                    var value = warehouse.GetType().GetProperty(courseName).GetValue(warehouse, null);
                    if (value != null && value.Equals(true))
                    {
                        selectedCourses.Add(courseName);
                    }
                }
                WarehouseViewModel warehouseViewModel = new WarehouseViewModel
                {
                    Warehouse = warehouse,
                    SelectedCourses = selectedCourses
                };
                warehouseViewModels.Add(warehouseViewModel);
            }
            return View(warehouseViewModels);
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int id)
        {
            Warehouse warehouse = warehouseService.Get(id);
            List<string> allCourseProperties = warehouse.GetType().GetProperties().Select(x => x.Name).Except(excludeProperties).ToList();
            List<string> selectedCourses = new List<string>();
            foreach (string courseName in allCourseProperties)
            {
                var value = warehouse.GetType().GetProperty(courseName).GetValue(warehouse, null);
                if (value != null && value.Equals(true))
                {
                    selectedCourses.Add(courseName);
                }
            }
            WarehouseViewModel warehouseViewModel = new WarehouseViewModel
            {
                Warehouse = warehouse,
                SelectedCourses = selectedCourses
            };
            return View(warehouseViewModel);
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            WarehouseViewModel warehouseViewModel = new WarehouseViewModel
            {
                Warehouse = new Warehouse(),
                AllCourses = courseService.GetAll()
            };
            return View(warehouseViewModel);
        }

        // POST: Warehouse/Create
        [HttpPost]
        public ActionResult Create(WarehouseViewModel warehouseViewModel)
        {
            Warehouse warehouse = warehouseViewModel.Warehouse;
            foreach(string course in warehouseViewModel.SelectedCourses)
            {
                warehouse.GetType().GetProperty(course).SetValue(warehouse, true, null);
            }
            try
            {
                warehouseService.Add(warehouse);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(warehouseViewModel);
            }
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int id)
        {
            Warehouse warehouse = warehouseService.Get(id);
            List<string> allCourseProperties = warehouse.GetType().GetProperties().Select(x => x.Name).Except(excludeProperties).ToList();
            List<string> selectedCourses = new List<string>();
            foreach (string courseName in allCourseProperties)
            {
                var value = warehouse.GetType().GetProperty(courseName).GetValue(warehouse, null);
                if (value != null && value.Equals(true))
                {
                    selectedCourses.Add(courseName);
                }
            }
            WarehouseViewModel warehouseViewModel = new WarehouseViewModel
            {
                Warehouse = warehouse,
                SelectedCourses = selectedCourses
            };
            return View(warehouseViewModel);
        }

        // POST: Warehouse/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Warehouse warehouse = warehouseService.Get(id);
            try
            {
                warehouseService.Delete(warehouse);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(warehouse);
            }
        }
    }
}
