﻿using ThienAspWebApi.Models;

namespace ThienAspWebApi.Repository.Interface
{
    public interface ITypeCateRepository 
    {
        Task<IEnumerable<TypeCate>> GetAllTypeCatesAsync();
        Task<TypeCate> GetTypeCateByIdAsync(int id);

        void CreateTypeCate(TypeCate typeCate);
        void UpdateTypeCate(TypeCate typeCate);
        void DeleteTypeCate(TypeCate typeCate);
    }
}
