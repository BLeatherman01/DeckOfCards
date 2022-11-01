using RestSharp;
using System;

namespace DeckOfCards.Models
{
    public class DeckDal
    {
        public NewDeck GetDeckId()
        {
            var client = new RestClient($"https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
            var request = new RestRequest();
            var reponse = client.GetAsync<NewDeck>(request);
            NewDeck deck = reponse.Result;
            
            return deck;
        }
    
        public DrawCards GetCards(string id)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{id}/draw/?count=5";
            
            var client = new RestClient(url);
            var request = new RestRequest();
            var reponse = client.GetAsync<DrawCards>(request);
            DrawCards cards = reponse.Result;

            return cards;
        }
    }
}
