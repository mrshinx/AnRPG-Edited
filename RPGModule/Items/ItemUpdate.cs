﻿using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.Utilities;
using AnotherRpgMod.RPGModule.Entities;
using AnotherRpgMod.Utils;
using AnotherRpgMod.RPGModule;
namespace AnotherRpgMod.Items
{
    class ItemUpdate : GlobalItem
    {

        public static bool HaveTree (Item item)
        {
            if (item.GetGlobalItem<ItemUpdate>() != null && item.GetGlobalItem<ItemUpdate>().NeedsSaving(item) && !item.accessory)
            {
                return true;
            }
            return false;
        }

        #region Variables

        string[] AscendName =
        {
            "",
            "Limit Broken ",
            "Mortal ",
            "Raised ",
            "Unleashed ",
            "Immortal ",
            "Ascended ",
            "High Ascended ",
            "Peak Ascended ",
            "Transcendental ",
            "Lower Divine Collection ",
            "Divine Collection ",
            "Higher Divine Collection ",
            "Heavenly Divine Collection ",
            "Heavenly Divine Collection ",
            "Heavenly Div1ne Collection ",
            "Heavenly D1vine Collection ",
            "HeAvenly D1v1ne CollEction ",
            "He@v3nly D1B1n3 C01leCti0n ",
            "C8@V3€4y D3?5n C01;eCti0, ",
            "C0rpt3d d30n Collection ",
            "Corrupted Demon Collection ",
            "Corrupted Arch-Demon Collection ",
            "Corrupted Devil Collection ",
            "Devil Horror Collection ",
            "Cosmic Horror Collection ",
            "Eldritch Horror Collection ",
            "........ ",
            "...H... ",
            "..Hello. ",
            "..Why are you keep using it ?.. ",
            "..This is beyond any limit... ",
            "..What are you trying to achieve like this ?.. ",
            "..Do you want Power ? You have it, wealth ? You have it too, WHAT IS THE POINTS OF THIS ?.. ",
            "..Oh you do it for the Text ?.. ",
            "..Do you realy think I want to speak to your ?.. ",
            "..Ah, you can stop here, there won't be more, honestly, I'm surprised you didn't get an int overflow yet.. ",
            "..Good bye.. ",
            "........ ",
            "........ ",
            "........ ",
            "........ ",
            "....LIFE ANSWER..... ",
            "...What are you doing ?! Did I fix this stupid overflow bug... ",
            "...Well, here something for you, Item node rarity increase as you go deep into the tree... ",
            "...So some impossible to get node will appear often at deep layer, but I guess you've seen it... ",
            "...Good Luck... ",
            "... ",
            ".. ",
            ". ",
            "",
            "One Punch Man ",
            "...Well, speaking of One Punch Man, maybe I should make a list of suggestion for manga to read ? ",
            "If you like cool fight, I realy sugest to read Kengan Asura (and Kengan Omega) ",
            "One of the popular manga out there is actualy a manhua titled 'Solo Leveling', you are playing a rpg mod, so you should definetly like it ",
            "Another manhua similar to solo leveling but taking a different story is 'I Am the sorcerer King' ",
            "Totaly different genre, but you should also read Dr.Stone, especialy if you like science ",
            "hmm... You realy like thos text ? Well ... ",
            "Player - Is this a discution ? ",
            "Discution - Ascension Text ",
            "Yea I mess arround, but guy, if you reach this far you most likely used an exploit, and are actively looking for this ! ",
            "So I'm doing this : NIGERUNDAYO ........ ",
            "... ",
            "Yea that jojo reference, Watch jojo you boi ! ",
            "You next sentence will be : 'Does this wall of text ever end ?' ",
            "Does this wall of text ever end ? ",
            "Hue ! How do you know ? ",
            "Simple ! I am the one writing these text ",
            "well it was fun, I'll find more stuff to talk about ",
            "69 LOL",
            "oh yea, do you want some cool music sugestion ? ",
            "then you should definetly look after 'M2U' realy original stuff ",
            "Shiro Sagisu is also nice to listen to, he composed ost of Evangelion ",
            "Look after Keichii Okabe, he made the ost of Nier, Drakengard and a few other game ! ",
            "ElectroSwing is also way to go, Parov stellar and Caravane Palace being classic ",
            "... ",
            "Do you know I'm actualy working for a game named 'QANGA' made by the IolaCorp ",
            "Sort of survival game in a post-apo sci-fi game where you play as human trapped in robot ",
            "Yea, that the reason, update are so scarce, that and MAINLY my lazyness, but please let me find some excuses ",
            "... ",
            "Another funFact, I've made a mod on dota 2 back in 2015, it was my first mod ever, It actualy was REALY sucessful ",
            "The name was 'Epic Boss Fight' and got more than 5 million subscriber, and even snatched most played mod from valve custom mod back then ",
            "now it's totaly broken and unplayable hahahaha.... volvo broke it I promise ! ",
            "The TRUE last text for ascended is 'Infinity +1', no lie ! ",
            "I will also randomly add new text with update without any changelog, there is nothing to gain, you ... well you will just make me laught to see you looking for all that ",
            "I mean, only because it's not that easy to find doesn't mean it's interesting, of you should read it, I even made some advertisement for a game I work on as employee Hahaha ",
            "... ",
            "Have you player CivIdle ? That a game I work on my freetime When I'm not lazy, Ready manhua, Working on AnRPG or other random stuff, You can easily find the link on discord ",
            "What is it ? A simply Idle uncomplete Game where you lead a civilization ! ",
            "The link ? SERIOUSLY ?!!! CHECK ON DISCORD DAMN IT ! ",
            "... ",
            "Yes... lower ascending name are inspired from chiness ArtMartial Manhua ",
            "... ",
            "... ",
            "...here a new text for 1.5, never knew I would come back at this, but here we goes... ",
            "I've finaly added some player ascend ",
            "Once you reach level 1000 you can obtain the Limit Break skill tree node ",
            "Allowing exp gain after level 1000 and unlocking ascended class ",
            "Infinity +1 ",
               

        };

        public string ItemName;

        protected ItemSkillTree m_itemTree;
        public int GetEvolutionPoints { get { return m_itemTree.EvolutionPoints; } }
        public int GetAscendPoints { get { return m_itemTree.AscendPoints; } }
        public int GetMaxEvolutionPoints { get { return m_itemTree.MaxEvolutionPoints; } }
        public int GetMaxAscendPoints { get { return m_itemTree.MaxAscendPoints; } }




        public Modifier modifier = Modifier.None;
        public Rarity rarity = Rarity.NONE;
        ItemStats stats = new ItemStats() { Stats = new List<ItemStat>()};

        ItemType itemType = ItemType.Other;
        public ItemType Get_ItemType { get { return itemType; } }


