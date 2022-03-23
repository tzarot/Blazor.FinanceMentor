using Blazor.FinanceMentor.Server.Storage;
using Blazor.FinanceMentor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.FinanceMentor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IRepository<Expense> _expensesRepository;

        public ExpensesController(IRepository<Expense> expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return _expensesRepository.GetAll()
                .OrderBy(earning => earning.Date);
        }

        [HttpPost]
        public void Post(Expense earning)
        {
            _expensesRepository.Add(earning);
        }

        [HttpDelete("{id?}")]
        public void Post(Guid id)
        {
            var entity = _expensesRepository
                .GetAll()
                .Single(e => e.Id == id);
            _expensesRepository.Remove(entity);

        }
    }

    
}
