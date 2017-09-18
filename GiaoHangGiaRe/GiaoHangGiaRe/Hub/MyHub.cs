﻿using System.Collections.Generic;
using System.Linq;
namespace GiaoHangGiaRe.Hub
{
    using global::Models.EntityModel;
    using Microsoft.AspNet.SignalR;
    using System.Threading.Tasks;
    [Authorize]
    public class MyHub : Hub
    {

        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();
        GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();
        List<DonHang> dsDonHang = new List<DonHang>();
        
        //public static void LayDanhSachDonHang(DonHang dh)
        //{
        //dsDonHang = db.DonHangs.ToList();
        //var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        //context.Clients.All.upadateDonHang(dh);
        //}
        //public void GuiDLTrungTam()
        //{
        //Clients.Group("admin",);
        //}
        //public void GuiTinNhan(float userId, float message)
        //{
        //    Clients.All.NhanTinNhan(userId,message);
        //    //Clients.User(userId).Send(message);
        //}
        public void UpdateDonhang(DonHang donhang)
        {
            
            Clients.All.updatedonhang(donhang);
        }
        public void GuiToaDo(float lat, float lng)
        {
            Clients.All.layToaDo(lat, lng);
        }
        public void SendChatMessage(string who, string message)
        {
            string name = Context.User.Identity.Name;

            foreach (var connectionId in _connections.GetConnections(who))
            {
                Clients.Client(connectionId).addChatMessage(name + ": " + message);
            }
        }
        //public void DanhSachOnline()
        //{
        //    string name = Context.User.Identity.Name;
           
           
        //}
        public override Task OnConnected()
        {       
            string name = Context.User.Identity.Name;
            _connections.Add(name, Context.ConnectionId);

            Clients.All.SoNguoiOnline(_connections.Count);
            IEnumerable<string> ds;
            ds = _connections.GetUserConnections();
            Clients.All.DanhSachOnline(ds);
            dsDonHang = (from dh in db.DonHangs where dh.TinhTrang== "Đã khóa yêu cầu" select dh).ToList();
            Clients.All.laydsDonHang(dsDonHang);
            
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;        
            _connections.Remove(name, Context.ConnectionId);

            Clients.All.SoNguoiOnline(_connections.Count);
            IEnumerable<string> ds;
            ds = _connections.GetUserConnections();
            Clients.All.DanhSachOnline(ds);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;
            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }
            Clients.All.SoNguoiOnline(_connections.Count);
            IEnumerable<string> ds;
            ds = _connections.GetUserConnections();
            Clients.All.DanhSachOnline(ds);

            return base.OnReconnected();
        }
    }
}