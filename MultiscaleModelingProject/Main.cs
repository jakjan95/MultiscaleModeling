﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Drawing.Imaging;

namespace MultiscaleModelingProject
{
    public partial class Main : Form
    {
        #region Properties
        private int GridWidth = 500;
        private int GridHeight = 500;

        private bool GridPeriodic
        {
            get { return this.gridPeriodicCheckBox.Checked; }
        }

        private int CAGrains
        {
            get { return (int)this.caGrainsNumericUpDown.Value; }
        }

        #endregion Properties

        private Grid grid;
        private AlgorithmCA ca;
        private List<Brush> brushes;


        //Storing all UI stateButtons
        private Dictionary<Button, EventsOfButton> stateButtons;
        private Button activeStateButton = null;


        public Main()
        {
            this.ca = new AlgorithmCA();

            InitializeComponent();
            this.SetupUI();
            this.SetupBrushes();
            this.SetupGrid();


        }
        /// <summary>
        /// whatever
        /// </summary>
        private void SetupUI()
        {
            this.caNeighborhoodComboBox.SelectedIndex = 0;
        }

        private void SetupGrid()
        {
            this.grid = new Grid(this.GridWidth, this.GridHeight, this.GridPeriodic);
            this.ca.Grid = this.grid;
            this.SetupBoard();
        }

        private void SetupBoard()
        {
            this.Board.Width = this.GridWidth;
            this.Board.Height = this.GridHeight;
            this.Board.Refresh();
        }

        private void SetupBrushes()
        {
            this.brushes = new List<Brush>();

            foreach(PropertyInfo pf in typeof (Brushes).GetProperties())
            {
                this.brushes.Add(pf.GetValue(null, null) as Brush);
            }
        }

        private void Board_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            for (int y = 0; y < this.grid.Height; ++y)
            {
                for (int x = 0; x < this.grid.Width; ++x)
                {
                    Cell c = this.grid.GetCell(x, y);
                    if (c.ID != 0)
                    {
                        e.Graphics.FillRectangle((c.Selected) ? Brushes.Red : this.brushes[c.ID], x, y, 1, 1);
                    }
                }
            }
        }


        //
        //



        private void caAddRandomGrainsButton_Click(object sender, EventArgs e)
        {
            this.ca.AddRandomGrains(this.CAGrains);
            this.Board.Refresh();
        }

        private void caSimulateButton_Click(object sender, EventArgs e)
        {
            var name = caNeighborhoodComboBox.SelectedItem.ToString();
            ca.Start(name, Board);
        }

        private void caNeighborhoodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.SetupGrid();
            this.SetupBoard();
        }

        private void NextStep_Button_Click(object sender, EventArgs e)
        {
            var name = caNeighborhoodComboBox.SelectedItem.ToString();
            ca.NextStep(name, Board);
        }

        private void SaveBitmap_Button_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Board.ClientSize.Width, Board.ClientSize.Height);
            Board.DrawToBitmap(bmp, Board.ClientRectangle);
            bmp.Save("board.bmp");
        }

        private void gridPeriodicCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
