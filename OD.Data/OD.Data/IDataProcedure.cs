using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OD.Data
{
	public interface IDataProcedure
	{
		string Procedure { get; }

		int Execute();
	}
}
