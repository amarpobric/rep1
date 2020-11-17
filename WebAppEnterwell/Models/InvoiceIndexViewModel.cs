using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppEnterwell.Models
{
    public class InvoiceIndexViewModel
    {
        public List<Row> Rows { get; set; }
        public class Row
        {
            public int Id { get; set; }

            [Display(Name = "Broj fakture")]
            public int InvoiceNumber { get; set; }

            [Display(Name = "Daum stvaranja fakture")]
            public DateTime CreateDate { get; set; }

            [Display(Name = "Datum dospijeća fakture")]
            public DateTime PaymentDueDate { get; set; }

            [Display(Name = "Stvaratelj racuna")]
            public string ApplicationUser { get; set; }

            [Display(Name = "Primatelj racuna")]
            public string InvoiceFor { get; set; }


            public int PDV { get; set; }

            [Display(Name = "Ukupna cijena bez poreza")]
            public double TotalAmount { get; set; }

            [Display(Name = "Ukupna cijena sa porezom")]
            public double TotalAmountIncludingTax { get; set; }

            public List<Items> Items { get; set; }

            public Items ItemsObject { get; set; }
        }
    }
}