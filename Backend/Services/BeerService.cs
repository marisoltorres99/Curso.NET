using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO>
    {
        private StoreContext _context;
        private IRepository<Beer> _beerRepository;

        public BeerService(StoreContext context, IRepository<Beer> beerRepository)
        {
            _context = context;
            _beerRepository = beerRepository;
        }
        public async Task<BeerDTO> Add(BeerInsertDTO beerInsertDTO)
        {
            var beer = new Beer()
            {
                Name = beerInsertDTO.Name,
                Alcohol = beerInsertDTO.Alcohol,
                BrandID = beerInsertDTO.BrandID
            };

            await _beerRepository.Add(beer);

            // se guardan los datos en BD
            await _beerRepository.Save();

            var beerDTO = new BeerDTO
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };

            return beerDTO;
        }

        public async Task<BeerDTO> Delete(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer != null)
            {
                var beerDTO = new BeerDTO
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID
                };

                _context.Remove(beer);
                await _context.SaveChangesAsync();

                return beerDTO;
            }

            return null;
        }

        public async Task<IEnumerable<BeerDTO>> Get()
        {
            var beers = await _beerRepository.Get();

            return beers.Select(b => new BeerDTO
            {
                Id = b.BeerID,
                Name = b.Name,
                Alcohol = b.Alcohol,
                BrandID = b.BrandID
            });
        }

        public async Task<BeerDTO> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                var beerDTO = new BeerDTO
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID
                };

                return beerDTO;
            }

            return null;
        }

        public async Task<BeerDTO> Update(int id, BeerUpdateDTO beerUpdateDTO)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                beer.Name = beerUpdateDTO.Name;
                beer.BrandID = beerUpdateDTO.BrandID;
                beer.Alcohol = beerUpdateDTO.Alcohol;

                _beerRepository.Update(beer);
                await _beerRepository.Save();

                var beerDTO = new BeerDTO
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID
                };

                return beerDTO;
            }

            return null;
        }
    }
}
