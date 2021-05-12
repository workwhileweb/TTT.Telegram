using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(-841733627)]
    public class TLRequestBindTempAuthKey : TLMethod<bool>
    {
        public override int Constructor
        {
            get
            {
                return -841733627;
            }
        }

        public long PermAuthKeyId { get; set; }
        public long Nonce { get; set; }
        public int ExpiresAt { get; set; }
        public byte[] EncryptedMessage { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PermAuthKeyId = br.ReadInt64();
            Nonce = br.ReadInt64();
            ExpiresAt = br.ReadInt32();
            EncryptedMessage = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(PermAuthKeyId);
            bw.Write(Nonce);
            bw.Write(ExpiresAt);
            BytesUtil.Serialize(EncryptedMessage, bw);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);
        }
    }
}
