namespace Infrastructure.Services;

internal class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}