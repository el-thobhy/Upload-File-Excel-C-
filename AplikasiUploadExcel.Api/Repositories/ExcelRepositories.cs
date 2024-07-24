using AplikasiUploadExcel.Api.DataModel;
using AplikasiUploadExcel.Api.DbContextDir;
using AplikasiUploadExcel.Api.Services;
using AplikasiUploadExcel.Api.ViewModel;

namespace AplikasiUploadExcel.Api.Repositories
{
    public class ExcelRepositories
    {
        private DatabaseKaryawanContext _dbContext;
        private ResponseResult _responseResult = new ResponseResult();
        public ExcelRepositories(DatabaseKaryawanContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseResult Upload(string filePath)
        {
            try
            {
                var biodata = UploadExcel.Import<BiodataViewModel>(filePath);
                foreach(var item in biodata)
                {
                    var entity = new Biodata
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Address = item.Address,
                        Pob = item.Pob,
                        Dob = item.Dob,
                        MaritalStatus = item.MaritalStatus,
                        CreateBy = item.CreateBy,
                        CreateDate = item.CreateDate,
                        IsDeleted = item.IsDeleted,
                        DeletedBy = item.DeletedBy,
                        DeletedDate = item.DeletedDate,
                        ModifiedBy = item.ModifiedBy,
                        ModifiedDate = item.ModifiedDate,
                    };
                    _dbContext.Biodata.Add(entity);
                }
                _dbContext.SaveChanges();
                _responseResult.Success = true;
                _responseResult.Message = "Upload Success";
            }
            catch (Exception e)
            {
                _responseResult.Success = false;
                _responseResult.Message = e.Message;
                throw;
            }
            return _responseResult;
        }
    }
}