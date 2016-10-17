using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;

namespace TFVC.PowerShell.Helpers.TFS
{
    public class TfsVersionControl
    {
        public bool CreateWorkspace(TfsTeamProjectCollection collection)
        {
            try
            {
                VersionControlServer versionControlServer = collection.GetService<VersionControlServer>();


                // Create a temporary workspace2.
                //workspace = versionControl.CreateWorkspace(workspaceName, versionControl.AuthorizedUser);

                // For this workspace, map a server folder to a local folder              
                //ReCreateWorkSpaceMappings(workspace);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateMapping(VersionControlServer vcs)
        {
            return true;
        }

        public bool GetItems(VersionControlServer vcs)
        {
            //var items = sourceControl.GetItems("$/Project/Path/subpath" / et cetera", VersionSpec.Latest, RecursionType.Full).Items.Where(x => x.ItemType == ItemType.File).ToList();

            return true;
        }
    }//End of class
}//End of namespace
