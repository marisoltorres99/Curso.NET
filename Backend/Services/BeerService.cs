using Backend.DTOs;

namespace Backend.Services
{
    public class BeerService : IBeerService
    {
        public Task<BeerDTO> Add(BeerInsertDTO beerInsertDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BeerDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BeerDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<BeerDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BeerDTO> Update(int id, BeerUpdateDTO beerUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
