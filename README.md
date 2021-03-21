# AnRPG-Edited
## What is this?
This is a modified version of a Tmodloader mod: **Another RPG Mod** by **Plexus**. In this version, everything is more balanced, more reasonable to prevent players from seeing astronomical numbers and some numerical bugs.
## What is changed?
### Player Stat
Nerf armor gain on VIT/CONS
### Item Tree
#### TLDR: Everything is nerfed, especially Ascension Nodes. 
#### Detailed changes:
- Ascension Flat Damage and Ascension Percentage Damage node value hugely decreased.
- Ascension Multiple Projectiles reworked. Now fires extra projectile with 30% damage. This node is very hard to balance, since it brings **100% more** damage for ranged weapons with just 1 point in early phase of the game. Moreover, not every weapon benefits from it, so it clutters the item tree with no real purpose, making ranged weapons lose Ascension Points for nothing. I couldn't know how to modifiy its rarity in the item tree to make it appear less frequent, so I disabled it by default.
- Slightly nerfed every other damage node.
- Defense bonus node on Armor pieces reworked. Cost increases the deeper you go into the skill tree, but they provide more defense per level. 
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
- Formulas for HP/Damage of NPC/Bosses nerfed. *(NPCUtils.cs line 628, 642, 649)*
- Formulas for Defense reworked. Now enemy defense matters. This is implemented to increase enemy survivability without the need of continuously increasing enemy HP. Moreover, this can prevent tank classes from investing all to defense stat and can still do damage. *(NPCUtils.cs line 657,659)*
### Misc/QoL
