using DeckOfCards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        DeckDal api = new DeckDal();
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           UsersDeck newDeck = new UsersDeck();
           NewDeck nd = api.GetDeckId();
           newDeck.Deck = nd;
           string id = nd.deck_id;
           newDeck.DeckId = id;
           newDeck.DisplayCards = api.GetCards(id);
           return View(newDeck);
        }
  
        public IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}