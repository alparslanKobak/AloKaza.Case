using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Core.Entities
{
    public interface IEntity // Proje içerisindeki varlıklarımızın sahip olduğu mirası imzalamak için interface oluşturduk.
    {
        public int Id { get; set; }
    }
}
