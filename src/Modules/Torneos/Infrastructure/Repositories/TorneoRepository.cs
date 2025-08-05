using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Application.Interfaces;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;
using LigaTorneo.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace LigaTorneo.src.Modules.Torneos.Infrastructure.Repositories;

public class TorneoRepository : ITorneoRepository
{
    private readonly AppDbContext _context;

    public TorneoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Torneo?> GetByIdAsync(int id)
    {
        return await _context.Torneos
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Torneo?>> GetAllAsync() =>
        await _context.Torneos.ToListAsync();

    public void Add(Torneo entity)
    {
        _context.Torneos.Add(entity);
    }

    public void Remove(Torneo entity) =>
        _context.Torneos.Remove(entity);


    public void Update(Torneo entity) =>
        _context.SaveChanges();
    public async Task SaveAsync() =>
    await _context.SaveChangesAsync();

}
