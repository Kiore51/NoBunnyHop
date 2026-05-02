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

            Timing.CallDelayed(Plugin.Singleton.Config.Cooldown, () =>
            {
                if (_counter.ContainsKey(player) && _counter[player] > 0)
                {
                    _counter[player]--;
                }
            });
            
            if (_counter[player] >= Plugin.Singleton.Config.JumpCounter)
            {
                ev.Player.Damage(Plugin.Singleton.Config.LostHp, "Bunny hop");
                ev.Player.SendHint("\n\n\n\n\n\n\n\n\n\n\n" + Plugin.Singleton.Config.HintMessage, Plugin.Singleton.Config.HintMessageDuration);
                
                _counter[player] = 0;
            }
        }
    }
}