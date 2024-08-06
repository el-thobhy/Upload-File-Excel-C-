using AplikasiUploadExcel.Web.ViewModel;

namespace AplikasiUploadExcel.Web.Services
{
    public class BiodataServices
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _url = "";
        BiodataViewModel response = new BiodataViewModel();

        public BiodataServices(string url)
        {
            _url =  url;
        }
        //public async Task<List<BiodataViewModel>> GetAllBiodata()
        //{
        //    string response = await _client.GetStringAsync(_url);
        //}
    }
}
