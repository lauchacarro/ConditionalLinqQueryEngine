using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using ConditonalLinqQueryEngine.Extensions;
using ConditonalLinqQueryEngine.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConditonalLinqQueryEngine.Pages
{
    public class IndexModel : PageModel
    {
        public List<BoardGame> Results { get; set; } = new List<BoardGame>();

        [BindProperty]
        public GameType SelectedGameType { get; set; }

        [BindProperty]
        [DisplayName("Search by Game Type")]
        public bool SearchByGameType { get; set; }

        [BindProperty]
        public int SelectedMinAge { get; set; }

        [BindProperty]
        [DisplayName("Search by Minimum Age")]
        public bool SearchByMinAge { get; set; }

        [BindProperty]
        public int SelectedPlayTime { get; set; }

        [BindProperty]
        [DisplayName("Search by Play Time")]
        public bool SearchByPlayTime { get; set; }

        [BindProperty]
        public int SelectedMaxPlayers { get; set; }

        [BindProperty]
        [DisplayName("Search by Max Players")]
        public bool SearchByMaxPlayers { get; set; }

        [BindProperty]
        public PlayType SelectedPlayType { get; set; }

        [BindProperty]
        [DisplayName("Search by Play Type")]
        public bool SearchByPlayType { get; set; }

        public IndexModel()
        {
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            BoardGameRepository repo = new BoardGameRepository();
            Results = repo.GetAll();

            Results = Results.WhereIf(SearchByGameType, x => x.GameType == SelectedGameType)
                             .WhereIf(SearchByMinAge, x => x.SuggestedMinimumAge >= SelectedMinAge)
                             .WhereIf(SearchByPlayTime, x => x.AverageGameTimeMinutes >= SelectedPlayTime)
                             .WhereIf(SearchByMaxPlayers,x => x.MaxPlayers == SelectedMaxPlayers)
                             .WhereIf(SearchByPlayType, x => x.PlayType == SelectedPlayType)
                             .ToList();
        }
    }
}
