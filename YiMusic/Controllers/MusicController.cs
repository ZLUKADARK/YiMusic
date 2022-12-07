using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YiMusic.BLL.Interfaces;
using YiMusic.Domain.DataTranserObjects.Music;

namespace YiMusic.Controllers
{
    public class MusicController : Controller
    {
        private readonly IMusicServices _musicService;
        
        public MusicController (IMusicServices musicService)
        {
            _musicService = musicService;
        }

        // GET: MusicController
        public async Task<ActionResult> Index()
        {
            return View(await _musicService.GetAllMusic());
        }

        // GET: MusicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMusicDto item)
        {
            try
            {
                await _musicService.CreateMusic(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _musicService.DeleteMusic(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
