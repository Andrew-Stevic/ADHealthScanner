unction Get-ADHealthTest {
    <#
    .SYNOPSIS
        Test script to verify PowerShell execution works
    .DESCRIPTION
        Returns basic AD domain information to verify the framework is working
    #>
    [CmdletBinding()]
    param()
    
    try {
        # Get basic domain info
        $domain = Get-ADDomain
        
        # Return as PSCustomObject
        [PSCustomObject]@{
            DomainName = $domain.DNSRoot
            DomainMode = $domain.DomainMode
            Forest = $domain.Forest
            Status = "Success"
            Message = "PowerShell execution framework is working!"
        }
    }
    catch {
        [PSCustomObject]@{
            DomainName = "Unknown"
            Status = "Error"
            Message = $_.Exception.Message
        }
    }
}

# Execute the function
Get-ADHealthTest