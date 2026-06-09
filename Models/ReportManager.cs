using Microsoft.EntityFrameworkCore;
using sutnance.Data;
namespace sutnance.Models;

public class ReportManager(sutnanceContext dbContext)
{
    private async Task<string> GetReportId()
    {
        try
        {
            var lastMachine =
                await dbContext.Reports.OrderByDescending(m => m.CreationTime).Take(1).SingleAsync();
            var lastId = Convert.ToInt32(lastMachine.Id.Split('-')[1]);
            return "R-" + ((lastId + 1).ToString());

        }
        catch (InvalidOperationException)
        {
            return "R-001";
        }
    }

    /*public async Task<List<Machine>> Get(string? search, MachineState? state, int page = 0)
    {
        const int pageSize = 10;
        int skipCount = pageSize * page;

        var query =
            from machine in dbContext.Machines.AsQueryable().OrderByDescending(m => m.CreationTime)
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

                e.Name.ToLower().Contains(search) ||
                e.Ip.ToLower().Contains(search)
            );
        }

        if (state != null)
        {
            query = query.Where(e => (e.LastReport != null) && e.LastReport.State == state);
        }

        return await query.Skip(skipCount).Take(pageSize).ToListAsync();
    }
    */

    public async Task Create(string machineId, MachineState state)
    {
        var report = new Report()
        {
            Id = await GetReportId(),
            State = state,
            MachineId = machineId,
        };
        dbContext.Reports.Add(report);
        await dbContext.SaveChangesAsync();
    }

    /*public async Task Update(string id, string name, string type, string ip, string site, DateTime bootTime)
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
    }*/

    /*
    public async Task Delete(string id)
    {
        var machine = await dbContext.Machines.FindAsync(id) ?? throw new InvalidOperationException();
        dbContext.Machines.Remove(machine);
        await dbContext.SaveChangesAsync();
    }
    */

    public async Task SeedAsync()
    {
        if (await dbContext.Reports.AnyAsync())
            return;

        var machineIds = await dbContext.Machines.Select(m => m.Id).ToListAsync();
        foreach (var machineid in machineIds)
        {
            var rnd = new Random();

            var states = Enum.GetValues<MachineState>();
            var randomState = states[rnd.Next(states.Length)];
            await this.Create(machineid,randomState);
        }


        await dbContext.SaveChangesAsync();
    }
}