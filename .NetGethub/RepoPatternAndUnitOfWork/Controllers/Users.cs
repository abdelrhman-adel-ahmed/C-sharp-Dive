using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternAndUnitOfWork.Contracts.Configuration;
using RepoPatternAndUnitOfWork.Models;

namespace RepoPatternAndUnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public Users(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("not valid") { StatusCode = 500 };
            }
            await _unitOfWork.Users.Add(user);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

    }
}
