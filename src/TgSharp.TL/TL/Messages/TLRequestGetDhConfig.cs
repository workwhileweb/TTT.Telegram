using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(651135312)]
    public class TLRequestGetDhConfig : TLMethod<Messages.TLAbsDhConfig>
    {
        public override int Constructor
        {
            get
            {
                return 651135312;
            }
        }

        public int Version { get; set; }
        public int RandomLength { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Version = br.ReadInt32();
            RandomLength = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Version);
            bw.Write(RandomLength);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsDhConfig)ObjectUtils.DeserializeObject(br);
        }
    }
}
