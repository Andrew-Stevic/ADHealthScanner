using ADHealthScanner.Core.Models;
using ADHealthScanner.Core.Scoring;

Console.WriteLine("AD Health Scanner - Scoring Engine Test");
Console.WriteLine("========================================");
Console.WriteLine();

// Create some mock findings
var findings = new List<HealthFinding>
{
    new HealthFinding
    {
        Title = "AD Replication Failure",
        Description = "Replication failing between DC01 and DC02",
        Category = FindingCategory.Replication,
        Severity = Severity.Critical,
        Effort = RemediationEffort.Hard,
        Risk = RemediationRisk.Medium,
        Evidence = new[] { "Last success: 2025-11-26", "Consecutive failures: 12" },
        RecommendedAction = "Check network connectivity between DCs"
    },
    new HealthFinding
    {
        Title = "Stale Computer Accounts",
        Description = "347 computer accounts have not logged in for over 90 days",
        Category = FindingCategory.Hygiene,
        Severity = Severity.Medium,
        Effort = RemediationEffort.Easy,
        Risk = RemediationRisk.Medium,
        Evidence = new[] { "Total stale accounts: 347", "Oldest: 547 days" },
        RecommendedAction = "Review and disable/delete inactive accounts"
    },
    new HealthFinding
    {
        Title = "Service Account in Domain Admins",
        Description = "Service account 'svc_backup' is member of Domain Admins group",
        Category = FindingCategory.Security,
        Severity = Severity.High,
        Effort = RemediationEffort.Medium,
        Risk = RemediationRisk.Medium,
        Evidence = new[] { "Account: svc_backup", "Group: Domain Admins" },
        RecommendedAction = "Remove from DA group, use least-privilege service account"
    },
    new HealthFinding
    {
        Title = "Empty Organizational Units",
        Description = "12 OUs contain no objects",
        Category = FindingCategory.Hygiene,
        Severity = Severity.Low,
        Effort = RemediationEffort.Easy,
        Risk = RemediationRisk.Low,
        Evidence = new[] { "Empty OUs: 12" },
        RecommendedAction = "Review and remove unused OUs"
    }
};

Console.WriteLine($"Created {findings.Count} mock findings:");
Console.WriteLine();

foreach (var finding in findings)
{
    Console.WriteLine($"  [{finding.Severity}] {finding.Title}");
    Console.WriteLine($"    Effort: {finding.Effort}, Risk: {finding.Risk}");
    Console.WriteLine();
}

// Calculate score
Console.WriteLine("Calculating health score...");
Console.WriteLine();

var scoringEngine = new ScoringEngine();
var healthScore = scoringEngine.CalculateScore(findings);

// Display results
Console.WriteLine("HEALTH SCORE RESULTS");
Console.WriteLine("====================");
Console.WriteLine($"Overall Score: {healthScore.Score}/100");
Console.WriteLine($"Status Level:  {healthScore.Level}");
Console.WriteLine();

Console.WriteLine("Finding Breakdown:");
Console.WriteLine($"  Critical: {healthScore.CriticalCount}");
Console.WriteLine($"  High:     {healthScore.HighCount}");
Console.WriteLine($"  Medium:   {healthScore.MediumCount}");
Console.WriteLine($"  Low:      {healthScore.LowCount}");
Console.WriteLine();

Console.WriteLine($"Calculated at: {healthScore.CalculatedAt}");
Console.WriteLine();

// Show expected calculation
Console.WriteLine("Expected Calculation:");
Console.WriteLine("  Start:              100");
Console.WriteLine("  Critical + Hard:    -15  (85)");
Console.WriteLine("  Medium + Easy:       -2  (83)");
Console.WriteLine("  High + Medium:       -5  (78)");
Console.WriteLine("  Low + Easy:          -1  (77)");
Console.WriteLine("  Final Score:         77 (Yellow)");

return 0;
