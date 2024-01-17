
namespace WebApplication.Controllers
{
    using BusinessCore.Abstract;
    using Data.Models;
    using Data.Models.DTOs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    [Authorize(Roles ="user")]
    public class UserController : Controller
    {
        private readonly IThesisService _thesisService;
        private readonly IUniversityService _universityService;
        private readonly IInstituteService _instituteService;
        private readonly IAuthorService _authorService;
        private readonly ISupervisorService _supervisorService;

        public UserController(IThesisService thesisService, IUniversityService universityService,
            IInstituteService instituteService, IAuthorService authorService, ISupervisorService supervisorService)
        {
            _thesisService = thesisService;
            _instituteService = instituteService;
            _universityService = universityService;
            _authorService = authorService;
            _supervisorService = supervisorService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var result = _thesisService.GetAllByUsername(User.Identity.Name.ToString());
                return View(result.Data);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new CreateThesisModel();
            List<SelectListItem> universities;
            List<SelectListItem> institutes;
            List<SelectListItem> supervisors;

            universities = (from i in _universityService.List().Data
                            select new SelectListItem
                            {
                                Value = i.UNIVERSITYID.ToString(),
                                Text = i.NAME.ToString(),
                            }).ToList();
            institutes = (from i in _instituteService.List().Data
                          select new SelectListItem
                          {
                              Value = i.INSTITUTEID.ToString(),
                              Text = i.NAME.ToString()
                          }).ToList();
            supervisors = (from i in _supervisorService.List().Data
                           select new SelectListItem
                           {
                               Value = i.SUPERVISORID.ToString(),
                               Text = i.LASTNAME.ToString()
                           }).ToList();
             
            ViewBag.universities = universities;
            ViewBag.institutes = institutes;
            ViewBag.supervisors = supervisors;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreateThesisModel createThesisModel)
        {
            if (ModelState.IsValid)
            {
                var result = _authorService.GetByName(User.Identity.Name);
                _thesisService.Add(createThesisModel , result.Data.AUTHORID);
                return View("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _thesisService.GetByID(id);
            var author = _authorService.GetById(result.Data.AUTHORID);
            
            if (result.Data.AUTHORID == author.Data.AUTHORID)
            {
                
                return View(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(Thesis thesis)
        {
            if (!ModelState.IsValid)
            {
                _thesisService.Update(thesis);
                return View("Index");
            }
            return View();
        }
        [HttpPost]
        public JsonResult DeleteUserById(int id)
        {
            try
            {
                var result = _thesisService.Delete(id);
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
