using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AloKaza.Core.Entities
{
     public class AppLog : IEntity // Hataları takip ederek onlara müdahale edebilmemizi sağlayacak bir Log sınıfı
    {
        public int Id { get; set; }


        [Display(Name = "Hata")]
        public string Title { get; set; }

        [Display(Name = "Hata içeriği")]
        public string Description { get; set; }

        [Display(Name = "Hata Detayı"),DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [Display(Name = "Oluşma Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "Hata Giderildi?")]
        public bool IsFixed { get; set; }

        [Display(Name = "Çözüm Detay"),DataType(DataType.MultilineText)]
        public string? SlnDetail { get; set; }

    }
}
