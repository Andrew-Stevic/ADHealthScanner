namespace ADHealthScanner.Core.Configuration
{
    /// <summary>
    /// Configuration settings for an Active Directory health scan.
    /// </summary>
    public class ScanConfiguration
    {
        /// <summary>
        /// Client Information
        /// </summary>
        public ClientInfo Client { get; set; } = new();

        /// <summary>
        /// Threshold values for various checks.
        /// </summary>
        public Thresholds Thresholds { get; set; } = new();

        /// <summary>
        /// Module enabled/disabled settings.
        /// </summary>
        public ModuleSettings Modules { get; set; } = new();

        /// <summary>
        /// Output generation settings.
        /// </summary>
        public OutputSettings Output { get; set; } = new();
    }

    /// <summary>
    /// Client information for the scan.
    /// </summary>
    public class ClientInfo
    {
        public string Name { get; set; } = "Unknown Client";

        /// <summary>
        /// Optional logo path
        /// </summary>
        public string? LogoPath { get; set; }

    }

    /// <summary>
    /// Module enabled/disabled settings.
    /// </summary>
    public class ModuleSettings
    {
        /// <summary>
        /// Enable Active Directory Health Checks
        /// </summary>
        public bool ActiveDirectory { get; set; } = true;

        /// <summary>
        /// Enable DNS Health Checks
        /// </summary>
        public bool DNS { get; set; } = false;

        /// <summary>
        /// Enable DHCP Health Checks
        /// </summary>
        public bool DHCP { get; set; } = false;
    }

    /// <summary>
    /// Output generation settings.
    /// </summary>
    public class OutputSettings
    {
        ///<summary>
        /// Generate PDF Report
        /// </summary>
        public bool GeneratePdf { get; set; } = true;

        /// <summary>
        /// Generate HTML Report
        /// </summary>
        public bool GenerateHtml { get; set; } = true;

        /// <summary>
        /// Generate CSV Report
        /// </summary>
        public bool GenerateCSV { get; set; } = false;

        /// <summary>
        /// Create ZIP Archive of Reports
        /// </summary>
        public bool CreateZipArchive { get; set; } = true;

        /// <summary>
        /// Directory to save output reports
        /// </summary>
        public string OutputDirectory { get; set; } = "./Reports";
    }
    /// <summary>
    /// Threshold values for health checks.
    /// </summary>
    public class Thresholds
    {
        /// <summary>
        /// Number of days before a computer account is considered stale.
        /// </summary>
        public int StaleComputerDays { get; set; } = 90;

        /// <summary>
        /// Number of days before a user account is considered stale.
        /// </summary>
        public int StaleUserDays { get; set; } = 180;

        /// <summary>
        /// Time synchronization threshold in minutes.
        /// </summary>
        public int TimeSyncToleranceMinutes { get; set; } = 5;

        /// <summary>
        /// Tombstone lifetime threshold warning in days
        /// </summary>
        public int TombstoneLifetimeWarningDays { get; set; } = 180;

        /// <summary>
        /// Threshold for empty OUs (0 = flag any empty OU).
        /// </summary>
        public int EmptyOUTreshold { get; set; } = 0;

        /// <summary>
        /// GPO count warning threshold.
        /// </summary>
        public int GpoCountWarning { get; set; } = 100;

        /// <summary>
        /// Creates default thresholds.
        /// </summary>
        public static Thresholds Default => new();
    }
}
