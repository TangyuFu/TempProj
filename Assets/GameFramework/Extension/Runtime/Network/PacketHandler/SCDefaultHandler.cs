using System;
using GameFramework.Network;

namespace UnityGameFramework.Runtime.Extension
{
    public class SCDefaultHandler : PacketHandlerBase
    {
        public override int Id => 1;

        public override void Handle(object sender, Packet packet)
        {
            SCDefault packetImpl = (SCDefault) packet;
            Log.Info("Receive default packet, id: '{0}', data: '{1}'.",
                packetImpl.Id,
                packetImpl.Data != null ? BitConverter.ToString(packetImpl.Data) : "");
        }
    }
}