        bool init = false;
        bool AscendLimit = false;
        int ascendedLevel = 0;
        int baseHealLife = 0;
        int baseHealMana = 0;
        int baseValue = 0;
        Int64 xp = 0;
        int level = 0;




        public float DamageBuffer = 0;
        public float DamageFlatBuffer = 0;
        public float DefenceBuffer = 0;
        public float DefenceFlatBuffer = 0;
        public float UseTimeBuffer = 0;
        public float ShootTimeBuffer = 0;
        public float leech= 0;
        public float bonusXp = 0;

        public int baseCap = 5;

        protected WeaponType m_weaponType;
        public WeaponType GetWeaponType { get { return m_weaponType;} }

        public int Level { get{ return level; } }
        public int Ascention { get { return ascendedLevel; } }


        List<TooltipLine> AscendToolTip = new List<TooltipLine>();

        public Int64 GetXp { get { return xp; } }
        public Int64 GetMaxXp { get { return GetExpToNextLevel(level,ascendedLevel); } }

        int baseDamage = 0;
        int baseShootTime = 1;
        public int BaseDamage { get { return baseDamage; } }

        int baseArmor = 0;
        int baseUseTime = 1;
        int baseMana = 0;
        bool baseAutoReuse = false;
        string baseName = "";

        float lifeLeech = 0;
        float manaLeech = 0;

        public float GetLifeLeech { get { return lifeLeech; } }
        public float GetManaLeech { get { return manaLeech; } }


        public static Dictionary<Message, List<ItemDataTag>> itemDataTags = new Dictionary<Message, List<ItemDataTag>>()
        {
            { Message.SyncWeapon, new List<ItemDataTag>(){ ItemDataTag.init
                , ItemDataTag.baseDamage,ItemDataTag.baseArmor,ItemDataTag.baseAutoReuse,ItemDataTag.baseName,ItemDataTag.baseUseTime,ItemDataTag.baseMana
                , ItemDataTag.level, ItemDataTag.xp, ItemDataTag.ascendedlevel, ItemDataTag.modifier, ItemDataTag.rarity
                , ItemDataTag.statst1, ItemDataTag.stat1
                , ItemDataTag.statst2, ItemDataTag.stat2
                , ItemDataTag.statst3, ItemDataTag.stat3
                , ItemDataTag.statst4, ItemDataTag.stat4
                , ItemDataTag.statst5, ItemDataTag.stat5
                , ItemDataTag.statst6, ItemDataTag.stat6
                , ItemDataTag.itemTree
            } },
        };

        #endregion

        #region Information

        private bool IsEquiped(Item item)
        {
            if (item.headSlot > 0 || item.legSlot > 0 || item.bodySlot > 0 || item.accessory)
                return true;
            return false;
        }

        public override bool OnPickup(Item item, Player player)
        {
            InitItem(item);
            return base.OnPickup(item, player);
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            InitItem(item);
            base.Update(item, ref gravity, ref maxFallSpeed);
        }

        static public bool NeedSavingStatic(Item item)
        {
            return (item.maxStack == 1 && (item.damage > 0 || item.headSlot > 0 || item.legSlot > 0 || item.bodySlot > 0 || item.accessory));
        }

        public override bool NeedsSaving(Item item)
        {
            return (item.maxStack == 1 && (item.damage > 0 || item.headSlot > 0 || item.legSlot > 0 || item.bodySlot > 0 || item.accessory));
        }

        public ItemType GetItemTypeCustom(Item item)
        {
            if (item.maxStack > 1)
            {
                if (item.healLife > 0 || item.healMana > 0)
                    return ItemType.Healing;
                return ItemType.Other;
            }
            else
            {
                if (item.accessory)
                    return ItemType.Accessory;
                if (item.bodySlot > 0 || item.legSlot > 0 || item.headSlot > 0)
                    return ItemType.Armor;
                if (item.damage > 0)
                    return ItemType.Weapon;
                return ItemType.Other;
            }
        }

        public float GetStatSlot(int slot)
        {
            return StatLevel(stats.Stats[slot].value);
        }

        public float GetStat(Stat stat)
        {
            float value = 0;
            for (int i = 0; i < stats.Stats.Count; i++)
            {
                if (stats.Stats[i].stat == stat)
                    value += stats.Stats[i].value;
            }
            return value;
        }


        public void UpdatePassive(Item item,Player player)
        {
            leech = 0;
            bonusXp = 0;

            if (m_itemTree == null)
            {
                m_itemTree = new ItemSkillTree();
                m_itemTree.Init(this);
            }
            m_itemTree.ApplyFlatPassives(item);
            m_itemTree.ApplyMultiplierPassives(item);
            m_itemTree.ApplyOtherPassives(item);
            m_itemTree.ApplyPlayerPassive(item,player);
        }


        public int GetDamage(Item item)
        {
            int _damage = baseDamage;
            DamageFlatBuffer = _damage;

           
            if (Config.gpConfig.ItemTree)
            {
                if (m_itemTree == null || item == null)
                    return _damage;
                m_itemTree.ApplyFlatPassives(item);
                DamageBuffer = DamageFlatBuffer;
                m_itemTree.ApplyMultiplierPassives(item);
                m_itemTree.ApplyOtherPassives(item);
                _damage = (int)(DamageBuffer * (1 + ModifierManager.GetRarityDamageBoost(rarity) * 0.01f));
            }
            else
            {
                _damage = Mathf.CeilInt(
                    ((float)_damage * (1f + (float)ascendedLevel * 0.1f + (float)level / 100f)
                     * (1 + ModifierManager.GetRarityDamageBoost(rarity) * 0.01f)));
            }
            return _damage;
        }

        public int GetUse(Item item)
        {
            int _use = baseUseTime;
            UseTimeBuffer = _use;
            if (Config.gpConfig.ItemTree)
            {
                if (m_itemTree == null || item == null)
                    return _use;
                m_itemTree.ApplyMultiplierPassives(item);
                m_itemTree.ApplyOtherPassives(item);
                _use = (int)UseTimeBuffer;
            }
            else { 
                float _useReduction = Mathf.Pow(0.95, ascendedLevel) * Mathf.Pow(0.995, level);
                _use = Mathf.FloorInt(_use * _useReduction);
            }
            return _use;

        }
        public int GetShoot(Item item)
        {
            int _use = baseShootTime;
            ShootTimeBuffer = _use;
            if (Config.gpConfig.ItemTree)
            {
                if (m_itemTree == null || item == null)
                    return _use;
                m_itemTree.ApplyMultiplierPassives(item);
                m_itemTree.ApplyOtherPassives(item);
                _use = (int)ShootTimeBuffer;
            }
            else
            {
                float _useReduction = Mathf.Pow(0.95, ascendedLevel) * Mathf.Pow(0.995, level);
                _use = Mathf.FloorInt(_use * _useReduction);
            }
            return _use;

        }
        public int GetDefense(Item item)
        {
            
            int _defense = baseArmor;
            DefenceBuffer = _defense;
            DefenceFlatBuffer = _defense;
            if (Config.gpConfig.ItemTree)
            {
                if (m_itemTree == null || item == null)
                    return _defense;
                m_itemTree.ApplyFlatPassives(item);
                DefenceBuffer = DefenceFlatBuffer;
                m_itemTree.ApplyMultiplierPassives(item);
                m_itemTree.ApplyOtherPassives(item);
                _defense = (int)DefenceBuffer;
            }
            else
                _defense = Mathf.CeilInt(_defense * (1 + ascendedLevel * 0.25f) + level * 0.25f);
            return _defense;
        }

