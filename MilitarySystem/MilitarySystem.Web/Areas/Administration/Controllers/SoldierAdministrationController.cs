
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MilitarySystem.Data;
using MilitarySystem.Data.Contracts;
using MilitarySystem.Models;
using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Areas.Administration.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitarySystem.Common;

namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    public class SoldierAdministrationController : GridAdministrationController<User, UserInputModel>
    {
        private IUsersService users;

        private IMessagesService messages;

        private IPlatoonsService platoons;

        private ISquadsService squads;

        private MilitarySystemContext context;

        public SoldierAdministrationController(
            IDataService<User> user,
            IUsersService users,
            IMessagesService messages,
            IPlatoonsService platoons,
            ISquadsService squads)
            : base(user)
        {
            this.users = users;
            this.messages = messages;
            this.platoons = platoons;
            this.squads = squads;
            this.context = new MilitarySystemContext();
        }

        // GET: Administration/SoldierAdministraton
        public ActionResult Index()
        {
            return View();
        }

        public override void Destroy(UserInputModel tea)
        {
            var userStore = new UserStore<User>(this.context);
            var userManager = new UserManager<User>(userStore);

            var user = this.Mapper.Map<User>(tea);

            var messages = this.messages.GetAll().Where(x => x.UserId == user.Id);
            foreach (var item in messages)
            {
                this.messages.Delete(item);
            }
            
            var squad = this.squads.GetAll().FirstOrDefault(x => x.SquadLeaderId == user.Id);

            if (squad != null)
            {
                squad.SquadLeaderId = null;
                this.squads.Update(squad);
                userManager.RemoveFromRole(user.Id, ModelsConstraints.SquadLeaderRoleName);
            }

            var platoon = this.platoons
                .GetAll()
                .FirstOrDefault(x => x.PlatoonCommanderId == user.Id);

            if (platoon != null)
            {
                platoon.PlatoonCommanderId = null;
                this.platoons.Update(platoon);
                userManager.RemoveFromRole(user.Id, ModelsConstraints.PlatoonLeaderRoleName);
            }


            this.users.Delete(user);
        }
    }
}