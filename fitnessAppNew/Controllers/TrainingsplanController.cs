using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace fitnessAppNew.Controllers
{
    public class TrainingsplanController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public TrainingsplanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objTrainingsplaeneList = _unitOfWork.Trainingsplaene.GetAll().ToList();
            return View(objTrainingsplaeneList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Uebung obj)
        {
            if (ModelState.IsValid)
            {
                obj.UebungId = Guid.NewGuid();
                _unitOfWork.Uebungen.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Der Trainingsplan wurde erfolgreich erstellt";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Rename(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Trainingsplan? trainingsplanFromDb = _unitOfWork.Trainingsplaene.Get(u => u.TrainingsplanId == id);

            if (trainingsplanFromDb == null)
            {
                return NotFound();
            }

            return View(trainingsplanFromDb);
        }

        [HttpPost]
        public IActionResult Rename( Trainingsplan obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Trainingsplaene.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Der Trainingsplan wurde erfolgreich umbenannt";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Trainingsplan? trainingsplanFromDb = _unitOfWork.Trainingsplaene.Get(u => u.TrainingsplanId == id);

            if (trainingsplanFromDb == null)
            {
                return NotFound();
            }

            List<GeplanteUebung> zugehoerigeUebungen = _unitOfWork.GeplanteUebungen.getGeplanteUebungenWithUebung(id);

            ViewBag.UebungsListe = zugehoerigeUebungen;

            return View(trainingsplanFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Guid? id)
        {
            Trainingsplan trainingsplanFromDb = _unitOfWork.Trainingsplaene.Get(u => u.TrainingsplanId == id);

            if (trainingsplanFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Trainingsplaene.Delete(trainingsplanFromDb);

            //Alle zugehörigen Übungen auch löschen
            List<GeplanteUebung> zugehoerigeUebungen = _unitOfWork.GeplanteUebungen.GetAllWithFilter(u => u.TrainingsplanId == id).ToList();
            if(zugehoerigeUebungen.Count > 0)
            {
                _unitOfWork.GeplanteUebungen.DeleteRange(zugehoerigeUebungen);
            }
            _unitOfWork.Save();

            TempData["success"] = "Der Trainingsplan wurde erfolgreich gelöscht";
            return RedirectToAction("Index");
        }

        
        public IActionResult EditUebungen(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Trainingsplan? trainingsplanFromDb = _unitOfWork.Trainingsplaene.Get(u => u.TrainingsplanId == id);

            if (trainingsplanFromDb == null)
            {
                return NotFound();
            }

            List<GeplanteUebung> zugehoerigeUebungen = _unitOfWork.GeplanteUebungen.getGeplanteUebungenWithUebung(id);

            ViewBag.UebungsListe = zugehoerigeUebungen;

            return View(trainingsplanFromDb);
        }

        public IActionResult AddUebung(Guid tpid)
        {
            GeplanteUebung geplanteUebung = new GeplanteUebung();

            geplanteUebung.TrainingsplanId = tpid;
            ViewBag.Uebungen = _unitOfWork.Uebungen.GetAll().ToList();
            return View(geplanteUebung);
        }

        [HttpPost]
        public IActionResult AddUebung(GeplanteUebung obj)
        {
            if (ModelState.IsValid)
            {
                obj.GeplanteUebungId = Guid.NewGuid();
                _unitOfWork.GeplanteUebungen.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Die Übung wurde erfolgreich hinzugefügt";
                return RedirectToAction("EditUebungen", new { id = obj.TrainingsplanId });
            }
            return View();
        }

        public IActionResult EditUebung(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GeplanteUebung geplanteUebung = _unitOfWork.GeplanteUebungen.Get(u => u.GeplanteUebungId == id);

            if(geplanteUebung == null)
            { 
                return NotFound(); 
            }

            ViewBag.Uebungen = _unitOfWork.Uebungen.GetAll().ToList();

            return View(geplanteUebung);
        }

        [HttpPost]
        public IActionResult EditUebung( GeplanteUebung obj )
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.GeplanteUebungen.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Die Änderungen wurden erfolgreich gespeichert";
                return RedirectToAction("EditUebungen", new { id = obj.TrainingsplanId});
            }
            return View();
        }

        public IActionResult DeleteUebung(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GeplanteUebung? geplanteUebung = _unitOfWork.GeplanteUebungen.getGeplanteUebungWithUebung(id);

            if (geplanteUebung == null)
            {
                return NotFound();
            }

            return View(geplanteUebung);
        }

        [HttpPost, ActionName("DeleteUebung")]
        public IActionResult DeleteUebungPost(Guid? id)
        {
            if(id == null) 
            { 
                return NotFound(); 
            }

            GeplanteUebung geplanteUebungFromDb = _unitOfWork.GeplanteUebungen.Get(u => u.GeplanteUebungId == id);

            if(geplanteUebungFromDb == null )
            {
                return NotFound();
            }

            _unitOfWork.GeplanteUebungen.Delete(geplanteUebungFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Die Änderungen wurden erfolgreich gespeichert";
            return RedirectToAction("EditUebungen", new { id = geplanteUebungFromDb.TrainingsplanId });
        }



    }
}
