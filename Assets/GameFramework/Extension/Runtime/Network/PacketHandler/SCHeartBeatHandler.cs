using GameFramework.Network;

namespace UnityGameFramework.Runtime.Extension
{
    public class SCHeartBeatHandler : PacketHandlerBase
    {
        public override int Id => 0;

        public override void Handle(object sender, Packet packet)
        {
            SCHeartBeat packetImpl = (SCHeartBeat) packet;
            Log.Info("Receive heartbeat packet, id '{0}'.", packetImpl.Id);
        }
    }
}