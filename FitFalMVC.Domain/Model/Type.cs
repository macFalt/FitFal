using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Domain.Model
{
    public class Type
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } // moj jeden typ moze zawierac wiele przedmiotow. Jeden typ moze byc przypisany do wielu produktow.


    }
}
