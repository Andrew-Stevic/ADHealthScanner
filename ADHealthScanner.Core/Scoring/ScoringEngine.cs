using ADHealthScanner.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHealthScanner.Core.Scoring
{
    /// <summary>
    /// Calculates health scores based on scan findings.
    /// </summary>
    public class ScoringEngine

    {
        /// <summary>
        /// Calculates overall health score.
        /// </summary>
        /// <param name="="findings">List of health findings to score</param>
        /// <returns>Calculated health score</returns>
        public HealthScore CalculateScore(List<HealthFinding> findings)
        {
            var score = new HealthScore
            {
                Score = 100
            };

            // Process each finding
            foreach (var finding in findings)
            {
                // Deducts points based on severity and effort
                var deduction = CalculateDeduction(finding.Severity, finding.Effort);
                score.Score = Math.Max(0, score.Score - deduction);

                // Count by severity
                switch (finding.Severity)
                {
                    case Severity.Critical:
                        score.CriticalCount++;
                        break;
                    case Severity.High:
                        score.HighCount++;
                        break;
                    case Severity.Medium:
                        score.MediumCount++;
                        break;
                    case Severity.Low:
                        score.LowCount++;
                        break;
                }
            }

            // Determine score level based on final score
            score.Level = DetermineScoreLevel(score.Score);
            score.CalculatedAt = DateTime.Now;

            return score;
        }

        /// <summary>
        /// Calcuates point deduction
        /// </summary>
        /// <param name="severity">Finding severity</param>
        /// <param name="effort">Remediation effort</param>
        /// <returns>Points to deduct</returns>
        private int CalculateDeduction(Severity severity, RemediationEffort effort)
        {
            return (severity, effort) switch
            {
                (Severity.Critical, RemediationEffort.Hard) => 15,
                (Severity.Critical, RemediationEffort.Medium) => 10,
                (Severity.Critical, RemediationEffort.Easy) => 8,
                (Severity.High, RemediationEffort.Hard) => 8,
                (Severity.High, RemediationEffort.Medium) => 5,
                (Severity.High, RemediationEffort.Easy) => 3,
                (Severity.Medium, _) => 2,
                (Severity.Low, _) => 1,
                _ => 0
            };
        }

        /// <summary>
        /// Determines score level based on numeric score
        /// </summary>
        /// <param name="score">Numeric Score (0-100)</param>
        /// <returns> Score Level (Red/Yellow?Green)</returns>
        private ScoreLevel DetermineScoreLevel(int score)
        {
            return score switch
            {
                >= 90 => ScoreLevel.Green,
                >= 60 => ScoreLevel.Yellow,
                _ => ScoreLevel.Red
            };
        }
    }
}
