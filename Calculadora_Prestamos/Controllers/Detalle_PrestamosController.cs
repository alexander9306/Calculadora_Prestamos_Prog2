using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Calculadora_Prestamos.Datos;
using Calculadora_Prestamos.Entidades;

namespace Calculadora_Prestamos.Controllers
{
    public class Detalle_PrestamosController : Controller
    {
        private readonly DbContextSistema _context;

        public Detalle_PrestamosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: Detalle_Prestamos
        public async Task<IActionResult> Index()
        {
            var dbContextSistema = _context.Detalle_Prestamos.Include(d => d.Prestamo);
            return View(await dbContextSistema.ToListAsync());
        }

        // GET: Detalle_Prestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_Prestamo = await _context.Detalle_Prestamos
                .Include(d => d.Prestamo)
                .FirstOrDefaultAsync(m => m.Detalle_PrestamoID == id);
            if (detalle_Prestamo == null)
            {
                return NotFound();
            }

            return View(detalle_Prestamo);
        }

        // GET: Detalle_Prestamos/Create
        public IActionResult Create()
        {
            ViewData["PrestamoID"] = new SelectList(_context.Prestamos, "PrestamoID", "PrestamoID");
            return View();
        }

        // POST: Detalle_Prestamos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Detalle_PrestamoID,PrestamoID,FechaPago,SaldoInicial,Cuotas,Avances,PagoTotal,Capital,Interes,BalanceFinal,InteresAcumulado")] Detalle_Prestamo detalle_Prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_Prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PrestamoID"] = new SelectList(_context.Prestamos, "PrestamoID", "PrestamoID", detalle_Prestamo.PrestamoID);
            return View(detalle_Prestamo);
        }

        // GET: Detalle_Prestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_Prestamo = await _context.Detalle_Prestamos.FindAsync(id);
            if (detalle_Prestamo == null)
            {
                return NotFound();
            }
            ViewData["PrestamoID"] = new SelectList(_context.Prestamos, "PrestamoID", "PrestamoID", detalle_Prestamo.PrestamoID);
            return View(detalle_Prestamo);
        }

        // POST: Detalle_Prestamos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Detalle_PrestamoID,PrestamoID,FechaPago,SaldoInicial,Cuotas,Avances,PagoTotal,Capital,Interes,BalanceFinal,InteresAcumulado")] Detalle_Prestamo detalle_Prestamo)
        {
            if (id != detalle_Prestamo.Detalle_PrestamoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_Prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_PrestamoExists(detalle_Prestamo.Detalle_PrestamoID))
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
            ViewData["PrestamoID"] = new SelectList(_context.Prestamos, "PrestamoID", "PrestamoID", detalle_Prestamo.PrestamoID);
            return View(detalle_Prestamo);
        }

        // GET: Detalle_Prestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_Prestamo = await _context.Detalle_Prestamos
                .Include(d => d.Prestamo)
                .FirstOrDefaultAsync(m => m.Detalle_PrestamoID == id);
            if (detalle_Prestamo == null)
            {
                return NotFound();
            }

            return View(detalle_Prestamo);
        }

        // POST: Detalle_Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalle_Prestamo = await _context.Detalle_Prestamos.FindAsync(id);
            _context.Detalle_Prestamos.Remove(detalle_Prestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_PrestamoExists(int id)
        {
            return _context.Detalle_Prestamos.Any(e => e.Detalle_PrestamoID == id);
        }
    }
}
