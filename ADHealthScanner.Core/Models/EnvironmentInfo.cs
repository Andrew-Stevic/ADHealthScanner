using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHealthScanner.Core.Models
{
    /// <summary>
    /// Represents information about the Active Directory environment being scanned.
    /// </summary>
    public class EnvironmentInfo
    {
        /// <summary>
        /// DNS name of the domain.
        /// </summary>
        public string DomainName { get; set; } = string.Empty;

        /// <summary>
        /// DNS name of the forest.
        /// </summary>
        public string ForestName { get; set; } = string.Empty;

        /// <summary>
        /// Number of domain controllers in domain.
        /// </summary>
        public int DomainControllerCount { get; set; }

        /// <summary>
        /// list of domain controller names.
        /// </summary>
        public string[] DomainControllers { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Forest functional level.
        /// </summary>
        public string ForestFunctionalLevel { get; set; } = string.Empty;

        /// <summary>
        /// Domain functional level.
        /// </summary>
        public string DomainFunctionalLevel { get; set; } = string.Empty;
    }
}
