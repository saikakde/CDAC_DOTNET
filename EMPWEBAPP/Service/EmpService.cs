using EmpWebApp.Models;
using EmpWebApp.Repository;

namespace EmpWebApp.Service
{
    public class EmpService : IEmpService
    {
        private IEmpManager empman = new EmpManager();
        public void Add(Emp e)
        {
            empman.Add(e);
        }

        public List<Emp> All()
        {
           return empman.All();
        }

        public void Deletebyid(int id)
        {
            empman.Deletebyid(id);
        }

        public void Getbyid(int id)
        {
           empman.Getbyid(id);
        }

        public List<Emp> Sort()
        {
            return empman.Sort();
        }

        public void Update(Emp e)
        {
           empman.Update(e);
        }
    }
}
