﻿using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    public abstract class HubApiController<THub> : ApiController where THub : IHub
    {
        Lazy<IHubContext> hub = new Lazy<IHubContext>(
       () => GlobalHost.ConnectionManager.GetHubContext<THub>()
        );

        protected IHubContext Hub
        {
            get { return hub.Value; }
        }
    }
}
