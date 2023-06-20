using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Core.Entities
{
    public class Damage : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Kaza Resmi")]
        public string? Image { get; set; }

        [Display(Name = "Kaza Tanım")]
        public string? Title { get; set; }

        [Display(Name = "Hasar Bedeli"), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Tutanak")]
        public int ReportId { get; set; }

        [Display(Name = "Tutanak")]
        public Report? Report { get; set; }

    }
}
