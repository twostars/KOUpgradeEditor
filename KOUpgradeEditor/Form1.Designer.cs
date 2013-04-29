namespace KOUpgradeEditor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbScrolls = new System.Windows.Forms.ListBox();
            this.txtScrollID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmsScrollList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTrinaPercent = new System.Windows.Forms.TextBox();
            this.txtModifier = new System.Windows.Forms.TextBox();
            this.lblSelectedScroll = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTrinaPercent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rbDispell = new System.Windows.Forms.RadioButton();
            this.rbAccessoryEnchant = new System.Windows.Forms.RadioButton();
            this.rbAccessoryCompound = new System.Windows.Forms.RadioButton();
            this.rbStat = new System.Windows.Forms.RadioButton();
            this.rbElemental = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.gbGrade = new System.Windows.Forms.GroupBox();
            this.rbLow = new System.Windows.Forms.RadioButton();
            this.rbMiddle = new System.Windows.Forms.RadioButton();
            this.rbHigh = new System.Windows.Forms.RadioButton();
            this.rbBlessed = new System.Windows.Forms.RadioButton();
            this.lbGrades = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
            this.cbWeapon = new System.Windows.Forms.CheckBox();
            this.cbArmor = new System.Windows.Forms.CheckBox();
            this.cbAccessory = new System.Windows.Forms.CheckBox();
            this.cmsScrollList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbType.SuspendLayout();
            this.gbGrade.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbScrolls
            // 
            this.lbScrolls.FormattingEnabled = true;
            this.lbScrolls.Location = new System.Drawing.Point(12, 12);
            this.lbScrolls.Name = "lbScrolls";
            this.lbScrolls.Size = new System.Drawing.Size(120, 212);
            this.lbScrolls.TabIndex = 1;
            this.lbScrolls.SelectedIndexChanged += new System.EventHandler(this.lbScrolls_SelectedIndexChanged);
            this.lbScrolls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbScrolls_MouseDown);
            // 
            // txtScrollID
            // 
            this.txtScrollID.Location = new System.Drawing.Point(12, 230);
            this.txtScrollID.Name = "txtScrollID";
            this.txtScrollID.Size = new System.Drawing.Size(120, 20);
            this.txtScrollID.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(138, 230);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmsScrollList
            // 
            this.cmsScrollList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.cmsScrollList.Name = "cmsScrollList";
            this.cmsScrollList.Size = new System.Drawing.Size(114, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAccessory);
            this.groupBox1.Controls.Add(this.cbArmor);
            this.groupBox1.Controls.Add(this.cbWeapon);
            this.groupBox1.Controls.Add(this.txtTrinaPercent);
            this.groupBox1.Controls.Add(this.txtModifier);
            this.groupBox1.Controls.Add(this.lblSelectedScroll);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTrinaPercent);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.txtPercent);
            this.groupBox1.Controls.Add(this.gbType);
            this.groupBox1.Controls.Add(this.gbGrade);
            this.groupBox1.Controls.Add(this.lbGrades);
            this.groupBox1.Location = new System.Drawing.Point(138, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 212);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // txtTrinaPercent
            // 
            this.txtTrinaPercent.Location = new System.Drawing.Point(134, 164);
            this.txtTrinaPercent.Name = "txtTrinaPercent";
            this.txtTrinaPercent.Size = new System.Drawing.Size(78, 20);
            this.txtTrinaPercent.TabIndex = 9;
            this.txtTrinaPercent.Visible = false;
            // 
            // txtModifier
            // 
            this.txtModifier.Location = new System.Drawing.Point(134, 125);
            this.txtModifier.Name = "txtModifier";
            this.txtModifier.Size = new System.Drawing.Size(78, 20);
            this.txtModifier.TabIndex = 8;
            // 
            // lblSelectedScroll
            // 
            this.lblSelectedScroll.AutoSize = true;
            this.lblSelectedScroll.Location = new System.Drawing.Point(132, 192);
            this.lblSelectedScroll.Name = "lblSelectedScroll";
            this.lblSelectedScroll.Size = new System.Drawing.Size(78, 13);
            this.lblSelectedScroll.TabIndex = 7;
            this.lblSelectedScroll.Text = "Selected Scroll";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Modifier";
            // 
            // lblTrinaPercent
            // 
            this.lblTrinaPercent.AutoSize = true;
            this.lblTrinaPercent.Location = new System.Drawing.Point(132, 148);
            this.lblTrinaPercent.Name = "lblTrinaPercent";
            this.lblTrinaPercent.Size = new System.Drawing.Size(71, 13);
            this.lblTrinaPercent.TabIndex = 5;
            this.lblTrinaPercent.Text = "Trina Percent";
            this.lblTrinaPercent.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Percent";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(135, 85);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(78, 20);
            this.txtCost.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(322, 150);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(135, 39);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(78, 20);
            this.txtPercent.TabIndex = 3;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rbDispell);
            this.gbType.Controls.Add(this.rbAccessoryEnchant);
            this.gbType.Controls.Add(this.rbAccessoryCompound);
            this.gbType.Controls.Add(this.rbStat);
            this.gbType.Controls.Add(this.rbElemental);
            this.gbType.Controls.Add(this.rbNormal);
            this.gbType.Location = new System.Drawing.Point(222, 19);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(94, 164);
            this.gbType.TabIndex = 2;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type";
            // 
            // rbDispell
            // 
            this.rbDispell.AutoSize = true;
            this.rbDispell.Location = new System.Drawing.Point(7, 88);
            this.rbDispell.Name = "rbDispell";
            this.rbDispell.Size = new System.Drawing.Size(56, 17);
            this.rbDispell.TabIndex = 4;
            this.rbDispell.TabStop = true;
            this.rbDispell.Tag = "DISPELL";
            this.rbDispell.Text = "Dispell";
            this.rbDispell.UseVisualStyleBackColor = true;
            this.rbDispell.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbAccessoryEnchant
            // 
            this.rbAccessoryEnchant.AutoSize = true;
            this.rbAccessoryEnchant.Location = new System.Drawing.Point(6, 134);
            this.rbAccessoryEnchant.Name = "rbAccessoryEnchant";
            this.rbAccessoryEnchant.Size = new System.Drawing.Size(78, 17);
            this.rbAccessoryEnchant.TabIndex = 3;
            this.rbAccessoryEnchant.TabStop = true;
            this.rbAccessoryEnchant.Tag = "ACCESSORYENCHANT";
            this.rbAccessoryEnchant.Text = "A. Enchant";
            this.rbAccessoryEnchant.UseVisualStyleBackColor = true;
            this.rbAccessoryEnchant.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbAccessoryCompound
            // 
            this.rbAccessoryCompound.AutoSize = true;
            this.rbAccessoryCompound.Location = new System.Drawing.Point(6, 111);
            this.rbAccessoryCompound.Name = "rbAccessoryCompound";
            this.rbAccessoryCompound.Size = new System.Drawing.Size(76, 17);
            this.rbAccessoryCompound.TabIndex = 3;
            this.rbAccessoryCompound.TabStop = true;
            this.rbAccessoryCompound.Tag = "ACCESSORYCOMPOUND";
            this.rbAccessoryCompound.Text = "Compound";
            this.rbAccessoryCompound.UseVisualStyleBackColor = true;
            this.rbAccessoryCompound.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbStat
            // 
            this.rbStat.AutoSize = true;
            this.rbStat.Location = new System.Drawing.Point(7, 65);
            this.rbStat.Name = "rbStat";
            this.rbStat.Size = new System.Drawing.Size(65, 17);
            this.rbStat.TabIndex = 2;
            this.rbStat.TabStop = true;
            this.rbStat.Tag = "STAT";
            this.rbStat.Text = "Enchant";
            this.rbStat.UseVisualStyleBackColor = true;
            this.rbStat.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbElemental
            // 
            this.rbElemental.AutoSize = true;
            this.rbElemental.Location = new System.Drawing.Point(6, 42);
            this.rbElemental.Name = "rbElemental";
            this.rbElemental.Size = new System.Drawing.Size(71, 17);
            this.rbElemental.TabIndex = 1;
            this.rbElemental.TabStop = true;
            this.rbElemental.Tag = "ELEMENT";
            this.rbElemental.Text = "Elemental";
            this.rbElemental.UseVisualStyleBackColor = true;
            this.rbElemental.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(7, 19);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(58, 17);
            this.rbNormal.TabIndex = 0;
            this.rbNormal.TabStop = true;
            this.rbNormal.Tag = "REGULAR";
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // gbGrade
            // 
            this.gbGrade.Controls.Add(this.rbLow);
            this.gbGrade.Controls.Add(this.rbMiddle);
            this.gbGrade.Controls.Add(this.rbHigh);
            this.gbGrade.Controls.Add(this.rbBlessed);
            this.gbGrade.Location = new System.Drawing.Point(322, 19);
            this.gbGrade.Name = "gbGrade";
            this.gbGrade.Size = new System.Drawing.Size(79, 121);
            this.gbGrade.TabIndex = 1;
            this.gbGrade.TabStop = false;
            this.gbGrade.Text = "Scroll Grade";
            // 
            // rbLow
            // 
            this.rbLow.AutoSize = true;
            this.rbLow.Location = new System.Drawing.Point(7, 97);
            this.rbLow.Name = "rbLow";
            this.rbLow.Size = new System.Drawing.Size(45, 17);
            this.rbLow.TabIndex = 3;
            this.rbLow.TabStop = true;
            this.rbLow.Tag = "LOW";
            this.rbLow.Text = "Low";
            this.rbLow.UseVisualStyleBackColor = true;
            this.rbLow.CheckedChanged += new System.EventHandler(this.rbGrade_CheckedChanged);
            // 
            // rbMiddle
            // 
            this.rbMiddle.AutoSize = true;
            this.rbMiddle.Location = new System.Drawing.Point(7, 73);
            this.rbMiddle.Name = "rbMiddle";
            this.rbMiddle.Size = new System.Drawing.Size(56, 17);
            this.rbMiddle.TabIndex = 2;
            this.rbMiddle.TabStop = true;
            this.rbMiddle.Tag = "MIDDLE";
            this.rbMiddle.Text = "Middle";
            this.rbMiddle.UseVisualStyleBackColor = true;
            this.rbMiddle.CheckedChanged += new System.EventHandler(this.rbGrade_CheckedChanged);
            // 
            // rbHigh
            // 
            this.rbHigh.AutoSize = true;
            this.rbHigh.Location = new System.Drawing.Point(7, 49);
            this.rbHigh.Name = "rbHigh";
            this.rbHigh.Size = new System.Drawing.Size(47, 17);
            this.rbHigh.TabIndex = 1;
            this.rbHigh.TabStop = true;
            this.rbHigh.Tag = "HIGH";
            this.rbHigh.Text = "High";
            this.rbHigh.UseVisualStyleBackColor = true;
            this.rbHigh.CheckedChanged += new System.EventHandler(this.rbGrade_CheckedChanged);
            // 
            // rbBlessed
            // 
            this.rbBlessed.AutoSize = true;
            this.rbBlessed.Location = new System.Drawing.Point(7, 25);
            this.rbBlessed.Name = "rbBlessed";
            this.rbBlessed.Size = new System.Drawing.Size(62, 17);
            this.rbBlessed.TabIndex = 0;
            this.rbBlessed.TabStop = true;
            this.rbBlessed.Tag = "BLESSED";
            this.rbBlessed.Text = "Blessed";
            this.rbBlessed.UseVisualStyleBackColor = true;
            this.rbBlessed.CheckedChanged += new System.EventHandler(this.rbGrade_CheckedChanged);
            // 
            // lbGrades
            // 
            this.lbGrades.FormattingEnabled = true;
            this.lbGrades.Location = new System.Drawing.Point(6, 19);
            this.lbGrades.Name = "lbGrades";
            this.lbGrades.Size = new System.Drawing.Size(120, 186);
            this.lbGrades.TabIndex = 0;
            this.lbGrades.SelectedIndexChanged += new System.EventHandler(this.lbGrades_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(219, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDump
            // 
            this.btnDump.Location = new System.Drawing.Point(570, 227);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(78, 23);
            this.btnDump.TabIndex = 8;
            this.btnDump.Text = "Dump";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // cbWeapon
            // 
            this.cbWeapon.AutoSize = true;
            this.cbWeapon.Location = new System.Drawing.Point(407, 42);
            this.cbWeapon.Name = "cbWeapon";
            this.cbWeapon.Size = new System.Drawing.Size(67, 17);
            this.cbWeapon.TabIndex = 10;
            this.cbWeapon.Text = "Weapon";
            this.cbWeapon.UseVisualStyleBackColor = true;
            // 
            // cbArmor
            // 
            this.cbArmor.AutoSize = true;
            this.cbArmor.Location = new System.Drawing.Point(407, 69);
            this.cbArmor.Name = "cbArmor";
            this.cbArmor.Size = new System.Drawing.Size(53, 17);
            this.cbArmor.TabIndex = 11;
            this.cbArmor.Text = "Armor";
            this.cbArmor.UseVisualStyleBackColor = true;
            // 
            // cbAccessory
            // 
            this.cbAccessory.AutoSize = true;
            this.cbAccessory.Location = new System.Drawing.Point(407, 93);
            this.cbAccessory.Name = "cbAccessory";
            this.cbAccessory.Size = new System.Drawing.Size(75, 17);
            this.cbAccessory.TabIndex = 12;
            this.cbAccessory.Text = "Accessory";
            this.cbAccessory.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 260);
            this.Controls.Add(this.lbScrolls);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtScrollID);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "Upgrade Editor";
            this.cmsScrollList.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.gbGrade.ResumeLayout(false);
            this.gbGrade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbScrolls;
        private System.Windows.Forms.TextBox txtScrollID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip cmsScrollList;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbGrades;
        private System.Windows.Forms.GroupBox gbGrade;
        private System.Windows.Forms.RadioButton rbBlessed;
        private System.Windows.Forms.RadioButton rbHigh;
        private System.Windows.Forms.RadioButton rbMiddle;
        private System.Windows.Forms.RadioButton rbLow;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbStat;
        private System.Windows.Forms.RadioButton rbElemental;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.RadioButton rbAccessoryCompound;
        private System.Windows.Forms.RadioButton rbDispell;
        private System.Windows.Forms.RadioButton rbAccessoryEnchant;
        private System.Windows.Forms.Label lblSelectedScroll;
        private System.Windows.Forms.TextBox txtModifier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrinaPercent;
        private System.Windows.Forms.Label lblTrinaPercent;
        private System.Windows.Forms.CheckBox cbAccessory;
        private System.Windows.Forms.CheckBox cbArmor;
        private System.Windows.Forms.CheckBox cbWeapon;
    }
}

