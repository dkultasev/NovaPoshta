using System;
using System.Collections.Generic;
using NLog;

namespace NovaPoshta.Json
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

        public IEnumerable<T> GetListOfObjects<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            try
            {
                return _jsonLogic.GetListOfObjects<T>(modelName, calledMethod, methodProperties);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw;
            }
        }

        public T GetSingleObject<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            try
            {
                return _jsonLogic.GetSingleObject<T>(modelName, calledMethod, methodProperties);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw;
            }
        }
    }
}