using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Contacts
{
    [TLObject(-176409329)]
    public class TLRequestGetBlocked : TLMethod<Contacts.TLAbsBlocked>
    {
        public override int Constructor
        {
            get
            {
                return -176409329;
            }
        }

        public int Offset { get; set; }
        public int Limit { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Offset = br.ReadInt32();
            Limit = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Offset);
            bw.Write(Limit);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (Contacts.TLAbsBlocked)ObjectUtils.DeserializeObject(br);
        }
    }
}
