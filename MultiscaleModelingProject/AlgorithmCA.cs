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

        private ChooseFunction f;


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

        /////CA algorithm :)
        ///

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
                    } while (c.ID != 0 || c.Selected);

                    c.ID = notUsedIds[i];
                }

                else
                {
                    // No more id
                    break;
                }
            }

        }


        public void AddRandomInclusions(int number)
        {
            for (int i = 0; i < number; ++i)
            {
                Cell c;
                c = this.grid.GetCell(RandomHelper.Next(this.Width), RandomHelper.Next(this.Height));
                c.ID = 1;
                c.NewID = 1;

            }
        
        }

        // TUTAJ ROZKMINIC

        private bool isInCircle(int r, int y, int x)
        {
            return (x * x) + y * y <= r * r;
        }

        //Rozkminic dlaczego sie tak rozplywaja
        public void AddCircleInclusion(int x, int y, int r) 
        {
            for(int i = y - r; i <= y+r; i++)
            {
                for(int j= x-r ; j<= x+r ; j++)
                {
                    if(isInCircle(r, Math.Abs(y-i), Math.Abs(x-j))  && i >= 0 && j>= 0 && this.Width > j && this.Height > i)
                    {
                        this.AddInclusion(i, j);
                    }
                }

            }
        }

        protected void AddInclusion(int x, int y)
        {
            Cell c = this.grid.GetCell(x, y);
            c.ID = 1;
            c.NewID = 1;
        }


        /// <summary>
        /// edit on asynchronic
        /// </summary>
        /// <param name="name"></param>
        /// <param name="board"></param>
        public void Start(string name, PictureBox board)
        {
            while (Step(name))
            {
                board.Refresh();
            }
        }

        /// <summary>
        /// edit on asynchronic
        /// </summary>
        /// <param name="name"></param>
        /// <param name="board"></param>
        public async Task StartAsync(string name, PictureBox board, CancellationToken ct)
        {
            while (await StepAsync(name))
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

        public void NextStep(string name, PictureBox board)
        {
            Step(name);
            board.Refresh();
        }

        public async Task NextStepAnsyc(string name, PictureBox board, CancellationToken ct)
        {
            await StepAsync(name);
            board.Invoke(new Action(delegate ()
            {
                board.Refresh();
            }));

            if (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
            }
        }


        public bool Step(string name)
        {
            int changes = 0;
            this.grid.ResetCurrentCellPosition();

            if (name.Equals("Moore"))
                f += Moore;
            else if (name.Equals("Von Neumann"))
                f += VanNeuman;
            else if (name.Equals("Left Pentagonal"))
                f += LeftPentagonal;
            else if (name.Equals("Right Pentagonal"))
                f += RightPentagonal;
            else if (name.Equals("Left Hexagonal"))
                f += LeftHexagonal;
            else if (name.Equals("Right Hexagonal"))
                f += RightHexagonal;


            //Iterate cells line by line
            do
            {
                //Grains growth only on empty cell
                if (this.grid.CurrentCell.ID == 0)
                {
                    if (f(this.grid.CurrentCell))
                    {
                        ++changes;
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

        public async Task<bool> StepAsync(string name)
        {
            int changes = 0;
            grid.ResetCurrentCellPosition();

            if (name.Equals("Moore"))
                f += Moore;
            else if (name.Equals("Von Neumann"))
                f += VanNeuman;
            else if (name.Equals("Left Pentagonal"))
                f += LeftPentagonal;
            else if (name.Equals("Right Pentagonal"))
                f += RightPentagonal;
            else if (name.Equals("Left Hexagonal"))
                f += LeftHexagonal;
            else if (name.Equals("Right Hexagonal"))
                f += RightHexagonal;


            //Iterate cells line by line
            do
            {
                //Grains growth only on empty cell
                if (grid.CurrentCell.ID == 0)
                {
                    if (f(grid.CurrentCell))
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

        //
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
