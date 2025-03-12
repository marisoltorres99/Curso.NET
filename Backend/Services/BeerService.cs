using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : IBeerService
    {
        private StoreContext _context;

        public BeerService(StoreContext context)
        {
            _context = context;
        }
        public async Task<BeerDTO> Add(BeerInsertDTO beerInsertDTO)
        {
            var beer = new Beer()
            {
                Name = beerInsertDTO.Name,
                Alcohol = beerInsertDTO.Alcohol,
                BrandID = beerInsertDTO.BrandID
            };

            await _context.Beers.AddAsync(beer);

            // se guardan los datos en BD
            await _context.SaveChangesAsync();

            var beerDTO = new BeerDTO
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };

            return beerDTO;
        }

        public Task<BeerDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BeerDTO>> Get() =>
            await _context.Beers.Select(b => new BeerDTO
            {
                Id = b.BeerID,
                Name = b.Name,
                Alcohol = b.Alcohol,
                BrandID = b.BrandID
            }).ToListAsync();

        public async Task<BeerDTO> GetById(int id)
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

                return beerDTO;
            }

            return null;
        }

        public async Task<BeerDTO> Update(int id, BeerUpdateDTO beerUpdateDTO)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer != null)
            {
                beer.Name = beerUpdateDTO.Name;
                beer.BrandID = beerUpdateDTO.BrandID;
                beer.Alcohol = beerUpdateDTO.Alcohol;

                await _context.SaveChangesAsync();

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
