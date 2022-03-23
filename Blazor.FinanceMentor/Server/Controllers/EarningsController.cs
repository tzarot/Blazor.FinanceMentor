using Blazor.FinanceMentor.Server.Storage;
using Blazor.FinanceMentor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.FinanceMentor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarningsController : ControllerBase
    {
        private readonly IRepository<Earning> _earningRepository;

        public EarningsController(IRepository<Earning> earningRepository)
        {
            _earningRepository = earningRepository;
        }

        [HttpGet]
        public IEnumerable<Earning> Get()
        {
            return _earningRepository.GetAll()
                .OrderBy(earning => earning.Date);
        }

        [HttpPost]
        public void Post(Earning earning)
        {
            _earningRepository.Add(earning);
        }

        [HttpDelete("{id?}")]
        public void Post(Guid id)
        {
            var entity = _earningRepository
                .GetAll()
                .Single(e => e.Id == id);
            _earningRepository.Remove(entity);

        }
    }
}
