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
    public class PrestamosController : Controller
    {
        private readonly DbContextSistema _context;

        public PrestamosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: Prestamos
        public async Task<IActionResult> Index()
        {
            var dbContextSistema = _context.Prestamos.Include(p => p.Cliente).Include(p => p.Usuario);
            return View(await dbContextSistema.ToListAsync());
        }

        public ActionResult Indexs(int id)
        {
            var prestamo = _context.Prestamos.Include(p => p.Cliente).Include(p => p.Usuario).Where(p => p.Cliente.ClienteID.Equals(id));
            return View("Index", prestamo.ToList());
        }

        // GET: Prestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Cliente)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PrestamoID == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Apellido");
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contrasena");
            return View();
        }

        // POST: Prestamos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestamoID,MontoPrestamo,InteresAnual,PrediodoPrestamosAnnos,NumeroPagosAnno,FechaInicio,PagosAdicionales,UsuarioID,ClienteId")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Apellido", prestamo.ClienteId);
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contrasena", prestamo.UsuarioID);
            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Apellido", prestamo.ClienteId);
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contrasena", prestamo.UsuarioID);
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrestamoID,MontoPrestamo,InteresAnual,PrediodoPrestamosAnnos,NumeroPagosAnno,FechaInicio,PagosAdicionales,UsuarioID,ClienteId")] Prestamo prestamo)
        {
            if (id != prestamo.PrestamoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.PrestamoID))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteID", "Apellido", prestamo.ClienteId);
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contrasena", prestamo.UsuarioID);
            return View(prestamo);
        }

        // GET: Prestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Cliente)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PrestamoID == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.PrestamoID == id);
        }
    }
}
