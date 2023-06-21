using System.Globalization;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Reflection.Emit;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using System.Collections.Generic;
using LoggerCode.Model.LogData


namespace.LoggerCode.GetLogData
{

    /*public DateTime GetTimeStamp(DateTime timeStamp)
    {
        return timeStamp;
    }
    public void SetTimeStamp(DateTime timeStamp)
    {
        this.timeStamp = timeStamp;
    }
    public string GetHost(string host)
    {
        return host;
    }
    public void SetHost(string host)
    {
        this.host = host;
    }
    public string GetSource(string source)
    {
        return source;
    }
    public void SetSource(string host)
    {
        this.source = source;
    }

    public string GetCorrelationId(string correlationId)
    {
        return correlationId;
    }
    public void SetCorrelationId(string correlationId)
    {
        this.correlationId = correlationId;
    }

    public string GetCode(string code)
    {
        return code;
    }
    public void SetCode(string code)
    {
        this.code = code;
    }

    public string GetMessage(string message)
    {
        return code;
    }
    public void SetMessage(string message)
    {
        this.code = code;
    }

    public string GetHttp(string http)
    {
        return http;
    }
    public void SetHttp(string http)
    {
        this.http = http;
    }

    public string GetTrace(string trace)
    {
        return trace;
    }
    public void SetTrace(string trace)
    {
        this.trace = trace;
    }

    public string GetData(string data)
    {
        return data;
    }
    public void SetData(List<string> data)
    {
        this.data = data;
    }*/


    public class LogSeverity
    {
        public static readonly LogSeverity Critical = new LogSeverity(TraceEventType.Critical);
        public static readonly LogSeverity Error = new LogSeverity(TraceEventType.Error);
        public static readonly LogSeverity Warning = new LogSeverity(TraceEventType.Warning);
        public static readonly LogSeverity Information = new LogSeverity(TraceEventType.Information);
        public static readonly LogSeverity Verbose = new LogSeverity(TraceEventType.Verbose);

        public static LogSeverity LEVEL
        {
            get
            {
                try
                {
                    return Error;
                }
                catch (Exception)
                {
                    return Error;
                }
            }
        }

        private LogSeverity(TraceEventType traceEventType)
        {
            this._traceEventType = traceEventType;
        }

        private readonly TraceEventType _traceEventType;

        public TraceEventType TraceEventType { get { return this._traceEventType; } }

        public static LogSeverity Parse(string severity)
        {
            LogSeverity defaultLoggingLevel = Error;

            if (string.IsNullOrEmpty(severity))
            {
                return defaultLoggingLevel;
            }

            switch (severity.ToLower())
            {
                case "critical":
                    return Critical;
                case "error":
                    return Error;
                case "warning":
                    return Warning;
                case "information":
                    return Information;
                case "verbose":
                    return Verbose;
                default:
                    return defaultLoggingLevel;
            }
        }

        public static bool IsSeverityLogged(LogSeverity severity)
        {
            if (severity == null) return false;
            return severity.TraceEventType <= LEVEL.TraceEventType;
        }
    }

    private string CreateSeverity(LogEntry log)
    {
        string severity = "DEBUG";

        if (log.Severity.TraceEventType == TraceEventType.Information || log.Severity.TraceEventType == TraceEventType.Verbose)
        {
            severity = "INFO";
        }
        else if (log.Severity.TraceEventType == TraceEventType.Critical || log.Severity.TraceEventType == TraceEventType.Error)
        {
            severity = "ERROR";
        }
        else if (log.Severity.TraceEventType == TraceEventType.Warning)
        {
            severity = "WARNING";
        }

        return severity;
    }

}