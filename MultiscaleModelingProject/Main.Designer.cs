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
            ((System.ComponentModel.ISupportInitialize)(this.Board)).BeginInit();
            this.caGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caGrainsNumericUpDown)).BeginInit();
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
            this.caGroupBox.Location = new System.Drawing.Point(12, 12);
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
            this.caGrainsNumericUpDown.Name = "caGrainsNumericUpDown";
            this.caGrainsNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.caGrainsNumericUpDown.TabIndex = 2;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(575, 77);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SaveBitmap_Button
            // 
            this.SaveBitmap_Button.Location = new System.Drawing.Point(554, 12);
            this.SaveBitmap_Button.Name = "SaveBitmap_Button";
            this.SaveBitmap_Button.Size = new System.Drawing.Size(96, 23);
            this.SaveBitmap_Button.TabIndex = 9;
            this.SaveBitmap_Button.Text = "Save as bitmap";
            this.SaveBitmap_Button.UseVisualStyleBackColor = true;
            this.SaveBitmap_Button.Click += new System.EventHandler(this.SaveBitmap_Button_Click);
            // 
            // csvSaveButton
            // 
            this.csvSaveButton.Location = new System.Drawing.Point(554, 41);
            this.csvSaveButton.Name = "csvSaveButton";
            this.csvSaveButton.Size = new System.Drawing.Size(96, 23);
            this.csvSaveButton.TabIndex = 10;
            this.csvSaveButton.Text = "Save as csv";
            this.csvSaveButton.UseVisualStyleBackColor = true;
            this.csvSaveButton.Click += new System.EventHandler(this.csvSaveButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 624);
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
    }
}

