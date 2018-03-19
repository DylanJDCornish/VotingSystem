using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class ProgManager
    {
        private int itemsLeft;

        public int ItemsLeft
        {
            get
            {
                return itemsLeft;
            }
            set
            {
                lock (this)
                {
                    itemsLeft = value;
                }
            }
        }

        public ProgManager()
        {
            this.ItemsLeft = 0;
        }

        public ProgManager(int item)
        {
            this.ItemsLeft = item;
        }
    }
}
