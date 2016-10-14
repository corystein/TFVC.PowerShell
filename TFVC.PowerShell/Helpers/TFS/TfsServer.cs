using System;
namespace TFVC.PowerShell
{
	/// <summary>
	/// Tfs server.
	/// </summary>
	public class TfsServer
	{
		#region Private Propeties
		#endregion

		#region Public Properties
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="T:TFVC.PowerShell.TfsServer"/> class.
		/// </summary>
		public TfsServer ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:TFVC.PowerShell.TfsServer"/> class.
		/// </summary>
		/// <param name="uri">URI.</param>
		public TfsServer (string uri)
		{
		}

		/// <summary>
		/// Connect the specified uri.
		/// </summary>
		/// <param name="uri">URI.</param>
		public bool Connect (string uri)
		{
			return true;
		}
	}
}
