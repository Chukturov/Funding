using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Funding.Data;
using Funding.Data.Model;

namespace Funding.Controllers
{
    public class PostsController : Controller
    {
        private readonly FundingContext _context;

        public PostsController(FundingContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index(string id)
        {
            var posts = await _context.Post.ToListAsync();
            if (id != null)
            {
                posts = await _context.Post.Where(p => p.Campaign.Id == id).ToListAsync();
            }
            return View(posts);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreateDate = DateTime.Now.ToString();
                post.Campaign = await _context.Campaign.FirstOrDefaultAsync(c => c.Id == post.Campaign.Id);
                post.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == post.User.Id);
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Img,Name,ShortDescription,Text")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Like(string PostId, string UserId)
        {
            if (ModelState.IsValid)
            {
                Like like = new Like();
                like.Post = await _context.Post.FirstOrDefaultAsync(p => p.Id == PostId);
                like.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
                _context.Add(like);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            //if (id != like.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(like);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!LikeExists(like.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(like);
        }

        [HttpPost]
        public async Task<JsonResult> LikeTest(string PostId, string UserId)
        {
            var result = _context.Like.Where(l => l.Post.Id == PostId && l.User.Id == UserId).ToList();
            if (result.Count!=0)
            {
                _context.Like.RemoveRange(result);
                await _context.SaveChangesAsync();
                return Json(false);
            }
            Like like = new Like();
            like.Post = await _context.Post.FirstOrDefaultAsync(p => p.Id == PostId);
            like.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            _context.Add(like);
            await _context.SaveChangesAsync();
            return Json(true);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(string id)
        {
            return _context.Post.Any(e => e.Id == id);
        }

        private bool LikeExists(string id)
        {
            return _context.Like.Any(e => e.Id == id);
        }
    }
}
