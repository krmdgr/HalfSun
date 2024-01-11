using HalfSun_Proj.Data_Model;
using HalfSun_Proj.Data_Model.Models;
using HalfSun_Proj.DTO;
using HalfSun_Proj.IRepo;
using HalfSun_Proj.Model;
using Microsoft.EntityFrameworkCore;

namespace HalfSun_Proj.Repos
{
    public class StaffRepo : IStaffRepo
    {
        protected readonly HalfSunDataContext _context;
        public StaffRepo(HalfSunDataContext context) => this._context = context;
        public async Task<List<StaffModel>> GetList()
        {
            try
            {
                var getStaffData = await _context.Staff.Select(x => new StaffModel
                { 
                   Id = x.Id,
                   StaffTypeId = x.StaffTypeId,
                   Address1 = x.Address1!,
                   FirstName = x.FirstName!,
                   LastName = x.LastName!,
                   StaffTypeName = x.StaffType!.Name!,
                   Benefits = (List<StaffBenefits>)x.StaffBenefitsMappings.Where(y => x.Id == y.StaffId).Select(z =>  new StaffBenefits()
                   {
                       Amount = z.Amount == null ? 0 : (decimal)z.Amount,
                       BenefitName = z.Benefit!.Name!,
                       BenefitId = z.BenefitId == null ? 0 : (int)z.BenefitId
                   }),
                }).ToListAsync();
                return getStaffData;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<ResponseDto> Add(StaffModel model)
        {
            try
            {
                Staff staff = new Staff
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StaffTypeId = model.StaffTypeId,
                    Address1 = model.Address1!                    
                };
                await _context.Staff.AddAsync(staff);
                await _context.SaveChangesAsync();
                if(model.Benefits.Count > 0)
                {
                    foreach(var f in model.Benefits)
                    {
                        StaffBenefitsMapping staffBenefitsMapping = new StaffBenefitsMapping()
                        {
                            BenefitId = f.BenefitId,
                            StaffId = staff.Id,
                            Amount = f.Amount
                        };
                        await _context.StaffBenefitsMappings.AddAsync(staffBenefitsMapping);
                    }
                    await _context.SaveChangesAsync();
                }
                return new ResponseDto
                {
                    Message = "Staff Inserted successfully",
                    Status = true,
                    Id = model.Id,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
