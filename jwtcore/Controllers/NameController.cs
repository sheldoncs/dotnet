using System.Collections.Generic;
using AutoMapper;
using jwtcore.Data.Entities;
using jwtcore.Data.Entities.Dtos;
using jwtcore.Filter;
using jwtcore.Repository.Contracts;
using jwtcore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwtcore.Controllers {

    [Authorize]
    [Route("api/advisors/")]
    [ApiController]
    public class NameController:ControllerBase {
        private readonly ICustomAuthenticationManager _customAuthenticationManager;
        private readonly IMapper _mapper;
        public NameController(ICustomAuthenticationManager customAuthenticationManager, IMapper mapper){
            _customAuthenticationManager = customAuthenticationManager;
            _mapper = mapper;
        }
       
         [HttpGet]
         public IEnumerable<string> Get(){
             return new string[] {"sheep","goat"};
         }
         [HttpGet("{id}",Name="Get")]
         public string Get(string id){
             return "value";
         }

        [AllowAnonymous] 
        [HttpPost("authenticate")]
        [AuthenticationFilter]
        public ActionResult<Token> Authenticate(AuthenticateCreateDto authenticationCreateDto)
        {
            var commandModel = _mapper.Map<Authentication>(authenticationCreateDto);
            var readDto = _mapper.Map<AuthenticateReadDto>(commandModel);
            var token = _customAuthenticationManager.Authenticate(authenticationCreateDto.Username, authenticationCreateDto.Password);
            
            var retToken = new Token () {
              token = token
            };

            return Ok(retToken);
        }
       // [HttpGet]

    }
}