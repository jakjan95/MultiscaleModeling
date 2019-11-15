using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelingProject
{
    public class Cell
    {
        public int ID { get; set; }

        public int NewID { get; set; }

        public bool Selected { get; set; }

        public Cell[] Neighbors { get; set; }

        public Cell() : this(0)
        {
            ;
        }

        public Cell(int id)
        {
            this.ID = ID;
        }


        #region Neighbors
        //NW    N    NE
        //W     [C]  E 
        //SW    S    SE

        public Cell NeighborN
        {
            get { return this.Neighbors[0]; }
        }

        public Cell NeighborNW
        {
            get { return this.Neighbors[1]; }
        }

        public Cell NeighborW
        {
            get { return this.Neighbors[2]; }
        }

        public Cell NeighborSW
        {
            get { return this.Neighbors[3]; }
        }

        public Cell NeighborS
        {
            get { return this.Neighbors[4]; }
        }

        public Cell NeighborSE
        {
            get { return this.Neighbors[5]; }
        }

        public Cell NeighborE
        {
            get { return this.Neighbors[6]; }
        }

        public Cell NeighborNE
        {
            get { return this.Neighbors[7]; }
        }

        public IEnumerable<Cell> MoorNeighborhood
        {
            get { return this.Neighbors; }
        }

        public IEnumerable<Cell> VonNeumannNeighborhood
        {
            get
            {
                return new Cell[]
                {
              this.NeighborN,
              this.NeighborE,
              this.NeighborS,
              this.NeighborW,
                };
            }
        }

        public IEnumerable<Cell> LeftPentagonal
        {
            get
            {
                return new Cell[]
                {
              this.NeighborN,
              this.NeighborNW,
              this.NeighborW,
              this.NeighborSW,
              this.NeighborS,
                };
            }
        }

        public IEnumerable<Cell> RightPentagonal
        {
            get
            {
                return new Cell[]
                {
              this.NeighborN,
              this.NeighborNE,
              this.NeighborE,
              this.NeighborSE,
              this.NeighborS,
                };
            }
        }

        public IEnumerable<Cell> LeftHexagonal
        {
            get
            {
                return new Cell[]
                {
              this.NeighborW,
              this.NeighborNW,
              this.NeighborN,
              this.NeighborE,
              this.NeighborSE,
              this.NeighborS,
                };
            }
        }

        public IEnumerable<Cell> RightHexagonal
        {
            get
            {
                return new Cell[]
                {
              this.NeighborN,
              this.NeighborNE,
              this.NeighborE,
              this.NeighborS,
              this.NeighborSW,
              this.NeighborW,
                };
            }
        }




        #endregion

    }
}
