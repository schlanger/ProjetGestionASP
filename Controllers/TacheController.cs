using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetGestion.DTO;
using ProjetGestion.Entities;

[ApiController]
[Route("api/[controller]")]

public class TacheController : Controller
    {
        private readonly ProjetGestionContext _dbContext;

        public TacheController(ProjetGestionContext dbContext)
        {
            _dbContext = dbContext;
        }

    [HttpGet("GetTaches")]
    public async Task<ActionResult<List<TacheDTO>>> Get()
    {
        var List = await _dbContext.Set<Tache>().Select(
            s => new TacheDTO
            {
                Id = s.Id,
                Titre = s.Titre,
                Contenu = s.Contenu,
                DateDeb = s.DateDeb,
                DateFin = s.DateFin
            }
        ).ToListAsync();

        if (List.Count < 0)
        {
            return NotFound();
        }
        else
        {
            return List;
        }
    }



}
