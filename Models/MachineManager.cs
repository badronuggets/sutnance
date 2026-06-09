using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using sutnance.Data;

namespace sutnance.Models;

public class MachineManager(sutnanceContext dbContext)
{
    private async Task<string> GetMachineId()
    {
        try
        {
            var lastMachine =
                await dbContext.Machines.OrderByDescending(m => m.CreationTime).Take(1).SingleAsync();
            var lastId = Convert.ToInt32(lastMachine.Id.Split('-')[1]);
            return "EQ-" + ((lastId + 1).ToString());

        }
        catch (InvalidOperationException )
        {
            return "EQ-001";
        }
    }

    public async Task<List<Machine>> Get(string? search,MachineState? state, int page = 0)
    {
        const int pageSize = 10;
        int skipCount = pageSize * page;

        var query =
            from machine in dbContext.Machines.AsQueryable().OrderByDescending(m=>m.CreationTime)
            join report in dbContext.Reports.AsQueryable()
                on machine.Id equals report.MachineId
                into reportjoin
            select new Machine()
            {
                Id = machine.Id,
                Name = machine.Name,
                Type = machine.Type,
                Ip = machine.Ip,
                Site = machine.Site,
                BootTime = machine.BootTime,

                LastReport = reportjoin
                    .OrderByDescending(r => r.CreationTime)
                    .FirstOrDefault()
            };
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(e =>
            
                e.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
                e.Ip.Contains(search, StringComparison.CurrentCultureIgnoreCase)
            );
        }

        if (state != null)
        {
            query = query.Where(e => (e.LastReport != null) && e.LastReport.State == state);
        }

        return await query.Skip(skipCount).Take(pageSize).ToListAsync();
    }
    public async Task Create(string name, string type, string ip,string site, DateTime bootTime)
    {
        var machine = new Machine()
        {
            Id = await GetMachineId(),
            Name = name,
            Type = type,
            Ip = ip,
            Site = site,
            BootTime = bootTime,
        };
        dbContext.Machines.Add(machine);
        await dbContext.SaveChangesAsync();
    }
    public async Task Update(string id, string name, string type, string ip, string site, DateTime bootTime)
    {
        var machine = new Machine()
        {
            Id = id,
            Name = name,
            Type = type,
            Ip = ip,
            Site = site,
            BootTime = bootTime,
        };
        dbContext.Machines.Update(machine);
        await dbContext.SaveChangesAsync();
    }
    public async Task Delete(string id)
    {
        var machine = await dbContext.Machines.FindAsync(id) ?? throw new InvalidOperationException();
        dbContext.Machines.Remove(machine);
        await dbContext.SaveChangesAsync();
    }

    public async Task SeedAsync()
    {
        if (await dbContext.Machines.AnyAsync())
        {
            return;
        }

        await this.Create("Badro PC", "Casrona", "172.0.0.1", "Tel Aviv", DateTime.UtcNow);
        await this.Create("Cisco Switch", "Switch", "172.0.0.1", "La DEX", DateTime.UtcNow);
        await this.Create("Modem 4G", "Modem", "172.0.0.1", "Bab Ezzouar", DateTime.UtcNow);
    }
}