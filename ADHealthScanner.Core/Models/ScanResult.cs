using ADHealthScanner.Core.Configuration;

namespace ADHealthScanner.Core.Models
{
    /// <summary>
    /// Represents the complete result of a health scan.
    /// Contains all findings, scoring, and metadata.
    /// </summary>
    public class ScanResult
    {
        /// <summary>
        /// Information about the scanned Active Directory environment.
        /// </summary>
        public string ScanId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// When the scan started.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary
        /// When the scan ended.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// How long the scan took.
        /// </summary>
        public TimeSpan Duration => EndTime != default ? EndTime - StartTime : TimeSpan.Zero;

        /// <summary>
        /// Configuration used for this scan.
        /// </summary>
        public ScanConfiguration Configuration { get; set; } = new();

        /// <summary>
        /// Overall health score.
        /// </summary>
        public HealthScore Score { get; set; } = new();

        /// <summary>
        /// All fiundings discovered during the scan.
        /// </summary>
        public List<HealthFinding> Findings { get; set; } = new();

        /// <summary>
        /// Information about the AD environment scanned.
        /// </summary>
        public EnvironmentInfo Environment { get; set; } = new();
    }
}
