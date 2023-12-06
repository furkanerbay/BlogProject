﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.EmailAuthenticator;

public class EmailAuthenticatorHelper : IEmailAuthenticatorHelper
{
    public Task<string> CreateEmailActivationCode()
    {
        string key = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        return Task.FromResult(key);
    }

    public Task<string> CreateEmailActivationKey()
    {
        string code = RandomNumberGenerator
            .GetInt32(Convert.ToInt32(Math.Pow(x: 10, y: 6)))
            .ToString()
            .PadLeft(totalWidth: 6, paddingChar: '0');
        return Task.FromResult(code);
    }
}
