using System.Collections.ObjectModel;
using MediatR;

namespace BaseballStatsApi.Domain;

public abstract class Entity
{
    private List<INotification> _domainEvents = new();
    public ReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();
    public void AddDomainEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);
    public void RemoveDomainEvent(INotification domainEvent) => _domainEvents.Remove(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}