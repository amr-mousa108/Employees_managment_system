using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IDepartementRepository
    {
        IEnumerable<Departement> GetAll();
        Departement Get(int id);
        int Add(Departement entity);
        int Update(Departement entity);
        int Delete(Departement entity);
    }
}
