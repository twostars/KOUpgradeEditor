using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace KOUpgradeEditor
{
    [Serializable]
    class UpgradeScroll
    {
        public enum UpgradeType
        {
            REGULAR, STAT, ELEMENT,
            ACCESSORYCOMPOUND, ACCESSORYENCHANT,
            DISPELL
        };

        public enum GradeLevel { BLESSED, HIGH, MIDDLE, LOW };
        public UpgradeScroll() { }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Modifier { get; set; }
        public UpgradeType Type { get; set; }
        public GradeLevel Grade { get; set; }
        public bool Weapon { get; set; }
        public bool Armor { get; set; }
        public bool Accessory { get; set; }
        public List<Rate> Rates { get; set; }

        public override string ToString() { return Name; }
    }

    [Serializable]
    class Rate
    {
        public Rate() {}

        public int Percent { get; set; }
        public int TrinaPercent { get; set; }
        public int Cost { get; set; }
        public int Grade { get; set; }
        public override string ToString() { return Grade.ToString(); }
    }
}
