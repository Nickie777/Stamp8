using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stamp8
{
    internal class StampPictures
    {
        public Guid Id { get; set; }
        public int pageNumber { get; set; }
        public int typePicture { get; set; } = 1;  // 1 Stamp 2 Facsimile
        public string filePath { get; set; }
        public int xCoordinate { get; set; } = 0;
        public int yCoordinate { get; set; } = 0;
        public int height { get; set; }
        public int width { get; set; }
        public float scale { get; set; }
        public int rotation { get; set; }
        public iText.Layout.Element.Image image { get; set; }
    }
}
