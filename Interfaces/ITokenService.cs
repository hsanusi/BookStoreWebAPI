using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface ITokenService
    {
        string? CreateToken(AppUser user);
    }
}