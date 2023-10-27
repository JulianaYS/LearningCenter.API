using AutoMapper;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Security.Domain.Repositories;
using LearningCenter.API.Security.Domain.Services;
using LearningCenter.API.Security.Domain.Services.Communication;

namespace LearningCenter.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task RegisterAsync(RegisterRequest model)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, UpdateRequest model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}