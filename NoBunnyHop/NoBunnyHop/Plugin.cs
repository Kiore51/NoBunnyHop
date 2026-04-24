using System;
using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;

namespace NoBunnyHop
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public override string Name { get; } = "NoBunnyUp";
        public override string Author { get; } = "Kiore";
        public override string Description { get; } = "No Bunny up";
        public override Version Version { get; } = new Version(1, 0, 1);
        public override Version RequiredApiVersion { get; } = new Version(LabApiProperties.CompiledVersion);
        public EventsHandler Events { get; } = new EventsHandler();

        public override void Enable()
        {
            Singleton = this;
            CustomHandlersManager.RegisterEventsHandler(Events);
        }

        public override void Disable()
        {
            CustomHandlersManager.UnregisterEventsHandler(Events);
        }
    }
}