using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SacramentsController : Controller
    {
        private readonly SacramentContext _context;

        public SacramentsController(SacramentContext context)
        {
            _context = context;
        }

        // GET: Sacraments
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Sacrament.Include(s => s.Speakers).ToListAsync());

        }

        // GET: Sacraments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacrament = await _context.Sacrament
                .Include(s => s.Speakers)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sacrament == null)
            {
                return NotFound();
            }

            return View(sacrament);
        }

        // GET: Sacraments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sacraments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Sacraments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Conducting,OpeningHymn,OpeningPrayer,SacramentHymn,IntermediateHymn,ClosingHymn,ClosingPrayer,Presiding")] Sacrament sacrament)
        {
            if (ModelState.IsValid)
            {

                if (sacrament != null)
                {
                    _context.Add(sacrament);
                    await _context.SaveChangesAsync();
                }
                string[] spk = Request.Form["Speaker"];
                string[] tpc = Request.Form["Topic"];
                List<Speaker> speakers = new List<Speaker>();
                for (int i = 0; i < spk.Length; i++)
                {
                    var speakr = new Speaker { SpeakerName = spk[i], Topic = tpc[i], SacramentID = sacrament.ID };
                    speakers.Add(speakr);
                }

                foreach (Speaker s in speakers)
                {
                    _context.Add(s);
                }

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(sacrament);
        }



        // GET: Sacraments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacrament = await _context.Sacrament
                 .Include(s => s.Speakers)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            if (sacrament == null)
            {
                return NotFound();
            }
            return View(sacrament);
        }

        // POST: Sacraments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Conducting,OpeningHymn,OpeningPrayer,SacramentHymn,IntermediateHymn,ClosingHymn,ClosingPrayer,Presiding")] Sacrament sacrament)
        {



            if (id != sacrament.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacrament);
                    await _context.SaveChangesAsync();


                    //what we are trying to do to delete the fields from the database and then let it add the new fields
                //    Speaker speakerToBeDeleted = await _context.Speakers
                //        .AsNoTracking()
                //        .SingleAsync(i => i.ID == id);
                //    speakerToBeDeleted.ForEach(d => d.ID = null);

                //    var departments = await _context.Departments
                //.Where(d => d.InstructorID == id)
                //.ToListAsync();
                //    departments.ForEach(d => d.InstructorID = null);

                //    if (speakerToBeDeleted != null)
                //        _context.Speakers.Remove(speakerToBeDeleted);

                    //This has added the new fields to the database
                    string[] spk = new string[] { };
                    string[] tpc = new string[] { };
                     spk = Request.Form["Speaker"];
                     tpc = Request.Form["Topic"];
                    List<Speaker> speakers = new List<Speaker>();
                    for (int i = 0; i < spk.Length; i++)
                    {
                        var speakr = new Speaker { SpeakerName = spk[i], Topic = tpc[i], SacramentID = sacrament.ID };
                        speakers.Add(speakr);
                    }

                    foreach (Speaker s in speakers)
                    {
                        _context.Add(s);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacramentExists(sacrament.ID))
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
            return View(sacrament);
        }

     

        // GET: Sacraments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacrament = await _context.Sacrament
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sacrament == null)
            {
                return NotFound();
            }

            return View(sacrament);
        }

        // POST: Sacraments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sacrament = await _context.Sacrament.FindAsync(id);
            _context.Sacrament.Remove(sacrament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacramentExists(int id)
        {
            return _context.Sacrament.Any(e => e.ID == id);
        }
    }
}
