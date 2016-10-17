using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;

namespace TFVC.PowerShell
{
	/// <summary>
	/// Tfs server.
	/// </summary>
	public class TfsServer : IDisposable
    {
		#region Private Propeties
	    private string _Uri;
        private string _Collection = "DefaultCollection";
        private string _Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        private string _Password;
        private bool _isConnected;
	    private TfsTeamProjectCollection _TfsTeamProjectCollection;
        private TfsConfigurationServer _TfsConfigurationServer;
        private VersionControlServer _VersionControlServer;
        #endregion

        #region Public Properties
        public string Uri { get { return _Uri; }  }
        public string Collection { get { return _Collection; } }
        public string Username { get { return _Username; } }
        public bool IsConnected { get { return _isConnected; } }
        public TfsTeamProjectCollection TfsTeamProjectCollection { get { return _TfsTeamProjectCollection; } }
        #endregion

        #region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:TFVC.PowerShell.TfsServer"/> class.
		/// </summary>
		/// <param name="uri">URI.</param>
		public TfsServer (string uri)
		{
		    try
		    {
		        Connect(uri);
		    }
		    catch (Exception ex)
		    {
		        throw ex;
		    }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
	    public TfsServer(string uri, string username, string password)
        {
            try
            {
                NetworkCredential nc = new NetworkCredential(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

	    ~TfsServer()
	    {
            // The object went out of scope and finalized is called
            // Lets call dispose in to release unmanaged resources 
            // the managed resources will anyways be released when GC 
            // runs the next time.
            Dispose(false);
        }
        #endregion

        #region Public Methods
        public void Dispose()
        {
            // If this function is being called the user wants to release the
            // resources. lets call the Dispose which will do this for us.
            Dispose(true);

            // Now since we have done the cleanup already there is nothing left
            // for the Finalizer to do. So lets tell the GC not to call it later.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                //someone want the deterministic release of all resources
                //Let us release all the managed resources
                _TfsTeamProjectCollection.Dispose();
            }
            else
            {
                // Do nothing, no one asked a dispose, the object went out of
                // scope and finalized is called so lets next round of GC 
                // release these resources
            }

            // Release the unmanaged resource in any case as they will not be 
            // released by GC
            _TfsTeamProjectCollection.Dispose();
        }

        /// <summary>
        /// Connect the specified uri.
        /// </summary>
        /// <param name="uri">URI.</param>
        public bool Connect (string uri)
		{
		    try
		    {
                #region Set TFS Uri
                Uri TfsUri = new Uri(uri);
                _Uri = TfsUri.ToString();
                #endregion

                #region Initialize TFS Collection
                TfsTeamProjectCollection collection =
                    new TfsTeamProjectCollection(TfsUri);

                collection.EnsureAuthenticated();
                #endregion

                #region Ensure connection and set internal objects
                if (collection.HasAuthenticated)
		        {
		            _Uri = collection.ConfigurationServer.Uri.ToString();

		            _isConnected = collection.ConfigurationServer.HasAuthenticated;

		            _TfsTeamProjectCollection = collection;
		            _TfsConfigurationServer = collection.ConfigurationServer;
		            _VersionControlServer = collection.GetService<VersionControlServer>();

		            _Collection = GetCollectionName(collection.InstanceId.ToString());

		            return true;
		        }
		        else
		        {
		            return false;
		        }
                #endregion

            }
		    catch
		    {
		        return false;
		    }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Connect(string uri, string username, string password)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<KeyValuePair<Guid, String>> GetCollections()
        {
            //ApplicationLogger.Log("Entered into GetCollections() : ");
            var collectionList = new List<KeyValuePair<Guid, String>>();
            try
            {
                _TfsConfigurationServer.Authenticate();

                ReadOnlyCollection<CatalogNode> collectionNodes = _TfsConfigurationServer.CatalogNode.QueryChildren(
                    new[] { CatalogResourceTypes.ProjectCollection },
                    false,
                    CatalogQueryOptions.None);
                foreach (CatalogNode collectionNode in collectionNodes)
                {
                    var collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
                    TfsTeamProjectCollection teamProjectCollection =
                        _TfsConfigurationServer.GetTeamProjectCollection(collectionId);

                    if (teamProjectCollection == null)
                        continue;

                    collectionList.Add(new KeyValuePair<Guid, String>(collectionId, teamProjectCollection.Name));
                }
            }
            catch (Exception e)
            {
                //ApplicationLogger.Log(e);
            }

            return collectionList;
        }
        #endregion

        #region Private Methods

	    private string GetCollectionName(string instanceId)
	    {
	        string collectionName = "DefaultCollection";

            // Get the catalog of team project collections
            ReadOnlyCollection<CatalogNode> collectionNodes = _TfsConfigurationServer.CatalogNode.QueryChildren(
                new[] { CatalogResourceTypes.ProjectCollection },
                false, CatalogQueryOptions.None);

            // List the team project collections
	        //foreach (CatalogNode collectionNode in collectionNodes)
	        //{
	            // Use the InstanceId property to get the team project collection
	            Guid collectionId = new Guid(instanceId);
	            TfsTeamProjectCollection teamProjectCollection =
	                _TfsConfigurationServer.GetTeamProjectCollection(collectionId);

	            // Print the name of the team project collection
	            //Console.WriteLine("Collection: " + teamProjectCollection.Name);
	            collectionName = teamProjectCollection.Name.Replace(teamProjectCollection.DisplayName, "").Remove(0,1);

	        //}

	        return collectionName;
	    }
        #endregion  

    }
}
