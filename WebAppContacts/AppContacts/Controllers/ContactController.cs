using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppContacts.Models;
using AppContacts.ViewModel;

namespace AppContacts.Controllers
{
    public class ContactController : Controller
    {
        private IContactClient contactClient;
      public  ContactController(IContactClient iContactClient)
        {
            this.contactClient = iContactClient;
        }
        public ActionResult Index()
        {
            //ContactClient contactClient = new ContactClient();
            ViewBag.listContacts = contactClient.FindAll();

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(ContactViewModel cvm)
        {
            //ContactClient contactClient = new ContactClient();
            contactClient.Create(cvm.Contact);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            //ContactClient contactClient = new ContactClient();
            contactClient.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //ContactClient contactClient = new ContactClient();
            ContactViewModel cvm = new ContactViewModel();
            cvm.Contact = contactClient.Find(id);
            return View("Edit", cvm);
        }
        [HttpPost]
        public ActionResult Edit(ContactViewModel cvm)
        {
            //ContactClient contactClient = new ContactClient();
            contactClient.Edit(cvm.Contact);
            return RedirectToAction("Index");
        }
    }
}