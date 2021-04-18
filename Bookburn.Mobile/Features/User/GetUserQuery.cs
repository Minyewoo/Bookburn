using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using Bookburn.Core.Utils;
using Bookburn.Mobile.Api.DTOs;
using MediatR;

namespace Bookburn.Mobile.Features.User
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public string Token { get; set; }
    }

    public class GetUserQueryException : Exception
    {
        public GetUserQueryException(string message) : base(message) {}
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var payload = new JwtManager().Decode(request.Token);

            if (payload == null || !payload.TryGetValue("passwordHash", out var passwordHash))
                throw new GetUserQueryException("User not found");

            if (payload.TryGetValue("email", out var email))
            {
                var user = await _userRepository.FindByEmailAndPassword(email, passwordHash, cancellationToken);
                if(user != null)
                    return new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        Nickname = user.Nickname,
                        Roles = user.Roles?.Select(x => new RoleDto {Id = x.Id, Name = x.Name}).ToArray(),
                    };
                
                throw new GetUserQueryException("User not found");
            }

            if (!payload.TryGetValue("phoneNumber", out var phoneNumber)) throw new GetUserQueryException("User not found");
            {
                var user = await _userRepository.FindByPhoneNumberAndPassword(phoneNumber, passwordHash,
                    cancellationToken);
                
                if(user != null)
                    return new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        Nickname = user.Nickname,
                        Roles = user.Roles.Select(x => new RoleDto {Id = x.Id, Name = x.Name}).ToArray(),
                    };
                throw new GetUserQueryException("User not found");
            }
        }
    }
}