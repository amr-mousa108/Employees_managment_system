using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class DepartementRepository : IDepartementRepository
    {
        private readonly AppDbContext _dbContext;
        public DepartementRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Departement entity) 
            {
                _dbContext.Add(entity);
                return _dbContext.SaveChanges();


            }

        public int Delete(Departement entity)
        {
            _dbContext.Departements.Remove(entity);
            return _dbContext.SaveChanges();
        }


        public Departement Get(int id)
        {
            return _dbContext.Departements.SingleOrDefault(b=>b.Id==id);        }

        public IEnumerable<Departement> GetAll()
        =>_dbContext.Departements.AsNoTracking().ToList();
        public int Update(Departement entity)
        {
            _dbContext.Departements.Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
