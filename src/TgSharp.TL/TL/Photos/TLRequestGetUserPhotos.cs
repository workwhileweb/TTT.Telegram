using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Photos
{
    [TLObject(-1848823128)]
    public class TLRequestGetUserPhotos : TLMethod<Photos.TLAbsPhotos>
    {
        public override int Constructor
        {
            get
            {
                return -1848823128;
            }
        }

        public TLAbsInputUser UserId { get; set; }
        public int Offset { get; set; }
        public long MaxId { get; set; }
        public int Limit { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            Offset = br.ReadInt32();
            MaxId = br.ReadInt64();
            Limit = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(UserId, bw);
            bw.Write(Offset);
            bw.Write(MaxId);
            bw.Write(Limit);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (Photos.TLAbsPhotos)ObjectUtils.DeserializeObject(br);
        }
    }
}
