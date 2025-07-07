using OnlinePharmacy.Application.Common.DTOs.User;
using OnlinePharmacy.Domain.Entities;
using OnlinePharmacy.Domain.Interfaces;
using OnlinePharmacy.Domain.Models;

namespace OnlinePharmacy.Application.Common.Interfaces
{
    public interface IAccountService : IGenericService<User, AccountCreateDTO, UserDTO, Guid>
    {
        Task<Result<UserDTO>> CreateStaffAsync(CreateStaffDTO entityDTO, string creatorName);
        Task<Result<UserDTO>> LoginAsync(AccountLoginDTO entityDTO);
    }
}
