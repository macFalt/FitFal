using FitFalMVC.Domain.Model;
using FitFalMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Infrastructure.Repositories
{
    public class DayOfEatingRepository : IDayOfEatingRepository
    {
        private readonly Context _context;

        public DayOfEating(Context context)
        {
            _context = context;
        }

        public void DeleteDayOfEating(int dayofeatingId)
        {
            var dayofeating = _context.DayOfEating.Find(dayofeatingId);
            if (dayofeating!=null)
            {
                _context.DayOfEating.Remove(dayofeating);
                _context.SaveChanges();
            }
        }


        public int AddDayOfEating(DayOfEating dayofeating)
        {
            _context.DayOfEating.Add(dayofeating);
            _context.SaveChanges();
            return dayofeating.Id;

        }

        public DayOfEating GetDayOfEatingById(int dayofeatingId)
        {
            var dayofeating= _context.DayOfEating.FirstOrDefault(i=>i.Id==dayofeatingId);
            return dayofeating;
        }


        public void UpdateDayOfEating(DayOfEating updatingDayofeating)
        {
            var existingDayofeating=_context.DayOfEating.FirstOrDefault(i=>i.Id= updatingDayofeating.Id);
            if (existingDayofeating=! null)
            {
                existingDayofeating.Name updatingDayofeating.Name;
            }
        }

    }
}
