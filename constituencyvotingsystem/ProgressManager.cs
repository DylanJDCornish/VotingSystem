using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class ProgressManager
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
                lock(this)
                {
                    itemsLeft = value;
                }
            }
        }

        public ProgressManager()
        {
            this.ItemsLeft = 0;
        }

        public ProgressManager(int item)
        {
            this.ItemsLeft = item;
        }
    }
}
