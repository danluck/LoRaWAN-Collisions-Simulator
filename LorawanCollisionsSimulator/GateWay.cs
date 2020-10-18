using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
	/// <summary>
	/// Имитирует работу БС
	/// В случае отправки подтверждений задействуется 2 приемных окна
	/// </summary>
	class Gateway
	{
		public Gateway()
		{
			_transmissionLog = new List<TransmissionLog>();
		}

		public List<TransmissionLog> GetGatewayTx(IEndNode[] endNodes)
		{
			if (Settings.IsConfirmed)
			{
				// #TODO Рассчитать время передачи исходя из знания о том,
				// что некоторые пакеты от конечных устройств будут пропущены,
				// пока БС занята передачей

				for (uint i = 0; i < endNodes.Length; i++)
				{
					var endNode = endNodes[i];
					var endNodeTransmissionTimes = endNode.GetTransmissionLog();
				}
				
				return _transmissionLog;
			}
			else
			{
				// В режиме приема без подтверждения БС не может
				// "пропустить" пакет, т.к. всегда находится в режиме прослушивания
				return _transmissionLog;
			}
		}

		private List<TransmissionLog> _transmissionLog;
	}
}
