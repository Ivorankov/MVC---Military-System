using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    public class MessageIndexViewModel
    {
        public MessageBoxViewModel MessageView { get; set; }

        public SendMessageViewModel SendInput { get; set;}
    }
}