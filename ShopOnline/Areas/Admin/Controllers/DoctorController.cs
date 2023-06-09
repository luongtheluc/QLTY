﻿using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class DoctorController : BaseController
    {
        OnlineShopDBContext db = new OnlineShopDBContext();
        // GET: Admin/Doctor
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            DoctorDao dao = new DoctorDao();
            var list = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(list);
        }

        public ActionResult Create()
        {
            Doctor doctor = new Doctor();
            doctor.list = db.Faculties.ToList();
            return View(doctor);
        }
        [HttpPost]
        public ActionResult Create(Doctor model)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = new Doctor();
                doctor.Name = model.Name;
                doctor.Address = model.Address;
                doctor.Phone = model.Phone;
                doctor.Email = model.Email;
                doctor.Address = model.Address;
                if (model.Gender == true)
                {
                    doctor.Gender = model.Gender;
                }
                else
                {
                    doctor.Gender = false;
                }
                doctor.FacultyId = model.FacultyId;
                DoctorDao dao = new DoctorDao();
                var rs = dao.Insert(doctor);
                if (rs > 0)
                {
                    ViewBag.Success = "Success!";
                    return Redirect("/Admin/Doctor");
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                }
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var Edit = db.Doctors.Where(n => n.Id.Equals(id)).FirstOrDefault();
            Edit.list = db.Faculties.ToList();
            return View(Edit);
        }
        [HttpPost]
        public ActionResult Edit(Doctor model)
        {
            model.list = db.Faculties.ToList();

            if (ModelState.IsValid)
            {


                DoctorDao dao = new DoctorDao();
                var rs = dao.Update(model);
                if (rs > 0)
                {
                    ViewBag.Success = "Success!";
                    return RedirectToAction("Index", "Doctor");
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                }
            }
            return View(model);
        }


            public ActionResult Details(long id)
        {
            var details = db.Doctors.Where(n => n.Id.Equals(id)).FirstOrDefault();
            return View(details);
        }
        public ActionResult Delete(int id)
        {
            var Delete = db.Doctors.Where(n => n.Id.Equals(id)).FirstOrDefault();
            return View(Delete);
        }

        [HttpPost]
        public ActionResult Delete(Doctor model)
        {
            var Delete = db.Doctors.Where(n => n.Id.Equals(model.Id)).FirstOrDefault();
            db.Doctors.Remove(Delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}