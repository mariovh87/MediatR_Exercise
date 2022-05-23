using BlazorComunicatingComponents.UI.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorComunicatingComponents.UI.Features
{
    public class UpdateColorCommand : INotification
    {
        public string Color { get; set; }
    }
    public class UpdateColorEventArgs : EventArgs
    {
        public string Color { get; set; }
    }
}

namespace BlazorComunicatingComponents.UI.Shared
{
    public partial class MainLayout : INotificationHandler<UpdateColorCommand>
    {
        public static event EventHandler<UpdateColorEventArgs> ColorChanged;
        public async Task Handle(UpdateColorCommand notification, CancellationToken cancellationToken)
        {
            ColorChanged?.Invoke(this, new UpdateColorEventArgs { Color = notification.Color });
        }
    }
}