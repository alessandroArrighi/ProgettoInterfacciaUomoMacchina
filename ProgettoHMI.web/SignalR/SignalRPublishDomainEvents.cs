﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ProgettoHMI.web.SignalR.Hubs;
using ProgettoHMI.web.SignalR.Hubs.Events;

namespace ProgettoHMI.web.SignalR
{
    public class SignalrPublishDomainEvents : IPublishDomainEvents
    {
        IHubContext<TemplateHub, ITemplateClientEvent> _templateHub;

        public SignalrPublishDomainEvents(IHubContext<TemplateHub, ITemplateClientEvent> templateHub)
        {
            _templateHub = templateHub;
        }

        private ITemplateClientEvent GetTemplateGroup(Guid id)
        {
            return _templateHub.Clients.Group(id.ToString());
        }

        public Task Publish(object evnt)
        {
            try
            {
                return ((dynamic)this).When((dynamic)evnt);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                return Task.CompletedTask;
            }
        }

        public Task When(NewMessageEvent e)
        {
            return GetTemplateGroup(e.IdGroup).NewMessage(e.IdUser, e.IdMessage);
        }
    }
}
