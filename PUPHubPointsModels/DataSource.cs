using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubModels
{
    [Serializable]
    public enum DataSource
    {
        InMemory,
        InJsonFile,
        Database
    }
}
