using BoardRoyal.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardRoyal
{
    class GameController
    {

        private void CheckCollision(ref GameObject game, int turn, Pos position, int boardDimensions)
        {
            var playerList = game.board[position.x + position.y * boardDimensions].players;
            var deleteFromTeam = new List<Player>();
            for (int i = 0; i < game.teams.Count; i++)
            {
                if (i != turn)
                {
                    foreach (var player in game.teams[i].players)
                    {
                        deleteFromTeam.Add(player);
                    }
                    
                }
            }
            var deletePlayers = new List<Player>();
            foreach (var player in playerList)
            {
                if (deleteFromTeam.Contains(player)){
                    //Console.WriteLine("ded");
                    deletePlayers.Add(player);
                }
            }

            foreach (var player in deletePlayers)
            {
                playerList.Remove(player);
                foreach (var team in game.teams)
                {
                    if (team.players.Contains(player))
                    {
                        team.players.Remove(player);
                    }
                }
                
            }

        }
        private void UpdateBoard(ref GameObject game, Pos playerPos, Pos newPos, Player player, int boardDimensions)
        {
            game.board[playerPos.x + playerPos.y * boardDimensions].players.Remove(player);
            game.board[newPos.x + newPos.y * boardDimensions].players.Add(player);
            
        }
        public void Move(ref GameObject game, ref int turn, int boardDimensions)
        {
            Random rng = new Random();
            List<Player> deletePlayers = new List<Player>();
            foreach (var player in game.teams[turn].players)
            {
                Pos playerPos = player.myPos;
                try
                {
                    //for ()
                    int playerMove = player.Move(new List<Board>(),rng.Next(1,10));
                    int indexConstant = playerPos.x + playerPos.y * boardDimensions;
                    if (playerMove >= 1 && playerMove <= 9 && (indexConstant >= 0 && indexConstant <= boardDimensions * boardDimensions - 1))
                    {
                        //Pos playerPos = player.myPos;
                        if (!game.board[playerPos.x + playerPos.y * boardDimensions].players.Contains(player)) throw new Exception("bad coordinate");
                        
                        switch (playerMove)
                        {
                            case 1:
                                if (playerPos.x > 0 && playerPos.y < boardDimensions - 1)
                                {
                                    player.myPos = new Pos() { x = player.myPos.x - 1, y = player.myPos.y + 1 };
                                    UpdateBoard(ref game, playerPos, player.myPos, player, boardDimensions);
                                }
                                //game.board[playerPos.x - 1 + (playerPos.y + 1) * boardDimensions].players.Add(player);
                                
                                break;
                            case 2:
                                if(playerPos.y < boardDimensions - 1)
                                {
                                    player.myPos = new Pos() { x = player.myPos.x, y = player.myPos.y + 1 };
                                    UpdateBoard(ref game, playerPos, player.myPos, player, boardDimensions);
                                }
                                //game.board[playerPos.x + (playerPos.y + 1) * boardDimensions].players.Add(player);
                                //player.myPos = new Pos() { x = player.myPos.x, y = player.myPos.y + 1 };
                                break;
                            case 3:
                                if (playerPos.y < boardDimensions - 1 && playerPos.x < boardDimensions - 1)
                                {
                                    player.myPos = new Pos() { x = player.myPos.x + 1, y = player.myPos.y + 1 };
                                    UpdateBoard(ref game, playerPos, player.myPos, player, boardDimensions);
                                }
                                //game.board[playerPos.x + 1 + (playerPos.y + 1) * boardDimensions].players.Add(player);
                                //player.myPos = new Pos() { x = player.myPos.x + 1, y = player.myPos.y + 1 };
                                break;
                            case 4:
                                if (playerPos.x > 0)
                                {
                                    player.myPos = new Pos() { x = player.myPos.x - 1, y = player.myPos.y };
                                    UpdateBoard(ref game, playerPos, player.myPos, player, boardDimensions);
                                }
                                //game.board[playerPos.x - 1 + (playerPos.y) * boardDimensions].players.Add(player);
                                //player.myPos = new Pos() { x = player.myPos.x - 1, y = player.myPos.y };
                                break;
                            case 6:
                                if (playerPos.x < boardDimensions - 1)
                                {
                                    player.myPos = new Pos() { x = player.myPos.x + 1, y = player.myPos.y };
                                    UpdateBoard(ref game, playerPos, player.myPos, player, boardDimensions);
                                }
                                //game.board[playerPos.x + 1 + (playerPos.y) * boardDimensions].players.Add(player);
                                
                                break;
                            case 7:
                                if (playerPos.x > 0 && playerPos.y > 0)
                                {
                                    player.myPos = new Pos() { x = player.myPos.x - 1, y = player.myPos.y - 1 };

                                    UpdateBoard(ref game, playerPos, player.myPos, player, boardDimensions);
                                }
                                //game.board[playerPos.x - 1 + (playerPos.y - 1) * boardDimensions].players.Add(player);
                                break;
                            case 8:
                                if (playerPos.y > 0)
                                {
                                    player.myPos = new Pos() { x = player.myPos.x, y = player.myPos.y - 1 };

                                    UpdateBoard(ref game, playerPos, player.myPos, player, boardDimensions);
                                }
                                //game.board[playerPos.x + (playerPos.y - 1) * boardDimensions].players.Add(player);
                                break;
                            case 9:
                                if (playerPos.x < boardDimensions - 1 && playerPos.y > 0)
                                {
                                    player.myPos = new Pos() { x = player.myPos.x + 1, y = player.myPos.y - 1 };

                                    UpdateBoard(ref game, playerPos, player.myPos, player, boardDimensions);
                                }
                                //game.board[playerPos.x + 1 + (playerPos.y - 1) * boardDimensions].players.Add(player);
                                break;
                            default:
                                //game.board[playerPos.x + playerPos.y * boardDimensions].players.Add(player);
                                break;
                        }

                        CheckCollision(ref game, turn, player.myPos, boardDimensions);
                    }

                }
                catch (Exception)
                {
                    //game.board[playerPos.x + playerPos.y * boardDimensions].players.Add(player);
                    deletePlayers.Add(player);
                }

            }
            //foreach(var player in deletePlayers)
            //{
            //    foreach (var team in game.teams)
            //    {
            //        if (team.players.Contains(player)) team.players.Remove(player);
            //        break;
            //    }
            //}
        }
        public bool IsGameOver(ref GameObject game)
        {
            int numTeams = game.teams.Count;
            foreach (var team in game.teams)
            {
                if (team.players.Count == 0)
                {
                    numTeams--;
                    game.teams.Remove(team);
                    break;
                }
            }
            if (numTeams == 1) return true;
            return false;
        }
        public void InitializeGameValues(ref GameObject game, int boardDimensions, int numPlayers)
        {
            Random rng = new Random();
            for (int x = 0; x < boardDimensions; x++)
            {
                for (int y = 0; y < boardDimensions; y++)
                {
                    game.board.Add(new Board() { position = new Pos() { x = y, y = x }, players = new List<Player>() });
                }
            }

            game.teams.Add(new Team() { teamName = "Red", teamColor = Color.Red, players = new List<Player>() });
            game.teams.Add(new Team() { teamName = "Blue", teamColor = Color.Blue, players = new List<Player>() });

            int fieldSize = (boardDimensions - 1) / 2 * boardDimensions;

            foreach (var team in game.teams)
            {
                int offset = (team.teamName == "Red") ? 0 : boardDimensions / 2 * boardDimensions;


                for (int i = 0; i < numPlayers; i++)
                {
                    Player newPlayer = new Player();
                    int playerPosChecker = rng.Next(0 + offset, fieldSize + offset);

                    while (game.board[playerPosChecker].players.Count != 0)
                        playerPosChecker = rng.Next(0 + offset, boardDimensions / 2 * boardDimensions + offset);
                    newPlayer.myPos = game.board[playerPosChecker].position;
                    game.board[playerPosChecker].players.Add(newPlayer);



                    team.players.Add(newPlayer);


                }
            }
        }


    }
}
