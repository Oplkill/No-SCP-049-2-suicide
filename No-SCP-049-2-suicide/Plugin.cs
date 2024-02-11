// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace No_SCP_049_2_suicide
{
    public class NoSCP0492Suicide : Plugin<Config, Translations>
    {
        public static NoSCP0492Suicide Instance;
        public override Version Version => new Version(0, 0, 1);
        public override string Author => "Oplkill";
        public override string Name => "No SCP-049-2 suicide";
        public override string Prefix => "No-SCP-049-2-Suicide";

        private EventHandlers _eventHandler;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
            Instance = null;
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _eventHandler = new EventHandlers();

            Player.Hurting += _eventHandler.OnHurting;
        }

        private void UnRegisterEvents()
        {
            Player.Hurting -= _eventHandler.OnHurting;

            _eventHandler = null;
        }
    }
}
