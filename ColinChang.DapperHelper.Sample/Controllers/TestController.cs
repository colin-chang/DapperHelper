using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace ColinChang.DapperHelper.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<long> Get([FromServices] IDapperHelper dapper)
        {
            return (long)await dapper.QueryScalarAsync("SELECT COUNT(1) FROM Worker");
        }
    }
}