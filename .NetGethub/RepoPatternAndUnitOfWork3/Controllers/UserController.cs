using Microsoft.AspNetCore.Mvc;
using RepoPatternAndUnitOfWork3.Contracts.UnitOfWork;
using RepoPatternAndUnitOfWork3.Models;

namespace RepoPatternAndUnitOfWork3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private IUserAccountsUnitOfWork _unitOfWork;

        public UserController(IUserAccountsUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public void InsertUser(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();
        }

    }
}
