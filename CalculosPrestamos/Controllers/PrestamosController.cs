using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalculosPrestamos.DAL;
using CalculosPrestamos.Models;

namespace CalculosPrestamos.Controllers
{
    public class PrestamosController : Controller
    {
        private CalculosPrestamosContext db = new CalculosPrestamosContext();

        // GET: Prestamos
        public ActionResult Index()
        {
            var prestamo = db.Prestamo.Include(p => p.Cliente).Include(p => p.Usuario);
            return View(prestamo.ToList());
        }
        //Filtro
        public ActionResult Indexs(int id)
        {
            var prestamo = db.Prestamo.Include(p => p.Cliente).Include(p => p.Usuario).Where(p=>p.Cliente.ClienteID.Equals(id));
            return View("Index",prestamo.ToList());
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            prestamo.DetallesPrestamos = CrearDetalles(prestamo);
            return View(prestamo);
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteID", "Nombre");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioId", "Nombre");
            return View();
        }

        // POST: Prestamos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrestamoID,MontoPrestamo,InteresAnual,PrediodoPrestamosAnnos,NumeroPagosAnno,FechaInicio,PagosAdicionales,UsuarioID,ClienteId")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                bool exist = false;
                Cliente cliente = null ;
                foreach (var item in db.Prestamo)
                {
                    if (item.ClienteId == prestamo.ClienteId)
                    {
                        cliente = item.Cliente;
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    db.Prestamo.Add(prestamo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteID", "Nombre", prestamo.ClienteId);
                    ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioId", "Nombre", prestamo.UsuarioID);
                    ViewBag.Message = string.Format("El cliente {0} {1} ya tiene un prestamo asociado", cliente.Nombre, cliente.Apellido);
                    return View(prestamo);
                }
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteID", "Nombre", prestamo.ClienteId);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioId", "Nombre", prestamo.UsuarioID);
            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteID", "Nombre", prestamo.ClienteId);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioId", "Nombre", prestamo.UsuarioID);
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrestamoID,MontoPrestamo,InteresAnual,PrediodoPrestamosAnnos,NumeroPagosAnno,FechaInicio,PagosAdicionales,UsuarioID,ClienteId")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteID", "Nombre", prestamo.ClienteId);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioId", "Nombre", prestamo.UsuarioID);
            return View(prestamo);
        }

        // GET: Prestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamo.Find(id);
            db.Prestamo.Remove(prestamo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public List<DetallesPrestamo> CrearDetalles(Prestamo prestamo)
        {
            DetallesPrestamo[] detalles = new DetallesPrestamo[prestamo.NumeroPagosAnno * prestamo.PrediodoPrestamosAnnos];
            int Plazo = prestamo.NumeroPagosAnno * prestamo.PrediodoPrestamosAnnos;
            double TazaInteresPorAnno = (prestamo.InteresAnual / 100) / Plazo;
            double SaldoInicial = prestamo.MontoPrestamo;
            DateTime Fecha = prestamo.FechaInicio;
            double Cuotas = (TazaInteresPorAnno * SaldoInicial) / (1 - Math.Pow((1 + TazaInteresPorAnno), -Plazo));
            double Avances;
            if (Cuotas + prestamo.PagosAdicionales < SaldoInicial)
            {
                Avances = prestamo.PagosAdicionales;
            }
            else if (SaldoInicial - Cuotas > 0)
            {
                Avances = SaldoInicial - Cuotas;
            }
            else
            {
                Avances = 0;
            }
            double PagoTotal = (Cuotas + Avances <= SaldoInicial) ? (Cuotas + Avances) : SaldoInicial;
            double Intereses = SaldoInicial * (TazaInteresPorAnno);
            double Capital = PagoTotal - Intereses;
            double BalanceFinal = (Cuotas + Avances <= SaldoInicial) ? (SaldoInicial - Capital) : 0;
            double InteresesAcumulados = Intereses;

            detalles[0] = new DetallesPrestamo();
            detalles[0].PrestamoID = prestamo.PrestamoID;
            detalles[0].FechaPago = Fecha;
            detalles[0].SaldoInicial = SaldoInicial;
            detalles[0].Cuotas = Cuotas;
            detalles[0].Avances = Avances;
            detalles[0].PagoTotal = PagoTotal;
            detalles[0].Interes = Intereses;
            detalles[0].Capital = Capital;
            detalles[0].BalanceFinal = BalanceFinal;
            detalles[0].InteresAcumulado = InteresesAcumulados;

            for (int i = 1; i < detalles.Length; i++)
            {
                detalles[i] = new DetallesPrestamo();
                detalles[i].PrestamoID = prestamo.PrestamoID;
                detalles[i].FechaPago = detalles[i - 1].FechaPago.AddMonths(1);
                detalles[i].SaldoInicial = detalles[i - 1].BalanceFinal;
                detalles[i].Cuotas = Cuotas;
                if (detalles[i].Cuotas + prestamo.PagosAdicionales < detalles[i].SaldoInicial)
                {
                    detalles[i].Avances = prestamo.PagosAdicionales;
                }
                else if (detalles[i].SaldoInicial - detalles[i].Cuotas > 0)
                {
                    detalles[i].Avances = detalles[i].SaldoInicial - detalles[i].Cuotas;
                }
                else
                {
                    detalles[i].Avances = 0;
                }
                detalles[i].PagoTotal = (detalles[i - 1].Cuotas + Avances <= detalles[i].SaldoInicial) ? (detalles[i].Cuotas + Avances) : detalles[i].SaldoInicial;
                detalles[i].Interes = detalles[i].SaldoInicial * (TazaInteresPorAnno);
                detalles[i].Capital = detalles[i].PagoTotal - detalles[i].Interes;
                detalles[i].BalanceFinal = (Cuotas + Avances <= detalles[i].SaldoInicial) ? (detalles[i].SaldoInicial - detalles[i].Capital) : 0;
                detalles[i].InteresAcumulado = detalles[i - 1].InteresAcumulado + detalles[i].Interes;
            }

            return detalles.ToList();
        }
    }
}
