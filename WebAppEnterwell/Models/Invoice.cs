using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEnterwell.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int InvoiceNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime PaymentDueDate { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string InvoiceFor { get; set; }

        public int PDVId { get; set; }

        public PDV PDV { get; set; }

        public double TotalAmount { get; set; }

        public double TotalAmountIncludingTax { get; set; }
    }
}