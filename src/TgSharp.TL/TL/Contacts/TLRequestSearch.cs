using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Contacts
{
    [TLObject(301470424)]
    public class TLRequestSearch : TLMethod<Contacts.TLFound>
    {
        public override int Constructor
        {
            get
            {
                return 301470424;
            }
        }

        public string Q { get; set; }
        public int Limit { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Q = StringUtil.Deserialize(br);
            Limit = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Q, bw);
            bw.Write(Limit);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (Contacts.TLFound)ObjectUtils.DeserializeObject(br);
        }
    }
}
