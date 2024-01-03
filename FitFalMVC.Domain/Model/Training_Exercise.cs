using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Domain.Model
{
    public class Training_Exercise
    {
        public int Id { get; set; }

        public int Id_Training { get; set; }

        public int Id_Exercise { get; set; }

        public int Sets { get; set; }

        public int Repetitions { get; set; }

        public float Weight { get; set; }

        public float Duration { get; set; } // zapytac o rodzaj zmiennej

        public string Description { get; set; }
    }
}
