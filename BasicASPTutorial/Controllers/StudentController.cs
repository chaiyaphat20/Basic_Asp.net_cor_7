using Microsoft.AspNetCore.Mvc;

namespace BasicASPTutorial.Controllers
{
    //Map จะได้ route -> https://localhost:44336/Student
    public class StudentController : Controller
    {
        //https://localhost:44336/Student/index
        public IActionResult Index()
        {
            return View();
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
