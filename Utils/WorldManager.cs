using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ModLoader.IO;
using System.IO;
using Terraria.ID;

namespace AnotherRpgMod.Utils
{
    class WorldManager : ModWorld
    {

        public static Dictionary<Message, List<WorldDataTag>> worldDataTag = new Dictionary<Message, List<WorldDataTag>>()
        {
            { Message.syncWorld, new List<WorldDataTag>(){
                WorldDataTag.Day,WorldDataTag.BossDefeated,WorldDataTag.lastDayTime,WorldDataTag.ascended,WorldDataTag.ascendedLevel,WorldDataTag.PlayerLevel,
            } },
        };

        public static int BossDefeated = 0;
        public static int Day = 1;
        private static bool lastDayTime = true;

        public static bool ascended = false;
        public static int ascendedLevelBonus = 0;

        public static int PlayerLevel = 1;

        public static List<int> BossDefeatedList;

        public static WorldManager instance;

        public static void OnBossDefeated(NPC npc)
        {
            if (BossDefeatedList.Exists(x => x == npc.type))
            {
                return;
            }
            BossDefeatedList.Add(npc.type);
            BossDefeated++;
            Main.NewText("The world grow stronger..", 144, 32, 185);
        }

        public override void Initialize()
        {
            instance = this;
            BossDefeated = 0;
            BossDefeatedList = new List<int>();
        }

        public static int GetWorldLevelMultiplier(int Level)
        {
            float baseLevelMult = 0.6f;
            if (Main.hardMode)
                baseLevelMult = 1;
            baseLevelMult += Day * 0.1f;
            if (!Main.expertMode)
            {
                 Mathf.Clamp(baseLevelMult, 0, 1);
            }
            return Mathf.FloorInt(baseLevelMult * Level) + ascendedLevelBonus;
        } 

        public static int GetMaximumAscend()
        {
            if (!Config.gpConfig.AscendLimit)
            {
                return 999;
            }

            float limit = 0;

            limit = (BossDefeated * Config.gpConfig.AscendLimitPerBoss);

            if (Main.hardMode && limit < 5)
            {
                limit = 5;
                if (NPC.downedPlantBoss && limit < 15)
                    limit = 15;
                if (NPC.downedMoonlord)
                    return 999;
            }

            return Mathf.FloorInt(limit);
        }

        public static float GetHealthMultiplierAscendCap()
        {
            float limit = 0;

            limit = (BossDefeated * Config.gpConfig.AscendLimitPerBoss);
            return 1+ Mathf.FloorInt(limit)*0.5f;
        }







        public override void PostUpdate()
        {
            if (Main.dayTime != lastDayTime) {
                lastDayTime = Main.dayTime;
                if (Main.dayTime)
                {
                    Day++;
                    
                }
                    
            }
            base.PostUpdate();
        }

        public static int GetWorldAdditionalLevel()
        {
            int bonuslevel = 0;

            bonuslevel = (int)(BossDefeated * Config.NPCConfig.NPCGrowthValue);

            if (Main.hardMode)
            {
                bonuslevel = Mathf.CeilInt(bonuslevel * Config.NPCConfig.NPCGrowthHardModePercent);
                bonuslevel += Config.NPCConfig.NPCGrowthHardMode;
            }
            
            return bonuslevel;
        }

        public override TagCompound Save()
        {
            if (BossDefeatedList == null)
            {
                BossDefeatedList = new List<int>();
            }
            return new TagCompound {
                    {"BossDefeated", BossDefeated},
                    {"BossDefeatedList", ConvertToInt(BossDefeatedList)},
                    {"day", Day},
                    {"ascended", ascended},
                    {"ascendedLevel", ascendedLevelBonus},
                    {"PlayerLevel", PlayerLevel},
                };
        }

        private int[] ConvertToInt(List<int> list)
        {
            int[] newList = new int[list.Count];
            for(int i = 0;i< list.Count; i++)
            {
                newList[i] = list[i];
            }
            return newList;
        }

        private void ConvertToList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                BossDefeatedList.Add(list[i]);
            }
        }

        public override void Load(TagCompound tag)
        {
            BossDefeatedList = new List<int>();
            BossDefeated = tag.GetInt("BossDefeated");
            Day = tag.GetInt("day");
            ConvertToList(tag.GetIntArray("BossDefeatedList"));
            ascended = tag.GetBool("ascended");
            ascendedLevelBonus = tag.GetInt("ascendedLevel");
            if (Main.netMode == NetmodeID.SinglePlayer)
                PlayerLevel = tag.GetInt("PlayerLevel");
            else
            {
                PlayerLevel = 0;
            }
            

        }

        public void NetUpdateWorld()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = mod.GetPacket();
                packet.Write((byte)Message.syncWorld);
                packet.Write(Day);
                packet.Write(BossDefeated);
                packet.Write(lastDayTime);
                packet.Write(ascended);
                packet.Write(ascendedLevelBonus);
                packet.Write(PlayerLevel);
                packet.Send();
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write((byte)Message.syncWorld);
            writer.Write(Day);
            writer.Write(BossDefeated);
            writer.Write(lastDayTime);
            writer.Write(ascended);
            writer.Write(ascendedLevelBonus);
            writer.Write(PlayerLevel);
            base.NetSend(writer);
        }

        public override void NetReceive(BinaryReader reader)
        {

            Message msg;
            msg = (Message)reader.ReadByte();
            if (msg == Message.syncWorld) { 
                Dictionary<WorldDataTag, object> tags = new Dictionary<WorldDataTag, object>();
                foreach (WorldDataTag tag in worldDataTag[msg])
                {
                    tags.Add(tag, tag.read(reader));
                }

                Day = (int)tags[WorldDataTag.Day];
                BossDefeated = (int)tags[WorldDataTag.BossDefeated];
                lastDayTime = (bool)tags[WorldDataTag.lastDayTime];
            
                ascended = (bool)tags[WorldDataTag.ascended];
                ascendedLevelBonus = (int)tags[WorldDataTag.ascendedLevel];
                PlayerLevel = (int)tags[WorldDataTag.PlayerLevel];
            }



            base.NetReceive(reader);
        }

    }

    
    


    public class WorldDataTag
    {
        public static WorldDataTag Day = new WorldDataTag(reader => reader.ReadInt32());
        public static WorldDataTag BossDefeated = new WorldDataTag(reader => reader.ReadInt32());
        public static WorldDataTag lastDayTime = new WorldDataTag(reader => reader.ReadBoolean());
        public static WorldDataTag ascended = new WorldDataTag(reader => reader.ReadBoolean());
        public static WorldDataTag ascendedLevel = new WorldDataTag(reader => reader.ReadInt32());
        public static WorldDataTag PlayerLevel = new WorldDataTag(reader => reader.ReadInt32());

        public Func<BinaryReader, object> read;

        public WorldDataTag(Func<BinaryReader, object> read)
        {
            this.read = read;
        }
    }
}
