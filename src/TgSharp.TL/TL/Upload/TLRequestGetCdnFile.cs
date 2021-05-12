using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Upload
{
    [TLObject(536919235)]
    public class TLRequestGetCdnFile : TLMethod<Upload.TLAbsCdnFile>
    {
        public override int Constructor
        {
            get
            {
                return 536919235;
            }
        }

        public byte[] FileToken { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            FileToken = BytesUtil.Deserialize(br);
            Offset = br.ReadInt32();
            Limit = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            BytesUtil.Serialize(FileToken, bw);
            bw.Write(Offset);
            bw.Write(Limit);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (Upload.TLAbsCdnFile)ObjectUtils.DeserializeObject(br);
        }
    }
}
