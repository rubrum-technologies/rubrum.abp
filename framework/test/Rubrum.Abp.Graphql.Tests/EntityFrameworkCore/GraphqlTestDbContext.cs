using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Rubrum.Abp.Graphql.EntityFrameworkCore;

public class GraphqlTestDbContext : AbpDbContext<GraphqlTestDbContext>
{
    public GraphqlTestDbContext(DbContextOptions<GraphqlTestDbContext> options) : base(options)
    {
    }
}