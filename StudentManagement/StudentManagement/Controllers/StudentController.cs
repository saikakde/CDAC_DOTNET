using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        // GET: Student/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Student/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string mobile)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Student_Email == email && s.Mobile_number == mobile);

            if (student != null)
            {
                // Set user type to Student
                TempData["UserType"] = "Student";
                // Add login logic here (e.g., session management)
                TempData["StudentID"] = student.Student_ID;
                return RedirectToAction(nameof(ViewDetails));
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }


        // POST: Student/Login
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(string email, string mobile)
        //{
        //    var student = await _context.Students
        //        .FirstOrDefaultAsync(s => s.Student_Email == email && s.Mobile_number == mobile);

        //    if (student != null)
        //    {
        //        // Add login logic here (e.g., session management)
        //        // For simplicity, we will store the student ID in TempData
        //        TempData["StudentID"] = student.Student_ID;
        //        return RedirectToAction(nameof(ViewDetails));
        //    }

        //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    return View();
        //}



        // GET: Student/ViewDetails
        public async Task<IActionResult> ViewDetails()
        {
            if (TempData["StudentID"] == null)
            {
                return RedirectToAction(nameof(Login));
            }

            int studentId = (int)TempData["StudentID"];
            var student = await _context.Students.FindAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/EditDetails
        public async Task<IActionResult> EditDetails()
        {
            if (TempData["StudentID"] == null)
            {
                return RedirectToAction(nameof(Login));
            }

            int studentId = (int)TempData["StudentID"];
            var student = await _context.Students.FindAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/EditDetails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDetails([Bind("Student_ID,Student_Name,Student_Email,Mobile_number,Student_Address,admission_date,fees,Status")] Student student)
        {
            if (TempData["StudentID"] == null)
            {
                return RedirectToAction(nameof(Login));
            }

            int studentId = (int)TempData["StudentID"];
            if (studentId != student.Student_ID)
            {
                return NotFound();
            }

            // Prevent editing of admission_date, fees, and Student_ID
            var originalStudent = await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Student_ID == studentId);
            if (originalStudent == null)
            {
                return NotFound();
            }

            student.admission_date = originalStudent.admission_date;
            student.fees = originalStudent.fees;
            student.Student_ID = originalStudent.Student_ID;

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
                return RedirectToAction(nameof(ViewDetails));
            }
            return View(student);
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Student_ID == id);
        }
    }
}
