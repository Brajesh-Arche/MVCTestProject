using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Authorize]
    public class OrganizationController : Controller
    {
        MVCTestEntities2 db = new MVCTestEntities2();
        // GET: Organization
        public ActionResult Dashboard()
        {
            DashViewModel model = new DashViewModel()
            {
                id=db.Orgnization_Table.Count()
            };
            
            return View(model);
        }
        public ActionResult Index()
        {

            List<OrgViewModel> OrgList = (from o in db.Orgnization_Table
                                          join ct in db.City_Table on o.CityId equals ct.CityId
                                          join s in db.State_Table on o.StateId equals s.StateId
                                          join c in db.Country_Table on o.CountryId equals c.CountryId

                                          select new { s, c, ct, o }).ToList().Select(x => new OrgViewModel
                                          {
                                              CountryId = x.o.CountryId,
                                              CountryName = x.c.CountryName,
                                              StateId = x.o.StateId,
                                              StateName = x.s.StateName,
                                              CityId = x.o.CityId,
                                              CityName = x.ct.CityName,
                                              OrgId = x.o.OrganizationId,
                                              OrganizationName = x.o.OrganizationName,
                                              Website = x.o.Website,
                                              Specialities = x.o.Specialities,
                                              NoOFEmployee = x.o.NoOFEmployee,
                                              Addresss = x.o.Addresss,
                                              OfficePhone = x.o.OfficePhone,
                                              MobileNo = x.o.MobileNo,
                                              LinkedinURL = x.o.LinkedinURL
                                          }).ToList();

            return View(OrgList);
        }
        public ActionResult AddOrg()
        {
            var context = db.Country_Table.Select(x => new SelectListItem { Text = x.CountryName, Value = x.CountryId.ToString() }).ToList();
            List<SelectListItem> list = new List<SelectListItem>().ToList();
            ViewBag.countryList = context;
            var cont = db.State_Table.Select(x => new SelectListItem { Text = x.StateName, Value = x.StateId.ToString() }).ToList();
            List<SelectListItem> list1 = new List<SelectListItem>().ToList();
            ViewBag.statelist = cont;
            var cont2 = db.City_Table.Select(x => new SelectListItem { Text = x.CityName, Value = x.CityId.ToString() }).ToList();
            List<SelectListItem> list2 = new List<SelectListItem>().ToList();
            ViewBag.CityLst = cont2;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrg(OrgModel model)
        {
            if (ModelState.IsValid)
            {
                Orgnization_Table tbl = new Orgnization_Table();
                tbl.OrganizationName = model.OrganizationName;
                tbl.Website = model.Website;
                tbl.Specialities = model.Specialities;
                tbl.NoOFEmployee = model.NoOFEmployee;
                tbl.Addresss = model.Addresss;
                tbl.CountryId = model.CountryId;
                tbl.StateId = model.StateId;
                tbl.CityId = model.CityId;
                tbl.OfficePhone = model.OfficePhone;
                tbl.MobileNo = model.MobileNo;
                tbl.LinkedinURL = model.LinkedinURL;
                db.Orgnization_Table.Add(tbl);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult EditOrg(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tbl = db.Orgnization_Table.Find(id);
            if (tbl == null)
            {
                return HttpNotFound();
            }
            var context = db.Country_Table.Select(x => new SelectListItem { Text = x.CountryName, Value = x.CountryId.ToString() }).ToList();
            List<SelectListItem> list = new List<SelectListItem>().ToList();
            ViewBag.countryList = context;
            var cont = db.State_Table.Select(x => new SelectListItem { Text = x.StateName, Value = x.StateId.ToString() }).ToList();
            List<SelectListItem> list1 = new List<SelectListItem>().ToList();
            ViewBag.statelist = cont;
            var cont2 = db.City_Table.Select(x => new SelectListItem { Text = x.CityName, Value = x.CityId.ToString() }).ToList();
            List<SelectListItem> list2 = new List<SelectListItem>().ToList();
            ViewBag.CityLst = cont2;
            return View(tbl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrg(Orgnization_Table model)
        {

            Orgnization_Table tbl = db.Orgnization_Table.Find(model.OrganizationId);
            if (tbl != null)
            {
                if (ModelState.IsValid)
                {
                    tbl.OrganizationName = model.OrganizationName;
                    tbl.Website = model.Website;
                    tbl.Specialities = model.Specialities;
                    tbl.NoOFEmployee = model.NoOFEmployee;
                    tbl.Addresss = model.Addresss;
                    tbl.CountryId = model.CountryId;
                    tbl.StateId = model.StateId;
                    tbl.CityId = model.CityId;
                    tbl.OfficePhone = model.OfficePhone;
                    tbl.MobileNo = model.MobileNo;
                    tbl.LinkedinURL = model.LinkedinURL;
                    db.Entry(tbl).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();

        }
        public ActionResult DeleteOrg(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orgnization_Table tbl = db.Orgnization_Table.Find(id);
            if (tbl == null)
            {
                return HttpNotFound();
            }
            db.Orgnization_Table.Remove(tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}