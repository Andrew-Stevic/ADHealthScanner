# Contributing to AD Health Scanner

Thank you for your interest in contributing! This project welcomes contributions from the community.

## Project Goals

This tool aims to provide MSPs and IT professionals with comprehensive, automated Active Directory health assessments. Contributions should align with:

- **Accuracy:** Health checks must be reliable and accurate
- **Performance:** Scans should complete in reasonable time (<10 minutes)
- **Usability:** Easy to use, clear reporting
- **Maintainability:** Clean, well-documented code

## Getting Started

### Development Environment

1. **Prerequisites:**
   - Visual Studio 2022 or VS Code
   - .NET 8.0 SDK
   - Git
   - Access to an Active Directory lab environment for testing

2. **Setup:**
   ```bash
   git clone https://github.com/andrew-stevic/ADHealthScanner.git
   cd ADHealthScanner
   dotnet restore
   dotnet build
   ```

3. **Run Tests:**
   ```bash
   dotnet test
   ```

See [Development Setup Guide](docs/development-setup.md) for detailed instructions.

## How to Contribute

### Reporting Bugs

Found a bug? [Open an issue](https://github.com/andrew-stevic/ADHealthScanner/issues/new?template=bug_report.md) with:

- Clear description of the problem
- Steps to reproduce
- Expected vs. actual behavior
- Environment details (OS version, AD functional level)
- Relevant logs or error messages

### Suggesting Features

Have an idea? [Open a feature request](https://github.com/andrew-stevic/ADHealthScanner/issues/new?template=feature_request.md) with:

- Use case description
- Proposed solution
- Alternative approaches considered
- Willingness to implement it yourself

### Submitting Code

**Before you start:**
1. Check existing issues/PRs to avoid duplicating work
2. Comment on an issue to claim it
3. For large changes, open an issue first to discuss

**Pull Request Process:**

1. **Fork and Branch:**
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. **Follow Code Standards:**
   - Use C# naming conventions (PascalCase for classes, camelCase for variables)
   - Add XML documentation comments to public methods
   - Follow existing patterns in the codebase
   - Write PowerShell with approved verbs (Get-, Test-, Set-)

3. **Write Tests:**
   - Unit tests for new health checks
   - Test on real AD environment if possible
   - Update documentation

4. **Commit with Clear Messages:**
   ```bash
   git commit -m "Add replication health check for read-only DCs"
   ```

5. **Push and Create PR:**
   ```bash
   git push origin feature/your-feature-name
   ```
   Then open a Pull Request on GitHub

6. **PR Checklist:**
   - [ ] Code builds without errors
   - [ ] Tests pass
   - [ ] Documentation updated
   - [ ] No sensitive data in commits
   - [ ] Follows existing code style

## Development Guidelines

### Code Style

**C# Code:**
- Use nullable reference types (`string?` for nullables)
- Prefer `async/await` for I/O operations
- Use dependency injection
- Keep methods focused (single responsibility)

**PowerShell Scripts:**
- Use approved verbs: `Get-ADHealth[Component]`
- Include comment-based help
- Return PSCustomObjects for structured data
- Handle errors gracefully (try/catch)

**Example:**
```powershell
function Get-ADHealthReplication {
    <#
    .SYNOPSIS
        Checks Active Directory replication status
    .DESCRIPTION
        Queries all domain controllers and reports replication health
    .EXAMPLE
        Get-ADHealthReplication
    #>
    [CmdletBinding()]
    param()
    
    try {
        # Implementation
    }
    catch {
        Write-Error "Failed to check replication: $_"
        return $null
    }
}
```

### Testing

**Required Testing:**
- Unit tests for C# business logic
- Pester tests for PowerShell functions (optional but encouraged)
- Manual testing on lab AD environment

**Before Submitting:**
- Test on at least one real AD environment
- Verify reports generate correctly
- Check performance (scan completes in reasonable time)

### Documentation

**Update when you:**
- Add new health check → Update PowerShell functions spec
- Change configuration → Update config.example.json
- Add new feature → Update README.md
- Change architecture → Update architecture docs

**In-Code Documentation:**
- XML comments on all public C# methods
- Comment-based help in PowerShell functions
- Inline comments for complex logic

## Project Structure

```
ADHealthScanner/
├── ADHealthScanner.Core/          # Core framework
│   ├── Configuration/             # Config management
│   ├── PowerShell/                # PS execution
│   ├── Models/                    # Data models
│   └── Scoring/                   # Health scoring
├── ADHealthScanner.Modules/       # Health check modules
│   └── ActiveDirectory/           
│       ├── Scripts/               # PowerShell scripts
│       └── Checks/                # C# check implementations
├── ADHealthScanner.Reporting/     # Report generation
└── ADHealthScanner.CLI/           # Command-line interface
```

**Where to Add:**
- New health check → `Modules/ActiveDirectory/Checks/`
- New PowerShell function → `Modules/ActiveDirectory/Scripts/`
- New report format → `Reporting/`
- Configuration option → `Core/Configuration/`

## Community Guidelines

### Code of Conduct

- Be respectful and professional
- Constructive feedback only
- No harassment or discrimination
- Assume good intent

See [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md) for full details.

### Communication

- **GitHub Issues:** Bug reports, feature requests
- **Pull Requests:** Code contributions, documentation
- **Discussions:** Questions, ideas, general discussion

**Response Time:**
- Issues: We'll respond within 3-5 days
- PRs: Initial review within 1 week
- This is a personal project, so patience is appreciated!

## Contribution Ideas

**Good First Issues:**
- Add new health checks (stale accounts, GPO issues)
- Improve error messages
- Add unit tests
- Documentation improvements
- PowerShell function optimization

**Advanced Contributions:**
- New module (DNS, DHCP)
- Report template enhancements
- Performance optimization
- Multi-domain support

Check [Issues labeled "good first issue"](https://github.com/andrew-stevic/ADHealthScanner/labels/good%20first%20issue) for beginner-friendly tasks.

## Recognition

Contributors will be:
- Listed in README.md acknowledgments
- Credited in release notes
- Appreciated forever!

## Questions?

- Open a [Discussion](https://github.com/andrew-stevic/ADHealthScanner/discussions)
- Comment on an existing issue
- Contact the maintainer (see README)

Thank you for contributing to AD Health Scanner!