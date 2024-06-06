﻿using LibraryManagementSystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries.UserGetById
{
    public class UserGetByIdQuery : IRequest<UserDetailViewModel>
    {
        public UserGetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
