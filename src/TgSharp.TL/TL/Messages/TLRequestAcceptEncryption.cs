using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(1035731989)]
    public class TLRequestAcceptEncryption : TLMethod<TLAbsEncryptedChat>
    {
        public override int Constructor
        {
            get
            {
                return 1035731989;
            }
        }

        public TLInputEncryptedChat Peer { get; set; }
        public byte[] GB { get; set; }
        public long KeyFingerprint { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLInputEncryptedChat)ObjectUtils.DeserializeObject(br);
            GB = BytesUtil.Deserialize(br);
            KeyFingerprint = br.ReadInt64();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            BytesUtil.Serialize(GB, bw);
            bw.Write(KeyFingerprint);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsEncryptedChat)ObjectUtils.DeserializeObject(br);
        }
    }
}
