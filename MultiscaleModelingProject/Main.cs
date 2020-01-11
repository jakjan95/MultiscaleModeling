using System;
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

        private int Propability
        {
            get { return (int)this.GBCnumericUpDown.Value; }
        }

        private bool DPcheck
        {
            get { return this.DPcheckBox.Checked; }
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
            this.SetupStateButtons();


        }


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
            this.brushes.Add(Brushes.Red);
            foreach (PropertyInfo pf in typeof(Brushes).GetProperties().Where(p => p.Name != "Black" && p.Name != "Red"))
            {
                this.brushes.Add(pf.GetValue(null, null) as Brush);
            }


            this.brushes.Insert(0, Brushes.Black);
        }


        private void SetupStateButtons()
        {
            this.stateButtons = new Dictionary<Button, EventsOfButton>();

            this.stateButtons.Add(this.SelectButton, new EventsOfButton { BoardClick = SelectGrain, On = SelectGrain_Start, Off = SelectGrain_End });
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
                        e.Graphics.FillRectangle(this.brushes[c.ID], x, y, 1, 1);
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

        private void GBCnextStep_Click(object sender, EventArgs e)
        {
            int chance = Propability;
            ca.Step_GBC(chance);
            Board.Refresh();
        }

        private void GBCsimulate_Click(object sender, EventArgs e)
        {
            int chance = Propability;
            while (ca.Step_GBC(chance))
            {
                Board.Refresh();
            }   
        }

        #region BoardClickLogic

        private void Board_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            int x = me.X;
            int y = me.Y;

            if (this.activeStateButton != null && this.stateButtons.ContainsKey(this.activeStateButton) && this.stateButtons[this.activeStateButton].BoardClick != null)
            {
                this.stateButtons[activeStateButton].BoardClick(x, y);
                this.Board.Refresh();
            }
        }


        private void stateButton_Click(object sender, EventArgs e)
        {
            foreach (Button btn in stateButtons.Keys)
            {
                btn.BackColor = SystemColors.Control;
                btn.ForeColor = SystemColors.ControlText;
            }

            Button clickedButton = sender as Button;

            // Off logic for prevoius button 
            if (this.activeStateButton != null && this.stateButtons.ContainsKey(this.activeStateButton) && this.stateButtons[this.activeStateButton].Off != null)
            {
                this.stateButtons[this.activeStateButton].Off();
            }

            // Click in different button
            if (this.activeStateButton != clickedButton)
            {
                this.activeStateButton = clickedButton;
                clickedButton.BackColor = SystemColors.Highlight;
                clickedButton.ForeColor = SystemColors.HighlightText;

                // On logic
                if (this.activeStateButton != null && this.stateButtons.ContainsKey(this.activeStateButton) && this.stateButtons[this.activeStateButton].On != null)
                {
                    this.stateButtons[this.activeStateButton].On();
                }
            }

            // Unclick active button
            else
            {
                activeStateButton = null;
            }
        }

        private void SelectGrain_Start()
        {
            this.ca.StartSelectGrains(this.DPcheck);
            //this.ca.StartSelectGrains(true);
        }

        private void SelectGrain(int x, int y)
        {
            this.ca.SelectGrain(x, y);
            this.Board.Refresh();
        }

        private void SelectGrain_End()
        {
            this.ca.EndSelectGrains();
            this.Board.Refresh();
        }


        #endregion BoardClickLogic

        private void DPcheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void boundariesButton_Click(object sender, EventArgs e)
        {
            int length=0;
            for (int y = 0; y < this.grid.Width-1; ++y)
            {
                for (int x = 1; x < this.grid.Height; ++x)
                {
                    Cell c = this.grid.GetCell(x - 1, y);
                    Cell c2 = this.grid.GetCell(x, y);
                    Cell c3 = this.grid.GetCell(x, y + 1);

                    if (c.ID > 1 && ( c.ID != c2.ID || c.ID != c3.ID ))
                    {
                        c.ID = 1;
                        c.NewID = 1;
                        length++;
                    }

                }
            }
            this.Board.Refresh();

            //============================================
            HashSet<int> set = new HashSet<int>();

            grid.ResetCurrentCellPosition();
            do
            {
                set.Add(grid.CurrentCell.ID);

            } while (grid.Next());

            var total = set.Count-1;
            double averangeGrain = (this.grid.Height * this.grid.Width) / total;
            //=============================================


            DialogResult result;
            result = MessageBox.Show("Total Length[pixels] :" + length + "\nAverange size[pixels] :" + averangeGrain);
            
        }
    }
}
