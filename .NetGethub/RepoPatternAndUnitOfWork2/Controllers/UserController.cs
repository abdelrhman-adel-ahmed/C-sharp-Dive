using RepoPatternAndUnitOfWork2.Contracts.UnitOfWork;
using RepoPatternAndUnitOfWork2.Models;
using System.Web.Http;

namespace RepoPatternAndUnitOfWork2.Controllers
{
    public class UserController : ApiController
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
        }
       
    }
}
