using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Funding.Data;
using Funding.Data.Model;
using Microsoft.AspNetCore.Identity;
using Funding.Areas.Identity.Data;
using Dropbox.Api;
using System.IO;
using System.Text.RegularExpressions;
using Dropbox.Api.Files;

namespace Funding.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly FundingContext _context;
        private static string token = "QAY0acSlThsAAAAAAAAAAT5434MivLSp9jW9JZcy6Q6E5apgXHpirN0MiLmqDoE_";

        public CampaignsController(FundingContext context)
        {
            _context = context;
        }

        // GET: Campaigns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campaign.ToListAsync());
        }

        // GET: Campaigns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaign
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // GET: Campaigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                using (var dbx = new DropboxClient(token))
                {
                    List<CampaignImgs> campaignImgs = new List<CampaignImgs>();
                    var PathImg = $"/{campaign.Name}/";
                    //campaign.ImgFiles = HttpContext.Request.Form.Files;
                    foreach (var item in campaign.ImgFiles)
                    {
                        var metadata = await dbx.Files.UploadAsync(PathImg + item.FileName, WriteMode.Add.Instance, true, body: item.OpenReadStream());
                        campaignImgs.Add(new CampaignImgs()
                        {
                            campaign = campaign,
                            Name = metadata.Name,
                            Alt = metadata.Name,
                            ImgLink = metadata.PathLower
                        });
                    }
                    _context.AddRange(campaignImgs);//Разобраться с sql
                }

                campaign.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == campaign.User.Id);
                _context.Add(campaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        [HttpPost]
        public async Task<JsonResult> UploadImage(string file)
        {
            if (file == null)
            {
                return Json(false);
            }
            var base64Data = Regex.Match(file, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            using (var dbx = new DropboxClient(token))
            {
                string folder = "/Public";
                string filename = "test.png";
                using (var stream = new MemoryStream(binData))
                {
                    await dbx.Files.UploadAsync(folder + "/" + filename, WriteMode.Overwrite.Instance, body: stream);
                }
            }
            return Json(true);
        }

        // GET: Campaigns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaign.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    campaign.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == campaign.User.Id);

                    _context.Update(campaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignExists(campaign.Id))
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
            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaign
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var campaign = await _context.Campaign.FindAsync(id);
            _context.Campaign.Remove(campaign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignExists(string id)
        {
            return _context.Campaign.Any(e => e.Id == id);
        }
    }
}
