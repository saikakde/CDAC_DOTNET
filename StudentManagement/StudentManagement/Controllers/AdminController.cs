    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using StudentManagement.Data;
    using StudentManagement.Models;
    using System.Linq;
    using System.Threading.Tasks;
namespace StudentManagement.Controllers
{

    public class AdminController : Controller
    {
        private readonly StudentContext _context;

        public AdminController(StudentContext context)
        {
            _context = context;
        }

        // GET: Admin/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Admin_Username == username && a.Admin_Password == password);

            if (admin != null)
            {
                // Set user type to Admin
                TempData["UserType"] = "Admin";
                // Add login logic here (e.g., session management)
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }


        //// POST: Admin/Login
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(Admin admin)
        //{
        //    var adminUser = await _context.Admins
        //        .FirstOrDefaultAsync(a => a.Admin_Username == admin.Admin_Username && a.Admin_Password == admin.Admin_Password);

        //    if (adminUser != null)
        //    {
        //        // Add login logic here (e.g., session management)
        //        return RedirectToAction(nameof(Index));
        //    }

        //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    return View(admin);
        //}

        // GET: Admin/Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Admin/AddStudent
        public IActionResult AddStudent()
        {
            return View();
        }

        // POST: Admin/AddStudent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        //// GET: Admin/EditStudent/5
        //public async Task<IActionResult> EditStudent(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Students.FindAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(student);
        //}

        //// POST: Admin/EditStudent/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditStudent(int id, Student student)
        //{
        //    if (id != student.Student_ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(student);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StudentExists(student.Student_ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}

        // GET: Admin/EditStudent/5
        public async Task<IActionResult> EditStudent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Admin/EditStudent/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStudent(int id, [Bind("Student_ID,Student_Name,Student_Email,Mobile_number,Student_Address,admission_date,fees,Status")] Student student)
        {
            if (id != student.Student_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Student_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }


        // GET: Admin/DeleteStudent/5
        public async Task<IActionResult> DeleteStudent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Student_ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Admin/DeleteStudent/5
        [HttpPost, ActionName("DeleteStudent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudentConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Student_ID == id);
        }

        // GET: Admin/SearchByStatus
        public async Task<IActionResult> SearchByStatus(string status)
        {
            var students = from s in _context.Students
                           select s;

            if (!string.IsNullOrEmpty(status))
            {
                students = students.Where(s => s.Status == status);
            }

            return View(await students.ToListAsync());
        }

        // GET: Admin/SortByStatus
        public async Task<IActionResult> SortByStatus()
        {
            var students = from s in _context.Students
                           select s;

            students = students.OrderBy(s => s.Status);

            return View(await students.ToListAsync());
        }

     
    }

}
