namespace MilitarySystem.Web.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class Chat : Hub
    {
        public void SendMessage(string message)
        {
            var msg = string.Format("{0}: {1}", Context.User.Identity.Name, message);
            Clients.All.addMessage(msg);
        }

        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
            Clients.Caller.joinRoom(room);
        }


    }
}