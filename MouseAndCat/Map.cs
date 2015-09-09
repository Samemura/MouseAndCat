using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MouseAndCat;

namespace MouseAndCat
{
    public enum WallStatus { Unkown, None, Exist }

    public class Wall
    {
        public byte data;
        public WallStatus north
        {
            get { return getWallStatus(data, 0x01); }
        }
        public WallStatus east
        {
            get { return getWallStatus(data, 0x02); }
        }
        public WallStatus south
        {
            get { return getWallStatus(data, 0x04); }
        }
        public WallStatus west
        {
            get { return getWallStatus(data, 0x08); }
        }

        private WallStatus getWallStatus(byte data, byte mask)
        {  
            return ((data & mask)==mask) ? WallStatus.Exist : WallStatus.None;
        }
    }


    public class Map
    {
        public int mapSizeX
        {
            get { return wall.GetLength(0); }
        }
        public int mapSizeY
        {
            get { return wall.GetLength(1); }
        }
        public Wall[,] wall;

        public Map(int sizeX, int sizeY){
            wall = new Wall[sizeX, sizeY];
            for (int x = 0; x < mapSizeX; x ++ )
                for (int y = 0; y < mapSizeY; y++)
                    wall[x, y] = new Wall();

        }

    }

}
