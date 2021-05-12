using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Upload
{
    [TLObject(619086221)]
    public class TLRequestGetWebFile : TLMethod<Upload.TLWebFile>
    {
        public override int Constructor
        {
            get
            {
                return 619086221;
            }
        }

        public TLAbsInputWebFileLocation Location { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Location = (TLAbsInputWebFileLocation)ObjectUtils.DeserializeObject(br);
            Offset = br.ReadInt32();
            Limit = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Location, bw);
            bw.Write(Offset);
            bw.Write(Limit);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (Upload.TLWebFile)ObjectUtils.DeserializeObject(br);
        }
    }
}
