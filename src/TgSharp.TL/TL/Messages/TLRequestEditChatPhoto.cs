using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-900957736)]
    public class TLRequestEditChatPhoto : TLMethod<TLAbsUpdates>
    {
        public override int Constructor
        {
            get
            {
                return -900957736;
            }
        }

        public int ChatId { get; set; }
        public TLAbsInputChatPhoto Photo { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
            Photo = (TLAbsInputChatPhoto)ObjectUtils.DeserializeObject(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);
            ObjectUtils.SerializeObject(Photo, bw);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}
