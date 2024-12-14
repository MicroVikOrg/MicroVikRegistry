using MicroVikRegistry.WebApi.Database;

namespace MicroVikRegistry.WebApi.Nodes.Infrastructure
{
    public interface INodeRepository
    {
        Task<bool> ExistsAsync(string url, ApplicationContext context);
        Task InsertAsync(Node node, ApplicationContext context);
    }
}
