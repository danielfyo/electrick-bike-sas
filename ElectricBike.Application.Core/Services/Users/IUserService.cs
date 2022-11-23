namespace ElectricBike.Application.Core.Services.Users;

public interface IUserService
{
    Task<UserDto> Create(UserDto dto);
    Task<UserDto> GetById(int id);
    Task<IEnumerable<UserDto>> GetAll();
    Task<bool> Update(UserDto dto);
    Task<bool> Delete(int id);
}