using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelingProject
{
    public class Grid
    {
        protected Cell[,] cells;

        public int Width { get; set; }
        public int Height { get; set; }

        public bool periodic;
        public int currentPosX;
        public int currentPosY;

        public Grid(int width, int height, bool periodic)
        {
            this.Width = width;
            this.Height = height;
            this.periodic = periodic;

            //Initialization of cells:
            this.cells = new Cell[height, width];

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    this.cells[i, j] = new Cell();
                }
            }

            //Set up neighbors
            this.ResetCurrentCellPosition();

            do
            {
                this.CurrentCell.Neighbors = this.NeighborhoodOfCurrentCell;
            } while (this.Next());
        }

        public Cell CurrentCell
        {
            get
            {
                return this.GetCell(this.currentPosX, this.currentPosY);
            }
        }

        public Cell GetCell(int x, int y)
        {
            if(x  < 0 || x >= this.Width || y < 0 || y >= this.Height)
            {
                //For Periodic boundary condition
                if (this.periodic)
                {
                    return this.cells[MathFunctions.MathMod(y,this.Height), MathFunctions.MathMod(x, this.Width)];
                }
                //Absorbent boundary condition
                else
                {
                    return new Cell();
                }
            }

            else
            {
                return this.cells[y, x];
            }
        }

        public void ResetCurrentCellPosition()
        {
            this.currentPosX = 0;
            this.currentPosY = 0;
        }

        public bool Next()
        {
            //For last cell 
            if(this.currentPosX==this.Width-1 && this.currentPosY == this.Height - 1)
            {
                return false;
            }

            //Moving pointer to the next cell   
            if (this.currentPosX == this.Width - 1)
            {
                this.currentPosX = 0;
                this.currentPosY += 1;
            }
            else
            {
                this.currentPosX += 1;
            }

            return true;
        }

        //Using after one step of growth(moving newID to value to ID)
        public void CopyNewIDtoID()
        {
            for(int i = 0; i < this.Height; i++)
            {
                for(int j = 0; j < this.Width; j++)
                {
                    this.cells[i, j].ID = this.cells[i, j].NewID;
                }
            }
        }

        //Neighbors of current cell by directions of the world
        #region Neighbors
        public Cell NeighborN
        {
            get { return this.GetNeighbor(0,1); }
        }

        public Cell NeighborNW
        {
            get { return this.GetNeighbor(1, 1); }
        }

        public Cell NeighborW
        {
            get { return this.GetNeighbor(1, 0); }
        }

        public Cell NeighborSW
        {
            get { return this.GetNeighbor(1, -1); }
        }

        public Cell NeighborS
        {
            get { return this.GetNeighbor(0, -1); }
        }

        public Cell NeighborSE
        {
            get { return this.GetNeighbor(-1, -1); }
        }

        public Cell NeighborE
        {
            get { return this.GetNeighbor(-1, 0); }
        }

        public Cell NeighborNE
        {
            get { return this.GetNeighbor(-1, 1); }
        }
       

        protected Cell GetNeighbor(int diffX, int diffY)
        {
            return this.GetCell(this.currentPosX + diffX, this.currentPosY + diffY);
        }

        public Cell[] NeighborhoodOfCurrentCell
        {
            get
            {
                List<Cell> cells = new List<Cell>();

                cells.Add(this.NeighborN);
                cells.Add(this.NeighborNE);
                cells.Add(this.NeighborE);
                cells.Add(this.NeighborSE);
                cells.Add(this.NeighborS);
                cells.Add(this.NeighborSW);
                cells.Add(this.NeighborW);
                cells.Add(this.NeighborNW);

                return cells.ToArray();
            }
        }
        #endregion
    }
}
