# Security Policy

## Supported Versions

| Version | Supported          |
| ------- | ------------------ |
| 1.x     | :white_check_mark: |
| < 1.0   | :x:                |

## Reporting a Vulnerability

**DO NOT** open a public issue for security vulnerabilities.

Please report security vulnerabilities via GitHub's private vulnerability reporting:

1. Go to the Security tab
2. Click "Report a vulnerability"
3. Fill out the form with details

You can also email: ADHealthScanner@andrewstevic.com

### What to Include

- Description of the vulnerability
- Steps to reproduce
- Potential impact
- Suggested fix (if you have one)

### Response Timeline

- **Acknowledgment:** Within 48 hours
- **Initial assessment:** Within 7 days
- **Fix timeline:** Within 30 days for confirmed issues

## Security Features

### Supply Chain Security
- Software Bill of Materials (SBOM) with every release
- Automated dependency scanning (Dependabot)
- Static analysis (CodeQL) on every commit
- Build provenance attestation

### Verification
See [README.md](README.md#verification) for instructions on verifying release integrity.

## Security Considerations

### Required Privileges
This tool requires Domain Admin or equivalent privileges to query Active Directory.

### Data Handling
The tool reads Active Directory configuration. It does NOT:
- Modify Active Directory
- Store or transmit credentials
- Send data to external servers
- Cache sensitive information

## Disclosure Policy

We follow coordinated disclosure:
1. Report received and verified
2. Fix developed and tested
3. Security advisory published
4. CVE requested if applicable
5. Fix released
6. Public disclosure 7 days after fix

## Contact

Security contact: ADHealthScanner@andrewstevic.com