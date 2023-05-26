using Bulky.DataAccess.Data.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CoverTypeController : Controller
{
	private readonly IUnitOfWork _unitOfWork;

    public CoverTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
	{
        IEnumerable<CoverType> objFromDb = _unitOfWork.CoverType.GetAll();
		return View(objFromDb);
	}

    // get
    public IActionResult Create()
    {
        return View();
    }

    // POST
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(CoverType obj)
    {
        if (ModelState.IsValid)
        {
			_unitOfWork.CoverType.Add(obj);
			_unitOfWork.Save();
			TempData["success"] = "Cover Type created successfully";
			return RedirectToAction(nameof(Index));
		}
        return View(obj);
    }

    // get
    public IActionResult Edit(int? id)
    {
        if (id is null || id == 0)
        {
            return NotFound();
        }
        var objFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        if (objFromDb is null)
        {
            return NotFound();
        }
        return View(objFromDb);
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        if (ModelState.IsValid)
        {
			_unitOfWork.CoverType.Update(obj);
			_unitOfWork.Save();
			TempData["success"] = "Cover Type updated successfully";
			return RedirectToAction(nameof(Index));
		}
        return View(obj);
	}

    // get
    public IActionResult Delete(int? id)
    {
        if (id is null || id == 0)
        {
            return NotFound();
        }
        var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        if (coverTypeFromDb is null)
        {
            return NotFound();
        }
        return View(coverTypeFromDb);
    }

    // POST
    [HttpPost, ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
		if (coverTypeFromDb is null)
        {
            return NotFound();
        }
        _unitOfWork.CoverType.Remove(coverTypeFromDb);
		_unitOfWork.Save();
        TempData["success"] = "Cover Type deleted successfully";
        return RedirectToAction(nameof(Index));
	}
}
