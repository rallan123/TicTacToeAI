using System;
using TicTacToe.Interfaces;
using TicTacToe.General;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using TicTacToe.Backend.Models;

namespace TicTacToe.General
{
    public static class GameHelper
    {
        public static void PrintMoves(List<TblMove> moves){
            for(int r=0;r<3;r++){
                for(int c=0;c<3;c++){
                    TblMove move = moves.FirstOrDefault(m => m.Row == r && m.Col == c);
                    Console.Write(move?.PlayerNumber.ToString() ?? "X");
                }   
                Console.WriteLine("");
            }
        }
    }
}
