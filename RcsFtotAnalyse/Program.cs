using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcsFtotAnalyse
{
    using System.Xml.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var filename = "RCS_R_T_180115_03106.xml";
                var doc = XDocument.Load(filename);
                var r1 = doc.Descendants("FTOT").Select(x => x.Descendants("LicenseeType")
                    .Where(licenseeType => licenseeType.Attribute("lt")?.Value == "00001" &&
                           licenseeType.Descendants("Licensee")
                                .Select(licensee=>licensee.Descendants("Channel").Select(channelNode=>channelNode.Attribute("ch")?.Value).Contains("00004")
                           ))).

            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
