﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIExemploInjecao.Testes;

namespace APIExemploInjecao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ITesteA _testeA;
        private ITesteB _testeB;
        private TesteC _testeC;
        
        public ValuesController(
            ITesteA testeA,
            ITesteB testeB,
            TesteC testeC)
        {
            _testeA = testeA;
            _testeB = testeB;
            _testeC = testeC;
        }

        [HttpGet]
        public ActionResult<object> Get(
            [FromServices]ITesteA testeA,
            [FromServices]ITesteB testeB,
            [FromServices]TesteC testeC)
        {
            var valoresA = new { Construtor = _testeA.IdReferencia,
                Action = testeA.IdReferencia };
            var valoresB = new { Construtor = _testeB.IdReferencia,
                Action = testeB.IdReferencia };
            var valoresC = new { Construtor = _testeC.IdReferencia,
                Action = testeC.IdReferencia };

            return new { valoresA, valoresB, valoresC };
        }
   }
}