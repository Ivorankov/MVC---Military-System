namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;
    using ViewModels;
    using Web.Controllers;
    using MilitarySystem.Models;
    using Microsoft.AspNet.Identity;

    public class MessageController : BaseController
    {
        private IMessagesService messages;

        private ISquadsService squads;

        private IPlatoonsService platoons;

        public MessageController(IMessagesService messages, ISquadsService squads, IUsersService users, IPlatoonsService platoons) : base(users)
        {
            this.messages = messages;
            this.squads = squads;
            this.platoons = platoons;
        }

        public ActionResult Message()
        {
            var allMessages = this.squads.GetById(1).Messages;
            var messages = new MessageBoxViewModel();
            allMessages.Reverse();
            messages.Content = allMessages.ToList();
            @ViewBag.HeaderText = "Send message to commander";
            var data = new MessageIndexViewModel() { SendInput = new SendMessageViewModel(), MessageView = messages };
            return PartialView("_SendMessage", data);
        }

        [HttpPost]
        public ActionResult SendMessage(MessageIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.Users.GetById(User.Identity.GetUserId());
                var message = new Message() { Content = model.SendInput.Content };
                message.UserId = user.Id;
                this.messages.Add(message);
             
                //Squad sending to Platoon
                if (user.Squad != null)
                {
                    var squad = this.squads.GetById(user.SquadId.GetValueOrDefault());
                    var platoon = this.platoons.GetById(squad.PlatoonId.GetValueOrDefault());
                    platoon.Messages.Add(message);
                    this.platoons.Update(platoon);
                }
                else
                {
                    var squad = this.squads.GetById(user.SquadId.GetValueOrDefault());
                    squad.Messages.Add(message);
                    this.squads.Update(squad);
                }

            }

            return Json(null);
        }

    }
}