using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET5.Business;
using RestWithASP_NET5.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class FileController : ControllerBase
    {
        private readonly IFileBusiness _fileBusiness;

        public FileController(IFileBusiness fileBusiness)
        {
            _fileBusiness = fileBusiness;
        }
        
        [HttpPost("upload-file")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileDetailVO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public async Task<IActionResult> UploadOneFile([FromForm] IFormFile file)
        {
            FileDetailVO detail = await _fileBusiness.SaveFileToDisk(file);
            return Ok(detail);
        }

        [HttpPost("upload-multiple-files")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileDetailVO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public async Task<IActionResult> UploadMultipleFiles([FromForm] List<IFormFile> files)
        {
            List<FileDetailVO> details = await _fileBusiness.SaveFilesToDisk(files);
            return Ok(details);
        }
    }
}
