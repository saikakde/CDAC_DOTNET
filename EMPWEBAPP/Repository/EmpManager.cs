using EmpWebApp.Models;

namespace EmpWebApp.Repository
{
    public class EmpManager : IEmpManager
    {
        public void Add(Emp e)
        {
            using (var cn = new CollectionContext()) {
                cn.emps.Add(e);
                cn.SaveChanges();
            }
        }

        public List<Emp> All()
        {
                /*List<Emp> list = new List<Emp>();*/
            using (var cn = new CollectionContext()) {
                var emp = from e
                          in cn.emps
                                select e;

                return emp.ToList();
            }
        }

        public void Deletebyid(int id)
        {
            using (var cn = new CollectionContext())
            {
                cn.emps.Remove(cn.emps.Find(id));
                cn.SaveChanges() ;
            }
        }

        public void Getbyid(int id)
        {
            using (var cn = new CollectionContext()) {
                cn.emps.Find(id);
            }
        }

        public List<Emp> Sort()
        {
            using (var cn = new CollectionContext()) {
                var emp = from e in cn.emps orderby e.name select e;

                return emp.ToList<Emp>();
            }


        }

        public void Update(Emp e)
        {
            using (var cn = new CollectionContext())
            {
                var emp = cn.emps.Find(e.id);
                emp.id = e.id;
                emp.name = e.name;
                emp.email = e.email;
                emp.address = e.address;
                emp.phone = e.phone;
                emp.salary = e.salary;
                emp.status = e.status;
                cn.SaveChanges();
            }
        }
    }
}
