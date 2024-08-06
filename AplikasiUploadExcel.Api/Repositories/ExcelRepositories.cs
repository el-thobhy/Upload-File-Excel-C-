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
                var biodata = UploadExcel.Import<BiodataViewModel>(filePath,0);
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

        public ResponseResult UploadCC_Category(string filePath)
        {
            try
            {
                var biodata = UploadExcel.Import<CC_CategoryViewModel>(filePath,0);
                foreach (var item in biodata)
                {
                    var entity = new CC_Category
                    {
                        ChangeTrackingMask = item.ChangeTrackingMask,
                        Code = item.Code,
                        CodeCategory = item.CodeCategory,
                        CodeGroup = item.CodeGroup,
                        CodeGroupName = item.CodeGroupName,
                        EnterDateTime = item.EnterDateTime,
                        EnterUserName = item.EnterUserName,
                        EnterVersionNumber = item.EnterVersionNumber,
                        LastChgDateTime = item.LastChgDateTime,
                        LastChgUserName = item.LastChgUserName,
                        LastChgVersionNumber = item.LastChgVersionNumber,
                        MUID = item.MUID,
                        Name = item.Name,
                        ValidationStatus = item.ValidationStatus,
                        VersionFlag = item.VersionFlag,
                        Version_ID = item.Version_ID,
                        VersionName = item.VersionName,
                        VersionNumber = item.VersionNumber,
                    };
                    _dbContext.CC_Categories.Add(entity);
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


        public ResponseResult UploadCC_Priority(string filePath)
        {
            try
            {
                var biodata = UploadExcel.Import<CC_PriorityViewModel>(filePath,1);
                foreach (var item in biodata)
                {
                    var entity = new CC_Priority
                    {
                        ChangeTrackingMask = item.ChangeTrackingMask,
                        Code = item.Code,
                        EnterDateTime = item.EnterDateTime,
                        EnterUserName = item.EnterUserName,
                        EnterVersionNumber = item.EnterVersionNumber,
                        LastChgDateTime = item.LastChgDateTime,
                        LastChgUserName = item.LastChgUserName,
                        LastChgVersionNumber = item.LastChgVersionNumber,
                        MUID = item.MUID,
                        Name = item.Name,
                        ValidationStatus = item.ValidationStatus,
                        VersionFlag = item.VersionFlag,
                        Version_ID = item.Version_ID,
                        VersionName = item.VersionName,
                        VersionNumber = item.VersionNumber,
                    };
                    _dbContext.CC_Priorities.Add(entity);
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

        public ResponseResult UploadMaterialPlant(string filePath)
        {
            try
            {
                var biodata = UploadExcel.Import<MaterialPlantViewModel>(filePath,2);
                foreach (var item in biodata)
                {
                    var entity = new MaterialPlant
                    {
                        ChangeTrackingMask = item.ChangeTrackingMask,
                        Code = item.Code,
                        EnterDateTime = item.EnterDateTime,
                        EnterUserName = item.EnterUserName,
                        EnterVersionNumber = item.EnterVersionNumber,
                        LastChgDateTime = item.LastChgDateTime,
                        LastChgUserName = item.LastChgUserName,
                        LastChgVersionNumber = item.LastChgVersionNumber,
                        MUID = item.MUID,
                        Name = item.Name,
                        ValidationStatus = item.ValidationStatus,
                        VersionFlag = item.VersionFlag,
                        Version_ID = item.Version_ID,
                        VersionName = item.VersionName,
                        VersionNumber = item.VersionNumber,
                    };
                    _dbContext.MaterialPlants.Add(entity);
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

        public ResponseResult UploadOrg_dept(string filePath)
        {
            try
            {
                var biodata = UploadExcel.Import<Org_DeptViewModel>(filePath,3);
                foreach (var item in biodata)
                {
                    var entity = new Org_Dept
                    {
                        ChangeTrackingMask = item.ChangeTrackingMask,
                        Code = item.Code,
                        EnterDateTime = item.EnterDateTime,
                        EnterUserName = item.EnterUserName,
                        EnterVersionNumber = item.EnterVersionNumber,
                        LastChgDateTime = item.LastChgDateTime,
                        LastChgUserName = item.LastChgUserName,
                        LastChgVersionNumber = item.LastChgVersionNumber,
                        MUID = item.MUID,
                        Name = item.Name,
                        ValidationStatus = item.ValidationStatus,
                        VersionFlag = item.VersionFlag,
                        Version_ID = item.Version_ID,
                        VersionName = item.VersionName,
                        VersionNumber = item.VersionNumber,
                        OrgCode = item.OrgCode,
                    };
                    _dbContext.Org_Depts.Add(entity);
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