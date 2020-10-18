using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
	struct TransmissionLog
	{
		public uint StartMs;
		public uint EndMs;

		/// <summary>
		/// Номер канала, на котором велась передача
		/// </summary>
		public uint ChannelNumber;

		/// <summary>
		/// Равен true, если во время передачи пакета БС не вела передачу данных
		/// </summary>
		public bool IsPacketCanBeListenByGateway;

		/// <summary>
		/// Равен true, если пакет попал в коллизию с другим конечным устройством
		/// </summary>
		public bool IsPacketCollisionsWithOtherEndNodes;
	}

	interface IEndNode
	{
		TransmissionLog[] GetTransmissionLog();

		uint GetOnePacketTransmitTimeMs();
	}
}
