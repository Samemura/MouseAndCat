using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MouseBT_Tool;

namespace MouseBT_Tool
{
    public enum wall    {        Unkown, None, Exist    }

    public class Position
    {
        public wall northWall, eastWall, westWall, southWall;
        public Position() 
        {
            northWall= new wall();
            eastWall = new wall();
            westWall = new wall();
            southWall = new wall();
        }
    }

    public class Map
    {
        private int posSizeX, posSizeY; 
        public Position[,] pos;

        public Map(int sizeX, int sizeY){
            posSizeX = sizeX;
            posSizeY = sizeY;
            pos = new Position[sizeX, sizeY];
            for (int x = 0; x < posSizeX; x ++ )
            {
                for (int y = 0; y < posSizeY; y++)
                {
                pos[x, y] = new Position();
                }
            }

        }

    }

}
