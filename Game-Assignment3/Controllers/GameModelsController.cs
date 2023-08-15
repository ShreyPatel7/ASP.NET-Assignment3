﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Game_Assignment3.Data;
using Game_Assignment3.Models;

namespace Game_Assignment3.Controllers
{
    public class GameModelsController : Controller
    {
        private readonly Game_Assignment3Context _context;

        public GameModelsController(Game_Assignment3Context context)
        {
            _context = context;
        }

        // GET: GameModels
        public async Task<IActionResult> Index()
        {
            return _context.GameModel != null ?
                        View(await _context.GameModel.ToListAsync()) :
                        Problem("Entity set 'Game_Assignment3Context.GameModel'  is null.");
        }

        // GET: GameModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameModel == null)
            {
                return NotFound();
            }

            var gameModel = await _context.GameModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameModel == null)
            {
                return NotFound();
            }

            return View(gameModel);
        }

        // GET: GameModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,ReleaseDate,Price")] GameModel gameModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameModel);
        }

        // GET: GameModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameModel == null)
            {
                return NotFound();
            }

            var gameModel = await _context.GameModel.FindAsync(id);
            if (gameModel == null)
            {
                return NotFound();
            }
            return View(gameModel);
        }

        // POST: GameModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,ReleaseDate,Price")] GameModel gameModel)
        {
            if (id != gameModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameModelExists(gameModel.Id))
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
            return View(gameModel);
        }

        // GET: GameModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameModel == null)
            {
                return NotFound();
            }

            var gameModel = await _context.GameModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameModel == null)
            {
                return NotFound();
            }

            return View(gameModel);
        }

        // POST: GameModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameModel == null)
            {
                return Problem("Entity set 'Game_Assignment3Context.GameModel'  is null.");
            }
            var gameModel = await _context.GameModel.FindAsync(id);
            if (gameModel != null)
            {
                _context.GameModel.Remove(gameModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameModelExists(int id)
        {
            return (_context.GameModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
