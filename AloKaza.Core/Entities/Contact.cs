using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AloKaza.Core.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        public string? Surname { get; set; }
        [EmailAddress, Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Email { get; set; }

        [Display(Name = "Telefon"),DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Display(Name = "Mesaj"), DataType(DataType.MultilineText), Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Message { get; set; }

        [Display(Name = "Mesaj Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
