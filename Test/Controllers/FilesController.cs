using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }

        [HttpGet]
        public ActionResult GetFile()
        {
            string pathToFile = "tst.zip";
            if (!System.IO.File.Exists(pathToFile))
                return NotFound();

            var bytes = System.IO.File.ReadAllBytes(pathToFile);


            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";

            }

            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
