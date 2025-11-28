# AD Health Scanner

A comprehensive Active Directory health assessment tool designed for Managed Service Providers (MSPs) and IT professionals.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![PowerShell](https://img.shields.io/badge/PowerShell-5.1+-blue)](https://docs.microsoft.com/en-us/powershell/)

## Project Status

**Current Version:** 0.1.0-alpha (Active Development)

This project is in early development. Features are being actively built and APIs may change.

## Overview

AD Health Scanner is a tool that automates Active Directory infrastructure assessment, providing detailed health reports for:

- Active Directory replication and health
- Domain controller status and FSMO roles
- Security audit (privileged accounts, weak configurations)
- Hygiene checks (stale accounts, empty OUs)
- Group Policy health
- DNS integration (planned - Phase 2)
- DHCP health (planned - Phase 3)

**Built for MSPs:** Designed specifically for client onboarding, routine health checks, and proactive maintenance.

## Features (Planned for v1.0)

- Comprehensive AD health checks
- Multi-format reports (PDF, HTML, CSV)
- Configurable thresholds
- Health scoring system (0-100)
- Baseline tracking for trend analysis
- Single executable deployment
- DNS health checks (Phase 2)
- DHCP health checks (Phase 3)

## Quick Start

### Prerequisites

- Windows Server 2016+ or Windows 10/11
- Domain Admin or equivalent permissions
- PowerShell 5.1 or later
- Active Directory PowerShell module (RSAT)

### Installation

**Option 1: Download Release (Coming Soon)**
```powershell
# Download latest release from GitHub Releases
# Run on domain controller or domain-joined machine
.\ADHealthScanner.exe
```

**Option 2: Build from Source**
```powershell
# Clone repository
git clone https://github.com/andrew-stevic/ADHealthScanner.git
cd ADHealthScanner

# Build
dotnet build

# Run
cd ADHealthScanner.CLI
dotnet run
```

### Configuration

Create `config.json` in the same directory as the executable:

```json
{
  "client": {
    "name": "Your Client Name"
  },
  "thresholds": {
    "staleComputerDays": 90,
    "staleUserDays": 180
  },
  "output": {
    "outputDirectory": "./Reports"
  }
}
```

See `config.example.json` for all available options.

## Sample Output

**Reports Generated:**
- `ClientName_Executive_Summary.pdf` - Client-facing health overview
- `ClientName_Technical_Report.pdf` - Detailed findings for IT staff
- `ClientName_Findings_Raw.csv` - Data export for analysis
- `ClientName_Interactive_Report.html` - Interactive browser-based report
- `ClientName_Baseline.json` - Baseline data for future comparison

All reports packaged in timestamped ZIP file.

## Architecture

**Technology Stack:**
- C# / .NET 8.0
- PowerShell SDK for AD interaction
- Modular architecture (AD, DNS, DHCP modules)
- QuestPDF for PDF generation

**Design Principles:**
- Single responsibility per module
- Easy to extend with new checks
- Configurable and flexible
- Well-documented code

See [Architecture Documentation](docs/architecture.md) for details (coming soon).

## Contributing

Contributions are welcome! This project is in active development.

**How to Contribute:**
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-check`)
3. Commit your changes (`git commit -m 'Add amazing health check'`)
4. Push to the branch (`git push origin feature/amazing-check`)
5. Open a Pull Request

See [CONTRIBUTING.md](CONTRIBUTING.md) for detailed guidelines.

**Areas needing help:**
- Additional health checks
- PowerShell function optimization
- Report template improvements
- Testing on different AD environments
- Documentation

## Documentation

- [Installation Guide](docs/installation.md) (coming soon)
- [Configuration Reference](docs/configuration.md) (coming soon)
- [Development Setup](docs/development-setup.md) (coming soon)
- [PowerShell Functions Reference](docs/powershell-functions.md) (coming soon)

## Roadmap

**Phase 1: Active Directory Module (v1.0)** - Q1 2026
- Core AD health checks
- Report generation
- Configuration system
- Single executable deployment

**Phase 2: DNS Module (v1.1)** - Q2 2026
- DNS zone health
- SRV record validation
- Integration with AD checks

**Phase 3: DHCP Module (v1.2)** - Q2 2026
- Scope utilization
- Failover status
- DHCP option consistency

**Phase 4: Enhancement (v2.0)** - Q3 2026 - Q1 2027
- Multi-domain support
- Historical trending
- Advanced reporting

See [Project Board](https://github.com/andrew-stevic/ADHealthScanner/projects/1) for current progress.

## Known Issues

See [Issues](https://github.com/andrew-stevic/ADHealthScanner/issues) for current bugs and feature requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Disclaimer

**This is a personal project developed independently by Andrew Stevic.**

- Not affiliated with, endorsed by, or sponsored by any employer or organization
- Provided "as is" without warranty of any kind
- Use at your own risk in production environments
- Always test in a lab environment first
- The author is not responsible for any damage or data loss

## Author

**Andrew Stevic**
- GitHub: [@andrew-stevic](https://github.com/andrew-stevic)
- LinkedIn: [Andrew Stevic](https://www.linkedin.com/in/andrew-stevic/)
- Project Contact Email: ADHealthScanner@andrewstevic.com

## Acknowledgments

- Microsoft Active Directory PowerShell module
- The open-source community

## Support

- Report a Bug: https://github.com/andrew-stevic/ADHealthScanner/issues/new?template=bug_report.md
- Request a Feature: https://github.com/andrew-stevic/ADHealthScanner/issues/new?template=feature_request.md
- Discussions: https://github.com/andrew-stevic/ADHealthScanner/discussions



**Star this repository if you find it useful!**