using System.Management.Automation;
using System.Collections.ObjectModel;

namespace ADHealthScanner.Core.PowerShell
{
    /// <summary>
    /// Executes PowerShell scripts using the PowerShell SDK.
    /// </summary>
    public class PowerShellRunner : IDisposable
    {
        private readonly System.Management.Automation.PowerShell _powerShell;
        private readonly ScriptLoader _scriptLoader;

        public PowerShellRunner(ScriptLoader scriptLoader)
        {
            _scriptLoader = scriptLoader;
            _powerShell = System.Management.Automation.PowerShell.Create();

            // Import required PowerShell modules
            ImportRequiredModules();
        }

        /// <summary>
        /// Import PowerShell modules needed for AD health checks.
        /// </summary>
        private void ImportRequiredModules()
        {
            try
            {
                // Import Active Directory module
                _powerShell.AddScript("Import-Module ActiveDirectory -ErrorAction Stop");
                _powerShell.Invoke();
                _powerShell.Commands.Clear();

                // Check for errors
                if (_powerShell.HadErrors)
                {
                    var errors = string.Join(", ", _powerShell.Streams.Error.ReadAll().Select(e => e.ToString()));
                    throw new InvalidOperationException(
                        $"Failed to import ActiveDirectory module. Ensure RSAT tools are installed. Errors: {errors}");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Failed to initialize PowerShell environment. Ensure you're running on a domain-joined machine with RSAT tools installed.", ex);
            }
        }

        /// <summary>
        /// Executes a PowerShell script from embedded resources.
        /// </summary>
        /// <param name="scriptName">Name of the script (e.g., "Get-ADHealthReplication.ps1")</param>
        /// <param name="parameters">Optional parameters to pass to the script</param>
        /// <returns>Collection of PowerShell objects returned by the script</returns>
        public Collection<PSObject> ExecuteScript(string scriptName, Dictionary<string, object>? parameters = null)
        {
            try
            {
                // Load the script from embedded resources
                var scriptContent = _scriptLoader.LoadScript(scriptName);

                // Add the script to PowerShell
                _powerShell.AddScript(scriptContent);

                // Add parameters if provided
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        _powerShell.AddParameter(param.Key, param.Value);
                    }
                }

                // Execute the script
                var results = _powerShell.Invoke();

                // Check for errors
                if (_powerShell.HadErrors)
                {
                    var errors = _powerShell.Streams.Error.ReadAll();
                    var errorMessage = string.Join("; ", errors.Select(e => e.ToString()));
                    throw new InvalidOperationException($"PowerShell script '{scriptName}' failed: {errorMessage}");
                }

                // Clear commands for next execution
                _powerShell.Commands.Clear();

                return results;
            }
            catch (Exception ex) when (ex is not InvalidOperationException)
            {
                // Wrap unexpected exceptions with context
                throw new InvalidOperationException($"Failed to execute PowerShell script '{scriptName}'", ex);
            }
        }

        /// <summary>
        /// Dispose of PowerShell runspace.
        /// </summary>
        public void Dispose()
        {
            _powerShell?.Dispose();
        }
    }
}