using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class CountryController : Controller
    {
        MVCTestEntities2 db = new MVCTestEntities2();
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCountry(CountryModel model)
        {
            if(ModelState.IsValid)
            {
                Country_Table table = new Country_Table();
                table.CountryName = model.CountryName;
                db.Country_Table.Add(table);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult AddState()
        {
            List<StateViewModel> ListState = (from s in db.State_Table
                                              join c in db.Country_Table on s.CountryId equals c.CountryId
                                              select new { s, c }).ToList().Select(x=>new StateViewModel
                                              {
                                                  CountyryId=x.s.CountryId,
                                                  CountryName=x.c.CountryName,
                                                  StateId=x.s.StateId,
                                                  StateName=x.s.StateName
                                              }).ToList();
            var context=db.Country_Table.Select(x=>new SelectListItem { Text=x.CountryName,Value=x.CountryId.ToString()});
            List<SelectList> list = new List<SelectList>().ToList();
            ViewBag.CountryList = context;
            return View();
        }
        [HttpPost]
        public ActionResult AddState(StateModel model)
        {
            if(ModelState.IsValid)
            {
                State_Table table = new State_Table();
                table.StateName = model.StateName;
                table.CountryId = model.countryId;
                db.State_Table.Add(table);
                db.SaveChanges();
            }
            return View("AddCountry");
        }
        public ActionResult AddCity()
        {
            List<CityViewModel> ListState = (from ct in db.City_Table
                                              join s in db.State_Table on ct.StateId equals s.StateId
                                              join c in db.Country_Table on ct.CountryId equals c.CountryId

                                              select new { s, c,ct }).ToList().Select(x => new CityViewModel
                                              {
                                                  CountyryId = x.ct.CountryId,
                                                  CountryName = x.c.CountryName,
                                                  StateId = x.ct.StateId,
                                                  StateName = x.s.StateName,
                                                  CityId=x.ct.CityId,
                                                  CityName=x.ct.CityName
                                              }).ToList();
            var context = db.Country_Table.Select(x => new SelectListItem { Text = x.CountryName, Value = x.CountryId.ToString() });
            List<SelectList> list = new List<SelectList>().ToList();
            ViewBag.CountryList = context;
            var Scontext=db.State_Table.Select(x=>new SelectListItem { Text=x.StateName,Value=x.StateId.ToString()});
            List<SelectList> list2 = new List<SelectList>().ToList();
            ViewBag.StateList = Scontext;
            return View();
           
        }
        [HttpPost]
        public ActionResult AddCity(CityModel model)
        {
            if(ModelState.IsValid)
            {
                City_Table table = new City_Table();
                table.CityName=model.CityName;
                table.StateId = model.StateId;
                table.CountryId = model.CountryId;
                //table.CountryId = model.CountryId;
                db.City_Table.Add(table);
                db.SaveChanges();
            }
            return View("Country");
        }
    }
}