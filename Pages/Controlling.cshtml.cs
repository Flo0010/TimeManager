using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimeManager.Database;
using TimeManager.Extensions;
using TimeManager.Model;

namespace TimeManager.Pages
{
  public class ControllingPageModel : PageModel
  {
    public IActionResult OnPost(string idAbsence, bool value)
    {
      using (var db = new DatabaseContext())
      {
        // Gets user from db by id and changes the value of approved
        var absence = db.Absence.SingleOrDefault(a => a.ID == new Guid(idAbsence));
        absence.Approved = value;
        db.SaveChanges();
        // Returning page to update view
        return Page();
      }
    }

    public async Task<IActionResult> OnGetFerienlisteAsync()
    {
      UserModel user;
      using (var db = new DatabaseContext())
      {
        user = db.User.Where(u => u.ID == new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value)).FirstOrDefault();
      }
      var filename = "Ferienliste_" + user.Department + ".xlsx";

      await ExcelHandler.CreateFerienliste(user.Department);
      return File(System.IO.File.ReadAllBytes(filename), "application/vnd.ms-excel", filename);
    }

    public async Task<IActionResult> OnGetÜberzeitkontrolleAsync()
    {
      UserModel user;
      using (var db = new DatabaseContext())
      {
        user = db.User.Where(u => u.ID == new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value)).FirstOrDefault();
      }
      var filename = "Überzeitkontrolle_" + user.Department + ".xlsx";

      await ExcelHandler.CreateÜberzeitkontrolle(user.Department);
      return File(System.IO.File.ReadAllBytes(filename), "application/vnd.ms-excel", filename);
    }
  }
}