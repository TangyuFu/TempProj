using System;
using GameFramework.Network;

namespace UnityGameFramework.Runtime.Extension
{
    public class SCPacketHandler : PacketHandlerBase
    {
        public override int Id => 0;

        public override void Handle(object sender, Packet packet)
        {
            SCPacket packetImpl = (SCPacket) packet;
            Log.Info("Receive packet, data: '{0}'.",
                packetImpl.Data != null ? BitConverter.ToString(packetImpl.Data) : "");
        }
    }
}