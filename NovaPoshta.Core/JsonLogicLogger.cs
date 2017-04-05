using System;
using System.Collections.Generic;
using NLog;

namespace NovaPoshta.Core
{
    public class JsonLogicLogger : IJsonLogic
    {
        private readonly IJsonLogic _jsonLogic;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public JsonLogicLogger(IJsonLogic jsonLogic)
        {
            if (jsonLogic == null) throw new ArgumentNullException(nameof(jsonLogic));
            _jsonLogic = jsonLogic;
        }

        public IEnumerable<T> GetJsonData<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            try
            {
                return _jsonLogic.GetJsonData<T>(modelName, calledMethod, methodProperties);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw;
            }
        }

        public T GetJsonRootData<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            try
            {
                return _jsonLogic.GetJsonRootData<T>(modelName, calledMethod, methodProperties);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw;
            }
        }
    }
}