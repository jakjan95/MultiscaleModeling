namespace MultiscaleModelingProject
{
    partial class Main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Board = new System.Windows.Forms.PictureBox();
            this.caSimulateButton = new System.Windows.Forms.Button();
            this.caGroupBox = new System.Windows.Forms.GroupBox();
            this.caGrainsLabel = new System.Windows.Forms.Label();
            this.NextStep_Button = new System.Windows.Forms.Button();
            this.caNeighborHoodLabel = new System.Windows.Forms.Label();
            this.gridPeriodicCheckBox = new System.Windows.Forms.CheckBox();
            this.caNeighborhoodComboBox = new System.Windows.Forms.ComboBox();
            this.caAddRandomGrainsButton = new System.Windows.Forms.Button();
            this.caGrainsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SaveBitmap_Button = new System.Windows.Forms.Button();
            this.csvSaveButton = new System.Windows.Forms.Button();
            this.BoardWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BoardHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BoardWidthLabel = new System.Windows.Forms.Label();
            this.BoardHeightLabel = new System.Windows.Forms.Label();
            this.InclusionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.addInclusionButton = new System.Windows.Forms.Button();
            this.minRnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxRnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.inclusionMinRLabel = new System.Windows.Forms.Label();
            this.inclusionMaxRLabel = new System.Windows.Forms.Label();
            this.csvLoadButton = new System.Windows.Forms.Button();
            this.GBCgroupBox = new System.Windows.Forms.GroupBox();
            this.GBCnextStep = new System.Windows.Forms.Button();
            this.GBCnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GBCsimulate = new System.Windows.Forms.Button();
            this.GBClabel = new System.Windows.Forms.Label();
            this.InclusiongroupBox1 = new System.Windows.Forms.GroupBox();
            this.BoardgroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Board)).BeginInit();
            this.caGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caGrainsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InclusionsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRnumericUpDown)).BeginInit();
            this.GBCgroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GBCnumericUpDown)).BeginInit();
            this.InclusiongroupBox1.SuspendLayout();
            this.BoardgroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Board
            // 
            this.Board.BackColor = System.Drawing.Color.White;
            this.Board.Location = new System.Drawing.Point(56, 116);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(500, 500);
            this.Board.TabIndex = 0;
            this.Board.TabStop = false;
            this.Board.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            // 
            // caSimulateButton
            // 
            this.caSimulateButton.Location = new System.Drawing.Point(77, 75);
            this.caSimulateButton.Name = "caSimulateButton";
            this.caSimulateButton.Size = new System.Drawing.Size(75, 23);
            this.caSimulateButton.TabIndex = 1;
            this.caSimulateButton.Text = "Simulate";
            this.caSimulateButton.UseVisualStyleBackColor = true;
            this.caSimulateButton.Click += new System.EventHandler(this.caSimulateButton_Click);
            // 
            // caGroupBox
            // 
            this.caGroupBox.Controls.Add(this.caGrainsLabel);
            this.caGroupBox.Controls.Add(this.NextStep_Button);
            this.caGroupBox.Controls.Add(this.caNeighborHoodLabel);
            this.caGroupBox.Controls.Add(this.gridPeriodicCheckBox);
            this.caGroupBox.Controls.Add(this.caNeighborhoodComboBox);
            this.caGroupBox.Controls.Add(this.caAddRandomGrainsButton);
            this.caGroupBox.Controls.Add(this.caGrainsNumericUpDown);
            this.caGroupBox.Controls.Add(this.caSimulateButton);
            this.caGroupBox.Location = new System.Drawing.Point(96, 10);
            this.caGroupBox.Name = "caGroupBox";
            this.caGroupBox.Size = new System.Drawing.Size(254, 100);
            this.caGroupBox.TabIndex = 2;
            this.caGroupBox.TabStop = false;
            this.caGroupBox.Text = "Cellular Automaton";
            // 
            // caGrainsLabel
            // 
            this.caGrainsLabel.AutoSize = true;
            this.caGrainsLabel.Location = new System.Drawing.Point(41, 22);
            this.caGrainsLabel.Name = "caGrainsLabel";
            this.caGrainsLabel.Size = new System.Drawing.Size(37, 13);
            this.caGrainsLabel.TabIndex = 7;
            this.caGrainsLabel.Text = "Grains";
            // 
            // NextStep_Button
            // 
            this.NextStep_Button.Location = new System.Drawing.Point(157, 75);
            this.NextStep_Button.Name = "NextStep_Button";
            this.NextStep_Button.Size = new System.Drawing.Size(75, 23);
            this.NextStep_Button.TabIndex = 8;
            this.NextStep_Button.Text = "Next Step";
            this.NextStep_Button.UseVisualStyleBackColor = true;
            this.NextStep_Button.Click += new System.EventHandler(this.NextStep_Button_Click);
            // 
            // caNeighborHoodLabel
            // 
            this.caNeighborHoodLabel.AutoSize = true;
            this.caNeighborHoodLabel.Location = new System.Drawing.Point(4, 51);
            this.caNeighborHoodLabel.Name = "caNeighborHoodLabel";
            this.caNeighborHoodLabel.Size = new System.Drawing.Size(74, 13);
            this.caNeighborHoodLabel.TabIndex = 6;
            this.caNeighborHoodLabel.Text = "Neighborhood";
            // 
            // gridPeriodicCheckBox
            // 
            this.gridPeriodicCheckBox.AutoSize = true;
            this.gridPeriodicCheckBox.Checked = true;
            this.gridPeriodicCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridPeriodicCheckBox.Location = new System.Drawing.Point(7, 81);
            this.gridPeriodicCheckBox.Name = "gridPeriodicCheckBox";
            this.gridPeriodicCheckBox.Size = new System.Drawing.Size(64, 17);
            this.gridPeriodicCheckBox.TabIndex = 5;
            this.gridPeriodicCheckBox.Text = "Periodic";
            this.gridPeriodicCheckBox.UseVisualStyleBackColor = true;
            this.gridPeriodicCheckBox.CheckedChanged += new System.EventHandler(this.gridPeriodicCheckBox_CheckedChanged);
            // 
            // caNeighborhoodComboBox
            // 
            this.caNeighborhoodComboBox.FormattingEnabled = true;
            this.caNeighborhoodComboBox.Items.AddRange(new object[] {
            "Moore",
            "Von Neumann",
            "Left Pentagonal",
            "Right Pentagonal",
            "Left Hexagonal",
            "Right Hexagonal"});
            this.caNeighborhoodComboBox.Location = new System.Drawing.Point(84, 48);
            this.caNeighborhoodComboBox.Name = "caNeighborhoodComboBox";
            this.caNeighborhoodComboBox.Size = new System.Drawing.Size(148, 21);
            this.caNeighborhoodComboBox.TabIndex = 4;
            this.caNeighborhoodComboBox.SelectedIndexChanged += new System.EventHandler(this.caNeighborhoodComboBox_SelectedIndexChanged);
            // 
            // caAddRandomGrainsButton
            // 
            this.caAddRandomGrainsButton.Location = new System.Drawing.Point(146, 16);
            this.caAddRandomGrainsButton.Name = "caAddRandomGrainsButton";
            this.caAddRandomGrainsButton.Size = new System.Drawing.Size(86, 23);
            this.caAddRandomGrainsButton.TabIndex = 3;
            this.caAddRandomGrainsButton.Text = "Add Grains";
            this.caAddRandomGrainsButton.UseVisualStyleBackColor = true;
            this.caAddRandomGrainsButton.Click += new System.EventHandler(this.caAddRandomGrainsButton_Click);
            // 
            // caGrainsNumericUpDown
            // 
            this.caGrainsNumericUpDown.Location = new System.Drawing.Point(84, 19);
            this.caGrainsNumericUpDown.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.caGrainsNumericUpDown.Name = "caGrainsNumericUpDown";
            this.caGrainsNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.caGrainsNumericUpDown.TabIndex = 2;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(575, 196);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SaveBitmap_Button
            // 
            this.SaveBitmap_Button.Location = new System.Drawing.Point(562, 116);
            this.SaveBitmap_Button.Name = "SaveBitmap_Button";
            this.SaveBitmap_Button.Size = new System.Drawing.Size(96, 23);
            this.SaveBitmap_Button.TabIndex = 9;
            this.SaveBitmap_Button.Text = "Save as bitmap";
            this.SaveBitmap_Button.UseVisualStyleBackColor = true;
            this.SaveBitmap_Button.Click += new System.EventHandler(this.SaveBitmap_Button_Click);
            // 
            // csvSaveButton
            // 
            this.csvSaveButton.Location = new System.Drawing.Point(562, 142);
            this.csvSaveButton.Name = "csvSaveButton";
            this.csvSaveButton.Size = new System.Drawing.Size(96, 23);
            this.csvSaveButton.TabIndex = 10;
            this.csvSaveButton.Text = "Save as csv";
            this.csvSaveButton.UseVisualStyleBackColor = true;
            this.csvSaveButton.Click += new System.EventHandler(this.csvSaveButton_Click);
            // 
            // BoardWidthNumericUpDown
            // 
            this.BoardWidthNumericUpDown.Location = new System.Drawing.Point(36, 16);
            this.BoardWidthNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.BoardWidthNumericUpDown.Name = "BoardWidthNumericUpDown";
            this.BoardWidthNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.BoardWidthNumericUpDown.TabIndex = 9;
            this.BoardWidthNumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // BoardHeightNumericUpDown
            // 
            this.BoardHeightNumericUpDown.Location = new System.Drawing.Point(38, 55);
            this.BoardHeightNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.BoardHeightNumericUpDown.Name = "BoardHeightNumericUpDown";
            this.BoardHeightNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.BoardHeightNumericUpDown.TabIndex = 9;
            this.BoardHeightNumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // BoardWidthLabel
            // 
            this.BoardWidthLabel.AutoSize = true;
            this.BoardWidthLabel.Location = new System.Drawing.Point(3, 18);
            this.BoardWidthLabel.Name = "BoardWidthLabel";
            this.BoardWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.BoardWidthLabel.TabIndex = 9;
            this.BoardWidthLabel.Text = "Width";
            // 
            // BoardHeightLabel
            // 
            this.BoardHeightLabel.AutoSize = true;
            this.BoardHeightLabel.Location = new System.Drawing.Point(3, 57);
            this.BoardHeightLabel.Name = "BoardHeightLabel";
            this.BoardHeightLabel.Size = new System.Drawing.Size(38, 13);
            this.BoardHeightLabel.TabIndex = 11;
            this.BoardHeightLabel.Text = "Height";
            // 
            // InclusionsNumericUpDown
            // 
            this.InclusionsNumericUpDown.Location = new System.Drawing.Point(10, 19);
            this.InclusionsNumericUpDown.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.InclusionsNumericUpDown.Name = "InclusionsNumericUpDown";
            this.InclusionsNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.InclusionsNumericUpDown.TabIndex = 9;
            // 
            // addInclusionButton
            // 
            this.addInclusionButton.Location = new System.Drawing.Point(68, 16);
            this.addInclusionButton.Name = "addInclusionButton";
            this.addInclusionButton.Size = new System.Drawing.Size(59, 23);
            this.addInclusionButton.TabIndex = 9;
            this.addInclusionButton.Text = "Add";
            this.addInclusionButton.UseVisualStyleBackColor = true;
            this.addInclusionButton.Click += new System.EventHandler(this.addInclusionButton_Click);
            // 
            // minRnumericUpDown
            // 
            this.minRnumericUpDown.Location = new System.Drawing.Point(72, 43);
            this.minRnumericUpDown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.minRnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minRnumericUpDown.Name = "minRnumericUpDown";
            this.minRnumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.minRnumericUpDown.TabIndex = 12;
            this.minRnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // maxRnumericUpDown
            // 
            this.maxRnumericUpDown.Location = new System.Drawing.Point(72, 72);
            this.maxRnumericUpDown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.maxRnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRnumericUpDown.Name = "maxRnumericUpDown";
            this.maxRnumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.maxRnumericUpDown.TabIndex = 13;
            this.maxRnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inclusionMinRLabel
            // 
            this.inclusionMinRLabel.AutoSize = true;
            this.inclusionMinRLabel.Location = new System.Drawing.Point(7, 48);
            this.inclusionMinRLabel.Name = "inclusionMinRLabel";
            this.inclusionMinRLabel.Size = new System.Drawing.Size(56, 13);
            this.inclusionMinRLabel.TabIndex = 9;
            this.inclusionMinRLabel.Text = "Minimal R:";
            // 
            // inclusionMaxRLabel
            // 
            this.inclusionMaxRLabel.AutoSize = true;
            this.inclusionMaxRLabel.Location = new System.Drawing.Point(7, 76);
            this.inclusionMaxRLabel.Name = "inclusionMaxRLabel";
            this.inclusionMaxRLabel.Size = new System.Drawing.Size(59, 13);
            this.inclusionMaxRLabel.TabIndex = 14;
            this.inclusionMaxRLabel.Text = "Maximal R:";
            this.inclusionMaxRLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // csvLoadButton
            // 
            this.csvLoadButton.Location = new System.Drawing.Point(562, 167);
            this.csvLoadButton.Name = "csvLoadButton";
            this.csvLoadButton.Size = new System.Drawing.Size(96, 23);
            this.csvLoadButton.TabIndex = 15;
            this.csvLoadButton.Text = "Load from csv";
            this.csvLoadButton.UseVisualStyleBackColor = true;
            this.csvLoadButton.Click += new System.EventHandler(this.csvLoadButton_Click);
            // 
            // GBCgroupBox
            // 
            this.GBCgroupBox.Controls.Add(this.GBClabel);
            this.GBCgroupBox.Controls.Add(this.GBCnextStep);
            this.GBCgroupBox.Controls.Add(this.GBCnumericUpDown);
            this.GBCgroupBox.Controls.Add(this.GBCsimulate);
            this.GBCgroupBox.Location = new System.Drawing.Point(495, 17);
            this.GBCgroupBox.Name = "GBCgroupBox";
            this.GBCgroupBox.Size = new System.Drawing.Size(163, 88);
            this.GBCgroupBox.TabIndex = 16;
            this.GBCgroupBox.TabStop = false;
            this.GBCgroupBox.Text = "GBC";
            // 
            // GBCnextStep
            // 
            this.GBCnextStep.Location = new System.Drawing.Point(81, 40);
            this.GBCnextStep.Name = "GBCnextStep";
            this.GBCnextStep.Size = new System.Drawing.Size(75, 23);
            this.GBCnextStep.TabIndex = 8;
            this.GBCnextStep.Text = "Next Step";
            this.GBCnextStep.UseVisualStyleBackColor = true;
            this.GBCnextStep.Click += new System.EventHandler(this.GBCnextStep_Click);
            // 
            // GBCnumericUpDown
            // 
            this.GBCnumericUpDown.Location = new System.Drawing.Point(17, 32);
            this.GBCnumericUpDown.Name = "GBCnumericUpDown";
            this.GBCnumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.GBCnumericUpDown.TabIndex = 2;
            this.GBCnumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // GBCsimulate
            // 
            this.GBCsimulate.Location = new System.Drawing.Point(81, 11);
            this.GBCsimulate.Name = "GBCsimulate";
            this.GBCsimulate.Size = new System.Drawing.Size(75, 23);
            this.GBCsimulate.TabIndex = 1;
            this.GBCsimulate.Text = "Simulate";
            this.GBCsimulate.UseVisualStyleBackColor = true;
            this.GBCsimulate.Click += new System.EventHandler(this.GBCsimulate_Click);
            // 
            // GBClabel
            // 
            this.GBClabel.AutoSize = true;
            this.GBClabel.Location = new System.Drawing.Point(1, 16);
            this.GBClabel.Name = "GBClabel";
            this.GBClabel.Size = new System.Drawing.Size(72, 13);
            this.GBClabel.TabIndex = 9;
            this.GBClabel.Text = "Propability [%]";
            // 
            // InclusiongroupBox1
            // 
            this.InclusiongroupBox1.Controls.Add(this.InclusionsNumericUpDown);
            this.InclusiongroupBox1.Controls.Add(this.addInclusionButton);
            this.InclusiongroupBox1.Controls.Add(this.minRnumericUpDown);
            this.InclusiongroupBox1.Controls.Add(this.inclusionMaxRLabel);
            this.InclusiongroupBox1.Controls.Add(this.maxRnumericUpDown);
            this.InclusiongroupBox1.Controls.Add(this.inclusionMinRLabel);
            this.InclusiongroupBox1.Location = new System.Drawing.Point(356, 10);
            this.InclusiongroupBox1.Name = "InclusiongroupBox1";
            this.InclusiongroupBox1.Size = new System.Drawing.Size(133, 100);
            this.InclusiongroupBox1.TabIndex = 17;
            this.InclusiongroupBox1.TabStop = false;
            this.InclusiongroupBox1.Text = "Inclusions";
            // 
            // BoardgroupBox
            // 
            this.BoardgroupBox.Controls.Add(this.BoardHeightNumericUpDown);
            this.BoardgroupBox.Controls.Add(this.BoardWidthNumericUpDown);
            this.BoardgroupBox.Controls.Add(this.BoardWidthLabel);
            this.BoardgroupBox.Controls.Add(this.BoardHeightLabel);
            this.BoardgroupBox.Location = new System.Drawing.Point(4, 17);
            this.BoardgroupBox.Name = "BoardgroupBox";
            this.BoardgroupBox.Size = new System.Drawing.Size(90, 91);
            this.BoardgroupBox.TabIndex = 18;
            this.BoardgroupBox.TabStop = false;
            this.BoardgroupBox.Text = "Board";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 624);
            this.Controls.Add(this.BoardgroupBox);
            this.Controls.Add(this.InclusiongroupBox1);
            this.Controls.Add(this.GBCgroupBox);
            this.Controls.Add(this.csvLoadButton);
            this.Controls.Add(this.csvSaveButton);
            this.Controls.Add(this.SaveBitmap_Button);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.caGroupBox);
            this.Controls.Add(this.Board);
            this.Name = "Main";
            this.Text = "Grain growth";
            ((System.ComponentModel.ISupportInitialize)(this.Board)).EndInit();
            this.caGroupBox.ResumeLayout(false);
            this.caGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caGrainsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InclusionsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRnumericUpDown)).EndInit();
            this.GBCgroupBox.ResumeLayout(false);
            this.GBCgroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GBCnumericUpDown)).EndInit();
            this.InclusiongroupBox1.ResumeLayout(false);
            this.InclusiongroupBox1.PerformLayout();
            this.BoardgroupBox.ResumeLayout(false);
            this.BoardgroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Board;
        private System.Windows.Forms.Button caSimulateButton;
        private System.Windows.Forms.GroupBox caGroupBox;
        private System.Windows.Forms.Label caNeighborHoodLabel;
        private System.Windows.Forms.CheckBox gridPeriodicCheckBox;
        private System.Windows.Forms.ComboBox caNeighborhoodComboBox;
        private System.Windows.Forms.Button caAddRandomGrainsButton;
        private System.Windows.Forms.NumericUpDown caGrainsNumericUpDown;
        private System.Windows.Forms.Label caGrainsLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button NextStep_Button;
        private System.Windows.Forms.Button SaveBitmap_Button;
        private System.Windows.Forms.Button csvSaveButton;
        private System.Windows.Forms.NumericUpDown BoardWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown BoardHeightNumericUpDown;
        private System.Windows.Forms.Label BoardWidthLabel;
        private System.Windows.Forms.Label BoardHeightLabel;
        private System.Windows.Forms.NumericUpDown InclusionsNumericUpDown;
        private System.Windows.Forms.Button addInclusionButton;
        private System.Windows.Forms.NumericUpDown minRnumericUpDown;
        private System.Windows.Forms.NumericUpDown maxRnumericUpDown;
        private System.Windows.Forms.Label inclusionMinRLabel;
        private System.Windows.Forms.Label inclusionMaxRLabel;
        private System.Windows.Forms.Button csvLoadButton;
        private System.Windows.Forms.GroupBox GBCgroupBox;
        private System.Windows.Forms.Label GBClabel;
        private System.Windows.Forms.Button GBCnextStep;
        private System.Windows.Forms.NumericUpDown GBCnumericUpDown;
        private System.Windows.Forms.Button GBCsimulate;
        private System.Windows.Forms.GroupBox InclusiongroupBox1;
        private System.Windows.Forms.GroupBox BoardgroupBox;
    }
}

