using Microsoft.AspNetCore.Mvc;
using Online_Exam.Models;

namespace Online_Exam.Controllers
{
    public class PrintController : Controller
    {
		private readonly OnlineExammDbContext _context;

		public PrintController(OnlineExammDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<Exam> ListExam = _context.Exams.ToList();
			List<Questions> ListQuestions = _context.Questions.ToList();
			List<Choices> ListChoices = _context.Choices.ToList();
			PrintViewModel obViewModel = new PrintViewModel
			{
				ExamViewModel = ListExam,
				QuestionsViewModel = ListQuestions,
				ChoicesViewModel = ListChoices
			};

			return View(obViewModel);
		}
	}
}
