using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using WebAppEnterwell.Models;

namespace WebAppEnterwell.Controllers
{
    public class InvoiceController : Controller
    {
       
        public ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            InvoiceIndexViewModel model = new InvoiceIndexViewModel();
            model.Rows = db.Invoice.Select(x => new InvoiceIndexViewModel.Row
            {
                Id = x.Id,
                ApplicationUser = x.ApplicationUser.FirstName + " " + x.ApplicationUser.LastName,
                CreateDate = x.CreateDate,
                PaymentDueDate = x.PaymentDueDate,
                InvoiceNumber = x.InvoiceNumber,
                InvoiceFor = x.InvoiceFor,
                TotalAmount = x.TotalAmount,
                TotalAmountIncludingTax = x.TotalAmountIncludingTax

            }).ToList();


            return View(model);
        }

        public ActionResult Details(int Id)
        {
            var invoice = db.Invoice.Where(x => x.Id == Id).Include(x=>x.PDV).Include(x=>x.ApplicationUser).SingleOrDefault();
            
            var model = new InvoiceDetailsViewModel();
            model.Id = invoice.Id;
            model.InvoiceNumber = invoice.InvoiceNumber;
            model.InvoiceFor = invoice.InvoiceFor;
            model.CreateDate = invoice.CreateDate;
            model.PaymentDueDate = invoice.PaymentDueDate;
            model.TotalAmount = invoice.TotalAmount;
            model.TotalAmountIncludingTax = invoice.TotalAmountIncludingTax;
            model.ApplicationUser = invoice.ApplicationUser.FirstName + " " + invoice.ApplicationUser.LastName;
            model.PDV = invoice.PDV.Name + " - " + invoice.PDV.Value + " % ";
            model.Items = db.Items.Where(x => x.InvoiceId == Id).ToList();
            
            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            var invoice = db.Invoice.Where(x => x.Id == Id).SingleOrDefault();
            var items = db.Items.Where(x => x.InvoiceId == Id).ToList();
            foreach (var item in items)
            {
                db.Items.Remove(item);
            }
            db.Invoice.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("Index", "Invoice");
        }
        public ActionResult Create()
        {
            InvoiceCreateViewModel model = new InvoiceCreateViewModel();
            model.CreateDate = DateTime.Now;
            model.PaymentDueDate = DateTime.Now;
            model.ApplicationUserId = User.Identity.GetUserId();
            model.Items = new List<Items>();
            model.PDV = db.PDV.Select(x => new SelectListItem
            {
                Text=x.Name+ " - " + x.Value + "%",
                Value=x.Id.ToString()
            }).ToList();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(InvoiceCreateViewModel model)
        {
            Invoice newInvoice = new Invoice()
            {
                ApplicationUserId = model.ApplicationUserId,
                CreateDate = model.CreateDate,
                PaymentDueDate = model.PaymentDueDate,
                InvoiceNumber = model.InvoiceNumber,
                InvoiceFor = model.InvoiceFor,
                TotalAmount = model.TotalAmount,
                TotalAmountIncludingTax = model.TotalAmountIncludingTax,
                PDVId=model.PDVId
                
            };
            db.Invoice.Add(newInvoice);

            if (model.Items != null)
            {
                foreach (var item in model.Items)
                {
                    var newItem = new Items()
                    {
                        InvoiceId=newInvoice.Id,
                        Description=item.Description,
                        ItemPrice=item.ItemPrice,
                        Quantity=item.Quantity,
                        TotalItemPrice=item.TotalItemPrice
                    };
                    db.Items.Add(newItem);
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Invoice");
        }
    }
}