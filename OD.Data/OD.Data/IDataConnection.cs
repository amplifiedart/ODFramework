using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OD.Data
{
	/// <summary>
	/// Contract for a connection to a Data Provider
	/// </summary>
	public interface IDataConnection
	{
		/// <summary>
		/// Opens the continuous connection.
		/// </summary>
		void OpenContinuousConnection();

		/// <summary>
		/// Closes the continuous connection.
		/// </summary>
		void CloseContinuousConnection();

		/// <summary>
		/// Gets a value indicating whether this instance is a continuous connection.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is continuous connection; otherwise, <c>false</c>.
		/// </value>
		bool IsContinuousConnection { get; }
	}
}
