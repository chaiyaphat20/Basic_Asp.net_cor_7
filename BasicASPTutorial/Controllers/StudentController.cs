using BasicASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASPTutorial.Controllers
{
    //Map จะได้ route -> https://localhost:44336/Student
    public class StudentController : Controller
    {
        //https://localhost:44336/Student/index
        public IActionResult Index()
        {
            Student s1 = new Student();
            s1.Id = 1;
            s1.Name= "อาทรักสยาม";
            s1.Score = 80;

            var s2 = new Student();
            s2.Id = 2;
            s2.Name = "โจโจ้";
            s2.Score = 45;

            Student s3 = new();
            s3.Id= 3;
            s3.Name = "Jane";
            s3.Score = 50;

            List<Student> allStudent = new List<Student>();
            allStudent.Add(s1);
            allStudent.Add(s2);
            allStudent.Add(s3);


            return View(allStudent);
        }

        //https://localhost:44336/Student/Create
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
    }
}
