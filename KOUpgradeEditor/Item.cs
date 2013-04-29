using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOUpgradeEditor
{
    class Item
    {
       
        public Item(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int DaggerAC
        {
            get;
            set;
        }

        public int SwordAC
        {
            get;
            set;
        }

        public int MaceAC
        {
            get;
            set;
        }

        public int AxeAC
        {
            get;
            set;
        }

        public int SpearAC
        {
            get;
            set;
        }

        public int BowAC
        {
            get;
            set;
        }

        public int FireDamage
        {
            get;
            set;
        }

        public int IceDamage
        {
            get;
            set;
        }

        public int LightDamage
        {
            get;
            set;
        }

        public int PoisonDamage
        {
            get;
            set;
        }

        public int HPDrain
        {
            get;
            set;
        }

        public int MPDamage
        {
            get;
            set;
        }

        public int MPDrain
        {
            get;
            set;
        }

        public int MirrorDamage
        {
            get;
            set;
        }

        public int Strength
        {
            get;
            set;
        }

        public int Health
        {
            get;
            set;
        }

        public int Dexterity
        {
            get;
            set;
        }

        public int Intelligence
        {
            get;
            set;
        }

        public int MagicPower
        {
            get;
            set;
        }

        public int MaxHealth
        {
            get;
            set;
        }

        public int MaxMana
        {
            get;
            set;
        }

        public int FireResist
        {
            get;
            set;
        }

        public int IceResist
        {
            get;
            set;
        }

        public int LightResist
        {
            get;
            set;
        }

        public int MagicResist
        {
            get;
            set;
        }

        public int PoisonResist
        {
            get;
            set;
        }

        public int CurseResist
        {
            get;
            set;
        }

        public int Extension
        {
            get;
            set;
        }

        public int Damage
        {
            get;
            set;
        }

        public int Defense
        {
            get;
            set;
        }

        public int RequiredLevel
        {
            get;
            set;
        }


        /// <summary>
        /// 1 - Magic Item non-upgradable
        /// 2 - Rare non-upgradable
        /// 3 - Unique non-upgradable (Goblin Armor)
        /// 4 - Unique Upgradable (Hell Breaker)
        /// 5 - UpgradeItem Upgradable
        /// 6 - Event Item non-upgradable
        /// </summary>
        public int Type
        {
            get;
            set;
        }

        public int Slot
        {
            get;
            set;
        }


        public int Grade
        {
            //defined in item_org 36 + item_ext 29
            get;
            set;
        }

        public int Base
        {
            get
            {
                return int.Parse(ID.ToString().Substring(0, 6));
            }
        }

        public int ExtensionID
        {
            get
            {
                return int.Parse(ID.ToString().Substring(6, 3));
            }
        }

        public int UniqueID
        {
            get;
            set;
        }

        public bool isAccessory
        {
            get
            {
                return frmMain.accessorySlots.Contains(Slot);
            }
        }

        /*
        * 
        *  Num, Ext, strName, Damage, Ac, ReqLevel, DaggerAc, SwordAc, MaceAc, AxeAc, SpearAc, BowAc, FireDamage, IceDamage, LightningDamage, PoisonDamage, HPDrain, MPDamage, 
                     MPDrain, MirrorDamage, Droprate, StrB, StaB, DexB, IntelB, ChaB, MaxHpB, MaxMpB, FireR, ColdR, LightningR, MagicR, PoisonR, CurseR
        */

        public override string ToString()
        {
            return Name;
        }
    }
}
