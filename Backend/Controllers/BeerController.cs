﻿using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private IValidator<BeerInsertDTO> _beerInsertValidator;
        private IValidator<BeerUpdateDTO> _beerUpdateValidator;
        private ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO> _beerService;

        public BeerController(IValidator<BeerInsertDTO> beerInsertValidator, 
            IValidator<BeerUpdateDTO> beerUpdateValidator,
            [FromKeyedServices("beerService")] ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO> beerService)
        {
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator = beerUpdateValidator;
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDTO>> Get() =>
            await _beerService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDTO>> GetById(int id)
        {
            var beerDTO = await _beerService.GetById(id);

            return beerDTO == null ? NotFound() : Ok(beerDTO);
        }

        [HttpPost]

        public async Task<ActionResult<BeerDTO>> Add(BeerInsertDTO beerInsertDTO)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDTO);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var beerDTO = await _beerService.Add(beerInsertDTO);

            return CreatedAtAction(nameof(GetById), new { id = beerDTO.Id }, beerDTO);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<BeerDTO>> Update(int id, BeerUpdateDTO beerUpdateDTO)
        {
            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDTO);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var beerDTO = await _beerService.Update(id, beerUpdateDTO);

            return beerDTO == null ? NotFound() : Ok(beerDTO);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<BeerDTO>> Delete(int id)
        {
            var beerDTO = await _beerService.Delete(id);
            return beerDTO == null ? NotFound() : Ok(beerDTO);
        }
    }
}
