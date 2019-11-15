using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelingProject
{
    public class Counter
    {
        protected Dictionary<int, int> counter;

        public Counter()
        {
            this.counter = new Dictionary<int, int>();
        }

        //HMMMMM?
        public void AddCell(Cell cell)
        {
            //0 - null
            //Selected grains can not grow

            if (cell.ID > 1 && !cell.Selected)
            {
                if (!this.counter.ContainsKey(cell.ID))
                {
                    this.counter[cell.ID] = 0;
                }
                ++this.counter[cell.ID];
            }
        }

        public void AddCells(IEnumerable<Cell> cells)
        {
            foreach (Cell c in cells)
            {
                this.AddCell(c);
            }
        }
        //????

        public CounterReturn MostCommonID
        {
            get
            {
                if (this.counter.Count > 0)
                {
                    KeyValuePair<int, int> max = this.counter.Aggregate((l, r) => l.Value > r.Value ? l : r);

                    return new CounterReturn { ID = max.Key,  Count = max.Value};
                }
                return null;
             }
            
            
        }

    




    }
}
