using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FredsBoats.Web.Data;
using FredsBoats.Web.Models;

namespace FredsBoats.Web.Controllers
{
    public class BoatsController : Controller
    {
        private readonly FredsBoatsContext _context;

        public BoatsController(FredsBoatsContext context)
        {
            _context = context;
        }

        // GET: Boats
        public async Task<IActionResult> Index()
        {
            var boats = _context.Boats
                .Include(b => b.Category)
                .Include(b => b.BoatColour);
            return View(await boats.ToListAsync());
        }

        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var boat = await _context.Boats
                .Include(b => b.Category)
                .Include(b => b.BoatColour)
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(m => m.BoatId == id);

            if (boat == null) return NotFound();

            return View(boat);
        }
    }
    [HTTPpost]
    public async Task<IActionResult> AddComment(int BoatId, string Author, string Content)
    {
        var comment=new Comment
        {
            BoatId = BoatId,
            Author = Author,
            Content = Content,
            CreatedAt = DateTime.Now
        };
        _content.Add(comment);
        await _content.SaveChangesAsyncO();
        return RedirectToAction("Details", new {id = BoatId});
    }
}