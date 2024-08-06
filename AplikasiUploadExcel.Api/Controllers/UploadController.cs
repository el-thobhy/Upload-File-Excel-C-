using AplikasiUploadExcel.Api.DbContextDir;
using AplikasiUploadExcel.Api.Repositories;
using AplikasiUploadExcel.Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplikasiUploadExcel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IWebHostEnvironment _env;
        private ExcelRepositories _repo;

        public UploadController(IWebHostEnvironment env, DatabaseKaryawanContext dbContext)
        {
            _env = env;
            _repo = new ExcelRepositories(dbContext);
        }

        [HttpPost("Upload")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(CancellationToken ct)
        {
            if (Request.Form.Files.Count == 0) return NoContent();
            var file = Request.Form.Files[0];
            var filePath = SaveToFolderUploaded(file);
            ResponseResult result = _repo.Upload(filePath);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("UploadCC_Category")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadCC_Category(CancellationToken ct)
        {
            if (Request.Form.Files.Count == 0) return NoContent();
            var file = Request.Form.Files[0];
            var filePath = SaveToFolderUploaded(file);
            ResponseResult result = _repo.UploadCC_Category(filePath);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        
        [HttpPost("UploadCC_Priority")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadCC_Priority(CancellationToken ct)
        {
            if (Request.Form.Files.Count == 0) return NoContent();
            var file = Request.Form.Files[0];
            var filePath = SaveToFolderUploaded(file);
            ResponseResult result = _repo.UploadCC_Priority(filePath);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        
        
        [HttpPost("UploadMaterialPlant")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadMaterialPlant(CancellationToken ct)
        {
            if (Request.Form.Files.Count == 0) return NoContent();
            var file = Request.Form.Files[0];
            var filePath = SaveToFolderUploaded(file);
            ResponseResult result = _repo.UploadMaterialPlant(filePath);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        
        
        [HttpPost("UploadOrg_dept")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadOrg_dept(CancellationToken ct)
        {
            if (Request.Form.Files.Count == 0) return NoContent();
            var file = Request.Form.Files[0];
            var filePath = SaveToFolderUploaded(file);
            ResponseResult result = _repo.UploadOrg_dept(filePath);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }




        private string SaveToFolderUploaded(IFormFile file)
        {
            if(file.Length == 0)
            {
                throw new BadHttpRequestException("File Is Empty");
            }
            var webRootPath = _env.WebRootPath;
            if(string.IsNullOrEmpty(webRootPath))
            {
                webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "uploaded");
            }

            var folderPath = Path.Combine(webRootPath, "upload");
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = $"file_{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            return filePath;
        }
    }
}
