using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(-1250643605)]
    public class TLRequestSetContentSettings : TLMethod<bool>
    {
        public override int Constructor
        {
            get
            {
                return -1250643605;
            }
        }

        public int Flags { get; set; }
        public bool SensitiveEnabled { get; set; }
        

        public void ComputeFlags()
        {
            Flags = 0;
Flags = SensitiveEnabled ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            SensitiveEnabled = (Flags & 1) != 0;
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Flags);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);
        }
    }
}