        public Int64 GetExpToNextLevel(int _level, int _ascendedLevel)
        {

            if (level == GetCapLevel() * (ascendedLevel + 1))
                return Mathf.Floorlong((_level + 1) * 10000 + Mathf.Pow(_level, 4f));

            return Mathf.Floorlong((_level + 1) * 1000 + Mathf.Pow(_level,3f));


            /*
            if (itemType == ItemType.Weapon)
            {
                if (_level <= 11)
                    return Mathf.Floorlong((_level + 1) * 50 + Mathf.Pow(_level * (baseDamage * 0.3f) * (1 + 15 / baseUseTime), 2.0f) * Mathf.Pow(1.5f, _ascendedLevel));
                else
                    return Mathf.Floorlong((_level + 1) * 50 + Mathf.Pow(_level * (baseDamage * 0.3f) * (1 + 15 / baseUseTime), 2.05f) * Mathf.Pow(1.5f, _ascendedLevel)) * Mathf.Floorlong(1 + _level / 10);
            }
            else
                return Mathf.Floorlong((_level + 1) * 50 + Mathf.Pow(baseArmor * 10 * _level, 2.0f) * Mathf.Pow(1.5f, _ascendedLevel));
            */
        }

        private float StatLevel(float statsvalue)
        {
            statsvalue = (statsvalue + (1 + level) * statsvalue * (1f / 40f)) * (1 + ascendedLevel * .05f);
            return statsvalue;
        }

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }


        public ItemSkillTree GetItemTree { get { return m_itemTree; } }
        

        public void SpendPoints(int points,bool ascend = false)
        {
            if (ascend)
            {
                m_itemTree.AscendPoints -= points;
            }
            else
            {
                m_itemTree.EvolutionPoints -= points;
            }
        }
        
        #endregion

        


        private void InitItem(Item item)
        {

            m_weaponType = ModifierManager.GetWeaponType(item);
            

            if (init)
                return;
            init = true;
            if (NeedsSaving(item))
            {
                baseMana = item.mana;
                baseAutoReuse = item.autoReuse;
                baseUseTime = item.useTime;
                baseName = item.Name;
                baseValue = item.value;
                itemType = GetItemTypeCustom(item);
                baseArmor = item.defense;
                baseDamage = item.damage;

                Roll(item);

                baseCap = GetCapLevel();

                


                if (HaveTree(item) && (m_itemTree == null || m_itemTree.GetSize == 0))
                {
                    m_itemTree = new ItemSkillTree();
                    m_itemTree.Init(this);
                }
                if (WorldManager.ascended)
                {

                    int AscendLevel = 1 + (WorldManager.ascendedLevelBonus / 250);

                    ascendedLevel = AscendLevel;
                    m_itemTree.MaxAscendPoints = ascendedLevel;

                    m_itemTree.ExtendTree(Mathf.Clamp(Mathf.CeilInt(Mathf.Pow(baseCap / 3f, 0.95)), 5, 99) * ascendedLevel);
                }




            }

            if (item.healLife > 0)
                baseHealLife = item.healLife;

            if (item.healMana > 0)
                baseHealMana = item.healMana;
            if (stats.Stats == null)
                stats.Stats = new List<ItemStat>();

        }

        #region OverrideFunction

