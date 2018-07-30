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
            foreach(Warehouse warehouse in warehouses)
            {
                WarehouseViewModel warehouseViewModel = new WarehouseViewModel
                {
                    Warehouse = warehouse,
                    SelectedCourses = warehouse.GetType().GetProperties().Where(x => x.GetValue(warehouse).Equals(true)).Select(x => x.Name)
                };
                warehouseViewModels.Add(warehouseViewModel);
            }
            return View(warehouseViewModels);
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouse/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Warehouse/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Warehouse/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
