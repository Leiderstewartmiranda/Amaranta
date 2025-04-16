using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMARANTA.Models;

namespace AMARANTA.Controllers
{
    public class AbonosController : Controller
    {
        private readonly AmarantaContext _context;

        public AbonosController(AmarantaContext context)
        {
            _context = context;
        }

        // GET: Abonos
        public async Task<IActionResult> Index()
        {
            var amarantaContext = _context.Abonos.Include(a => a.IdUsuarioNavigation);
            return View(await amarantaContext.ToListAsync());
        }

        // GET: Abonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abono = await _context.Abonos
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodigoAbono == id);
            if (abono == null)
            {
                return NotFound();
            }

            return View(abono);
        }

        // GET: Abonos/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: Abonos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoAbono,FechaAbono,Abonado,IdUsuario")] Abono abono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre", abono.IdUsuario);
            return View(abono);
        }

        // GET: Abonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abono = await _context.Abonos.FindAsync(id);
            if (abono == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre", abono.IdUsuario);
            return View(abono);
        }

        // POST: Abonos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoAbono,FechaAbono,Abonado,IdUsuario")] Abono abono)
        {
            if (id != abono.CodigoAbono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbonoExists(abono.CodigoAbono))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre", abono.IdUsuario);
            return View(abono);
        }

        // GET: Abonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abono = await _context.Abonos
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodigoAbono == id);
            if (abono == null)
            {
                return NotFound();
            }

            return View(abono);
        }

        // POST: Abonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abono = await _context.Abonos.FindAsync(id);
            if (abono != null)
            {
                _context.Abonos.Remove(abono);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbonoExists(int id)
        {
            return _context.Abonos.Any(e => e.CodigoAbono == id);
        }
    }
}
