using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-2084618926)]
    public class TLRequestGetSavedGifs : TLMethod<Messages.TLAbsSavedGifs>
    {
        public override int Constructor
        {
            get
            {
                return -2084618926;
            }
        }

        public int Hash { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsSavedGifs)ObjectUtils.DeserializeObject(br);
        }
    }
}
