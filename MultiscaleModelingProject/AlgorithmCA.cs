using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiscaleModelingProject
{
    public class AlgorithmCA
    {

        private const int MAX_GRAIN_ID = 200;
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

            for(int i=0; i < number; ++i)
            {
                if (i < notUsedIds.Length)
                {
                    Cell c;
                    //Looking for empty cell
                    do
                    {
                        c = this.grid.GetCell(RandomHelper.Next(this.Width), RandomHelper.Next(this.Height));
                    } while (c.ID != 0 || c.Selected);

                    c.ID = notUsedIds[i];
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// edycja na asynchroniczne
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
        public void NextStep(string name, PictureBox board)
        {
            Step(name);
            board.Refresh();
        }

        public bool Step(string name)
        {
            int changes = 0;
            this.grid.ResetCurrentCellPosition();
            if(name.Equals("Moore"))
                f += Moore;
            else if (name.Equals("Von Neumann"))
                f += VanNeuman;
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
    }
}
