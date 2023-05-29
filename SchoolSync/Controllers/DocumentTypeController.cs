using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSync.DAL.Repositories.Interfaces; 

namespace SchoolSync.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        public DocumentTypeController(IDocumentType documentType)
        {

        }



    }
}