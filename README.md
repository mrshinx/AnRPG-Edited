# AnRPG-Edited
## What is this?
This is a modified version of a Tmodloader mod: **Another RPG Mod** by **Plexus**. In this version, everything is more balanced, more reasonable to prevent players from seeing astronomical numbers and some numerical bugs.
## What is changed?
### Player Stat
Nerf armor gain on VIT/CONS
### Item Tree
#### TLDR: Everything is nerfed, especially Ascension Nodes. All weapons get equal level requirement for ascension.
#### Detailed changes:
- Ascension Flat Damage and Ascension Percentage Damage node value hugely decreased.
- Ascension Multiple Projectiles reworked. Now fires extra projectile with 30% damage. This node is very hard to balance, since it brings **100% more** damage for ranged weapons with just 1 point in early phase of the game. Moreover, not every weapon benefits from it, so it clutters the item tree with no real purpose, making ranged weapons lose Ascension Points for nothing. I couldn't know how to modifiy its rarity in the item tree to make it appear less frequent, so I disabled it by default. *(ItemNodeAtlas.cs Line 35)*
- Slightly nerfed every other damage node.
- Life leech node nerfed.
- Defense bonus node on Armor pieces reworked. Cost increases the deeper you go into the item tree, but they provide more defense per level. 
- All weapons now have the same 10 level requirement for ascension. The current system can lead to wrong assumption of item's power, for example a Sky Fracture can be obtained pre-Mech bosses and Megashark is obtained post-Mech. But Megashark's level requirement for ascension is 10 while a Sky Fracture has 20. By the time both items have ascended 10 times, Sky Fracture has 220 level while a Megashark only has 110. This gives Sky Fracture more space to generate high-level ascension node as well as 2x amount of damage nodes to invest to. Imagine items with 40 level requirement, they will be able to scale crazily. *(ItemUpdate.cs Line 1341)*
- All armor pieces have 5 level requirement for ascension.
- Changed flat defense node to %.
- Added Ascended Flat Defense node.
### Skill Tree
#### TLDR: Every class bonus damage is nerfed, some tweaks to bonus class damage nodes.
#### Detailed changes:
- Almost every class gets their damage bonus halved.
- Bonus damage nodes have more level, meaning that players should have something to invest to at high levels.
- Summoner class nerfed to the ground. Reason: The only nodes that can appear on Summon Weapons are damage nodes. No mana cost, No leech, No attack speed, only damage and damage. This gives Summon Weapon the potential to outscale every other weapon type.
- Tank classes get a very slight nerf to armor bonus and slight bonus to HP bonus. 
### Enemy Changes
#### TLDR: Enemy level now depends only on boss kills. Enemies are much weaker to compensate for the changes made to player character.
#### Detailed changes:
- Enemy now starts with base level cap of 20. The cap then raises for each unique boss kill based on NPC growth per boss value, configurable in setting. *(NPCUtils.cs line 143)*
- Enemy spawns with randomized level around the cap with a range of -7 to +3 level. Bosses randomly get 10-25 increased level above the cap.
- Formulas for HP/Damage of NPC/Bosses nerfed. *(NPCUtils.cs line 637, 641, 652, 654)*
- Formulas for Defense reworked. Now enemy defense matters. This is implemented to increase enemy survivability without the need of continuously increasing enemy HP. Moreover,     this can prevent tank classes from investing all to defense stat and can still do damage. *(NPCUtils.cs line 662,664)*
- Changed projectile damage calculation to match the new enemy scaling system. Now projectile damage scales off of enemy current level cap. *(ARPGGlobalProjectile.cs line 30,58)*
- Added a different formula for projectile damage when a boss is alive. *(ARPGGlobalProjectile.cs line 46-49)*
- Added scaling post-Plantera. After Plantera has been defeated, enemies get stronger. *(NPCUtils.cs line 630)*
- Added Defense Multiplier factor. Enemies get 50% of their armor value at day 0, up to 100% at day 20. This is implemented to help ease the struggle in the very beginning of a new playthrough. *(NPCUtils.cs line 627)*
### Misc/QoL/Bug fixes
- Increase exp gain per hit for weapons to compensate for the damage loss with the nerf. *(RPGPlayer.cs Line 190)*
- Increase exp gain per hit for armor to compensate for the defense loss with the nerf. *(RPGPlayer.cs Line 630)*
- Reduce exp lost when transfering XP from 75% -> 30% ( you keep 70% of the old item's XP) *(ItemExtraction.cs Line 36)*
- Fixed life leech calculation resulting in 2x life leech amount from item tree. This was fixed by dividing the value by 2 after calculating it from item tree. This is a dumb     way to fix and just acts as a temporary workaround. *(RPGPlayer.cs Line 1464)*
- Changed value increment of Item Ascension Limit Per Boss in config from 0.25 -> 0.1. This enables having values like 0.2 (1 for 5 boss kills).
- Fixed conflict with Calamity. There was a fix in the code that tried to balance Calamity, but it's causing some of the vanilla mobs (and Calamity ones) to not scale correctly.   Now with the new level cap system, hopefully this will calms Calamity scaling down a little bit. Removed the fix *(NPCUtils.cs Line 112-123)*.
- Greatly increased stat impact on Symphonic and Radiant damage to hopefully offset the disadvantage of not having class node in skill tree.
- Fixed wrong XP transfer calculation by adding a new separate method to calculate each level XP requirement *(ItemUpdate.cs Line 414-419)*.
