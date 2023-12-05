﻿using System;
using FluentValidation;

namespace EliDinner.Application.Authentication.Queries.Login
{
	public class LoginQueryValidator :AbstractValidator<LoginQuery>
	{
		public LoginQueryValidator()
		{
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
	}
}

