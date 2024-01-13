using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class SaveData
    {
        public float[] playerPosition;
        public int seedMap;

        public SaveData(Player player, int seedMap)
        {
            playerPosition[0] = player.transform.position.x;
            playerPosition[1] = player.transform.position.y;
            this.seedMap = seedMap;
        }
    }
}
