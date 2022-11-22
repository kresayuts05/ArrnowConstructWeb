﻿using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository repo;

        public ClientService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(string userId)
        {
            var client = new Client()
            {
                UserId = userId,
            };

            await repo.AddAsync(client);
            await repo.SaveChangesAsync();
        }

        public async Task<int> GetClientId(string userId)
        {
            return (await repo.AllReadonly<Client>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }
    }
}
