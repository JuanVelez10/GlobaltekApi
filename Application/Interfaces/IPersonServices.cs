﻿using Application.References;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPersonServices
    {
        public Task<Person> GetPersonForId(Guid? id);

        public Task<BaseResponse<Login>> GetPersonLogin(string email, string password);
    }
}