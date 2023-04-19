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
                NewDeck result = await _deckApiService.GetNewDeck();

                result = await _deckApiService.ShuffleDeck(result.deck_id);

                DrawnDeck.Deck drawnCards = await _deckApiService.GetDrawnCards(result.deck_id);
                return View(drawnCards);
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