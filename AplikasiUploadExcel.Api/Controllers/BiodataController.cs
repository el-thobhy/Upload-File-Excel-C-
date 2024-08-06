using AplikasiUploadExcel.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplikasiUploadExcel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiodataController : ControllerBase
    {
        private readonly IBiodataServices _services;
        public BiodataController()
        {
            
        }
    }
}
