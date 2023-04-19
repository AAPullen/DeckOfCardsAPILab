using DeckOfCardsAPILab.Models;
using DeckOfCardsAPILab.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsAPILab.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeckApiService _deckApiService;
        public HomeController(DeckApiService deckApiService)
        {
            _deckApiService = deckApiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                DrawnDeck.Deck result = await _deckApiService.GetDrawnCards();
                return View(result);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                Debug.WriteLine(ex);
                return View();
            }
        }

    }
}