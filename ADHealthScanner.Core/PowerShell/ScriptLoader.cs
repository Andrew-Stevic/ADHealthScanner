using System.Reflection;

namespace ADHealthScanner.Core.PowerShell
{
    /// <summary>
    /// Loads PowerShell scripts from embedded resources in the Modules assembly.
    /// </summary>
    public class ScriptLoader
    {
        private readonly Assembly _modulesAssembly;

        public ScriptLoader()
        {
            // Force load the Modules assembly if not already loaded
            var modulesAssemblyName = "ADHealthScanner.Modules";

            _modulesAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name == modulesAssemblyName);

            // If not loaded, try to load it
            if (_modulesAssembly == null)
            {
                try
                {
                    _modulesAssembly = Assembly.Load(modulesAssemblyName);
                }
                catch
                {
                    throw new InvalidOperationException(
                        $"Could not find or load {modulesAssemblyName} assembly. " +
                        "Ensure the Modules project is referenced and built.");
                }
            }
        }

        /// <summary>
        /// Loads a PowerShell script from embedded resources.
        /// </summary>
        /// <param name="scriptName">Name of the script file (e.g., "Get-ADHealthReplication.ps1")</param>
        /// <returns>Script content as a string</returns>
        public string LoadScript(string scriptName)
        {
            // Build the resource name: Namespace.Folder.Filename
            var resourceName = $"ADHealthScanner.Modules.ActiveDirectory.Scripts.{scriptName}";

            // Get the embedded resource stream
            using var stream = _modulesAssembly.GetManifestResourceStream(resourceName);

            if (stream == null)
            {
                throw new FileNotFoundException($"Embedded script not found: {scriptName}");
            }

            // Read the script content
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}