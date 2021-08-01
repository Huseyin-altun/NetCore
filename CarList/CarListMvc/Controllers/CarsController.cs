using CarListMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarListMvc.Controllers
{
    public class CarsController : Controller
    {

        private readonly AplicationDbContext _aplicationDbContext;
        public CarsController(AplicationDbContext aplicationDbContext)
        {
            _aplicationDbContext = aplicationDbContext;
        }
        [BindProperty]
        public Car Car { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Car = new Car();
            if (id==null)
            {
                //create
                return View(Car);
            }
            Car = _aplicationDbContext.Cars.FirstOrDefault(x=>x.CarID==id);
            if (Car == null)
            {
                return NotFound();
            }
            return View(Car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Car.CarID==0)
                {
                    _aplicationDbContext.Add(Car);
                }
                else
                {
                    _aplicationDbContext.Update(Car);

                }
                _aplicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Car);
        }

        #region API 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _aplicationDbContext.Cars.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _aplicationDbContext.Cars.FirstOrDefaultAsync(u => u.CarID == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Silme sırasında hata ile karşılaştı" });
            }
            _aplicationDbContext.Cars.Remove(bookFromDb);
            await _aplicationDbContext.SaveChangesAsync();
            return Json(new { success = true, message = "Başarıyla Silindi" });
        }
        #endregion
    }
}
