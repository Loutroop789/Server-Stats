using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomPlayerEffects;
using MEC;
using Qurre;
using Qurre.API;
using Qurre.API.Events;
using UnityEngine;

namespace Server_Stats
{
    public class EventHandler
    {
        public static Dictionary<string,API.PlayerData> LeavePro = new Dictionary<string,API.PlayerData>();
        public static List<Vector3> Pos = new List<Vector3>();
        public PluginClass pluginClass;
        public static List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();
        public EventHandler(PluginClass pluginClass) => this.pluginClass = pluginClass;
        public IEnumerator<float> CheckPos()
        {
            yield return Timing.WaitForSeconds(0.5f);
            foreach (Player player in Player.List)
            {
                if (Configs.returnHP)
                {
                    if (player.Team == Team.SCP)
                    {
                        Pos.Add(player.Position);
                        Timing.WaitForSeconds(Configs.returnHPTime);
                        if (Pos.Contains(player.Position))
                        {
                            player.HP += Configs.returnHPvalue;
                        }
                    }
                }
            }
            if (Configs.Debug)
            {
                Log.Debug($"returnHP: {Configs.returnHP}\nreturnHPTime: {Configs.returnHPTime}\nreturnHPValue: {Configs.returnHPvalue}");
            }
        }
        public void Escape(EscapeEvent ev)
        {
            if (ev.Player.Role == RoleType.ClassD)
            {
                ev.NewRole = (RoleType)Configs.DEscapeRole; 
            }
            if (ev.Player.Role == RoleType.Scientist)
            {
                ev.NewRole = (RoleType)Configs.REscapeRole;
            }
        }
        public void RoundStart()
        {
            if (Configs.returnHP) Coroutines.Add(Timing.RunCoroutine(CheckPos()));
            if (Configs.AutoNuck) Coroutines.Add(Timing.RunCoroutine(AutoNuck()));
            if (Configs.Debug)
            {
                Log.Debug("Round starting");
            }
            foreach (Player player in Player.List)
            {
                player.FriendlyFire = false;
            }
        }
        public void RoundRestart()
        {
            Coroutines.Clear();
            if (Configs.Debug)
            {
                Log.Debug("Round Restating...");
            }
        }
        public void End(RoundEndEvent ev)
        {
            foreach (Player player in Player.List)
            {
                if (Configs.FriendlyFireRoundEnd)
                {
                    player.FriendlyFire = true;
                    player.TeleportToRandomRoom();
                    if (Configs.EffectRoundEnd.Length > 0) player.EnableEffect(Configs.EffectRoundEnd, 30);
                }
            }
        }
        public void Spawn(SpawnEvent ev)
        {
            if (Configs.Debug)
            {
                Log.Debug($"Spawn Debug");
                Log.Debug($"Spawning Player: {ev.Player.Nickname}");
                Log.Debug($"Spawning Role: {ev.Player.RoleName}");
            }
            if (ev.Player.Role == RoleType.ChaosInsurgency)
            {
                ev.Player.HP = Configs.CIHP;
                if (Configs.CIItem.Count != 0)
                {
                    ev.Player.AllItems.Clear();
                    foreach (int item in Configs.CIItem)
                        ev.Player.AddItem((ItemType)item);
                }
            }
            if (ev.Player.Role == RoleType.ClassD)
            {
                ev.Player.HP = Configs.CDPHP;
                if (Configs.CDPItem.Count != 0)
                {
                    ev.Player.AllItems.Clear();
                    foreach (int item in Configs.CDPItem)
                        ev.Player.AddItem((ItemType)item);
                }
            }
            if (ev.Player.Role == RoleType.NtfCommander)
            {
                ev.Player.HP = Configs.NTFCommanderHP;
                if (Configs.NTFCommanderItem.Count != 0)
                {
                    ev.Player.AllItems.Clear();
                    foreach (int item in Configs.NTFCommanderItem)
                        ev.Player.AddItem((ItemType)item);
                }
            }
            if (ev.Player.Role == RoleType.NtfCadet)
            {
                ev.Player.HP = Configs.NTFCadetHP;
                if (Configs.NTFCadetItem.Count != 0)
                {
                    ev.Player.AllItems.Clear();
                    foreach (int item in Configs.NTFCadetItem)
                        ev.Player.AddItem((ItemType)item);
                }
            }
            if (ev.Player.Role == RoleType.NtfLieutenant)
            {
                ev.Player.HP = Configs.NTFLieutenantHP;
                if (Configs.NTFLieutenantItem.Count != 0)
                {
                    ev.Player.AllItems.Clear();
                    foreach (int item in Configs.NTFLieutenantItem)
                        ev.Player.AddItem((ItemType)item);
                }
            }
            if (ev.Player.Role == RoleType.FacilityGuard)
            {
                ev.Player.HP = Configs.FGHP;
                if (Configs.FGItem.Count != 0)
                {
                    ev.Player.AllItems.Clear();
                    foreach (int item in Configs.FGItem)
                        ev.Player.AddItem((ItemType)item);
                }
            }
            if (ev.Player.Role == RoleType.NtfScientist)
            {
                ev.Player.HP = Configs.NTFScientistHP;
                if (Configs.NTFScientistItem.Count != 0)
                {
                    ev.Player.AllItems.Clear();
                    foreach (int item in Configs.NTFScientistItem)
                        ev.Player.AddItem((ItemType)item);
                }
            }
            if (ev.Player.Role == RoleType.Scientist)
            {
                ev.Player.HP = Configs.RSCHP;
                if (Configs.RSCItem.Count != 0)
                {
                    ev.Player.AllItems.Clear();
                    foreach (int item in Configs.RSCItem)
                        ev.Player.AddItem((ItemType)item);
                }
            }
            if (ev.Player.Role == RoleType.Scp049)
            {
                ev.Player.HP = Configs.SCP049HP;
            }
            if (ev.Player.Role == RoleType.Scp0492)
            {
                ev.Player.HP = Configs.SCP0492HP;
            }
            if (ev.Player.Role == RoleType.Scp096)
            {
                ev.Player.HP = Configs.SCP096HP;
            }
            if (ev.Player.Role == RoleType.Scp106)
            {
                ev.Player.HP = Configs.SCP106HP;
            }
            if (ev.Player.Role == RoleType.Scp173)
            {
                ev.Player.HP = Configs.SCP173HP;
            }
            if (ev.Player.Role == RoleType.Scp93953)
            {
                ev.Player.HP = Configs.SCP93953HP;
            }
            if (ev.Player.Role == RoleType.Scp93989)
            {
                ev.Player.HP = Configs.SCP93989HP;
            }
            if (ev.Player.Role == RoleType.Tutorial)
            {
                ev.Player.HP = Configs.TUTHP;
                if (Configs.TUTItem.Count != 0)
                {
                    ev.Player.AllItems.Clear();
                    foreach (int item in Configs.TUTItem)
                        ev.Player.AddItem((ItemType)item);
                }
            }
        }
        public void Leave(LeaveEvent ev)
        {
            if (Configs.Debug)
            {
                Log.Debug($"Leave Debug");
                Log.Debug($"Leaving Player: {ev.Player.Nickname}");
            }
                if (Configs.LeaveProtect)
            {
                LeavePro.Add(ev.Player.UserId,new API.PlayerData(ev.Player.UserId));
            }
        }
        public void Join(JoinEvent ev)
        {
            if (Configs.Debug)
            {
                Log.Debug($"Join Player: {ev.Player.Nickname}\nJoin Player IP: {ev.Player.IP}\nJoin Player UserId: {ev.Player.UserId}");
            }
                if (Configs.LeaveProtect)
            {
                if (LeavePro.ContainsKey(ev.Player.UserId))
                {
                    ev.Player.Role = API.PlayerData.PlayerRole;
                    ev.Player.Position = API.PlayerData.PlayerPos;
                    ev.Player.AddItem((ItemType)API.PlayerData.items);
                }
            }
            ev.Player.Broadcast(Configs.JoinMsgTime ,Configs.JoinMsg);
        }
        public IEnumerator<float> AutoNuck()
        {
            yield return Timing.WaitForSeconds(0.5f);
            if (RoundSummary.roundTime == Configs.AutoNuckTime)
            {
                AlphaWarheadController.Host.StartDetonation();
            }
        }
    }
}
