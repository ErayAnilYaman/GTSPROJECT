
namespace WebApplication.Controllers
{
    #region usings
    using BusinessCore.Abstract;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    #endregion
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly IThesisService _thesisService;
        private readonly IUniversityService _universityService;
        private readonly IInstituteService _instituteService;
        private readonly ISupervisorService _supervisorService;
        private readonly IAuthorService _authorService;

        public AdminController(IThesisService thesisService, IUniversityService universityService , 
            IInstituteService instituteService , IAuthorService authorService, ISupervisorService supervisorService)
        {
            _thesisService = thesisService;
            _universityService = universityService;
            _instituteService = instituteService;
            _supervisorService = supervisorService;
            _authorService = authorService;

        }
        public IActionResult Index()
        {
            var result = _thesisService.GetAll();
            return View(result.Data);
        }
        public IActionResult Institutes() 
        {
            var result = _instituteService.List();
            if (result != null)
            {
                return View(result.Data);
            }
            return View(null);
        }
        public IActionResult Universities() 
        {
            var result = _universityService.List();
            if (result != null)
            {
                return View(result.Data);
            }
            return View(null);
        }
        public IActionResult Supervisors() 
        {
            var result = _supervisorService.List();
            if (result != null)
            {
                return View(result.Data);
            }
            return View(null);
        }
        public IActionResult Authors() 
        {
            var result = _authorService.GetAll();
            if (result != null)
            {
                return View(result.Data);
            }
            return View(null);
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult AddUniversity()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUniversity(University university)
        {
            if (ModelState.IsValid)
            {
                _universityService.Add(university);
                return View("universities");
            }
            return View();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]

        public IActionResult UpdateUniversity(int universityID)
        {
            var result = _universityService.GetById(universityID);
            if (result != null)
            {
                return View(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult UpdateUniversity(University university)
        {
            if (ModelState.IsValid)
            {
                _universityService.Update(university);
                return View("Index");
            }
            return View();
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult AddSupervisor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSupervisor(Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                _supervisorService.Add(supervisor);
                return View("universities");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateSupervisor(int id)
        {

            var model = _supervisorService.GetByID(id);
            return View(model);
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult AddInstitute()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInstitute(Institute institute)
        {
            if (ModelState.IsValid)
            {
                _instituteService.Add(institute);
                return View("Universities");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateInstitute(int id)
        {
            var result = _instituteService.GetById(id);
            if (result.IsSuccess)
            {
                return View(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult UpdateInstitute(Institute institute)
        {
            if (ModelState.IsValid)
            {
                _instituteService.Update(institute);
                return View("Index");
            }
            return View();
        }


        [HttpPost]
        public JsonResult DeleteInstituteById(int id)
        {
            try
            {
                var result = _instituteService.DeleteById(id);
                if (result.IsSuccess)
                {
                    return Json(new { success = result.IsSuccess, messages = result.Message });
                }
                return Json(new { success = result.IsSuccess, messages = result.Message });
            }
            catch (Exception ex)
            {
                return Json(new {success = false, Messages = ex.Message});
            }
        }


        [HttpPost]
        public JsonResult DeleteUniversityById(int id)
        {
            try
            {
                var result = _universityService.DeleteById(id);
                if (result.IsSuccess)
                {
                    return Json(new { success = result.IsSuccess, messages = result.Message });
                }
                return Json(new { success = result.IsSuccess, messages = result.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Messages = ex.Message });
            }
        }



    }
}
