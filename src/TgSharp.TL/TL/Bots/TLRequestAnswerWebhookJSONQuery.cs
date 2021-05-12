using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Bots
{
    [TLObject(-434028723)]
    public class TLRequestAnswerWebhookJSONQuery : TLMethod<bool>
    {
        public override int Constructor
        {
            get
            {
                return -434028723;
            }
        }

        public long QueryId { get; set; }
        public TLDataJSON Data { get; set; }
        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            QueryId = br.ReadInt64();
            Data = (TLDataJSON)ObjectUtils.DeserializeObject(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(QueryId);
            ObjectUtils.SerializeObject(Data, bw);
        }

        protected override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);
        }
    }
}
