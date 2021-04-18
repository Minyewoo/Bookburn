using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using Bookburn.Core.Utils;
using Bookburn.Mobile.Api.DTOs;
using MediatR;

namespace Bookburn.Mobile.Features.User
{
    public class GetTokenQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class GetTokenQueryException : Exception
    {
        public GetTokenQueryException(string message) : base(message)
        {
        }
    }

    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly IUserRepository _userRepository;

        public GetTokenQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Password)) throw new GetTokenQueryException("Password required");

            if (!string.IsNullOrEmpty(request.Email))
            {
                var user = await _userRepository.FindByEmailAndPassword(request.Email,
                    EncryptPassword(request.Password),
                    cancellationToken);
                if (user == null) throw new GetTokenQueryException("User not found");
                return new JwtManager().Encode(new Dictionary<string, string>
                    {{"email", user.Email}, {"passwordHash", user.PasswordHash}});
            }

            if (string.IsNullOrEmpty(request.PhoneNumber))
                throw new GetTokenQueryException("Email or phone number required");
            {
                var user = await _userRepository.FindByPhoneNumberAndPassword(request.PhoneNumber,
                    EncryptPassword(request.Password),
                    cancellationToken);
                if (user == null) throw new GetTokenQueryException("User not found");
                return new JwtManager().Encode(new Dictionary<string, string>
                    {{"phoneNumber", request.PhoneNumber}, {"passwordHash", user.PasswordHash}});
            }
        }

        private string EncryptPassword(string password)
        {
            var bytes = new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(password));
            return string.Join("", bytes.Select(x => x.ToString("X2")));
        }
    }
}