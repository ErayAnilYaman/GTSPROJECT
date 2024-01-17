
namespace WebApplication.Controllers
{
    #region usings
    using Microsoft.AspNetCore.Mvc;
    using PagedList;
    using BusinessCore.Abstract;
    using Data.Db;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using WebApplication.Models;
    using Data.Models.DTOs;
    using Data.Models;
    using System.Linq;
    using System.Dynamic;
    #endregion
    public class ThesesController : Controller
    {
        private readonly IThesisService _thesisService;
        private readonly IInstituteService _instituteService;
        private readonly IUniversityService _universityService;
        private ThesesContext db = new ThesesContext();

        public ThesesController(IThesisService thesisService , IInstituteService instituteService , IUniversityService universityService)
        {
            _thesisService = thesisService;
            _instituteService = instituteService;
            _universityService = universityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var result = _thesisService.GetAll();
                if (result.IsSuccess)
                {
                    return View(result.Data);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public IActionResult GetByNumber(string thesisNumber)
        {
            try
            {
                List<Thesis> theses = new List<Thesis>();
                var result = _thesisService.GetByNumber(Convert.ToInt32(thesisNumber));
                theses.Add(result.Data);
                if (result.IsSuccess)
                {
                    return View("Index",theses);
                }
                return View("Index", null);

            }
            catch (Exception ex)
            {
                return PartialView(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Filter()
        {
            var thesisModel = new ThesisModel();

            List<SelectListItem> universities;
            List<SelectListItem> institutes;
            universities = _universityService.List().Data.Select(i => new SelectListItem
            {
                Text = i.NAME.ToString(),
                Value = i.UNIVERSITYID.ToString()

            }).ToList();

            institutes = _instituteService.List().Data.Select(i => new SelectListItem
            {
                Text = i.NAME.ToString(),
                Value = i.INSTITUTEID.ToString()
            }).ToList();

            ViewBag.Universities = universities;
            ViewBag.Institutes = institutes;
            return View(thesisModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(ThesisModel thesisModel)
        {
            var result = _thesisService.GetFilter(thesisModel);
            if (result.IsSuccess)
            {
                return View("Index",result.Data);
            }
            return View();
        }
        [HttpGet]
        public JsonResult GetData(int number)
        {
            try
            {
                var result = _thesisService.GetByNumber(number);
                if (result.Data != null)
                {
                    return Json(new { success = result.IsSuccess, message = result.Message , thesis = result.Data });
                }
                return Json(new { success = result.IsSuccess, message = result.Message });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
