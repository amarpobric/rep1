using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEnterwell.Models
{
    public class Items
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double ItemPrice { get; set; }

        public double TotalItemPrice { get; set; }

        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }
    }
}