        public override void NetSend(Item item, BinaryWriter writer)
        {
            if (NeedsSaving(item))
            {

                writer.Write((byte)Message.SyncWeapon);
                writer.Write(init);

                writer.Write(baseDamage);
                writer.Write(baseArmor);
                writer.Write(baseAutoReuse);
                writer.Write(baseName);
                writer.Write(baseUseTime);
                writer.Write(baseMana);

                writer.Write(level);
                writer.Write(xp);
                writer.Write(ascendedLevel);
                writer.Write((int)modifier);
                writer.Write((int)rarity);


                

                if (stats.Stats == null)
                    stats.Stats = new List<ItemStat>();

                for (int i = 0; i < 6; i++)
                {
                    if (i < stats.Stats.Count)
                    {
                        writer.Write((sbyte)stats.Stats[i].stat);
                        writer.Write((int)(stats.Stats[i].value * 100));
                    }
                    else
                    {
                        writer.Write((sbyte)-1);
                        writer.Write(0);
                    }
                }

                string itemTree = "";
                if (HaveTree(item) && m_itemTree != null && m_itemTree.GetSize > 0)
                {
                    itemTree = ItemSkillTree.ConvertToString(m_itemTree);
                }
                else
                {
                    m_itemTree = new ItemSkillTree();
                    m_itemTree.Init(this);
                    itemTree = ItemSkillTree.ConvertToString(m_itemTree);
                }

                writer.Write(itemTree);
            }
            
            
            base.NetSend(item, writer);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            if (NeedsSaving(item))
            {
                Message msg;
                msg = (Message)reader.ReadByte();
                Dictionary<ItemDataTag, object> tags = new Dictionary<ItemDataTag, object>();
                foreach (ItemDataTag tag in itemDataTags[msg])
                {
                    tags.Add(tag, tag.read(reader));
                }
                switch (msg)
                {
                    case Message.SyncWeapon:
                        baseName = (string)tags[ItemDataTag.baseName];
                        init = (bool)tags[ItemDataTag.init];
                        

                        baseDamage = (int)tags[ItemDataTag.baseDamage];
                        baseArmor = (int)tags[ItemDataTag.baseArmor];
                        baseAutoReuse = (bool)tags[ItemDataTag.baseAutoReuse];
                        baseUseTime = (int)tags[ItemDataTag.baseUseTime];
                        baseMana = (int)tags[ItemDataTag.baseMana];

                        itemType = GetItemTypeCustom(item);
                        if (itemType == ItemType.Armor)
                            item.defense = GetDefense(item);

                        else if (itemType == ItemType.Weapon)
                        {
                            if (item.pick > 0 || item.axe > 0 || item.hammer > 0) { 
                                item.useTime = GetUse(item);
                                item.useAnimation = item.useTime;
                            }
                            else
                                item.damage = GetDamage(item);
                        }


                        level = (int)tags[ItemDataTag.level];
                        xp = (long)tags[ItemDataTag.xp];
                        ascendedLevel = (int)tags[ItemDataTag.ascendedlevel];
                        modifier = (Modifier)tags[ItemDataTag.modifier];
                        rarity = (Rarity)tags[ItemDataTag.rarity];


                        stats = new ItemStats
                        {
                            Stats = new List<ItemStat>()
                        };

                        if ((sbyte)tags[ItemDataTag.statst1] >= 0)
                        {
                            stats.Stats.Add(ReceivedStat((sbyte)tags[ItemDataTag.statst1], (int)tags[ItemDataTag.stat1]));
                        }
                        if ((sbyte)tags[ItemDataTag.statst2] >= 0)
                        {
                            stats.Stats.Add(ReceivedStat((sbyte)tags[ItemDataTag.statst2], (int)tags[ItemDataTag.stat2]));
                        }
                        if ((sbyte)tags[ItemDataTag.statst3] >= 0)
                        {
                            stats.Stats.Add(ReceivedStat((sbyte)tags[ItemDataTag.statst3], (int)tags[ItemDataTag.stat3]));
                        }
                        if ((sbyte)tags[ItemDataTag.statst4] >= 0)
                        {
                            stats.Stats.Add(ReceivedStat((sbyte)tags[ItemDataTag.statst4], (int)tags[ItemDataTag.stat4]));
                        }
                        if ((sbyte)tags[ItemDataTag.statst5] >= 0)
                        {
                            stats.Stats.Add(ReceivedStat((sbyte)tags[ItemDataTag.statst5], (int)tags[ItemDataTag.stat5]));
                        }
                        if ((sbyte)tags[ItemDataTag.statst6] >= 0)
                        {
                            stats.Stats.Add(ReceivedStat((sbyte)tags[ItemDataTag.statst6], (int)tags[ItemDataTag.stat6]));
                        }



                        if ((string)tags[ItemDataTag.itemTree] != "")
                            m_itemTree = ItemSkillTree.ConvertToTree((string)tags[ItemDataTag.itemTree], this,level,ascendedLevel);

                        init = true;
                        break;
                }
            }

            base.NetReceive(item, reader);
        }

        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int Projectileid = type;
            if (m_itemTree != null) { 
                if (ModifierManager.HaveModifier(Modifier.Random, modifier))
                {
                    Projectileid = Mathf.RandomInt(1, 500);
                    float spread = 10 * 0.0174f; //20 degree cone
                    float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY) * (1 + 0.1f * Main.rand.NextFloat());
                    double baseAngle = Math.Atan2(speedX, speedY);
                    double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                    float spdX = baseSpeed * (float)Math.Sin(randomAngle);
                    float spdY = baseSpeed * (float)Math.Cos(randomAngle);
                    int projnum = Projectile.NewProjectile(position.X, position.Y, spdX, spdY, Projectileid, damage, knockBack, player.whoAmI);
                    Main.projectile[projnum].friendly = true;
                    Main.projectile[projnum].hostile = false;

                }
            /*
            if (!item.summon) { 
                for (int i = 0; i < ascendedLevel; i++)
                {
                    float spread = 10 * 0.0174f; //20 degree cone
                    float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY) * (1 + 0.1f * Main.rand.NextFloat());
                    double baseAngle = Math.Atan2(speedX, speedY);
                    double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                    float spdX = baseSpeed * (float)Math.Sin(randomAngle);
                    float spdY = baseSpeed * (float)Math.Cos(randomAngle);

                    int projnum = Projectile.NewProjectile(position.X, position.Y, spdX, spdY, Projectileid, damage, knockBack, player.whoAmI);
                    Main.projectile[projnum].friendly = true;
                    Main.projectile[projnum].hostile = false;
                }
            }
            */
            
