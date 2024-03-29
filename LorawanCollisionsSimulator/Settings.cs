﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorawanCollisionsSimulator
{
    

    static class Settings
	{
		public static uint Rx1PeriodS = 1;
		public static uint Rx2PeriodS = Rx1PeriodS + 1;

		public static bool IsConfirmed = false;

		public static uint EndNodesCount = 15;

		public static uint SimulateLengthMs = MS_IN_HOUR * 2;

		public static uint ChannelsCount = 7;

		public static uint PacketsPerHour = 12;

		public static uint PacketPayloadSizeBytes = 12;

		// 13 = 12.25 (sym) Preamble (From LoraModem Calculator)
		// 4 = 2 + 2 (PHDR + PHDR CRC)
		// 1 MHDR
		// 4 DevAddr
		// 1 FCtrl
		// 2 FCnt
		// 1 FPort
		// 4 MIC
		// 2 - Total CRC
		public static uint PacketHeaderSizeBytes = 13 + 4 + 1 + 4 + 1 + 2 + 1 + 4 + 2;

		public static bool IsRx1GatewayEnabled = true;
		public static bool IsRx2GatewayEnabled = true;

		/// <summary>
		/// Длительность передачи одного байта, с
		/// </summary>
		public static uint OneByteTransmitTimeUs;

		public const uint SF_MIN = 7;
		public const uint SF_MAX = 12;
		public const uint SF_DEFAULT = SF_MAX;

        public const uint MS_IN_HOUR = 60 * 60 * 1000;

        public static uint GetPacketsCountFromOneNode()
        {
            float hours = (float)SimulateLengthMs / (float)MS_IN_HOUR;
            float totalPacketsFromOneNode = (float)Settings.PacketsPerHour * hours;
            return (uint)totalPacketsFromOneNode;
        }
        public static uint GetTotalPacketsCount()
        {
            float totalPackets = GetPacketsCountFromOneNode() * (float)Settings.EndNodesCount;
            return (uint)totalPackets;
        }
	}
}
