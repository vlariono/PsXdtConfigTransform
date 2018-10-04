using System.IO;
using System.Management.Automation;
using System.Xml;
using DotNet.Xdt;

namespace PsXdtConfigTransform
{
    /// <summary>
    ///     <para type="synopsis">Applies xdt transform to config file</para>
    ///     <para type="description">Does the same things as Visual Studio does to web.config, but can be used with app.config as well</para>
    /// </summary>
    /// <example>
    ///     <para>Invoke-XdtConfigTransform -Path 'App.config' -XdtTranformPath 'App.Debug.config' -OutputPath 'App.out.config' -Verbose</para>
    ///     <para>Applies xdt transform defined in App.Debug.config to App.config, result is saved to App.out.config</para>
    /// </example>
    /// <example>
    ///     <para>ls -File C:\Config\Xdt|select -ExpandProperty FullName|Invoke-XdtConfigTransform -Path C:\Config\App.config -Verbose</para>
    ///     <para>Applies all xdt transforms from C:\Config\Xdt to C:\Config\App.config, writes resulting config to output channel</para>
    /// </example>
    [Cmdlet(VerbsLifecycle.Invoke, "XdtConfigTransform")]
    [OutputType(typeof(XmlTransformableDocument))]
    public class PsXdtConfigTransform : PSCmdlet
    {
        private readonly XmlTransformableDocument _configDocument = new XmlTransformableDocument() { PreserveWhitespace = true };
        private string _path;
        private string _xdtTranformPath;

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if (!File.Exists(XdtTranformPath))
                throw new FileNotFoundException(XdtTranformPath);
            
            using (var xdtConfig = File.OpenRead(XdtTranformPath))
            using (var tranformation = new XmlTransformation(xdtConfig, new PsXdtConfigTransformLog(this)))
            {
                tranformation.Apply(_configDocument);
            }
        }

        /// <inheritdoc />
        protected override void BeginProcessing()
        {
            if (!File.Exists(Path))
                throw new FileNotFoundException(Path);

            using (var appConfig = File.OpenRead(Path))
            {
                _configDocument.Load(appConfig);
            }
        }

        /// <inheritdoc />
        protected override void EndProcessing()
        {
            if (OutputPath != null)
            {
                using (_configDocument)
                using (var outConfig = File.Create(OutputPath))
                using (var xmlWriter = XmlWriter.Create(outConfig, new XmlWriterSettings() { Indent = true }))
                {
                    _configDocument.WriteTo(xmlWriter);
                }
            }
            else
            {
                WriteObject(_configDocument);
            }
        }

        /// <summary>
        ///     <para type="description">Path to source xml config</para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Path
        {
            get => _path;
            set => _path = GetUnresolvedProviderPathFromPSPath(value);
        }

        /// <summary>
        ///     <para type="description">Path to xdt transform file</para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string XdtTranformPath
        {
            get => _xdtTranformPath;
            set => _xdtTranformPath = GetUnresolvedProviderPathFromPSPath(value);
        }

        /// <summary>
        ///     <para type="description">Path to save resulting config file to</para>
        ///     <para type="description">If not set, result is written to output channel</para>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2)]
        public string OutputPath { get; set; }
    }
}
