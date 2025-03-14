﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetGestion.DTO;
using ProjetGestion.Entities;
using System.Net;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // Appel à la classe de type DbContext pour la connexion à la base de données
    private readonly ProjetGestionContext _dbContext;

    public UserController(ProjetGestionContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Lister les utilisateurs
    [HttpGet("GetUsers")]
    public async Task<ActionResult<List<UserDTO>>> Get()
    {
        var List = await _dbContext.Set<User>().Select(
            s => new UserDTO
            {
                Id = s.Id,
                Nom = s.Nom,
                Prenom = s.Prenom,
                Email = s.Email
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

    // Lire un utilisateur par son Id
    [HttpGet("GetUserById")]
    public async Task<ActionResult<UserDTO>> GetUserById(int Id)
    {
        UserDTO User = await _dbContext.Set<User>().Select(s => new UserDTO
        {
            Id = s.Id,
            Nom = s.Nom,
            Prenom = s.Prenom,
            Email = s.Email
        }).FirstOrDefaultAsync(s => s.Id == Id);
        if (User == null)
        {
            return NotFound();
        }
        else
        {
            return User;
        }
    }

    // Ajouter un utilisateur
    [HttpPost("InsertUser")]
    public async Task<HttpStatusCode> InsertUser(UserDTO User)
    {
        var entity = new User()
        {
            Nom = User.Nom,
            Prenom = User.Prenom,
            Email = User.Email,
        };
        _dbContext.Set<User>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return HttpStatusCode.Created;
    }

    // Modifier un utilisateur
    [HttpPut("UpdateUser")]
    public async Task<HttpStatusCode> UpdateUser(UserDTO User)
    {
        var entity = await _dbContext.Set<User>().FirstOrDefaultAsync(s => s.Id == User.Id);
        entity.Nom = User.Nom;
        entity.Prenom = User.Prenom;
        entity.Email = User.Email;
        await _dbContext.SaveChangesAsync();
        return HttpStatusCode.OK;
    }

    // Supprimer un utilisateur
    [HttpDelete("DeleteUser/{Id}")]
    public async Task<HttpStatusCode> DeleteUser(int Id)
    {
        var entity = new User()
        {
            Id = Id
        };
        _dbContext.Set<User>().Attach(entity);
        _dbContext.Set<User>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return HttpStatusCode.OK;
    }
}
