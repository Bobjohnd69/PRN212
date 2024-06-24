using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
   
    public class SupplierCompanyService:GenericRepository<SupplierCompany>
    {

        AirConditionerShop2023DbContext _context;
        DbSet<SupplierCompany> _dbSet;

        public SupplierCompanyService()
        {
            _context = new AirConditionerShop2023DbContext();
            _dbSet = _context.Set<SupplierCompany>();
        }
        public SupplierCompany GetSupplierCompany(String SupplierId)
        {
            return _dbSet.FirstOrDefault(s => s.SupplierId == SupplierId);
        }

        public void DeleteSupplierCompany(SupplierCompany supplierCompany)
        {
            _dbSet.Remove(supplierCompany);
            _context.SaveChanges();
        }
    }
}
