﻿using BigSchool.Models;
using BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
       public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var vieModel = new CourseViewModel
            {
                categories = _dbContext.categories.ToList()
            };
            return View(vieModel);
            
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.categories= _dbContext.categories.ToList();
                return View("Create",viewModel);
            } 
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime=viewModel.GetDateTime(),
                CategoryId=viewModel.Category,
                Place=viewModel.Place

            };
            _dbContext.courses.Add(course);
            _dbContext.SaveChanges();

            return RedirectToAction("Index","Home");

        }
    }
}