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
using System.Threading;

namespace MultiscaleModelingProject
{
    public partial class Main : Form
    {
        #region Properties
        private int GridWidth
        {
            get { return (int)this.BoardWidthNumericUpDown.Value; }
        }

        private int GridHeight
        {
            get { return (int)this.BoardHeightNumericUpDown.Value; }
        }

        private bool GridPeriodic
        {
            get { return this.gridPeriodicCheckBox.Checked; }
        }

        private int CAGrains
        {
            get { return (int)this.caGrainsNumericUpDown.Value; }
        }

        private int Inclusions
        {
            get { return (int)this.InclusionsNumericUpDown.Value; }
        }

        private int InclusionsMinR
        {
            get { return (int)this.minRnumericUpDown.Value; }
        }

        private int InclusionsMaxR
        {
            get { return (int)this.maxRnumericUpDown.Value; }
        }

        #endregion Properties

        private Grid grid;
        private AlgorithmCA ca;
        private List<Brush> brushes;
        private Task t;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        //private PauseTokenSource tokenSource = new PauseTokenSource();


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

            this.brushes.Add(Brushes.Black);

            foreach (PropertyInfo pf in typeof(Brushes).GetProperties().Where(p => p.Name != "Black"))
            {
                this.brushes.Add(pf.GetValue(null, null) as Brush);
            }


            this.brushes.Insert(0, Brushes.Black);
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
                        e.Graphics.FillRectangle((c.Selected) ? Brushes.Yellow : this.brushes[c.ID], x, y, 1, 1);
                    }
                }
            }
        }



        private void caAddRandomGrainsButton_Click(object sender, EventArgs e)
        {
            this.ca.AddRandomGrains(this.CAGrains);
            this.Board.Refresh();
        }

        private void caSimulateButton_Click(object sender, EventArgs e)
        {
            
            var name = caNeighborhoodComboBox.SelectedItem.ToString();
            tokenSource = new CancellationTokenSource();
            
            t = Task.Run(async () =>
            {
                try
                {
                    await ca.StartAsync(name, Board, tokenSource.Token);
                }
                catch (OperationCanceledException)
                {
                    Debug.WriteLine($"\n{nameof(OperationCanceledException)} thrown\n");
                }
            }, tokenSource.Token);
        }




        private void caNeighborhoodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
            this.SetupGrid();
            this.SetupBoard();
        }

        //private void NextStep_Button_Click(object sender, EventArgs e)
        //{
        //    var name = caNeighborhoodComboBox.SelectedItem.ToString();
        //    ca.NextStep(name, Board);
        //}



        private void NextStep_Button_Click(object sender, EventArgs e)
        {
            var name = caNeighborhoodComboBox.SelectedItem.ToString();
            tokenSource = new CancellationTokenSource();
            t = Task.Run(async () => await ca.NextStepAns(name, Board, tokenSource.Token), tokenSource.Token);

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

        private void csvSaveButton_Click(object sender, EventArgs e)
        {
            string filepath = "board.txt";
            System.IO.File.WriteAllBytes(filepath, new byte[0]);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                for (int x = 0; x < this.grid.Height; ++x)
                {
                    for (int y = 0; y < this.grid.Width; ++y)
                    {
                        Cell c = this.grid.GetCell(x, y);
                        file.WriteLine(x + "," + y + "," + c.ID);
                    }
                }
            }
        }

        private void addInclusionButton_Click(object sender, EventArgs e)
        {
            this.ca.AddRandomInclusions(this.Inclusions, this.InclusionsMinR, this.InclusionsMaxR);
            this.Board.Refresh();
        }

        private void csvLoadButton_Click(object sender, EventArgs e)
        {
            string path = "board.txt";
            string line;

            if (System.IO.File.Exists(path))
            {
                System.IO.StreamReader file = null;
                try
                {
                    file = new System.IO.StreamReader(path);
                    while ((line = file.ReadLine()) != null)
                    {
                        String[] coordinates = line.Split(',');
                        int tmp_x = System.Convert.ToInt32(coordinates[0]);
                        int tmp_y = System.Convert.ToInt32(coordinates[1]);
                        int tmp_id = System.Convert.ToInt32(coordinates[2]);
                        
                        Cell c = this.grid.GetCell(tmp_x, tmp_y);
                        c.ID = tmp_id;
                        c.NewID = tmp_id;
                    }
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
            Console.ReadLine();
            this.Board.Refresh();

        }
    }
}


//TO DO:
//Upgrade ansyc