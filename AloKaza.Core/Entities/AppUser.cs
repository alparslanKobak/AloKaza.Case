using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AloKaza.Core.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Logo / Profil Fotoğrafı")]
        public string? Image { get; set; }

        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} Alanı Gereklidir!"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Şifre"), Required(ErrorMessage = "{0} Alanı Gereklidir!"),DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Telefon"), Required(ErrorMessage = "{0} Alanı Gereklidir!"),DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Kurumsal?")]
        public bool IsCorporate { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }

        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;


        [ScaffoldColumn(false)]
        public Guid? UserGuid { get; set; } 

        [Display(Name = "Kaza Tutanakları")]
        public List<Report>? Reports { get; set; }
    }
}
