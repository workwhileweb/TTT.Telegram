using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-148247912)]
    public class TLRequestAcceptUrlAuth : TLMethod<TLAbsUrlAuthResult>
    {
        public override int Constructor
        {
            get
            {
                return -148247912;
            }
        }

        public int Flags { get; set; }
        public bool WriteAllowed { get; set; }
        public TLAbsInputPeer Peer { get; set; }
        public int MsgId { get; set; }
        public int ButtonId { get; set; }
        

        public void ComputeFlags()
        {
            Flags = 0;
Flags = WriteAllowed ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            WriteAllowed = (Flags & 1) != 0;
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            MsgId = br.ReadInt32();
            ButtonId = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(MsgId);
            bw.Write(ButtonId);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUrlAuthResult)ObjectUtils.DeserializeObject(br);
        }
    }
}
