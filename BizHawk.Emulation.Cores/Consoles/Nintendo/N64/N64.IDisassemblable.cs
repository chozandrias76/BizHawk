﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using BizHawk.Emulation.Common;

namespace BizHawk.Emulation.Cores.Nintendo.N64
{
	public partial class N64 : IDisassemblable
	{
		public string Cpu
		{
			get { return "R4300"; }
			set { }
		}

		public IEnumerable<string> AvailableCpus
		{
			get
			{
				yield return "R4300";
			}
		}

		public string PCRegisterName
		{
			get { return "PC"; }
		}

		public string Disassemble(MemoryDomain m, uint addr, out int length)
		{
			length = 4; // TODO: is this right?
			var instruction = m.PeekWord(addr, true);

			var result = api.m64p_decode_op((uint)instruction, (int)addr);
			var strResult = Marshal.PtrToStringAnsi(result);

			return strResult;
		}
	}
}
