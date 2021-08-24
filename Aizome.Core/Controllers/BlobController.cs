using Aizome.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aizome.Core.Controllers
{
    public class BlobController : ControllerBase
    {
        private readonly IBlobService _blobService;
        public BlobController(IBlobService blobService)
        {
            _blobService = blobService;
        }
    }
}
