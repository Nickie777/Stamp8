using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stamp8
{
    internal class StampPictures
    {
        private int Id { get; set; }
        private string FilePath { get; set; }
        private int xCoordinate { get; set; } = 0;
        private int yCoordinate { get; set; } = 0;
        private int height { get; set; }
        private int width { get; set; }
        private float scale { get; set; }
        private int rotation { get; set; }
    }
}
