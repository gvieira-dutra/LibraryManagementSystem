﻿using LibraryManagementSystem.Application.ViewModels;
using LibraryManagementSystem.Core.Entities;

namespace LibraryManagementSystem.Application.Services.Interfaces
{
    public interface IBookService
    {
        public List<BookViewModel>? BookGetAll(string query);
        public Book? BookGetOne(int id);
        public void BookDelete(int id);

    }
}
