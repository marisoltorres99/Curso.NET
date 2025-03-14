﻿using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO>
    {
        private IRepository<Beer> _beerRepository;
        private IMapper _mapper;

        public BeerService(IRepository<Beer> beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }
        public async Task<BeerDTO> Add(BeerInsertDTO beerInsertDTO)
        {
            var beer = _mapper.Map<Beer>(beerInsertDTO);

            await _beerRepository.Add(beer);

            // se guardan los datos en BD
            await _beerRepository.Save();

            var beerDTO = _mapper.Map<BeerDTO>(beer);

            return beerDTO;
        }

        public async Task<BeerDTO> Delete(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                var beerDTO = _mapper.Map<BeerDTO>(beer);

                _beerRepository.Delete(beer);
                await _beerRepository.Save();

                return beerDTO;
            }

            return null;
        }

        public async Task<IEnumerable<BeerDTO>> Get()
        {
            var beers = await _beerRepository.Get();

            return beers.Select(b => _mapper.Map<BeerDTO>(b));
        }

        public async Task<BeerDTO> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                var beerDTO = _mapper.Map<BeerDTO>(beer);

                return beerDTO;
            }

            return null;
        }

        public async Task<BeerDTO> Update(int id, BeerUpdateDTO beerUpdateDTO)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                beer = _mapper.Map<BeerUpdateDTO, Beer>(beerUpdateDTO, beer);

                _beerRepository.Update(beer);
                await _beerRepository.Save();

                var beerDTO = _mapper.Map<BeerDTO>(beer);

                return beerDTO;
            }

            return null;
        }
    }
}
