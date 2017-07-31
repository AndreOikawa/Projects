using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardRoyal.Struct
{
    public struct Pos
    {
        public int x, y;
    }
    public struct Board
    {
        public Pos position;
        public List<Player> players;
    }
    public struct Team
    {
        public string teamName;
        public Color teamColor;
        public List<Player> players;
    }
    public struct GameObject
    {
        public List<Team> teams;
        public List<Board> board;
    }
}
