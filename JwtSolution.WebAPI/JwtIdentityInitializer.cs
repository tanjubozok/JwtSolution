using JwtSolution.Business.Abstract;
using JwtSolution.Business.StringInfos;
using JwtSolution.Entities.Concrete;
using System.Threading.Tasks;

namespace JwtSolution.WebAPI
{
    public class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);
            if (adminRole == null)
            {
                await appRoleService.AddAsync(new AppRole
                {
                    Name = "Admin"
                });
            }

            var memberRole = await appRoleService.FindByName(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.AddAsync(new AppRole
                {
                    Name = "Member"
                });
            }

            var adminUser = await appUserService.FindByUsername("Admin");
            if (adminUser == null)
            {
                await appUserService.AddAsync(new AppUser
                {
                    Fullname = "Admin Guest",
                    Username = "Admin",
                    Password = "1"
                });

                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var admin = await appUserService.FindByUsername("Admin");
                await appUserRoleService.AddAsync(new AppUserRole
                {
                    AppRoleId = role.Id,
                    AppUserId = admin.Id
                });
            }
        }
    }
}
