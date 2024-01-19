using FitFalMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Domain.Interfaces
{
    public interface IDayOfEatingRepository
    {
        void DeleteDayOfEating(int dayofeatingId)

         int AddDayOfEating(DayOfEating dayofeating)

         DayOfEating GetDayOfEatingById(int dayofeatingId)

         void UpdateDayOfEating(DayOfEating updatingDayofeating)

    }
}
