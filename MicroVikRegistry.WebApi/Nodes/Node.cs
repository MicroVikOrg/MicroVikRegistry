using Microsoft.EntityFrameworkCore;

namespace MicroVikRegistry.WebApi.Nodes
{
    public sealed class Node
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = null!;
        public string? Location { get; set; }
        public bool IsOffical { get; set; }
        public DateTime? StartedAt { get; set; }
        public string? Wallet { get; set; }
    }
}
