// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Linq;
using UnityEngine;

namespace No_SCP_049_2_suicide
{
    internal class EventHandlers
    {
        public void OnHurting(HurtingEventArgs ev)
        {
            var player = ev.Player;

            if (player.Role.Type != PlayerRoles.RoleTypeId.Scp0492)
                return;

            // Falled into void
            if (ev.DamageHandler.Type == DamageType.Crushed)
            {
                var teleportPos = GetNearestAvailableTeleportPosition(player);

                if (teleportPos == null)
                    return;

                ev.IsAllowed = false;
                player.Position = teleportPos.Value;
                player.EnableEffect(EffectType.Ensnared, 5, true);
                player.EnableEffect(EffectType.Flashed, 5, false);
            }
            else if (ev.DamageHandler.Type == DamageType.Tesla)
            {
                bool isDamageDeadly = !((player.Health - ev.Amount) > 0.0);

                // Ignore not fatal damage
                if (!isDamageDeadly)
                    return;

                ev.IsAllowed = false;

                player.EnableEffect(EffectType.Flashed, 5, false);
            }
        }

        /// <summary>
        /// Get nearest available to teleport position
        /// </summary>
        /// <param name="player">Find position for player</param>
        /// <returns>Null if no place to teleport</returns>
        private Vector3? GetNearestAvailableTeleportPosition(Player player)
        {
            var doors = player.CurrentRoom.Doors.Where(d => d.RequiredPermissions.RequiredPermissions == Interactables.Interobjects.DoorUtils.KeycardPermissions.None);

            if (doors.IsEmpty())
                return null;

            var firstRoom = doors.First();

            if (firstRoom == null)
                return null;

            var newPos = firstRoom.Position;

            // Move forward from door
            newPos += Vector3.forward * 0.4f;

            // Move a little up for prevent stuck in the floor
            newPos += Vector3.up;

            return newPos;
        }
    }
}
