using BasicASPTutorial.Data;
using BasicASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace BasicASPTutorial.Controllers
{
    //Map จะได้ route -> https://localhost:44336/Student
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)  //ใช้ Concept  DI (dependency injection)
        {
            _db = db;  //ใช้เข้าถึง ฐานข้อมูล ผ่านตัวแปร _dbContext ได้
        }

        //https://localhost:44336/Student/index
        public IActionResult Index()
        {
            IEnumerable<Student> allStudent = _db.Students; // List<Student> allStudent = _db.Students.ToList();

            return View(allStudent);
        }

        //https://localhost:44336/Student/Create
        //Default เป็น GET Method
        public IActionResult Create()
        {
            return View();
        }

        //https://localhost:44336/Student/ShowScore/2   
        //เมื่อตัวแปร params ที่รับ int id คือ 2 หรือ id
        public IActionResult ShowScore(int id)
        {
            return Content($"คะแนนสอบของนักเรียน เลชที่ {id}");
        }

        [HttpPost]  //ถ้าไม่ระบุ Http Method มันจะมองเป็น HttpGet
        [ValidateAntiForgeryToken]  //ValidateAntiForgeryToken ป้องกัน Hacker check type อะไรสักอย่าง...
        public IActionResult Create(Student obj)
        {  //Student obj คือ ตัวแปร ที่รับ มาจาก Form ของ html
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);  //insert data
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);  //return หน้าเดิม
        }


        public IActionResult Edit(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }

           var obj =  _db.Students.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]  
        [ValidateAntiForgeryToken] 
        public IActionResult Edit(Student obj)
        { 
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj); 
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
