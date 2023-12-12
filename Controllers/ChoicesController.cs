//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Online_Exam.Models;
//using System.Linq;

//namespace Online_Exam.Controllers
//{
//    public class ChoicesController : Controller
//    {
//        private readonly OnlineExammDbContext _context;

//        public ChoicesController(OnlineExammDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Choices
//        public IActionResult Index()
//        {
//            // Retrieve Exam_id and Question_id from the session
//            int examId = HttpContext.Session.GetInt32("Exam_id") ?? 0;
//            int questionId = int.Parse(HttpContext.Session.GetString("Question_id") ?? "0");

//            // Query the database for choices related to the given Exam_id and Question_id

//            var viewModel = new Questions
//            {
//                //Questions = new Questions(),
//                Choices = new List<Choices>()
//            };
//            var choices = _context.Choices
//                .Where(c => c.Exam_id == examId && c.Question_id == questionId)
//                .ToList();

//            return View(choices);
//        }

//        // GET: Choices/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Choices/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Choices choices)
//        {

//            if (ModelState.IsValid)
//            {
//                // Retrieve Exam_id and Question_id from the session
//                int examId = HttpContext.Session.GetInt32("Exam_id") ?? 0;
//                int questionId = HttpContext.Session.GetInt32("Question_id") ?? 0;

//                // Assign Exam_id and Question_id to the choices object
//                choices.Exam_id = examId;
//                choices.Question_id = questionId;

//                // Add the choices to the database and save changes
//                _context.Choices.Add(choices);
//                _context.SaveChanges();

//                return RedirectToAction(nameof(Index));
//            }
//            return View(choices);
//        }

//        // GET: Choices/Edit/5
//        public IActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var choices = _context.Choices.Find(id);
//            if (choices == null)
//            {
//                return NotFound();
//            }
//            return View(choices);
//        }

//        // POST: Choices/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(int id, Choices choices)
//        {
//            if (id != choices.Question_id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(choices);
//                    _context.SaveChanges();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ChoicesExists(choices.Question_id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(choices);
//        }

//        // GET: Choices/Delete/5
//        public IActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var choices = _context.Choices.Find(id);
//            if (choices == null)
//            {
//                return NotFound();
//            }

//            return View(choices);
//        }
//        // POST: Choices/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var choices = _context.Choices.Find(id);
//            _context.Choices.Remove(choices);
//            _context.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ChoicesExists(int id)
//        {
//            return _context.Choices.Any(e => e.Question_id == id);
//        }

//    }
//}