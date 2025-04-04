﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handle.Auth.AuthenticateUser;

public class AuthenticateUserCommand : IRequest<AuthenticateUserResult>
{
    #region properties

    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    #endregion
}

