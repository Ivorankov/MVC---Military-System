﻿namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using ViewModels;
    using MilitarySystem.Models;
    using Services.Contracts;

    [Authorize(Roles = Common.ModelsConstraints.SquadLeaderRoleName + ", " + Common.ModelsConstraints.PlatoonLeaderRoleName)]
    public class MessageController : TroopsController
    {
        private IMessagesService messages;

        private ISquadsService squads;

        private IPlatoonsService platoons;

        private IUsersService users;

        public MessageController(IMessagesService messages, ISquadsService squads, IUsersService users, IPlatoonsService platoons)
        {
            this.messages = messages;
            this.squads = squads;
            this.platoons = platoons;
            this.users = users;
        }

        [HttpGet]
        public ActionResult Message()
        {
            var user = this.users.GetById(User.Identity.GetUserId());
            var messages = new MessageBoxViewModel();
            var allMessages = new List<Message>();
            var squad = this.squads.GetById(user.SquadId.GetValueOrDefault());
            if (user.Squad != null)
            {
                allMessages = squad
                    .Messages
                    .ToList();
            }
            else
            {
                var platoon = this.platoons
                    .GetAll()
                    .FirstOrDefault(x => x.PlatoonCommanderId == user.Id);
                allMessages = platoon.Messages.ToList();
            }

            allMessages.Reverse();
            messages.Content = allMessages.ToList();
            @ViewBag.HeaderText = "Send message to commander";
            var data = new MessageIndexViewModel() { SendInput = new SendMessageViewModel(), MessageView = messages };
            return PartialView("_SendMessage", data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMessage(MessageIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.users.GetById(User.Identity.GetUserId());
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

            object a = "yey";
            return Json(a);
        }

    }
}