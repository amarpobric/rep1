using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppEnterwell.Models
{
    public class PDVCreateViewModel
    {
        [Required(ErrorMessage = "Obavezan unos")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        [Display(Name = "Vrijednost pdva u %")]
        public int Value { get; set; }
    }
}