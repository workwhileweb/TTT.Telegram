using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(363700068)]
    public class TLRequestSetInlineGameScore : TLMethod<bool>
    {
        public override int Constructor
        {
            get
            {
                return 363700068;
            }
        }

        public int Flags { get; set; }
        public bool EditMessage { get; set; }
        public bool Force { get; set; }
        public TLInputBotInlineMessageID Id { get; set; }
        public TLAbsInputUser UserId { get; set; }
        public int Score { get; set; }
        

        public void ComputeFlags()
        {
            Flags = 0;
Flags = EditMessage ? (Flags | 1) : (Flags & ~1);
Flags = Force ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            EditMessage = (Flags & 1) != 0;
            Force = (Flags & 2) != 0;
            Id = (TLInputBotInlineMessageID)ObjectUtils.DeserializeObject(br);
            UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            Score = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Id, bw);
            ObjectUtils.SerializeObject(UserId, bw);
            bw.Write(Score);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);
        }
    }
}
