using AspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC.Controllers
{
    public class CrudListController : Controller
    {
        
        private List<Student> students = StudentModel.GetStudent();

        // GET: CrudList
        public ActionResult Index()
        {
            return View(students);
        }
        public ActionResult StudentDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student st = students.Find(s => s.StudentId == id);
            if (st == null)
            {
                return HttpNotFound();
            }
            return View(st);
        }



        // GET: Student/ UpdateStudentDetails/5
        public ActionResult UpdateStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = students.Find(s => s.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/ UpdateStudentDetails/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStudent([Bind(Include = "StudentId,FullName,Email,ConfirmEmail,IsEnrol")] Student student)
        {
            if (ModelState.IsValid)
            {
                var st = students.FirstOrDefault(s => s.StudentId == student.StudentId);
                if (st != null) { st.FullName = student.FullName; st.Email = student.Email; st.IsEnrol = student.IsEnrol; }
                return RedirectToAction("Index");

            }
            return View(student);
        }
        //============= Create New Student =================
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent([Bind(Include = "StudentId,FullName,Email, ConfirmEmail,IsEnrol")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (students.Count < 50) students.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/DeleteStudent/ 
        public ActionResult DeleteStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = students.Find(s => s.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/DeleteStudent/5
        [HttpPost, ActionName("DeleteStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudentConfirmed(int id)
        {
            Student student = students.Find(s => s.StudentId == id);
            if (student != null)
                students.Remove(student);

             //or we can use the next  if there is more than one match: 
             //  students.RemoveAll(s => s.StudenId == id) 

            return RedirectToAction("Index");
        }       

    }
}