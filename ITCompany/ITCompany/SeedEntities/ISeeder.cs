using System.Threading.Tasks;

namespace ITCompany.SeedEntities
{
    public interface ISeeder
    {
        Task SeedAll();
    }
}
