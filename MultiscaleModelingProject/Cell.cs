﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelingProject
{
    public class Cell
    {
        public int ID { set; get; }

        public int NewID { set; get; }

        public bool Selected { set; get; }

        public Cell[] Neighbors { set; get; }

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
        #endregion
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

        public IEnumerable<Cell> LeftPentagonalNeighborhood
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

        public IEnumerable<Cell> RightPentagonalNeighborhood
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

        public IEnumerable<Cell> LeftHexagonalNeighborhood
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

        public IEnumerable<Cell> RightHexagonalNeighborhood
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


        //Nearest Moore same as VanNeuman
        public IEnumerable<Cell> FurtherMooreNeighborhood
        {
            get
            {
                return new Cell[]
                {
              this.NeighborNW,
              this.NeighborNE,
              this.NeighborSW,
              this.NeighborSE,
                };
            }
        }




    }
}
