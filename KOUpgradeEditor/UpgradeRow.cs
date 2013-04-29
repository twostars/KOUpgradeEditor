using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOUpgradeEditor
{
    class UpgradeRow : ICloneable
    {
        int npc = 5001;
        List<int> reqItems = new List<int>();
        public UpgradeRow()
        {
            for (int i = 0; i < 8; i++)
            {
                reqItems.Add(0);
            }
        }
        /*
         * nIndex, nNPCNum, strName, strNote, nOriginType, nOriginItem, nReqItem1, nReqItem2, nReqItem3, nReqItem4, nReqItem5, nReqItem6, nReqItem7, 
                      nReqItem8, nReqNoah, bRateType, nGenRate, nGiveItem
         */
        public int Index
        {
            get;
            set;
        }

        public int nNPCNum
        {
            get{
                return npc;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public int Extension
        {
            get;
            set;
        }

        public int Item
        {
            get;
            set;
        }

        public List<int> RequiredItems
        {
            get
            {
                return reqItems;
            }
        }

        public int Cost
        {
            get;
            set;
        }

        public int RateType
        {
            get;
            set;
        }

        public int Percent
        {
            get;
            set;
        }

        public int Modifier
        {
            get;
            set;
        }

        public string toInsert()
        {
            return string.Format("INSERT INTO ITEM_UPGRADE (nIndex, nNPCNum, strName, strNote, nOriginType, nOriginItem, nReqItem1, nReqItem2, nReqItem3, nReqItem4, nReqItem5, nReqItem6, nReqItem7, nReqItem8, nReqNoah, bRateType, nGenRate, nGiveItem) VALUES ({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17})",
                Index, nNPCNum, Name, Note, Extension, Item, RequiredItems[0], RequiredItems[1], RequiredItems[2], RequiredItems[3], RequiredItems[4], RequiredItems[5], RequiredItems[6], RequiredItems[7], Cost, RateType, Percent, Modifier);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public UpgradeRow Clone()
        { 
            UpgradeRow r = (UpgradeRow)this.MemberwiseClone();
            r.reqItems = new List<int>(reqItems);
            return r;
        }
     

    }
}
