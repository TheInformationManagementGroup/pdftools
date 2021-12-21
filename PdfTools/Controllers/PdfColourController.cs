using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PdfTools.Controllers
{
    public class PdfColourController : ApiController
    {
        [HttpPost]
        public PdfColourOutput CalculateColourPages([FromBody]PdfColourInput input)
        {
            var stream = new System.IO.MemoryStream(input.ByteArray);
            var result = Ghostscript.NET.GhostscriptPdfInfo.GetInkCoverage(stream);

            int col = 0;
            int bw = 0;
            foreach (var kvp in result)
            {
                if (kvp.Value.C > input.ColourTolerance || kvp.Value.M > input.ColourTolerance || kvp.Value.Y > input.ColourTolerance)
                    col++;
                else
                    bw++;
            }

            return new PdfColourOutput() { BWPages = bw, ColourPages = col };
        }
    }
}
