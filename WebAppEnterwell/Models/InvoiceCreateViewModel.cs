using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppEnterwell.Models
{
    public class InvoiceCreateViewModel
    {
        [Required(ErrorMessage ="Obavezan unos")]
        [Display(Name = "Broj fakture")]
        public int InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Obavezan odabir")]
        [Display(Name = "Datum stvaranja fakture")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Obavezan odabir")]
        [Display(Name = "Datum dospijeća fakture")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDueDate { get; set; }

        public string ApplicationUserId { get; set; }

        [Display(Name ="Primatelj racuna")]
        public string InvoiceFor { get; set; }

        [Required(ErrorMessage = "Obavezan odabir")]
        [Display(Name ="PDV")]
        public int PDVId { get; set; }

        public List<SelectListItem> PDV { get; set; }

        [Display(Name = "Ukupna cijena bez poreza")]
        public double TotalAmount { get; set; }

        [Display(Name = "Ukupna cijena sa porezom")]
        public double TotalAmountIncludingTax { get; set; }

        public List<Items> Items { get; set; }
        //public Items ItemsObject { get; set; }
    }
    
}