using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class AirConditionerService:GenericRepository<AirConditioner>
    {

        AirConditionerShop2023DbContext _context;
        DbSet<AirConditioner> _dbSet;

        public AirConditionerService()
        {
            _context = new AirConditionerShop2023DbContext();
            _dbSet = _context.Set<AirConditioner>();
        }
        public AirConditioner GetAirConditioner(int airConditionerID)
        {
            return _dbSet.FirstOrDefault(s => s.AirConditionerId == airConditionerID);
        }

        public void UpdateAirConditioner(AirConditioner airConditioner)
        {
            var tracker = _context.Attach(airConditioner);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAirConditioner(AirConditioner airConditioner)
        {
            _dbSet.Remove(airConditioner);
            _context.SaveChanges();
        }
    }
}
