using System;

namespace PdfTools
{
    public class PdfColourInput
    {
        public byte[] ByteArray { get; set; }

        public double ColourTolerance { get; set; }
    }

    public class PdfColourOutput
    {
        public int ColourPages { get; set; }

        public int BWPages { get; set; }
    }
}
