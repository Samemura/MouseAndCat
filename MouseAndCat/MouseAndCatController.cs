using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MouseAndCat
{
    class MouseAndCatController
    {
        public Map map = new Map(16, 16);

        public void setMapData(string[] dataStrings){
            for (int stringIdx = 0; stringIdx < dataStrings.Length; stringIdx++)
            {
                string[]  temp = dataStrings[stringIdx].Split(' ');
                if (temp.Length >= map.mapSizeY)
                {
                    int x = int.Parse(temp[0], System.Globalization.NumberStyles.HexNumber);
                    for (int i = 0; i < map.mapSizeY; i++)
                        map.wall[x, i].data = byte.Parse(temp[i + 2], System.Globalization.NumberStyles.HexNumber);
                }
            }
        }
    }
}
