namespace MilitarySystem.Web.Hubs
{
    using Microsoft.AspNet.SignalR;
    using System.Web;

    public class Chat : Hub
    {
        public void SendMessage(string message)
        {
            message = HttpContext.Current.Server.HtmlEncode(message);
            var msg = string.Format("{0}: {1}", Context.User.Identity.Name, message);
            Clients.All.addMessage(msg);
        }

        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
            Clients.Caller.joinRoom(room);
        }

        public void SendMessageToRoom(string message, string[] rooms)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);

            for (int i = 0; i < rooms.Length; i++)
            {
                Clients.Group(rooms[i]).addMessage(msg);
            }
        }

    }
}