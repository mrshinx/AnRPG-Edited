﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using AnotherRpgMod.Utils;

namespace AnotherRpgMod.Items
{
    class AdditionalDefenceNode : ItemNode
    {
        new protected string m_Name = "Additional Defence";
        new protected string m_Desc = "+ XX% Defense";


        public override NodeCategory GetNodeCategory 
        {
            get
            {
                
             //   return NodeCategory.Flat;
                return NodeCategory.Multiplier;
            }
        }

        public override string GetName
        {
            get
            {
                return m_Name;
            }
        }

        public override string GetDesc { get {
                return "Add " + (Def * Utils.Mathf.Clamp(GetLevel,1,GetMaxLevel)) + "% Defense";
            } }

        

        public int FlatDef;
        public float Def;

        public override void Passive(Item item)
        {
            item.GetGlobalItem<ItemUpdate>().DefenceBuffer += item.GetGlobalItem<ItemUpdate>().DefenceFlatBuffer * (Def * GetLevel) * 0.01f;
        }

        public override void SetPower(float value)
        {
            // FlatDef = Utils.Mathf.Clamp((int)Utils.Mathf.Pow(value * 0.8, 0.5f), 1, 999);
            Def = Utils.Mathf.Clamp(Utils.Mathf.Round(Utils.Mathf.Pow(value, 1.1f), 2), 3f, 20);
           // FlatDef = Utils.Mathf.Clamp((int)Utils.Mathf.Pow(value * 0.4, 0.7f), 1, 999);
            m_RequiredPoints = 1 + Utils.Mathf.FloorInt(value * 0.5f);
            power = value;
        }

        public override void LoadValue(string saveValue)
        {
            power = saveValue.SafeFloatParse();
            SetPower(power);
        }

        public override string GetSaveValue()
        {
            return power.ToString();
        }

    }
}
