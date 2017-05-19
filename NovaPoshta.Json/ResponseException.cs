using System;
using System.Collections.Generic;

namespace NovaPoshta.Json
{
    public class ResponseException : Exception
    {
        public string[] Errors { get; private set; }
        public ResponseException() : base()
        {
        }

        public ResponseException(List<string> errors) : base()
        {
            Errors = errors.ToArray();
        }
    }
}
