using Qurre.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Server_Stats.API
{
    public class PlayerData
    {
        public string UserID;
        public static Vector3 PlayerPos;
        public static RoleType PlayerRole;
        public static int items;
        public PlayerData(string UserID)
        {
            this.UserID = UserID;
            PlayerPos = Player.Get(UserID).Position;
            PlayerRole = Player.Get(UserID).Role;
            items = Player.Get(UserID).Inventory.itemUniq;
        }
    }
}
