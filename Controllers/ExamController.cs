using Microsoft.AspNetCore.Mvc;
using Online_Exam.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
public class ExamController : Controller
{
    private readonly OnlineExammDbContext _context;

    public ExamController(OnlineExammDbContext context)
    {
        _context = context;
    }
    public IActionResult Create()
    {
        Exam exam = new Exam();
        return View(exam);
    }

    [HttpPost]
    public IActionResult Create(Exam exam)
    {
        string adminEmail = HttpContext.Session.GetString("U_Email");
        exam.Adminstration_Email = adminEmail;
        _context.Exams.Add(exam);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("Exam_id", exam.Exam_id);
        return RedirectToAction("Create", "Questions");
    }

    public IActionResult Index()
    {
        string adminEmail = HttpContext.Session.GetString("U_Email");
        var exams = _context.Exams
            .Where(e => e.Adminstration_Email == adminEmail)
            .ToList();

        return View(exams);
    }
}