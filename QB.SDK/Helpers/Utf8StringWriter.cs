using System.IO;
using System.Text;

namespace QB.SDK;

internal class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}
