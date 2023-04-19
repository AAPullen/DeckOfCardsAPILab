using DeckOfCardsAPILab.Models;
using System.Reflection.Metadata.Ecma335;
using static System.Net.WebRequestMethods;

namespace DeckOfCardsAPILab.Services
{
    public class DeckApiService
    {
        private readonly HttpClient _httpClient;
        public DeckApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NewDeck> GetNewDeck()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("new/");

            NewDeck result = await response.Content.ReadAsAsync<NewDeck>();

            return result;
        }

        public async Task<NewDeck> ShuffleDeck(string deckId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{deckId}/shuffle/");

            NewDeck result = await response.Content.ReadAsAsync<NewDeck>();

            return result;
        }

        public async Task<DrawnDeck.Deck> GetDrawnCards(string deckId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{deckId}/draw/?count=5");

            DrawnDeck.Deck result = await response.Content.ReadAsAsync<DrawnDeck.Deck>();

            return result;
        }

    }
}