using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(852135825)]
    public class TLRequestGetWebPage : TLMethod<TLAbsWebPage>
    {
        public override int Constructor
        {
            get
            {
                return 852135825;
            }
        }

        public string Url { get; set; }
        public int Hash { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
            Hash = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Url, bw);
            bw.Write(Hash);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsWebPage)ObjectUtils.DeserializeObject(br);
        }
    }
}
