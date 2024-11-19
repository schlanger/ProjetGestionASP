using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetGestion.DTO;
using ProjetGestion.Entities;
using System.Net;

[ApiController]
[Route("api/[controller]")]

public class TacheController : Controller
    {
        private readonly ProjetGestionContext _dbContext;

        public TacheController(ProjetGestionContext dbContext)
        {
            _dbContext = dbContext;
        }

    [HttpGet("GetTasks")]
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

    // Lire une tache par son Id
    [HttpGet("GetTaskById")]
    public async Task<ActionResult<TacheDTO>> GetTaskById(int Id)
    {
        TacheDTO Tache = await _dbContext.Set<Tache>().Select(s => new TacheDTO
        {
            Id = s.Id,
            Titre = s.Titre,
            Contenu = s.Contenu,
            DateDeb = s.DateDeb,
            DateFin = s.DateFin

        }).FirstOrDefaultAsync(s => s.Id == Id);
        if (Tache == null)
        {
            return NotFound();
        }
        else
        {
            return Tache;
        }
    }

    // Ajouter une tâche
    [HttpPost("InsertTask")]
    public async Task<HttpStatusCode> InsertTask(TacheDTO Tache)
    {
        var entity = new Tache()
        {
            Titre = Tache.Titre,
            Contenu = Tache.Contenu,
            DateDeb = Tache.DateDeb,
            DateFin = Tache.DateFin
        };
        _dbContext.Set<Tache>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return HttpStatusCode.Created;
    }

    // Modifier une tâche
    [HttpPut("UpdateTask")]
    public async Task<HttpStatusCode> UpdateTask(TacheDTO Tache)
    {
        var entity = await _dbContext.Set<Tache>().FirstOrDefaultAsync(s => s.Id == Tache.Id);
        if (entity == null)
        {
            return HttpStatusCode.NotFound;
        }
        else
        {
            entity.Titre = Tache.Titre;
            entity.Contenu = Tache.Contenu;
            entity.DateDeb = Tache.DateDeb;
            entity.DateFin = Tache.DateFin;
            await _dbContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }

    // Supprimer une tâche
    [HttpDelete("DeleteTask/{Id}")]
    public async Task<HttpStatusCode> DeleteTask(int Id)
    {
        var entity = new Tache()
        {
            Id = Id
        };
        _dbContext.Set<Tache>().Attach(entity);
        _dbContext.Set<Tache>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return HttpStatusCode.OK;
    }



}
