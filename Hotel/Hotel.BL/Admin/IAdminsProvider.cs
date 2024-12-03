using Hotel.BL.Admin.Entities;

namespace Hotel.BL.Admin
{
    public interface IAdminsProvider
    {
        IEnumerable<AdminModel> GetAdmins(AdminModelFilter modelFilter = null);
        AdminModel GetAdminInfo(Guid id);
    }
}
