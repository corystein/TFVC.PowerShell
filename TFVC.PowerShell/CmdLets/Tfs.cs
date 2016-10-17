using System;
using System.Management.Automation;

namespace TFVC.PowerShell
{
	/// <summary>
	/// Connect tfs.
	/// </summary>
	[Cmdlet (VerbsCommunications.Connect, "Tfs")]
	public class ConnectTfs : Cmdlet
	{
		#region Parameters
		/// <summary>
		/// Gets or sets the URI.
		/// </summary>
		/// <value>The URI.</value>
		[ValidateNotNull]
		[Parameter (Position=0,Mandatory = true,HelpMessage="Enter a Uri")]
		public string Uri {
			get { return uri; }
			set { uri = value; }
		}
		private string uri;
		#endregion

		/// <summary>
		/// Processes the record.
		/// </summary>
		protected override void ProcessRecord ()
		{
			WriteObject ($"Connect to [{uri}]");
		}
	}

	/// <summary>
	/// Disconnect tfs.
	/// </summary>
	[Cmdlet (VerbsCommunications.Disconnect, "Tfs")]
	public class DisconnectTfs : Cmdlet
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[Parameter (Mandatory = true)]
		public string Name {
			get { return name; }
			set { name = value; }
		}
		private string name;

		/// <summary>
		/// Processes the record.
		/// </summary>
		protected override void ProcessRecord ()
		{
			WriteObject ("Hello " + name + "!");
		}
	}

	/// <summary>
	/// New workspace.
	/// </summary>
	[Cmdlet (VerbsCommon.New, "Workspace")]
	public class NewWorkspace : Cmdlet
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[Parameter (Mandatory = true)]
		public string Name {
			get { return name; }
			set { name = value; }
		}
		private string name;

		/// <summary>
		/// Processes the record.
		/// </summary>
		protected override void ProcessRecord ()
		{
			WriteObject ("Hello " + name + "!");
		}
	}

	/// <summary>
	/// New mapping.
	/// </summary>
	[Cmdlet (VerbsCommon.New, "Mapping")]
	public class NewMapping : Cmdlet
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[Parameter (Mandatory = true)]
		public string Name {
			get { return name; }
			set { name = value; }
		}
		private string name;

		/// <summary>
		/// Processes the record.
		/// </summary>
		protected override void ProcessRecord ()
		{
			WriteObject ("Hello " + name + "!");
		}
	}

	/// <summary>
	/// Get items.
	/// </summary>
	[Cmdlet (VerbsCommon.Get, "Items")]
	public class GetItems : Cmdlet
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[Parameter (Mandatory = true)]
		public string Name {
			get { return name; }
			set { name = value; }
		}
		private string name;

		/// <summary>
		/// Processes the record.
		/// </summary>
		protected override void ProcessRecord ()
		{
			WriteObject ("Hello " + name + "!");
		}
	}

    [Cmdlet("Exist", "Items")]
    public class ExistWorkspace : Cmdlet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Mandatory = true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name;

        /// <summary>
        /// Processes the record.
        /// </summary>
        protected override void ProcessRecord()
        {
            WriteObject("Hello " + name + "!");
        }
    }
}
