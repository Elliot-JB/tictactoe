using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;

namespace SearchService;


[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TicTacToeMatch>>> SearchMatches(string searchTerm)
    {
        var query = DB.Find<TicTacToeMatch>();

        query.Sort(m => m.Ascending(x => x.StartDate));

        var result = await query.ExecuteAsync();

        return result;
    }

}
