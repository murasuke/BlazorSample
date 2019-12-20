using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace SimpleButton3.Pages
{
    public partial class CodeBehind : ComponentBase
    {
        public string messageText { get; set; }
        public double _top { get; set; } = 160;
        public double _left { get; set; } = 20;

        [Inject]
        private NavigationManager NavMgr { get; set; }

        public void DivClick(MouseEventArgs e)
        {
            _top = e.ClientY;
            _left = e.ClientX;
        }

        public void MouseMove(MouseEventArgs e)
        {
            messageText = $"onMouseMove(x,y)=({e.ClientX},{e.ClientY})";
        }

        public void ClickReturn(MouseEventArgs e)
        {
            NavMgr.NavigateTo("/");
        }
    }
}