                m_itemTree.OnShoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            }
            return true;
        }

        public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {

            RPGPlayer rpgPlayer = player.GetModPlayer<RPGPlayer>();
            if (crit)
            {
                damage = (int)(0.5f * damage * rpgPlayer.GetCriticalDamage());
            }
            if (target.type != NPCID.TargetDummy)
                rpgPlayer.AddWeaponXp(damage, item);
            //rpgPlayer.Leech(damage);
            base.ModifyHitNPC(item, player, target, ref damage, ref knockBack, ref crit);
        }


        public override void Load(Item item, TagCompound tag)
        {
            if (init)
                return;
            //item.r
            if (!NeedsSaving(item))
                return;

            string itemTreeSave;
            ItemName = item.Name;
            xp = tag.GetAsLong("Exp");
            level = tag.GetInt("level");
            ascendedLevel = tag.GetInt("ascendedLevel");

            rarity = (Rarity)tag.GetInt("rarity");
            modifier = (Modifier)tag.GetInt("modifier");



            if (m_itemTree == null)
                m_itemTree = new ItemSkillTree();

            itemTreeSave = tag.Get<string>("tree");

            if (itemTreeSave != "")
            {
                m_itemTree = ItemSkillTree.ConvertToTree(itemTreeSave,this,0,0);
            }else
            {
                m_itemTree = new ItemSkillTree();
                m_itemTree.Init(this);
            }

            if (tag.GetIntArray("evolutionInfo") != null && tag.GetIntArray("evolutionInfo").Length == 4)
            {
                m_itemTree.EvolutionPoints = tag.GetIntArray("evolutionInfo")[0];
                m_itemTree.MaxEvolutionPoints = tag.GetIntArray("evolutionInfo")[1];
                m_itemTree.AscendPoints = tag.GetIntArray("evolutionInfo")[2];
                m_itemTree.MaxAscendPoints = tag.GetIntArray("evolutionInfo")[3];
            }
            else
            {
                level = 0;
                ascendedLevel = 0;
                xp = 0;
            }

            List<ItemStat> itemstatslist = new List<ItemStat>();
        


            for (int i = 0; i < tag.GetIntArray("stats").Length * 0.5f; i++)
            {

                itemstatslist.Add(new ItemStat((Stat)tag.GetIntArray("stats")[i * 2], tag.GetIntArray("stats")[i * 2 + 1] * 0.01f));
            }
            stats = new ItemStats()
            {
                Stats = itemstatslist
            };



            baseDamage = item.damage;
            baseArmor = item.defense;
            baseAutoReuse = item.autoReuse;
            baseName = item.Name;
            baseUseTime = item.useTime;


            itemType = GetItemTypeCustom(item);
            if (itemType == ItemType.Armor)
                item.defense = GetDefense(item);
            else if (itemType == ItemType.Weapon)
            {
                if (item.pick > 0 || item.axe > 0 || item.hammer > 0)
                {
                    item.useTime = GetUse(item);
                    item.useAnimation = item.useTime;
                }
                else
                    item.damage = GetDamage(item);
            }

            baseValue = item.value;
            baseMana = item.mana;

            if (item.healLife > 0)
                baseHealLife = item.healLife;
            if (item.healMana > 0)
                baseHealMana = item.healMana;


            if (rarity == Rarity.NONE)
            {
                Roll(item);
            }
            baseCap = GetCapLevel();
            if (stats.Stats == null)
                stats.Stats = new List<ItemStat>();
            init = true;
            
            item.SetNameOverride(SetName(item));

            
            
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {

            if (item.healLife > 0)
            {
                TooltipLine healtt = tooltips.Find(x => x.Name == "HealLife");
                if (healtt != null)
                {
                    int iheal = tooltips.FindIndex(x => x.Name == "HealLife");
                    healtt = new TooltipLine(mod, "HealLife", healtt.text + "( " + baseHealLife + " )");
                    tooltips[iheal] = healtt;
                }

            }
            if (item.healMana > 0)
            {
                TooltipLine healtt = tooltips.Find(x => x.Name == "HealMana");
                if (healtt != null)
                {
                    int iheal = tooltips.FindIndex(x => x.Name == "HealMana");
                    healtt = new TooltipLine(mod, "HealMana", healtt.text + "( " + baseHealMana + " )");
                    tooltips[iheal] = healtt;
                }
            }

            if (NeedsSaving(item))
            {


                if (itemType == ItemType.Accessory || itemType == ItemType.Armor || itemType == ItemType.Weapon)
                {

                    /*
                    if (itemType == ItemType.Weapon) { 
                        TooltipLine ITT = new TooltipLine(mod, "WeaponType",ItemUtils.GetWeaponType(item).ToString());
                        tooltips.Add(ITT);
                    }*/
                    if (Config.gpConfig.ItemRarity)
                    {
                        TooltipLine Rtt;
                        if (rarity != Rarity.NONE)
                            Rtt = new TooltipLine(mod, "Rarity", Enum.GetName(typeof(Rarity), rarity))
                            {
                                overrideColor = ModifierManager.GetRarityColor(rarity)
                            };
                        else
                        {
                            Rtt = new TooltipLine(mod, "Rarity", "???")
                            {
                                overrideColor = Color.Pink
                            };
                        }
                        tooltips.Add(Rtt);
                    }

                    if ((itemType == ItemType.Accessory || itemType == ItemType.Armor) && Config.gpConfig.ItemRarity)
                    {
                        if (stats.Stats.Count > 0)
                        {
                            for (int i = 0; i < stats.Stats.Count; i++)
                            {
                                TooltipLine Stt;
                                RPGPlayer p = Main.LocalPlayer.GetModPlayer<RPGPlayer>();
                                if (GetStatSlot(i) > 0)
                                    Stt = new TooltipLine(mod, "statsInfo" + i, Enum.GetName(typeof(Stat), stats.Stats[i].stat) + " +" + Mathf.Round(GetStatSlot(i),2) + " % ( +" + Mathf.Round(p.GetStat(stats.Stats[i].stat) * GetStatSlot(i) * 0.01f, 1) + " )")
                                    {
                                        overrideColor = Color.LimeGreen
                                    };
                                else
                                    Stt = new TooltipLine(mod, "statsInfo" + i, Enum.GetName(typeof(Stat), stats.Stats[i].stat) + " -" + Math.Abs(Mathf.Round(GetStatSlot(i),2)) + " % ( " + Mathf.Round(p.GetStat(stats.Stats[i].stat) * GetStatSlot(i) * 0.01f, 1) + " )")
                                    {
                                        overrideColor = Color.PaleVioletRed
                                    };

                                tooltips.Add(Stt);
                            }
                        }
                    }
                    if (itemType == ItemType.Weapon && Config.gpConfig.ItemRarity)
                    {
                        TooltipLine Stt;
                        RPGPlayer p = Main.LocalPlayer.GetModPlayer<RPGPlayer>();
                        if (ModifierManager.GetRarityDamageBoost(rarity) > 0)
                            Stt = new TooltipLine(mod, "statsInfo", "Rarity bonus + " + ModifierManager.GetRarityDamageBoost(rarity) + "% Damage")
                            {
                                overrideColor = ModifierManager.GetRarityColor(rarity)
                            };
                        else
                        {
                            Stt = new TooltipLine(mod, "statsInfo", "Rarity bonus " + ModifierManager.GetRarityDamageBoost(rarity) + "% Damage")
                            {
                                overrideColor = ModifierManager.GetRarityColor(rarity)
                            };
                        }
                        tooltips.Add(Stt);
                    }

                    if (Config.gpConfig.ItemModifier)
                    {
                        String[] SList = ModifierManager.GetModifierDesc(this);

                        for (int i = 0; i < SList.Length; i++)
                        {

                            TooltipLine Mtt = new TooltipLine(mod, "Modifier" + i, SList[i])
                            {
                                overrideColor = ModifierManager.GetRarityColor(rarity)
                            };
                            tooltips.Add(Mtt);
                        }
                    }
                }
                //BASE EXP BONUS FROM ITEM
                if (!item.accessory && itemType != ItemType.Healing)
                {
                    if (itemType == ItemType.Weapon)
                    {
                        TooltipLine bt = new TooltipLine(mod, "BaseDamage", "" + baseDamage + " Base Damage");
                        tooltips.Add(bt);
                    }
                    else if (itemType == ItemType.Armor)
                    {
                        TooltipLine bt = new TooltipLine(mod, "BaseDefense", "" + baseArmor + " Base Defense");
                        tooltips.Add(bt);
                    }


                    if (itemType == ItemType.Weapon || itemType == ItemType.Armor)
                    {
                        TooltipLine ltt = new TooltipLine(mod, "LevelInfo", "Level : " + level + " / " + (GetCapLevel() * (ascendedLevel+1)))
                        {
                            isModifier = true
                        };
                        tooltips.Add(ltt);
                        TooltipLine xptt = new TooltipLine(mod, "Experience", "Xp : " + GetXp + "/" + GetMaxXp)
                        {
                            isModifier = true
                        };
                        tooltips.Add(xptt);
                    }
                    if (level > 0)
                    {
                        if (Config.gpConfig.ItemTree && m_itemTree!= null)
                        {
                            if (m_itemTree.EvolutionPoints > 0)
                            {
                                TooltipLine infott = new TooltipLine(mod, "pointsInfo", m_itemTree.EvolutionPoints + " Evolution Points left !")
                                {
                                    isModifier = true,
                                    overrideColor = Color.Orange
                                };
                                tooltips.Add(infott);
                            }
                            if (m_itemTree.AscendPoints > 0)
                            {
                                TooltipLine infotta = new TooltipLine(mod, "pointsAscendInfo", m_itemTree.AscendPoints + " Ascend Points left !!!")
                                {
                                    isModifier = true,
                                    overrideColor = Color.Red
                                };
                                tooltips.Add(infotta);
                            }
                        }
                        else
                        {
                            
                            if (itemType == ItemType.Weapon)
                            {
                                if (item.pick > 0 || item.axe > 0 || item.hammer > 0)
                                {
                                    TooltipLine stt = new TooltipLine(mod, "BonusSpeedstuff", "+" + Math.Round(((Mathf.Pow(1.005, level) - 1) * 100 + (Mathf.Pow(1.05, ascendedLevel) - 1) * 100), 1) + "% Speed")
                                    {
                                        isModifier = true
                                    };
                                    tooltips.Add(stt);
                                }
                                else
                                {
                                    TooltipLine tt = new TooltipLine(mod, "PrefixDamage", "+" + (((float)level * 1f) + ascendedLevel * 10f) + "% Damage")
                                    {
                                        isModifier = true
                                    };
                                    tooltips.Add(tt);
                                }

                            }
                            if (itemType == ItemType.Armor)
                            {
                                TooltipLine tt = new TooltipLine(mod, "PrefixDefense", "+" + Mathf.CeilInt(((float)level * 0.25f) + baseArmor * ascendedLevel * 0.25f) + " Defense")
                                {
                                    isModifier = true
                                };
                                tooltips.Add(tt);


                            }
                        }
                        for (int i = 0; i < AscendToolTip.Count; i++)
                        {
                            tooltips.Add(AscendToolTip[i]);
                        }
                    }
                }
            }

        }

        public string treeToString(ItemSkillTree itemTree)
        {
            if (itemTree != null)
                return ItemSkillTree.ConvertToString(itemTree);
            return "";
        }

        public override TagCompound Save(Item item)
        {

            int[] statsArray = new int[0];
            if (stats.Stats != null && stats.Stats.Count > 0)
            {
                statsArray = new int[stats.Stats.Count * 2];
                for (int i = 0; i < stats.Stats.Count; i++)
                {
                    statsArray[(i * 2)] = (int)stats.Stats[i].stat;
                    statsArray[(i * 2) + 1] = (int)(stats.Stats[i].value * 100);
                }
            }
            //AnotherRpgMod.Instance.Logger.Info(item.Name);
            //AnotherRpgMod.Instance.Logger.Info(treeToString(m_itemTree));


            string treeToStringVal = "";
            int[] evInfo = new int[4] { 0,0,0,0 };
            if (m_itemTree != null)
            {
                treeToStringVal = treeToString(m_itemTree);
                if (m_itemTree.MaxEvolutionPoints >= level -1)
                    evInfo = new int[4] { GetEvolutionPoints, GetMaxEvolutionPoints, GetAscendPoints, GetMaxAscendPoints };
                else
                {
                    evInfo = new int[4] { level - 1 - m_itemTree.GetUsedPoints, level-1, m_itemTree.AscendPoints, ascendedLevel };
                }
            }

            return new TagCompound
                {
                    {"Exp", xp},
                    {"level",level },
                    {"ascendedLevel",ascendedLevel },
                    {"rarity",(int)rarity },
                    {"modifier",(int)modifier },
                    {"stats", statsArray},
                    {"tree", treeToStringVal},
                    {"evolutionInfo",  evInfo}
                };
        }

        public override bool ConsumeAmmo(Item item, Player player)
        {
            if (ascendedLevel > 0)
                return Main.rand.NextFloat() >= .5f;
            return base.ConsumeAmmo(item, player);
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (NeedsSaving(item))
            {
                if (rarity == Rarity.NONE)
                {
                    Roll(item);
                }
            }

            RPGPlayer character = player.GetModPlayer<RPGPlayer>();
            if (character != null)
            {

                AscendToolTip = new List<TooltipLine>();

                if (NeedsSaving(item) && (level > 0 || ascendedLevel > 0))
                {
                    
                    baseValue = (int)(item.value * (1 + Mathf.Pow(ascendedLevel, 2f) + level * 0.1f));
                    if (itemType == ItemType.Armor)
                    {
                        UpdatePassive(item,player);
                        item.defense = GetDefense(item);
                        if (ascendedLevel > 0)
                        {
                            int maxascend = Mathf.Clamp(ascendedLevel, 0, AscendName.Length - 1);
                            AscendToolTip.Add(new TooltipLine(mod, "Ascding", "Ascending Tier " + ascendedLevel + " : " + AscendName[maxascend]) { isModifier = true });
                        }
                    }
                }
                
            }
            InitItem(item);

        }

        public override void UpdateInventory(Item item, Player player)
        {
            RPGPlayer character = player.GetModPlayer<RPGPlayer>();
            if (NeedsSaving(item))
            {
                item.SetNameOverride(SetName(item));
            }
            if (character != null)
            {
                AscendToolTip = new List<TooltipLine>();
                
                InitItem(item);



                if (NeedsSaving(item) && (level > 0 || ascendedLevel > 0))
                {

                    UpdatePassive(item,player);

                    baseValue = (int)(item.value * (1 + Mathf.Pow(ascendedLevel, 1.5f) + level * 0.1f));
                    if (itemType == ItemType.Armor)
                    {
                        item.defense = GetDefense(item);
                        if (ascendedLevel > 0)
                        {
                            int maxascend = Mathf.Clamp(ascendedLevel, 0, AscendName.Length - 1);
                            AscendToolTip.Add(new TooltipLine(mod, "Ascding", "Ascending Tier " + ascendedLevel + " : " + AscendName[maxascend]) { isModifier = true });
                        }
                    }
                    if (itemType == ItemType.Weapon)
                    {
                        if (item.pick > 0 || item.axe > 0 || item.hammer > 0)
                        {
                            item.useTime = GetUse(item);
                            item.useAnimation = item.useTime;
                        }
                        else
                            item.damage = GetDamage(item);

                        if (ascendedLevel > 0)
                        {
                            int maxascend = Mathf.Clamp(ascendedLevel, 0, AscendName.Length - 1);
                            AscendToolTip.Add(new TooltipLine(mod, "Ascding", "Ascending Tier " + ascendedLevel + " : " + AscendName[maxascend]) { isModifier = true });

                            if (!Config.gpConfig.ItemTree) { 

                                if (!baseAutoReuse && !item.magic && !item.summon)
                                    AscendToolTip.Add(new TooltipLine(mod, "AscdAutoSwing", "Have AutoUse") { isModifier = true });
                                if (item.ranged)
                                    AscendToolTip.Add(new TooltipLine(mod, "ascdProjectile", "+ " + ascendedLevel + " Projectiles") { isModifier = true });

                                if ((baseAutoReuse) || (ascendedLevel > 1))
                                {
                                    AscendToolTip.Add(new TooltipLine(mod, "AscdAutoSwingBonus", "+ 40% attack speed") { isModifier = true });
                                    item.useTime = Mathf.CeilInt(baseUseTime * 0.6f);
                                    item.useAnimation = item.useTime;
                                }
                                if (baseMana > 0)
                                {
                                    AscendToolTip.Add(new TooltipLine(mod, "AscdAManaUse", "50% Mana Reduction") { isModifier = true });
                                    item.mana = Mathf.CeilInt(baseMana * 0.5f);
                                }
                                if (item.summon)
                                {
                                    AscendToolTip.Add(new TooltipLine(mod, "AscdMaxMinion", "Max minion +" + ascendedLevel) { isModifier = true });
                                    /*
                                    if (player.HeldItem == item)
                                        player.maxMinions+=ascendedLevel;
                                        */
                                }
                                if (!item.magic && !item.summon)
                                    item.autoReuse = true;
                            }
                        }
                        if (ascendedLevel > 1)
                        {
                            if (!Config.gpConfig.ItemTree)
                            {
                                if (item.melee)
                                {
                                    for (int i = 0; i < ascendedLevel; i++)
                                    {
                                        lifeLeech = i * 0.5f;
                                    }
                                    AscendToolTip.Add(new TooltipLine(mod, "AscdLifeLeech", "+ " + lifeLeech + "% LifeLeech") { isModifier = true });

                                }
                                if (item.magic)
                                {
                                    for (int i = 0; i < ascendedLevel; i++)
                                    {
                                        manaLeech = i;
                                    }
                                    AscendToolTip.Add(new TooltipLine(mod, "AscdManaLeech", "+ " + manaLeech + "% ManaLeech") { isModifier = true });
                                }
                                if (item.summon)
                                {

                                    AscendToolTip.Add(new TooltipLine(mod, "AscdMinionDamage", "+ 50% Minion Damage") { isModifier = true });
                                    player.minionDamage *= 1.5f;
                                }
                                if (item.useAmmo > 0)
                                {
                                    AscendToolTip.Add(new TooltipLine(mod, "AscdMinionDamage", "50% Chance Not to use ammo") { isModifier = true });
                                }
                            }
                        }

                        int manacostGain = 0;
                        if (Config.gpConfig.RPGPlayer && character.GetskillTree.HavePerk(Perk.ManaOverBurst) && item.magic && item.mana > 0)
                        {
                            
                            manacostGain = Mathf.CeilInt((player.statMana * (0.15f + ((float)character.GetskillTree.nodeList.GetPerk(Perk.ManaOverBurst).GetLevel - 1) * 0.15f))/ (float)Math.Sqrt(character.GetDamageMult(DamageType.Magic, 2)));
                        }
                        item.mana = baseMana + manacostGain;

                    }
                }





            }

        }


        public override void GetHealLife(Item item, Player player, bool quickHeal, ref int healValue)
        {
            healValue = (int)( healValue* player.GetModPlayer<RPGPlayer>().GetBonusHeal());
            base.GetHealLife(item, player, quickHeal, ref healValue);
        }

        public override void GetHealMana(Item item, Player player, bool quickHeal, ref int healValue)
        {
            healValue = (int)( healValue * player.GetModPlayer<RPGPlayer>().GetBonusHealMana());
            base.GetHealMana(item, player, quickHeal, ref healValue);
        }


        #endregion

        #region CustomFunction


        private int GetTier(float PowerLevel)
        {
            if(PowerLevel < 50)
            {
                return 1;
            }
            if(PowerLevel < 90)
            {
                return 2;
            }
            if (PowerLevel < 100)
            {
                return 3;
            }
            if (PowerLevel < 140)
            {
                return 4;
            }
            if ( PowerLevel < 200)
            {
                return 5;
            }
            if (PowerLevel < 300)
            {
                return 6;
            }
            if (PowerLevel < 400)
            {
                return 8;
            }
            if (PowerLevel < 700)
            {
                return 10;
            }
            if (PowerLevel < 1000)
            {
                return 15;
            }
            if (PowerLevel < 1500)
            {
                return 20;
            }
            if(PowerLevel < 2500)
            {
                return 30;
            }
            return 40;
        }

        public int GetCapLevel()
        {

            float powerLevel = BaseDamage * Mathf.Pow(Mathf.Clamp(60/ Mathf.Min(baseUseTime,1),2,30),0.5f) + Mathf.Pow(baseArmor,1.45f)*4;

            if (m_weaponType == WeaponType.Stab)
                powerLevel *= 0.5f;

            if (baseAutoReuse)
                powerLevel *= 1.2f;
            if (Config.gpConfig.ItemRarity)
                powerLevel *= (1 - Mathf.Log2((float)rarity) * 0.05f);
            //   return 5 *GetTier(powerLevel);
            return 10;
        }

        public void ResetTree()
        {
            m_itemTree.Reset(false);
        }

        public void CompleteReset()
        {
            m_itemTree.MaxEvolutionPoints = level;
            m_itemTree.MaxAscendPoints = ascendedLevel;
            m_itemTree.Reset(true);
            
            if (ascendedLevel>0)
                m_itemTree.ExtendTree(Mathf.Clamp(Mathf.CeilInt(Mathf.Pow(baseCap / 3f, 0.95)), 5, 99)*ascendedLevel);

            AnotherRpgMod.Instance.ItemTreeUI.Open(this);
        }

        public void ResetLevelXp(bool ascend = true)
        {
            level = 0;
            xp = 0;
            if (ascend)
                ascendedLevel = 0;
            m_itemTree.Reset(false);
            m_itemTree.AscendPoints = 0;
            m_itemTree.MaxAscendPoints = 0;
            m_itemTree.EvolutionPoints = 0;
            m_itemTree.MaxEvolutionPoints = 0;
        }

        public void Ascend()
        {

            
            if (ascendedLevel >= WorldManager.GetMaximumAscend())
            {
                if (!AscendLimit)
                {
                    AscendLimit = true;
                    Main.NewText("Your weapon have reached it's maximum power, the world can't handle anymore", 144, 32, 185);
                }
                return;
            }
                
            

            ascendedLevel++;
            m_itemTree.MaxAscendPoints++;
            m_itemTree.AscendPoints++;
            m_itemTree.ExtendTree(Mathf.Clamp( Mathf.CeilInt(Mathf.Pow(baseCap / 3f, 0.95)),5,99));

            if (UI.ItemTreeUi.visible)
            {
                AnotherRpgMod.Instance.ItemTreeUI.Init();
            }
            
            //First Ascension = LIMIT BREAK
            if (ascendedLevel == 0)
            {
                
                Main.NewText("WEAPON LIMIT BREAK !!!",Color.OrangeRed);
                m_itemTree.MaxAscendPoints = 0;
                m_itemTree.MaxEvolutionPoints = 0;
                m_itemTree.Reset(false);
                level = 0;
            }
            else
                Main.NewText("weapon ascended !");
        }

        public void Roll(Item item)
        {
            if (Config.gpConfig.ItemRarity || Config.gpConfig.ItemModifier)
            {
                RollInfo info = ModifierManager.RollItem(this, item);
                if (Config.gpConfig.ItemRarity)
                {
                    rarity = info.rarity;
                    stats = info.stats;
                }
                if (Config.gpConfig.ItemModifier)
                {
                    modifier = info.modifier;
                }
            }
        }

        ItemStat ReceivedStat(sbyte stat, int value)
        {
            return new ItemStat((Stat)stat, (float)(value) * 0.01f);
        }
            
        private string SetName(Item item)
        {

            int maxascend = Mathf.Clamp(ascendedLevel, 0, AscendName.Length - 1);
            string prefix = "";
            if (rarity != Rarity.NONE && Config.gpConfig.ItemRarity)
                prefix += Enum.GetName(typeof(Rarity), rarity) + " ";
            prefix += AscendName[maxascend];
            string sufix = "";
            if (level > 0)
                sufix = " +" + level;

            if (baseName == "")
            {
                baseName = item.Name;
            }

            return (prefix + baseName + sufix);
        }

        public void SilentLevelUp()
        {
            

            if (level >= (GetCapLevel() * (ascendedLevel + 1)) && ascendedLevel >= WorldManager.GetMaximumAscend())
            {
                return;
            }

            xp -= GetExpToNextLevel(level, ascendedLevel);
            level++;
            m_itemTree.MaxEvolutionPoints++;
            m_itemTree.EvolutionPoints++;

            if (level == GetCapLevel() && ascendedLevel == 0)
                Main.NewText("Your item has reached its limit", Color.Red);
            if (level > GetCapLevel() * (ascendedLevel + 1))
            {
                Ascend();
            }
        }

        public void LevelUp(Player player, Item item)
        {
            

            if (level >= (GetCapLevel() * (ascendedLevel + 1)) && ascendedLevel >= WorldManager.GetMaximumAscend())
            {
                return;
            }

            xp -= GetExpToNextLevel(level, ascendedLevel);
            if (itemType == ItemType.Armor)
                CombatText.NewText(player.getRect(), new Color(255, 26, 255), "Armor upgrade !", true);
            if (itemType == ItemType.Weapon)
                CombatText.NewText(player.getRect(), new Color(255, 26, 255), "Weapon upgrade !", true);
            level++;
            m_itemTree.MaxEvolutionPoints++;
            m_itemTree.EvolutionPoints++;

            if (level == GetCapLevel() && ascendedLevel == 0)
                Main.NewText("Your item has reached its limit", Color.Red);
            if (level > GetCapLevel()*(ascendedLevel+1))
            {
                Ascend();
            }
            item.SetNameOverride(SetName(item));
        }

        public void AddExp(Int64 _xp, Player player, Item item)
        {
            

            if (ModifierManager.HaveModifier(Modifier.SelfLearning, modifier) && !Main.dayTime)
            {
                _xp *= 1 + (long)ModifierManager.GetModifierBonus(Modifier.SelfLearning, this) * (long)0.01f;
                _xp *= 1 + (long)bonusXp;
            }
            if (!canLevelUpMore())
            {
                xp = (long)Mathf.Clamp(xp + _xp * Config.gpConfig.ItemXpMultiplier, 0, GetExpToNextLevel(level, ascendedLevel));
            }
            else 
                xp += (long)Mathf.Clamp(_xp * Config.gpConfig.ItemXpMultiplier, 0, long.MaxValue);
            while (xp >= GetExpToNextLevel(level, ascendedLevel) && canLevelUpMore())
            {
                LevelUp(player, item);
                if (!canLevelUpMore())
                {
                    xp = (long)Mathf.Clamp(xp, 0, GetExpToNextLevel(level, ascendedLevel));
                }
            }
        }


        public bool canLevelUpMore()
        {
            if (level < (GetCapLevel() * (ascendedLevel + 1)))
                return true;
            else
                return ascendedLevel < WorldManager.GetMaximumAscend();
        }

        public void xPTransfer(float _xp, Player player, Item item)
        {

            xp += (long)Mathf.Clamp(_xp, 0, long.MaxValue - xp);
            while (xp >= GetExpToNextLevel(level, ascendedLevel) && canLevelUpMore())
            {
                LevelUp(player, item);
            }
        }

        public void SilentxPTransfer(float _xp, bool silent = true)
        {

            xp += (long)Mathf.Clamp(_xp, 0, long.MaxValue - xp);
            
            while (xp >= GetExpToNextLevel(level, ascendedLevel) && canLevelUpMore())
            {
                SilentLevelUp();
            }
        }

        public void EquipedUpdateModifier(Item item, Player player)
        {
            if (ModifierManager.HaveModifier(Modifier.Thorny, modifier))
            {
                player.thorns += ModifierManager.GetModifierBonus(Modifier.Thorny, this) * 0.01f;
            }
            if (ModifierManager.HaveModifier(Modifier.VampiricAura, modifier))
            {
                for (int j = 0; j < Main.npc.Length; j++)
                {
                    float damageToApply = ModifierManager.GetModifierBonus(Modifier.VampiricAura, this) * (1f / 60f);
                    if (Vector2.Distance(Main.npc[j].position, player.position) < 1000 && !Main.npc[j].townNPC && Main.npc[j].damage > 1)
                    {
                        int heal = Main.npc[j].GetGlobalNPC<ARPGGlobalNPC>().ApplyVampricAura(Main.npc[j], damageToApply);
                        player.GetModPlayer<RPGPlayer>().ApplyReduction(ref heal);
                        player.GetModPlayer<RPGPlayer>().HealSlow(heal);

                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendData(MessageID.SyncItem, -1, -1, null, j, 0f, 0f, 0f, 0, 0, 0);
                        }
                    }
                }
            }
            if (ModifierManager.HaveModifier(Modifier.FireLord, modifier))
            {
                for (int j = 0; j < Main.npc.Length; j++)
                {
                    if (!Main.npc[j].townNPC)
                    {

                        if (Vector2.Distance(Main.npc[j].position, player.position) < ModifierManager.GetModifierBonus(Modifier.FireLord, this))
                        {
                            Main.npc[j].AddBuff(BuffID.OnFire, 15);
                        }
                    }
                }
            }
        }

        #endregion


    }
}
