using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository;
using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;
using Microsoft.AspNetCore.Mvc;

namespace fitnessAppNew.Controllers
{
    public class UebungController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UebungController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objUebungenList = _unitOfWork.Uebungen.GetAll().ToList();
            return View(objUebungenList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Uebung obj)
        {
            if(ModelState.IsValid)
            {
                obj.UebungId = Guid.NewGuid();
                _unitOfWork.Uebungen.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Übung wurde erfolgreich erstellt";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Uebung? uebungFromDb = _unitOfWork.Uebungen.Get(u=>u.UebungId==id);

            if(uebungFromDb == null) 
            { 
                return NotFound(); 
            }

            return View(uebungFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Uebung obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Uebungen.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Die Änderungen wurden erfolgreich gespeichert";
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
            Uebung? uebungFromDb = _unitOfWork.Uebungen.Get(u => u.UebungId == id);

            if (uebungFromDb == null)
            {
                return NotFound();
            }

            return View(uebungFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Guid? id)
        {
            Uebung? uebungFromDb = _unitOfWork.Uebungen.Get(u => u.UebungId == id);

            if(uebungFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Uebungen.Delete(uebungFromDb);
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }

    }
}
