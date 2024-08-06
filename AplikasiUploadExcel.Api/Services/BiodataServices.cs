using AplikasiUploadExcel.Api.Repositories;
using AplikasiUploadExcel.Api.ViewModel;

namespace AplikasiUploadExcel.Api.Services
{
    public interface IBiodataServices
    {
        Task<IEnumerable<BiodataViewModel>> GetAllDataAsync();
        Task<BiodataViewModel> GetDataByIdAsync(int id);
        Task<BiodataViewModel> AddDataAsync(BiodataViewModel data);
        Task UpdateDataAsync(BiodataViewModel data);
        Task DeleteDataAsync(int id);
    }
    public class BiodataServices : IBiodataServices
    {
        private readonly IBiodataRepositories _repo;
        public BiodataServices(IBiodataRepositories repo)
        {
            _repo = repo;
        }
        public Task<BiodataViewModel> AddDataAsync(BiodataViewModel data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDataAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BiodataViewModel>> GetAllDataAsync()
        {
            return await _repo.GetAllDataAsync();
        }

        public Task<BiodataViewModel> GetDataByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDataAsync(BiodataViewModel data)
        {
            throw new NotImplementedException();
        }
    }
}
