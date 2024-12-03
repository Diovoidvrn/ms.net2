using Hotel.BL.Admin.Entities;
using Hotel.DataAccess.Entities;
using Hotel.DataAccess;
using AutoMapper;

namespace Hotel.BL.Admin
{
    public class AdminsProvider : IAdminsProvider
    {
        private readonly IRepository<AdminEntity> _adminRepository;
        private readonly IMapper _mapper;

        public AdminsProvider(IRepository<AdminEntity> adminsRepository, IMapper mapper)
        {
            _adminRepository = adminsRepository;
            _mapper = mapper;
        }

        public AdminModel GetAdminInfo(Guid id)
        {
            var admin = _adminRepository.GetById(id);
            if (admin is null)
                throw new ArgumentException("Admin not found.");

            return _mapper.Map<AdminModel>(admin);
        }

        public IEnumerable<AdminModel> GetAdmins(AdminModelFilter modelFilter = null)
        {
            var surname = modelFilter?.Surname;
            var name = modelFilter?.Name;
            var phoneNumber = modelFilter?.PhoneNumber;
            var email = modelFilter?.Email;

            var admins = _adminRepository.GetAll(x => (
                surname == null || surname == x.Surname || 
                name == null || name == x.Name || 
                phoneNumber == null || phoneNumber == x.PhoneNumber || 
                email == null || email == x.Email));

            return _mapper.Map<IEnumerable<AdminModel>>(admins);
        }
    }
}
