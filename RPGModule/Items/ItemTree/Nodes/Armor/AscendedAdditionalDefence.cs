using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using AnotherRpgMod.Utils;

namespace AnotherRpgMod.Items
{
    class AscendedAdditionalDefence : ItemNode
    {
        new protected string m_Name = "(Ascended) Bonus Defense";
        new protected string m_Desc = "+ Defense";
        new public float rarityWeight = 0.05f;
        new protected bool m_isAscend = true;

        public override bool IsAscend
        {
            get
            {
                return m_isAscend;
            }
        }

        public override NodeCategory GetNodeCategory 
        {
            get
            {
                
                return NodeCategory.Flat;
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
                return "Add " + FlatDef + " Defense";
            } }



        public int FlatDef;

        public override void Passive(Item item)
        {
            item.GetGlobalItem<ItemUpdate>().DefenceFlatBuffer += FlatDef;
        }

        public override void SetPower(float value)
        {
            FlatDef = Utils.Mathf.Clamp((int)Utils.Mathf.Pow(value*0.6f, 1.01f), 1, 3);
            m_MaxLevel = 1;
            m_RequiredPoints = 1;
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
