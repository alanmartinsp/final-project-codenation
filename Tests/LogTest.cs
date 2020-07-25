using Api.Filters;
using Business.Models;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tests.Repositories;

namespace Tests
{
    [TestClass]
    public class LogTest
    {

        private LogService _logService;

        public LogTest()
        {
            List<Log> logs = new List<Log>()
            {
                new Log() { Id = 1, Level = Log.Type.Debug, Event = 100, Title = "log 1", Origin = "127.0.0.1", Details = "teste log 1",
                            Enviroment = Log.TypeEnviroment.Dev, UserId = 1 },
                new Log() { Id = 2, Level = Log.Type.Debug, Event = 100, Title = "log 2", Origin = "127.0.0.1", Details = "teste log 2",
                            Enviroment = Log.TypeEnviroment.Dev, UserId = 1 },
                new Log() { Id = 3, Level = Log.Type.Error, Event = 150, Title = "log 3", Origin = "127.0.0.1", Details = "teste log 3",
                            Enviroment = Log.TypeEnviroment.Homologation, UserId = 1 },
                new Log() { Id = 4, Level = Log.Type.Error, Event = 10, Title = "log 4", Origin = "127.0.0.10", Details = "teste log 4",
                            Enviroment = Log.TypeEnviroment.Production, UserId = 1 },
                new Log() { Id = 5, Level = Log.Type.Warning, Event = 110, Title = "log 5", Origin = "192.168.1.57", Details = "teste log 5",
                            Enviroment = Log.TypeEnviroment.Production, UserId = 1 }
            };

            _logService = new LogService(new LogRepository(logs));
        }

        [TestMethod]
        public void Log_Get_Id_1()
        {
            Log result = _logService.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(1, result.Id);
        }

        [TestMethod]
        public void Log_GetAll_Count_5()
        {
            IEnumerable<Log> result = _logService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void Log_GetByFilter_Homologation()
        {
            LogFilter filter = new LogFilter
            {
                Enviroment = (int)Log.TypeEnviroment.Homologation
            };

            IEnumerable<Log> result = _logService.Get(filter);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Log_GetByFilter_Production_Origin()
        {
            LogFilter filter = new LogFilter
            {
                Enviroment = (int)Log.TypeEnviroment.Production,
                Field = "origin",
                FieldDescription = "192.168.1.57"
            };

            IEnumerable<Log> result = _logService.Get(filter);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Log_Add_Id_10()
        {
            Log log = new Log()
            {
                Id = 10,
                Level = Log.Type.Error,
                Event = 110,
                Title = "log 6",
                Origin = "192.168.1.58",
                Details = "teste log 5",
                Enviroment = Log.TypeEnviroment.Dev,
                UserId = 1
            };

            _logService.Save(log);

            Log result = _logService.Get(log.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual<Log>(log, result);
        }
    }
}
