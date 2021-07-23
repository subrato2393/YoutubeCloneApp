using System.Threading.Tasks;

namespace YoutubeClone.Membership.Seed
{
    public interface IUserDataSeed
    {
        Task SeedUserAsync();
    }
}