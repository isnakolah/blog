using System.Reflection;
using Domain.Common.Entities;
using Domain.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IDateTime _dateTime;
    private readonly IDomainEventService _domainEventService;

    public ApplicationDbContext(DbContextOptions options, IDateTime dateTime, IDomainEventService domainEventService) : base(options)
    {
        (_dateTime, _domainEventService) = (dateTime, domainEventService);
    }

    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<Sex> Sexes => Set<Sex>();
    public DbSet<Occupation> Occupations => Set<Occupation>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedById = Guid.NewGuid();
                    entry.Entity.CreatedOn = _dateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.EditedById = Guid.NewGuid();
                    entry.Entity.EditedOn = _dateTime.Now;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents();

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    private async Task DispatchEvents()
    {
        while (true)
        {
            var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .FirstOrDefault(domainEvent => !domainEvent.IsPublished);

            if (domainEventEntity is null)
                break;

            domainEventEntity.IsPublished = true;

            await _domainEventService.PublishAsync(domainEventEntity);
        }
    }
}