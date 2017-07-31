using BoardRoyal.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardRoyal
{

    public class Player
    {
        public Pos myPos { get; set; }
        public Color teamColor { get; set; }

        private int turn = 0;
        public int Move(List<Board> surrounding, int rng)
        {
            //turn++;
            //if (turn %2 == 0)
            //return 2;
            return rng;
        }
    }
}
