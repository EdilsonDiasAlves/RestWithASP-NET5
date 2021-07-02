using Microsoft.AspNetCore.Http;
using RestWithASP_NET5.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string filename);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files);
    }
}
