using Hotel.BL.Admin.Entities;

namespace Hotel.BL.Admin
{
    public interface IAdminsManager
    {
        AdminModel CreateAdmin(CreateAdminModel model);
        void DeleteAdmin(Guid id);
        AdminModel UpdateAdmin(Guid id, UpdateAdminModel model);
    }
}
