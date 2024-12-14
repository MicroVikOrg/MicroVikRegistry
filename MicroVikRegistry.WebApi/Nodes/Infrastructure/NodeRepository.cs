using Microsoft.EntityFrameworkCore;
using MicroVikRegistry.WebApi.Database;

namespace MicroVikRegistry.WebApi.Nodes.Infrastructure
{
    public class NodeRepository : INodeRepository
    {
        public async Task<bool> ExistsAsync(string url, ApplicationContext context)
        {
            return await context.Nodes.AnyAsync(n =>  n.Url == url);
        }

        public async Task InsertAsync(Node node, ApplicationContext context)
        {
            context.Nodes.Add(node);
            await context.SaveChangesAsync();
        }
    }
}
