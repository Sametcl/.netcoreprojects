using EFCOREAPP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCOREAPP.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly DataContext _context;

        public OgretmenController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ogretmen = await _context.Ogretmenler.ToListAsync();
            return View(ogretmen);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {
            _context.Ogretmenler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _context.
                Ogretmenler.
                //Include(x => x.KursKayitlari).
                //ThenInclude(x => x.Kurs).
                FirstOrDefaultAsync(o => o.OgretmenId == id);
            //bulduğu ilk eşleşen id değerini ogr ye ata yoksa default olarak null gönder id den
            //farklı istediğin değişknelerle kontrol etmemizi sağlar ör= OgrenciAdı
            //var ogr =await _context.Ogrenciler.FirstOrDefaultAsync(o=> o.OgrenciId==id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Ogretmen model hidden da geliyor id router da geliyor  
        public async Task<IActionResult> Edit(int? id, Ogretmen model)
        {
            if (id != model.OgretmenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ogretmenler.Any(o => o.OgretmenId == model.OgretmenId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);

        }

    }
}
