using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHealthScanner.Core.Models
{
    /// <summary>
    /// Represents a singl health check finding (issue or observation).
    /// </summary>
    public class HealthFinding
    {
        /// <summary>
        /// Unique identifier for this finding.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Short titel describing the finding.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Detailed description of the issue or observation.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Category this finding belongs to.
        /// </summary>
        public FindingCategory Category { get; set; }

        /// <summary>
        /// How severe/important this finding is.
        /// </summary>
        public Severity Severity { get; set; }

        /// <summary>
        /// How much effort is required to remediate this finding.
        /// </summary>
        public RemediationEffort Effort { get; set; }

        /// <summary>
        /// Risk level of attempting remediation.
        /// </summary>
        public RemediationRisk Risk { get; set; }

        /// <summary>
        /// Supporting evidence for this finding. (e.g., sever names, counts, timestamps, etc.)
        /// </summary>
        public string[] Evidence { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Recommended action to resolve this finding.
        /// </summary>
        public string RecommendedAction { get; set; } = string.Empty;

        /// <summary>
        /// When this finding was discovered.
        /// </summary>
        public DateTime DiscoveredAt { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// Categories for grouping health check findings.
    /// </summary>
    public enum  FindingCategory
    {
        Replication,
        FSMO,
        Configuration,
        Hygiene,
        Security,
        GroupPolicy,
        Database        
    }

    /// <summary>
    /// Severity Levels for findings.
    /// </summary>
    public enum  Severity
    {
        Low,
        Medium,
        High,
        Critical
    }

    /// <summary>
    /// Effort required to remediate a finding.
    /// </summary>
    public enum RemediationEffort
    {
        Easy,
        Medium,
        Hard
    }

    /// <summary>
    /// Risk level of remediation causing issues.
    /// </summary>
    public enum RemediationRisk
    {
        Low,
        Medium,
        High
    }
}

