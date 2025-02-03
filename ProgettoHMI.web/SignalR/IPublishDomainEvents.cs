using System.Threading.Tasks;

namespace ProgettoHMI.web.SignalR
{
    public interface IPublishDomainEvents
    {
        Task Publish(object evnt);
    }
}
