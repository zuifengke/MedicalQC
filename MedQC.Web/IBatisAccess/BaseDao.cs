using IBatisNet.Common.Logging;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Collections.Generic;
using System.Reflection;

namespace MedQC.Web.IBatisAccess
{
    public class BaseDao
    {
        protected readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private volatile Dictionary<string, ISqlMapper> _mapper = null;
        protected void Configure(object obj)
        {
        }
        protected void InitMapper(string databaseName)
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            _mapper[databaseName] = builder.ConfigureAndWatch(databaseName,handler);
        }
        public ISqlMapper GetSqlMapper(string databaseName)
        {
            if (_mapper == null)
            {
                _mapper = new Dictionary<string, ISqlMapper>();
            }
            if (!_mapper.ContainsKey(databaseName)|| _mapper[databaseName] == null)
            {
                InitMapper(databaseName);
            }
            return _mapper[databaseName];
        }

    }
}
