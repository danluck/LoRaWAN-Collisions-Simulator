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
	class GateWay
	{
		public TimeTx[] GetGatewayTx(IEndNode[] endNodes)
		{
			if (Settings.IsConfirmed)
			{
				// #TODO Рассчитать время передачи
				var timeTx = new TimeTx[1];
				timeTx[0].StartMs = 0;
				timeTx[0].EndMs = 0;
				return timeTx;
			}
			else
			{
				var timeTx = new TimeTx[1];
				timeTx[0].StartMs = 0;
				timeTx[0].EndMs = 0;
				return timeTx;
			}
		}
	}
}
