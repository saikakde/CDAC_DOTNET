using EmpWebApp.Models;

namespace EmpWebApp.Service
{
    public interface IEmpService
    {
        List<Emp> All();
        void Add(Emp e);
        void Deletebyid(int id);
        void Update(Emp e);
        void Getbyid(int id);
        List<Emp> Sort();
    }
}
