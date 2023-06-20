using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AloKaza.Core.Entities
{
    public class Report : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Tutanak Başlığı")]
        public string Title { get; set; }

        [Display(Name = "Tutanak Açıklaması"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Kullanıcı")]
        public int AppUserId { get; set; }

        [Display(Name = "Kullanıcı")]
        public AppUser? AppUser { get; set; }

        [Display(Name = "Hasar Kayıt")]
        public List<Damage>? DamageRecords { get; set; }

        [Display(Name = "Hasar Kayıt"), DataType(DataType.Currency)]
        public decimal? TotalDamagePrice
        {
            get
            {
                if (DamageRecords != null)
                {
                    decimal price = DamageRecords.Sum(item => item.Price);

                    return price;
                }

                return null;
            }

        }

        public bool IsAnyCriminal { get; set; }

        [ScaffoldColumn(false)] // Her Tutanağın eşsiz olmasını sağladık.
        public Guid ReportGuid { get; set; } = Guid.NewGuid();
    }
}
