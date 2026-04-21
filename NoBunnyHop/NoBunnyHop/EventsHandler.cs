using System.Collections.Generic;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Wrappers;
using PlayerRoles;

namespace NoBunnyHop
{
    public class EventsHandler : CustomEventsHandler
    {
        private Dictionary<Player, int> _counter = new Dictionary<Player, int>();
        
        public override void OnPlayerJumped(PlayerJumpedEventArgs ev)
        {
            if (ev.Player.Role == RoleTypeId.Tutorial)
            {
                return;
            }
            
            Player player = ev.Player;

            if (!_counter.ContainsKey(player))
            {
                _counter[player] = 0;
            }
            
            _counter[player]++;
            
            if (_counter[player] >= Plugin.Instance.Config.JumpCounter)
            {
                ev.Player.Damage(Plugin.Instance.Config.LostHp, "Bunny hop");
                
                ev.Player.SendBroadcast(Plugin.Instance.Config.Message, Plugin.Instance.Config.BroadcastDuration);
                
                _counter[player] = 0;
            }
        }
    }
}