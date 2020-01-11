using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiscaleModelingProject
{
    public class AlgorithmCA
    {

        private const int MAX_GRAIN_ID = 150;
        public int Width { set; get; }
        public int Height { set; get; }
        protected Grid grid;
        protected int? idForSelectedGrain;
        private delegate bool ChooseFunction(Cell cell);

        private ChooseFunction selectedNeighborhood;


        public Grid Grid
        {
            get
            {
                return this.grid;
            }

            set
            {
                this.grid = value;
                this.Width = this.grid.Width;
                this.Height = this.grid.Height;
            }
        }

        public int[] GetNotUsedIds()
        {
            bool[] usesArr = Enumerable.Repeat(false, MAX_GRAIN_ID).ToArray();
            usesArr[0] = true; // empty
            usesArr[1] = true; // inclusion
            usesArr[2] = true; // Phase 1 for dualphase

            this.grid.ResetCurrentCellPosition();

            //Iterate cells line by line

            do
            {
                usesArr[this.grid.CurrentCell.ID] = true;
            } while (this.grid.Next());

            List<int> ret = new List<int>();

            for (int i = 0; i < usesArr.Length; ++i)
            {
                if (usesArr[i] == false)
                    ret.Add(i);
            }

            return ret.ToArray();

        }

        //CA algorithm :)
        public void AddRandomGrains(int number)
        {
            int[] notUsedIds = this.GetNotUsedIds();

            for (int i = 0; i < number; ++i)
            {
                if (i < notUsedIds.Length)
                {
                    Cell c;

                    // Look for empty cell
                    do
                    {
                        c = this.grid.GetCell(RandomHelper.Next(this.Width), RandomHelper.Next(this.Height));
                    } while (c.ID != 0 || c.Selected );
                c.ID = notUsedIds[i];
                }

                else
                {
                    // No more id
                    break;
                }
            }

        }

        public void AddRandomInclusions(int number, int min_r, int max_r)
        {
            Random rnd = new Random();
            for (int i = 0; i < number; i++)
            {
                Cell c;
                int temp_x = RandomHelper.Next(this.Width);
                int temp_y = RandomHelper.Next(this.Height);

                c = this.grid.GetCell(temp_x, temp_y);
                c.ID = 1;
                c.NewID = 1;

                int r = rnd.Next(min_r, max_r);
                AddCircleInclusion(temp_x, temp_y, r);
            }
        }
     
        private bool isInCircle(int r, int y, int x)
        {
            return ((x * x) + (y * y) ) <= r * r;
        }

        public void AddCircleInclusion(int x, int y, int r) 
        {
            for(int i = y-r; i <= y+r; i++)
            {
                for (int j = x - r; j <= x + r; j++)
                {

                    if (isInCircle(r, Math.Abs(y - i), Math.Abs(x - j)) && i >= 0 && j >= 0 && this.Width > j && this.Height > i)
                    {
                        this.AddInclusion(i, j);
                    }

                }
            }
        }

        protected void AddInclusion(int x, int y)
        {
            Cell c = grid.GetCell(x, y);
            c.ID = 1;
            c.NewID = 1;
        }

        /// <summary>
        /// edit on asynchronic
        /// </summary>
        /// <param name="name"></param>
        /// <param name="board"></param>
        //public void Start(string name, PictureBox board)
        //{
        //    while (Step(name))
        //    {
        //        board.Refresh();
        //    }
        //}

        /// <summary>
        /// TODO:
        /// --zrobic warunek ze jak jest 100% to leci z moora
        /// jezeli mniej niz 100% to leci wedlug tych zasad
        /// -zrobic warunek ze jezeli moor jest wybrany to wtedy powyzsze zasady dzialaja
        /// </summary>
        /// <param name="name"></param>
        /// <param name="board"></param>
        /// 
     
        public async Task StartAsync(string name, PictureBox board, CancellationToken ct)
        {
            if (name.Equals("Moore"))
                selectedNeighborhood = Moore;
            else if (name.Equals("Von Neumann"))
                selectedNeighborhood = VanNeuman;
            else if (name.Equals("Left Pentagonal"))
                selectedNeighborhood = LeftPentagonal;
            else if (name.Equals("Right Pentagonal"))
                selectedNeighborhood = RightPentagonal;
            else if (name.Equals("Left Hexagonal"))
                selectedNeighborhood = LeftHexagonal;
            else if (name.Equals("Right Hexagonal"))
                selectedNeighborhood = RightHexagonal;
            while (await StepAsync())
            {
                board.Invoke(new Action(delegate ()
                {
                    board.Refresh();
                }));
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
            }
        }

        public async Task NextStepAns(string name, PictureBox board, CancellationToken ct)
        {
            if (name.Equals("Moore"))
                selectedNeighborhood = Moore;
            else if (name.Equals("Von Neumann"))
                selectedNeighborhood = VanNeuman;
            else if (name.Equals("Left Pentagonal"))
                selectedNeighborhood = LeftPentagonal;
            else if (name.Equals("Right Pentagonal"))
                selectedNeighborhood = RightPentagonal;
            else if (name.Equals("Left Hexagonal"))
                selectedNeighborhood = LeftHexagonal;
            else if (name.Equals("Right Hexagonal"))
                selectedNeighborhood = RightHexagonal;
            await StepAsync();
            board.Invoke(new Action(delegate ()
            {
                board.Refresh();
            }));

            if (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
            }
        }

        public async Task<bool> StepAsync()
        {

            for(int x=0;x<this.grid.Width;x++)
            {
                for (int y = 0; y < this.grid.Width; y++)
                {
                    Cell c = this.grid.GetCell(x - 1, y);
                    if (c.ID == 2)
                    {
                        c.Selected = true;
                    }
                }

            }
            
            
            int changes = 0;
            grid.ResetCurrentCellPosition();
            //Iterate cells line by line
            do
            {

                //Grains growth only on empty cell
                if (grid.CurrentCell.ID == 0)
                {
                    if (selectedNeighborhood(grid.CurrentCell))
                    {
                            ++changes;
                    }
                }
            } while (grid.Next());

            if (changes > 0)
            {
                //Copying values
                this.grid.CopyNewIDtoID();
                return true;
            }
            return false;
        }


        public bool Step_GBC(int propability)
        {

            Random rnd = new Random();
            int changes = 0;
            this.grid.ResetCurrentCellPosition();

            //Iterate cells line by line
            do
            {
                //Grains growth only on empty cell
                if (this.grid.CurrentCell.ID == 0)
                {
                    //Check Rule 1
                    int id = -1;
                    int max = -1;
                    var x = grid.CurrentCell.MoorNeighborhood.Where(a => !a.Selected).GroupBy(a => a.ID).Select(a => new { Id = a.Key, Value = a.Count() }).ToList();
                    for (int i = 0; i < x.Count; i++)
                    {
                        if (x[i].Id == 0 || x[i].Id == 1 || x[i].Id == 2)
                            continue;
                        if (x[i].Value > max)
                        {
                            id = x[i].Id;
                            max = x[i].Value;
                        }
                    }
                    if (max >= 5 && id > 1)
                    {
                        ++changes;
                        grid.CurrentCell.NewID = id;
                        continue;
                    }


                    //Check Rule 2
                    id = -1;
                    max = -1;
                    x = grid.CurrentCell.VonNeumannNeighborhood.Where(a => !a.Selected).GroupBy(a => a.ID).Select(a => new { Id = a.Key, Value = a.Count() }).ToList();
                    for (int i = 0; i < x.Count; i++)
                    {
                       
                        if (x[i].Id == 0 || x[i].Id == 1 || x[i].Id == 2)
                            continue;
                        if (x[i].Value > max)
                        {
                            id = x[i].Id;
                            max = x[i].Value;
                        }
                    }
                    if (max >= 3 && id > 1)
                    {
                        ++changes;
                        grid.CurrentCell.NewID = id;
                        continue;
                    }


                    //Check Rule 3
                    id = -1;
                    max = -1;
                    x = grid.CurrentCell.FurtherMooreNeighborhood.Where(a => !a.Selected).GroupBy(a => a.ID).Select(a => new { Id = a.Key, Value = a.Count() }).ToList();
                    for (int i = 0; i < x.Count; i++)
                    {
                        if (x[i].Id == 0 || x[i].Id == 1 || x[i].Id == 2)
                            continue;
                        if (x[i].Value > max)
                        {
                            id = x[i].Id;
                            max = x[i].Value;
                        }
                    }
                    if (max >= 3 && id > 1)
                    {
                        ++changes;
                        grid.CurrentCell.NewID = id;
                        continue;
                    }

                    //Check Rule 4

                    id = -1;
                    max = -1;
                    x = grid.CurrentCell.MoorNeighborhood.Where(a => !a.Selected).GroupBy(a => a.ID).Select(a => new { Id = a.Key, Value = a.Count() }).ToList();
                    for (int i = 0; i < x.Count; i++)
                    {
                        if (x[i].Id == 0 || x[i].Id == 1 || x[i].Id == 2)
                            continue;
                        if (x[i].Value > max)
                        {
                            id = x[i].Id;
                            max = x[i].Value;
                        }
                    }
                    int number = rnd.Next(0, 100);
                    if (id > 1 && number < propability)
                    {
                        ++changes;
                        grid.CurrentCell.NewID = id;
                        continue;
                    }

                }
            } while (this.grid.Next());

            if (changes > 0)
            {
                //Copying values
                this.grid.CopyNewIDtoID();
                return true;
            }
            return false;
        }
        //======================================================================

        public void StartSelectGrains(bool changeId)
        {
            if (changeId)
            {
                this.idForSelectedGrain = 2;
            }
            else
            {
                this.idForSelectedGrain = null;
            }

            this.grid.ResetCurrentCellPosition();

            // Reset selected state
            do
            {
                this.grid.CurrentCell.Selected = false;
            } while (this.grid.Next());
        }

        public void SelectGrain(int x, int y)
        {
            int selectedId = this.grid.GetCell(x, y).ID;
            this.grid.ResetCurrentCellPosition();

            do
            {
                if (this.grid.CurrentCell.ID == selectedId)
                {
                    this.grid.CurrentCell.Selected = true;

                    if (this.idForSelectedGrain.HasValue)
                    {
                        this.grid.CurrentCell.ID = this.idForSelectedGrain.Value;
                        this.grid.CurrentCell.NewID = this.idForSelectedGrain.Value;
                    }
                }
            } while (this.grid.Next());
        }


        public void EndSelectGrains()
        {
            this.grid.ResetCurrentCellPosition();

            do
            {
                if (!this.grid.CurrentCell.Selected && this.grid.CurrentCell.ID > 1) // 0 - empty cell, 1 - inclusion
                {
                    this.grid.CurrentCell.ID = 0;
                    this.grid.CurrentCell.NewID = 0;
                }
            } while (this.grid.Next());
        }


        //=====================================================================================================================

        //For Moore
        protected bool Moore(Cell c)
        {
            CounterReturn cr = this.MooreMostCommonCell(c);
            
            if(cr != null)
            {
                this.grid.CurrentCell.NewID = cr.ID;
                return true;
            }
            return false;
        }

        protected bool VanNeuman(Cell c)
        {
            CounterReturn cr = this.VanNeumanMostCommonCell(c);

            if (cr != null)
            {
                this.grid.CurrentCell.NewID = cr.ID;
                return true;
            }

            return false;
        }

        protected bool LeftPentagonal(Cell c)
        {
            CounterReturn cr = this.LeftPentagonalMostCommonCell(c);

            if (cr != null)
            {
                this.grid.CurrentCell.NewID = cr.ID;
                return true;
            }

            return false;
        }

        protected bool RightPentagonal(Cell c)
        {
            CounterReturn cr = this.RightPentagonalMostCommonCell(c);

            if (cr != null)
            {
                this.grid.CurrentCell.NewID = cr.ID;
                return true;
            }

            return false;
        }

        protected bool LeftHexagonal(Cell c)
        {
            CounterReturn cr = this.LeftHexagonalMostCommonCell(c);

            if (cr != null)
            {
                this.grid.CurrentCell.NewID = cr.ID;
                return true;
            }

            return false;
        }

        protected bool RightHexagonal(Cell c)
        {
            CounterReturn cr = this.RightHexagonalCommonCell(c);

            if (cr != null)
            {
                this.grid.CurrentCell.NewID = cr.ID;
                return true;
            }

            return false;
        }

        protected CounterReturn MooreMostCommonCell(Cell c)
        {
            Counter counter = new Counter();
            counter.AddCells(c.MoorNeighborhood);
            return counter.MostCommonID;
        }


        protected CounterReturn VanNeumanMostCommonCell(Cell c)
        {
            Counter counter = new Counter();
            counter.AddCells(c.VonNeumannNeighborhood);
            return counter.MostCommonID;
        }

        protected CounterReturn LeftPentagonalMostCommonCell(Cell c)
        {
            Counter counter = new Counter();
            counter.AddCells(c.LeftPentagonalNeighborhood);
            return counter.MostCommonID;
        }

        protected CounterReturn RightPentagonalMostCommonCell(Cell c)
        {
            Counter counter = new Counter();
            counter.AddCells(c.RightPentagonalNeighborhood);
            return counter.MostCommonID;
        }

        protected CounterReturn LeftHexagonalMostCommonCell(Cell c)
        {
            Counter counter = new Counter();
            counter.AddCells(c.LeftHexagonalNeighborhood);
            return counter.MostCommonID;
        }

        protected CounterReturn RightHexagonalCommonCell(Cell c)
        {
            Counter counter = new Counter();
            counter.AddCells(c.RightHexagonalNeighborhood);
            return counter.MostCommonID;
        }
    }
}
