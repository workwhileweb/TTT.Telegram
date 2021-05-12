using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(-1907842680)]
    public class TLRequestDropTempAuthKeys : TLMethod<bool>
    {
        public override int Constructor
        {
            get
            {
                return -1907842680;
            }
        }

        public TLVector<long> ExceptAuthKeys { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            ExceptAuthKeys = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(ExceptAuthKeys, bw);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);
        }
    }
}
