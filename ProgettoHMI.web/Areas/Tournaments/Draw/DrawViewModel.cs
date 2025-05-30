using System.Collections.Generic;
using ProgettoHMI.web.Infrastructure;
using ProgettoHMI.Services.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProgettoHMI.web.Areas.Tournaments.Draw
{
    public class DrawViewModel
    {
        public GameSelectDTO Games { get; set; }
        public int selectBtn { get; set; }
        public string urlRaw { get; set; }
        
        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }

        public void SetUrls(IUrlHelper url)
        {
            this.urlRaw = url.Action(MVC.Tournaments.Draw.GetSingleDrawPosition());
        }

        [TypeScriptModule("Tournaments.Draw.Server")]
        public class DrawViewModelServer
        {
            
        }
    }
}
