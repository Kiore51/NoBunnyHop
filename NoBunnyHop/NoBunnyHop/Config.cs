using System.ComponentModel;

namespace NoBunnyHop
{
    public class Config
    {
        public bool Enabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        
        [Description("Number of jumps the player can complete before being punished.")]
        public int JumpCounter { get; set; } = 3;
        
        [Description("Number of health points the player loses on punishment.")]
        public int LostHp { get; set; } = 10;
        
        [Description("The message sent to the player during a bunny hop.")]
        public string HintMessage { get; set; } = "<size=18><b><color=#FF0000>Please, don’t do the Bunny Hop</color></b></size>";
        
        [Description("Duration of the hint message that is sent to the player during a bunny hop.")]
        public ushort HintMessageDuration { get; set; } = 5;
        
        [Description("Cooldown to space out the jumps")]
        public float Cooldown { get; set; } = 3f;
    }
}