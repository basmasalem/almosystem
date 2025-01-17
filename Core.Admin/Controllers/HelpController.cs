﻿using Core.Model;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Controllers
{
    public class HelpController : BaseController
    {
        private readonly IServiceWrapper _serviceWrapper;
        public HelpController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListHelps(int page = 1)
        {
            IPagedList<Help> Helps;
            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            Helps = _serviceWrapper.helpService.GetAllHelps().ToPagedList(page, ItemPerPage);
            return PartialView("_ListHelps", Helps);
        }
        [HttpPost]
        public IActionResult SearchHelps(string Name = "", string Email = "", int page = 1)
        {
            IPagedList<Help> Helps;
            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            Helps =  _serviceWrapper.helpService.GetAllHelps(Name, Email).ToPagedList(page, ItemPerPage);
            return PartialView("_ListHelps", Helps);
        }
        public IActionResult AddEdit(int? Id)
        {
            Help model = new Help() { };
            if (Id.HasValue && Id != 0)
                model =  _serviceWrapper.helpService.GetHelpData((int)Id);

            return View(model);
        }
        public IActionResult DeleteHelp(int id)
        {
            var help =  _serviceWrapper.helpService.GetHelpData(id);
             _serviceWrapper.helpService.DeleteHelp(help);

            return Json("1");
        }
    }
}
