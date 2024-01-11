using HalfSun_Proj.DTO;
using HalfSun_Proj.Model;

namespace HalfSun_Proj.IRepo
{
    public interface IStaffRepo
    {
        Task<List<StaffModel>> GetList();
        Task<ResponseDto> Add(StaffModel value);
    }
}
