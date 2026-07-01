using System.Collections.Generic;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Wrappers;
using PlayerRoles;
using MEC;

namespace NoBunnyHop
{
    public class EventsHandler : CustomEventsHandler
    {
        private Dictionary<Player, int> _counter = new Dictionary<Player, int>();

        public override void OnPlayerJumped(PlayerJumpedEventArgs ev)
        {
            ev.Player.StaminaRemaining = ev.Player.StaminaRemaining - 0.5f;
        }
    }
}