using System.Data;

namespace Dapper
{
    public class SqlScript
    {
        public string Sql { get; set; }
        public object Param { get; set; }
        public CommandType CommandType { get; set; }

        public SqlScript(string sql, object param = null, CommandType cmdType = CommandType.Text)
        {
            Sql = sql;
            Param = param;
            CommandType = cmdType;
        }
    }
}