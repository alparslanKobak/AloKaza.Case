using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AloKaza.Core.Entities
{
    public class Setting
    {
        public int Id { get; set; }

        [Display(Name = "Site Başlık")]
        public string? Title { get; set; }

        [Display(Name = "Site Açıklama"), DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Telefon"),DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Display(Name = "Mail Sunucusu")]
        public string? MailServer { get; set; }

        public int Port { get; set; }

        [Display(Name = "Mail Kullanıcı Adı")]
        public string? UserName { get; set; }

        [Display(Name = "Mail Şifresi"),DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Site İkon")]
        public string? Favicon { get; set; }

        [Display(Name = "Site Logo")]
        public string? Logo { get; set; }

        [Display(Name = "Firma Adresi"), DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Display(Name = "Firma Harita Kodu"), DataType(DataType.MultilineText)]
        public string? MapCode { get; set; }
    }
}
