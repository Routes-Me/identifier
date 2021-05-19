using System;
using IdentifiersService.Abstraction;
using IdentifiersService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentifiersService.Controllers
{
    [ApiController]
    [ApiVersion( "1.0" )]
    [Route("v{version:apiVersion}/")]
    public class IdentifiersController : ControllerBase
    {
        private readonly IIdentifiersRepository _IdentifiersRepository;
        public IdentifiersController(IIdentifiersRepository IdentifiersRepository)
        {
            _IdentifiersRepository = IdentifiersRepository;
        }

        [HttpGet]
        [Route("identifiers")]
        public IActionResult GenerateIdentifiers()
        {
            GeneratedIdentifierResponse generatedIdentifier = new GeneratedIdentifierResponse();
            try
            {
                generatedIdentifier = _IdentifiersRepository.GenerateIdentifiers();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            generatedIdentifier.Message = CommonMessage.IdentifierGenerated;

            return StatusCode(StatusCodes.Status200OK, generatedIdentifier);
        }

        [HttpGet]
        [Route("identifiers/resource-names")]
        public IActionResult GenerateResourceNames()
        {
            GeneratedResourceNamesResponse response = new GeneratedResourceNamesResponse();
            try
            {
                 response.resourceName = _IdentifiersRepository.GenerateResourceNames();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
