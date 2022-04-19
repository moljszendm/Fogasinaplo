using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fogasnaplo.Data;
using Fogasnaplo.Models;
using Microsoft.AspNetCore.Authorization;

namespace Fogasnaplo.Controllers
{
    public class FogasokController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FogasokController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fogasok
        public async Task<IActionResult> Index(string NevKeres, string CsapatKeres)
        {
            FogasokKeresese model = new FogasokKeresese();
            var adat = _context.Fogas.Select(x => x); //.OrderBy(x => x.Megnevezes);
            if (!string.IsNullOrEmpty(NevKeres))
            {
                model.NevKeres = NevKeres;
                adat = adat.Where(x => x.Nev.Contains(NevKeres));

            }

            if (!string.IsNullOrEmpty(CsapatKeres))
            {
                model.CsapatKeres = CsapatKeres;
                adat = adat.Where(x => x.CsapatNev == CsapatKeres);

            }

            model.FogasLista = await adat.ToListAsync();
            model.CsapatLista = new SelectList(await _context.Fogas.Select(x => x.CsapatNev).Distinct().OrderBy(x => x).ToListAsync());




            return View(model);
        }

        // GET: Fogasok/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fogas = await _context.Fogas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fogas == null)
            {
                return NotFound();
            }

            return View(fogas);
        }

        // GET: Fogasok/Create
        public async Task<IActionResult> Create()
        {
            Fogas fogas = new Fogas();
            var adat = await _context.User.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);

            fogas.Nev = adat.VezetekNev + " " + adat.KeresztNev;
            fogas.CsapatNev = adat.Csapatnev;
           
            await _context.SaveChangesAsync();
            return View(fogas);
        }

        // POST: Fogasok/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nev,CsapatNev,Ido,HalFajtak,Suly,Allasok")] Fogas fogas)
        {
            if (ModelState.IsValid)
            {
                fogas.Ido = DateTime.Now;


                _context.Add(fogas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fogas);
        }

        // GET: Fogasok/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fogas = await _context.Fogas.FindAsync(id);
            if (fogas == null)
            {
                return NotFound();
            }
            return View(fogas);
        }

        // POST: Fogasok/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nev,CsapatNev,Ido,HalFajtak,Suly,Allasok")] Fogas fogas)
        {
            if (id != fogas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fogas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FogasExists(fogas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fogas);
        }

        // GET: Fogasok/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fogas = await _context.Fogas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fogas == null)
            {
                return NotFound();
            }

            return View(fogas);
        }

        // POST: Fogasok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fogas = await _context.Fogas.FindAsync(id);
            _context.Fogas.Remove(fogas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Fogasok/Eredmenyek
        public async Task<IActionResult> Eredmenyek()
        {
            FogasokKeresese model = new FogasokKeresese();
            var adat = _context.Fogas.Select(x => x); //.OrderBy(x => x.Megnevezes);




            adat = adat.GroupBy(d => d.CsapatNev).Select(g => new Fogasnaplo.Models.Fogas
            {
                CsapatNev = g.Key,
                Suly = g.Sum(s => s.Suly)

            }).OrderByDescending(x => x.Suly);

            model.FogasLista = await adat.ToListAsync();
            return View(model);
        }


        private bool FogasExists(int id)
        {
            return _context.Fogas.Any(e => e.Id == id);
        }

        [Authorize(Roles = "SuperAdmin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index_Admin()
        {
            return View();
        }
    }
}
