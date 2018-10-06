using System;
using System.Management.Automation;
using Microsoft.Web.XmlTransform;

namespace Ps4XdtConfigTransform
{
    internal class Ps4XdtConfigTransformLog : IXmlTransformationLogger
    {
        private Cmdlet _cmdlet;

        public Ps4XdtConfigTransformLog(Cmdlet cmdlet)
        {
            _cmdlet = cmdlet;
        }

        public void LogMessage(string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                Message = message,
                MessageArgs = messageArgs
            };

            _cmdlet.WriteVerbose(logEntry.ToString());
        }

        public void LogMessage(MessageType type, string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                MessageType = type.ToString(),
                Message = message,
                MessageArgs = messageArgs
            };

            _cmdlet.WriteVerbose(logEntry.ToString());
        }

        public void LogWarning(string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                Message = message,
                MessageArgs = messageArgs
            };

            _cmdlet.WriteWarning(logEntry.ToString());
        }

        public void LogWarning(string file, string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                File = file,
                Message = message,
                MessageArgs = messageArgs
            };

            _cmdlet.WriteWarning(logEntry.ToString());
        }

        public void LogWarning(string file, int lineNumber, int linePosition, string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                File = file,
                LineNumber = lineNumber,
                LinePosition = linePosition,
                Message = message,
                MessageArgs = messageArgs
            };

            _cmdlet.WriteWarning(logEntry.ToString());
        }

        public void LogError(string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                Message = message,
                MessageArgs = messageArgs
            };

            var exception = new InvalidOperationException(logEntry.ToString());
            _cmdlet.WriteError(new ErrorRecord(exception,null,ErrorCategory.InvalidOperation,null));
        }

        public void LogError(string file, string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                File = file,
                Message = message,
                MessageArgs = messageArgs
            };

            var exception = new InvalidOperationException(logEntry.ToString());
            _cmdlet.WriteError(new ErrorRecord(exception, null, ErrorCategory.InvalidOperation, null));
        }

        public void LogError(string file, int lineNumber, int linePosition, string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                File = file,
                LineNumber = lineNumber,
                LinePosition = linePosition,
                Message = message,
                MessageArgs = messageArgs
            };

            var exception = new InvalidOperationException(logEntry.ToString());
            _cmdlet.WriteError(new ErrorRecord(exception, null, ErrorCategory.InvalidOperation, null));
        }

        public void LogErrorFromException(Exception ex)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                Exception = ex
            };

            var exception = new InvalidOperationException(logEntry.ToString());
            _cmdlet.WriteError(new ErrorRecord(exception, null, ErrorCategory.InvalidOperation, null));
        }

        public void LogErrorFromException(Exception ex, string file)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                File = file,
                Exception = ex
            };

            var exception = new InvalidOperationException(logEntry.ToString());
            _cmdlet.WriteError(new ErrorRecord(exception, null, ErrorCategory.InvalidOperation, null));
        }

        public void LogErrorFromException(Exception ex, string file, int lineNumber, int linePosition)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                File = file,
                Exception = ex,
                LineNumber = lineNumber,
                LinePosition = linePosition
            };

            var exception = new InvalidOperationException(logEntry.ToString());
            _cmdlet.WriteError(new ErrorRecord(exception, null, ErrorCategory.InvalidOperation, null));
        }

        public void StartSection(string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                Message = message,
                MessageArgs = messageArgs
            };

            _cmdlet.WriteVerbose(logEntry.ToString());
        }

        public void StartSection(MessageType type, string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                MessageType = type.ToString(),
                Message = message,
                MessageArgs = messageArgs
            };

            _cmdlet.WriteVerbose(logEntry.ToString());
        }

        public void EndSection(string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                Message = message,
                MessageArgs = messageArgs
            };

            _cmdlet.WriteVerbose(logEntry.ToString());
        }

        public void EndSection(MessageType type, string message, params object[] messageArgs)
        {
            var logEntry = new Ps4XdtConfigTransformLogEntry()
            {
                MessageType = type.ToString(),
                Message = message,
                MessageArgs = messageArgs
            };

            _cmdlet.WriteVerbose(logEntry.ToString());
        }
    }

}