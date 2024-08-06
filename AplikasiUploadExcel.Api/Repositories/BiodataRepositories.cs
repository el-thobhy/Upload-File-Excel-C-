using AplikasiUploadExcel.Api.DbContextDir;
using AplikasiUploadExcel.Api.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AplikasiUploadExcel.Api.Repositories
{
    public interface IBiodataRepositories
    {
        Task<IEnumerable<BiodataViewModel>> GetAllDataAsync();
        Task<BiodataViewModel> GetDataByIdAsync(int id);
        Task<BiodataViewModel> AddDataAsync(BiodataViewModel data);
        Task UpdateDataAsync(BiodataViewModel data);
        Task DeleteDataAsync(int id);
        Task<IEnumerable<BiodataViewModel>> UploadExcelAsync(Stream fileStream);
    }
    public class BiodataRepositories : IBiodataRepositories
    {
        private readonly DatabaseKaryawanContext _dbContext;
        public BiodataRepositories(DatabaseKaryawanContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<BiodataViewModel> AddDataAsync(BiodataViewModel data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDataAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BiodataViewModel>> GetAllDataAsync()
        {
            return await _dbContext.Set<BiodataViewModel>().ToListAsync();

        }

        public Task<BiodataViewModel> GetDataByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDataAsync(BiodataViewModel data)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BiodataViewModel>> UploadExcelAsync(Stream fileStream)
        {
            throw new NotImplementedException();
        }
    }
}
