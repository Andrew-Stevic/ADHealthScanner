using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHealthScanner.Core.Models
{
    /// <summary>
    /// Represents the overall health score for a scan.
    /// </summary>
    public class HealthScore
{
        /// <summary>
        /// Overall health score as a percentage (0-100).
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Health level based on the score.
        /// </summary>
        public ScoreLevel Level { get; set; }

        /// <summary>
        /// Count of Critical severity findings.
        /// </summary>
        public int CriticalCount { get; set; }

        /// <summary>
        /// Count of High severity findings.
        /// </summary>
        public int HighCount { get; set; }

        /// <summary>
        /// Count of Medium severity findings.
        /// </summary>
        public int MediumCount { get; set; }

        /// <summary>
        /// Count of Low severity findings.
        /// </summary>
        public int LowCount { get; set; }

        /// <summary>
        /// When this score was calculated.
        /// </summary>
        public DateTime CalculatedAt { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// Color-coded health levels.
    /// </summary>summary>
    public enum ScoreLevel
    {
        /// <summary>
        /// Poor health (0-59: Critical issues).
        /// </summary>
        Red,
        /// <summary>
        /// Fair health (60-79: Attention needed).
        /// </summary>
        Yellow,
        /// <summary>
        /// Good health (80-100: Healthy).
        /// </summary>
        Green
    }
}
