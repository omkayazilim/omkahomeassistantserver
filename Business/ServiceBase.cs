
using Infrastructer;
using Microsoft.Extensions.Logging;

namespace Business
{
    public class ServiceBase
    {
        public readonly IAppDbContext _dbContext;
        public ServiceBase(IAppDbContext dbContext) 
        { 
           _dbContext = dbContext;  
        }
    }
}
