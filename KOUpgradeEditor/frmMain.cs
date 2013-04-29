using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KOUpgradeEditor
{
    public partial class frmMain : Form
    {
        Dictionary<int, UpgradeScroll> _scrolls = new Dictionary<int, UpgradeScroll>();
        Dictionary<int, Item> _items = new Dictionary<int, Item>();
        Dictionary<int, UpgradeRow> upgradeRows = new Dictionary<int, UpgradeRow>();
        private UpgradeScroll.GradeLevel gradeLevel;
        private UpgradeScroll.UpgradeType type;

        public static List<int> accessorySlots = new List<int>() { 10, 11, 12, 14 };

        private const int WEAPON_INDEX = 100000;
        private const int ARMOR_INDEX = 200000;
        private const int HIGH_ARMOR_INDEX = 500000;
        private const int ACCESSORY_INDEX = 300000;
        private static int CURRENT_WEAPON_INDEX = 0;
        private static int CURRENT_ARMOR_INDEX = 0;
        private static int CURRENT_HIGHARMOR_INDEX = 0;
        private static int CURRENT_ACCESSORY_INDEX = 0;
        private const int TRINA_ID = 700002000;

        public frmMain()
        {
            InitializeComponent();
            loadItems();
            loadScrolls();
        }

        private void lbScrolls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int newIndex = lbScrolls.IndexFromPoint(e.X, e.Y);
                if (newIndex > -1)
                {
                    lbScrolls.SelectedIndex = newIndex;
                    cmsScrollList.Show(System.Windows.Forms.Control.MousePosition);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addScroll();
        }

        private void addScroll()
        {
            
            int id = int.Parse(txtScrollID.Text);
            if(!_items.ContainsKey(id))
                return;

            if (_scrolls.ContainsKey(id))
                return;

            UpgradeScroll s = new UpgradeScroll();
            s.ID = _items[id].ID;
            s.Grade = UpgradeScroll.GradeLevel.BLESSED;
            s.Type = UpgradeScroll.UpgradeType.REGULAR;
            s.Name = _items[id].Name;
            s.Rates = new List<Rate>();

            for (int i = 0; i < 11; i++)
                s.Rates.Add(new Rate() { Cost = 0, Grade = i, Percent = 10000 });

            _scrolls.Add(s.ID, s);
            lbScrolls.Items.Add(s);
        }

        private void lbGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbGrades.SelectedItem == null)
                return;

            Rate r = (Rate)lbGrades.SelectedItem;
            txtPercent.Text = r.Percent.ToString();
            txtCost.Text = r.Cost.ToString();
            txtModifier.Text = ((UpgradeScroll)lbScrolls.SelectedItem).Modifier.ToString();
            txtTrinaPercent.Text = ((UpgradeScroll)lbScrolls.SelectedItem).Rates[r.Grade].TrinaPercent.ToString();
        }

        private void lbScrolls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbScrolls.SelectedItem == null)
                return;

            UpgradeScroll s = (UpgradeScroll)lbScrolls.SelectedItem;

            lbGrades.Items.Clear();

            checkGrade(s.Grade);
            checkType(s.Type);

            cbAccessory.Checked = s.Accessory;
            cbArmor.Checked = s.Armor;
            cbWeapon.Checked = s.Weapon;

            foreach (Rate r in s.Rates)
                lbGrades.Items.Add(r);

            lblSelectedScroll.Text = s.Name;
            lbGrades.SelectedIndex = 0;
        }

        private void checkGrade(UpgradeScroll.GradeLevel gl)
        {
            switch (gl)
            {
                case UpgradeScroll.GradeLevel.BLESSED:
                    rbBlessed.Checked = true;
                    break;
                case UpgradeScroll.GradeLevel.HIGH:
                    rbHigh.Checked = true;
                    break;
                case UpgradeScroll.GradeLevel.MIDDLE:
                    rbMiddle.Checked = true;
                    break;
                case UpgradeScroll.GradeLevel.LOW:
                    rbLow.Checked = true;
                    break;
            }
        }

        private void checkType(UpgradeScroll.UpgradeType t)
        {
            switch (t)
            {
                case UpgradeScroll.UpgradeType.REGULAR:
                    rbNormal.Checked = true;
                    break;
                case UpgradeScroll.UpgradeType.ELEMENT:
                    rbElemental.Checked = true;
                    break;
                case UpgradeScroll.UpgradeType.STAT:
                    rbStat.Checked = true;
                    break;
                case UpgradeScroll.UpgradeType.ACCESSORYCOMPOUND:
                    rbAccessoryCompound.Checked = true;
                    break;
                case UpgradeScroll.UpgradeType.ACCESSORYENCHANT:
                    rbAccessoryEnchant.Checked = true;
                    break;
            }
        }

        private void addUniqueUpgrade(Item i)
        {
            int id = getUnlockedID(i);

            if (id == -1)
                return;
            //Check if is accessory
            
            foreach (UpgradeScroll us in _scrolls.Values)
            {
                UpgradeRow r;
                Rate sr = us.Rates[0];
                if (us.Type == UpgradeScroll.UpgradeType.ELEMENT || us.Type == UpgradeScroll.UpgradeType.ACCESSORYCOMPOUND)
                {
                    if (i.isAccessory)
                        r = new UpgradeRow(CURRENT_ACCESSORY_INDEX++, (id - i.ID), "Unique Accessory Elemental Unlock", sr.Cost, "(+" + sr.Grade + " -> +" + (sr.Grade + 1) + ")", i.Extension);
                    else
                        r = new UpgradeRow(CURRENT_WEAPON_INDEX++, (id - i.ID), "Unique Weapon Elemental Unlock", sr.Cost, "(+" + sr.Grade + " -> +" + (sr.Grade + 1) + ")", i.Extension);

                    r.RequiredItems[0] = us.ID;
                    r.Item = i.ExtensionID;
                    r.Percent = us.Rates[0].Percent;
                    upgradeRows.Add(r.Index, r);
                }

                if (us.Type == UpgradeScroll.UpgradeType.REGULAR || us.Type == UpgradeScroll.UpgradeType.ACCESSORYCOMPOUND)
                {
                    for (int c = 1; c < 11; c++)
                    {
                        sr = us.Rates[c];
                        if(i.isAccessory && us.Accessory)
                            r = new UpgradeRow(CURRENT_ACCESSORY_INDEX++, us.Modifier, "Unique Accessory Upgrade (" + i.Name.Replace("'", "''") + ")", sr.Cost, "(+" + sr.Grade + " -> +" + (sr.Grade + 1) + ")", i.Extension);
                        else
                            r = new UpgradeRow(CURRENT_WEAPON_INDEX++, us.Modifier, "Unique Weapon Upgrade (" + i.Name.Replace("'", "''") + ")", sr.Cost, "(+" + sr.Grade + " -> +" + (sr.Grade + 1) + ")", i.Extension);
                        r.RequiredItems[0] = us.ID;
                         
                        r.Item = (_items[id].ExtensionID+(c-1));
                        r.Percent = us.Rates[c].Percent;
                        upgradeRows.Add(r.Index, r);

                        if (us.Grade == UpgradeScroll.GradeLevel.BLESSED)
                        {
                            r = r.Clone();
                            if (i.isAccessory)
                                r.Index = CURRENT_ACCESSORY_INDEX++;
                            else
                                r.Index = CURRENT_WEAPON_INDEX++;

                            r.Item = (_items[id].ExtensionID + (c - 1));
                            r.RequiredItems[0] = TRINA_ID;
                            r.RequiredItems[1] = us.ID;
                            r.Percent = us.Rates[c].TrinaPercent;
                            upgradeRows.Add(r.Index, r);
                        }

                    }
                }

            }
        }

        private int getUnlockedID(Item i)
        {
            foreach(Item it in _items.Values)
            {
                if (it.UniqueID != i.UniqueID || it.UniqueID == 0)
                    continue;

                if (it.Name.Contains("(+1)"))
                    return it.ID;
            }

            return -1;
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            btnDump.Enabled = false;
            setGenerics();
            foreach(Item i in (_items.Values))
            {
                if (i.Extension == 22)
                    continue;
                if (i.Name.Contains("+"))
                    continue;

                switch (i.Type)
                {
                    case 4:
                        addUniqueUpgrade(i); 
                        break;
                    case 5:
                        break;
                    default:
                        continue;
                }
            }
            dumpToSQL();
            btnDump.Enabled = true;
        }

        #region Generic Item Upgrades
        private void setGenericItemUpgrades(UpgradeScroll s, int i)
        {
            for (int c = s.Grade == UpgradeScroll.GradeLevel.BLESSED ? 0 : 1; c < 2; c++)
            {
                Rate sr = s.Rates[i];
                UpgradeRow r;
                switch (s.Type)
                {
                    case UpgradeScroll.UpgradeType.REGULAR:
                        #region Generic Item Upgrades

                        string[] weaponUpgradeNames = { "", "Reduce", "Poison" };
                        int[] weaponUpgradeIDs = { 0, 30, 40 };
                        for (int n = 0; n < weaponUpgradeNames.Length; n++)
                        {
                            r = new UpgradeRow(CURRENT_WEAPON_INDEX++, s.Modifier, "Generic Weapon Upgrade" + (weaponUpgradeNames[n].Length > 0 ? " (" + weaponUpgradeNames[n] + ")" : ""), sr.Cost, "(+" + sr.Grade + " -> +" + (sr.Grade + 1) + ")");
                            if (c == 0)
                            {
                                r.RequiredItems[0] = TRINA_ID;
                                r.RequiredItems[1] = s.ID;
                            }
                            else
                                r.RequiredItems[0] = s.ID;

                            r.Item = weaponUpgradeIDs[n] + sr.Grade;
                            r.Percent = c == 0 ? sr.TrinaPercent : sr.Percent;
                            upgradeRows.Add(r.Index, r);
                        }

                        string[] armorUpgradeNames = { "", "Strength", "Intelligence", "Magic Power", "Health", "Dexterity", "Intelligence", "Magic Power" };
                        int[] armorUpgradeIDs = { 0, 10, 20, 30, 500, 510, 520, 530 };

                        for (int n = 0; n < armorUpgradeNames.Length; n++)
                        {
                            r = new UpgradeRow(CURRENT_ARMOR_INDEX++, s.Modifier, "Generic Armor Upgrade" + (armorUpgradeNames[n].Length > 0 ? " (" + armorUpgradeNames[n] + ")" : ""), sr.Cost, "(+" + sr.Grade + " -> +" + (sr.Grade + 1) + ")");
                            if (c == 0)
                            {
                                r.RequiredItems[0] = TRINA_ID;
                                r.RequiredItems[1] = s.ID;
                            }
                            else
                                r.RequiredItems[0] = s.ID;
                            r.Item = i + armorUpgradeIDs[n];
                            r.Percent = c == 0 ? sr.TrinaPercent : sr.Percent;
                            upgradeRows.Add(r.Index, r);
                            r = r.Clone();
                            r.Index = CURRENT_HIGHARMOR_INDEX++;
                            upgradeRows.Add(r.Index, r);
                        }
                        #endregion
                        break;
                    case UpgradeScroll.UpgradeType.ACCESSORYCOMPOUND:
                        #region Generic Accessories
                        int[] arr = { 0, 10, 20, 30, 70 };
                        int[] arr2 = { 500, 510, 520, 530, 550, 560, 570, 580, 600, 610, 620, 630, 650, 660, 670, 680, 700, 710, 720, 730 };
                        for (int n = 0; n < arr.Length; n++)
                        {
                            r = new UpgradeRow(CURRENT_ACCESSORY_INDEX++, s.Modifier, "Generic Accessory Upgrade", sr.Cost, "(+" + sr.Grade + " -> +" + (sr.Grade + 1) + ")");
                            r.Item = i + arr[n];
                            r.Percent = sr.Percent;
                            r.RequiredItems[0] = s.ID;
                            upgradeRows.Add(r.Index, r);
                        }

                        sr = s.Rates[i + 10];

                        for (int n = 0; n < arr2.Length; n++)
                        {
                            r = new UpgradeRow(CURRENT_ACCESSORY_INDEX++, s.Modifier, "Generic Accessory Upgrade", sr.Cost, "(+" + sr.Grade + " -> +" + (sr.Grade + 1) + ")");
                            r.Item = i + arr2[n];
                            r.Percent = sr.Percent;
                            r.RequiredItems[0] = s.ID;
                            upgradeRows.Add(r.Index, r);
                        }
                        #endregion 
                        break;
                    case UpgradeScroll.UpgradeType.ACCESSORYENCHANT:
                    #region Accessory Enchants
                    Dictionary<int, int> items = new Dictionary<int, int>();
                    switch (s.ID)
                    {
                        case 379160000:
                            items.Add(20, 531);
                            items.Add(30, 571);
                            items.Add(40, 611);
                            items.Add(80, 621);
                            break;
                        case 379161000:
                            items.Add(10, 491);
                            items.Add(30, 581);
                            items.Add(40, 621);
                            items.Add(80, 631);
                            break;
                        case 379162000:
                            items.Add(10, 491);
                            items.Add(30, 581);
                            items.Add(40, 621);
                            items.Add(80, 631);
                            break;
                        case 379163000:
                            items.Add(10, 491);
                            items.Add(30, 581);
                            items.Add(40, 621);
                            items.Add(80, 631);
                            break;
                        case 379164000:
                            items.Add(10, 521);
                            items.Add(20, 561);
                            items.Add(30, 601);
                            items.Add(40, 641);
                            break;
                    }
                    foreach (KeyValuePair<int, int> kvp in items)
                    {
                        r = new UpgradeRow() { Index = CURRENT_ACCESSORY_INDEX++, Item = kvp.Key, Percent = sr.Percent, Modifier = kvp.Value, Name = "Generic Accessory Upgrade", Note = "(+" + sr.Grade + " -> +" + (sr.Grade + 1) + ")", Cost = sr.Cost, Extension = -1 };
                        r.RequiredItems[0] = s.ID;
                        upgradeRows.Add(r.Index, r);
                    }
                    #endregion
                        break;
                }
            }
        }
        #endregion 

        private void setGenerics()
        {
            CURRENT_WEAPON_INDEX = WEAPON_INDEX;
            CURRENT_ARMOR_INDEX = ARMOR_INDEX;
            CURRENT_HIGHARMOR_INDEX = HIGH_ARMOR_INDEX;
            CURRENT_ACCESSORY_INDEX = ACCESSORY_INDEX;

            upgradeRows.Clear();

            foreach(UpgradeScroll s in _scrolls.Values)
            {

                if (s.Type == UpgradeScroll.UpgradeType.REGULAR || s.Type == UpgradeScroll.UpgradeType.ACCESSORYCOMPOUND || s.Type == UpgradeScroll.UpgradeType.ACCESSORYENCHANT)
                {
                    for (int i = 1; i < 11; i++)
                        setGenericItemUpgrades(s, i);
                }
                else
                {
                    
                    for (int i = 1; i < 11; i++)
                    {

                        Rate sr = s.Rates[i];
                        UpgradeRow r = new UpgradeRow();
                        if (s.Weapon)
                            r = new UpgradeRow(CURRENT_WEAPON_INDEX++, s.Modifier, "Generic Weapon Alteration", sr.Cost);
                        else if (s.Armor)
                            r = new UpgradeRow(CURRENT_ARMOR_INDEX++, s.Modifier, "Generic Armor Alteration", sr.Cost);

                        r.RequiredItems[0] = s.ID;
                        r.Item = i;
                        r.Percent = sr.Percent;
                        upgradeRows.Add(r.Index, r);
                    }
                }


            }
        }

        private void loadItems()
        {
            /*
             * select distinct Num, Ext, strName, Damage, Ac, ReqLevel,  DaggerAc, SwordAc, MaceAc, AxeAc, SpearAc, BowAc, FireDamage, IceDamage, LightningDamage, PoisonDamage, HPDrain, MPDamage, 
                      MPDrain, MirrorDamage, Droprate, StrB, StaB, DexB, IntelB, ChaB, MaxHpB, MaxMpB, FireR, ColdR, LightningR, MagicR, PoisonR, CurseR, ItemType, slot, uniqueid
                      from ITEM order by Num 
             * 
             */
            int x = 1, id;
            string str;
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader("items.txt"))
                {
                    while ((str = reader.ReadLine()) != null)
                    {
                        string[] strArray = str.Split(new char[] { '\t' });

                        if (strArray.Length != 37)
                        {
                            MessageBox.Show("Line " + x + " of items.txt is invalid. Should contain a total of 37 columns, instead has " + strArray.Length + " columns.");
                            Application.Exit();
                            return;
                        }

                        x++;
                        id = int.Parse(strArray[0]);

                        if (!_items.ContainsKey(id))
                        {
                            Item newItem = new Item(id, strArray[2]);
                            if (strArray[1] != "NULL")
                                newItem.Extension = int.Parse(strArray[1]);
                            else
                                newItem.Extension = -1;

                            newItem.Damage = int.Parse(strArray[3]);
                            newItem.Defense = int.Parse(strArray[4]);
                            newItem.RequiredLevel = int.Parse(strArray[5]);
                            newItem.DaggerAC = int.Parse(strArray[6]);
                            newItem.SwordAC = int.Parse(strArray[7]);
                            newItem.MaceAC = int.Parse(strArray[8]);
                            newItem.AxeAC = int.Parse(strArray[9]);
                            newItem.SpearAC = int.Parse(strArray[10]);
                            newItem.BowAC = int.Parse(strArray[11]);
                            newItem.FireDamage = int.Parse(strArray[12]);
                            newItem.IceDamage = int.Parse(strArray[13]);
                            newItem.LightDamage = int.Parse(strArray[14]);
                            newItem.PoisonDamage = int.Parse(strArray[15]);
                            newItem.HPDrain = int.Parse(strArray[16]);
                            newItem.MPDamage = int.Parse(strArray[17]);
                            newItem.MPDrain = int.Parse(strArray[18]);
                            newItem.MirrorDamage = int.Parse(strArray[19]);
                            newItem.Grade = int.Parse(strArray[20]);
                            newItem.Strength = int.Parse(strArray[21]);
                            newItem.Health = int.Parse(strArray[22]);
                            newItem.Dexterity = int.Parse(strArray[23]);
                            newItem.Intelligence = int.Parse(strArray[24]);
                            newItem.MagicPower = int.Parse(strArray[25]);
                            newItem.MaxHealth = int.Parse(strArray[26]);
                            newItem.MaxMana = int.Parse(strArray[27]);
                            newItem.FireResist = int.Parse(strArray[28]);
                            newItem.IceResist = int.Parse(strArray[29]);
                            newItem.LightResist = int.Parse(strArray[30]);
                            newItem.MagicResist = int.Parse(strArray[31]);
                            newItem.PoisonResist = int.Parse(strArray[32]);
                            newItem.CurseResist = int.Parse(strArray[33]);
                            newItem.Type = int.Parse(strArray[34]);
                            newItem.Slot = int.Parse(strArray[35]);
                            newItem.UniqueID = int.Parse(strArray[36]);

                            _items.Add(id, newItem);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading items.txt - " + ex.Message);
            }
        }

        // update current entry
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int newCost, newPercent, newModifier, newTrinaPercent = 0, selectedIndex;
            selectedIndex = lbGrades.SelectedIndex;
            try
            {
                newCost = int.Parse(txtCost.Text);
                newPercent = int.Parse(txtPercent.Text);
                newModifier = int.Parse(txtModifier.Text);
                newTrinaPercent = gradeLevel == UpgradeScroll.GradeLevel.BLESSED ? int.Parse(txtTrinaPercent.Text) : 0;
            }
            catch
            {
                MessageBox.Show("Cost and Percent must be valid integers (Cost 0 - 2100000000; Percent 0 - 10000)", "Invalid data");
                return;
            }

            if (newPercent > 10000 || newPercent < 0)
                newPercent = 0;

            if (newCost < 0)
                newCost = 0;

            UpgradeScroll s = _scrolls[((UpgradeScroll)lbScrolls.SelectedItem).ID];
            s.Armor = cbArmor.Checked;
            s.Weapon = cbWeapon.Checked;
            s.Accessory = cbAccessory.Checked;
            if (s.Accessory && s.Rates.Count < 21)
            {
                for (int i = 1; s.Rates.Count < 21; i++)
                {
                    s.Rates.Add(new Rate() { Cost = 0, Grade = i+10, Percent = 10000 });
                }
            }

            if (!s.Accessory && s.Rates.Count > 11)
            {
                while(s.Rates.Count > 11)
                {
                    s.Rates.RemoveAt(s.Rates.Count - 1);
                }
            }
            s.Type = type;
            s.Grade = gradeLevel;
            s.Modifier = newModifier;
            s.Rates[lbGrades.SelectedIndex].Cost = newCost;
            s.Rates[lbGrades.SelectedIndex].Percent = newPercent;
            s.Rates[lbGrades.SelectedIndex].TrinaPercent = newTrinaPercent;

            
            lbScrolls.Items[lbScrolls.SelectedIndex] = s;
            lbGrades.SelectedIndex = selectedIndex;
        }

        // save scrolls and their rates
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveScrolls();
        }

        private void saveScrolls()
        {
            Stream stream = File.Open("scrolls.ob", FileMode.Create);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bformatter.Serialize(stream, _scrolls);
            stream.Close();
        }


        private void loadScrolls()
        {
            try
            {
                Stream stream = File.Open("scrolls.ob", FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                _scrolls = (Dictionary<int, UpgradeScroll>)bformatter.Deserialize(stream);
                stream.Close();
                setScrollsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem reading scrolls.ob - " + ex.Message + ex.StackTrace,"Upgrade Editor");
            }
        }

        private void setScrollsList()
        {
            lbScrolls.Items.Clear();
            lbGrades.Items.Clear();

            foreach (UpgradeScroll s in _scrolls.Values)
                lbScrolls.Items.Add(s);

            if (lbScrolls.Items.Count > 0)
                lbScrolls.SelectedIndex = 0;
        }

        private void rbGrade_CheckedChanged(object sender, EventArgs e)
        {
            gradeLevel = (UpgradeScroll.GradeLevel)Enum.Parse(typeof(UpgradeScroll.GradeLevel), ((string)((RadioButton)sender).Tag));

            if (gradeLevel == UpgradeScroll.GradeLevel.BLESSED)
            {
                txtTrinaPercent.Visible = true;
                lblTrinaPercent.Visible = true;
            }
            else
            {
                txtTrinaPercent.Visible = false;
                lblTrinaPercent.Visible = false;
            }
        }

        private void rbType_CheckedChanged(object sender, EventArgs e)
        {
            type = (UpgradeScroll.UpgradeType)Enum.Parse(typeof(UpgradeScroll.UpgradeType), ((string)((RadioButton)sender).Tag));
        }

        private void dumpToSQL()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("sqldump.txt");
            file.WriteLine("TRUNCATE TABLE ITEM_UPGRADE");
            foreach (UpgradeRow r in upgradeRows.Values)
            {
                file.WriteLine(r.toInsert());
            }

            file.Close();
        }


        /*
         * 
         * nIndex, nNPCNum, strName, strNote, nOriginType, nOriginItem, nReqItem1, nReqItem2, nReqItem3, nReqItem4, nReqItem5, nReqItem6, 
                      nReqItem7, nReqItem8, nReqNoah, bRateType, nGenRate, nGiveItem

         * 
         */
    }
}
