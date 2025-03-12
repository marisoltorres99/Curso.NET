using Backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services
{
    public interface IBeerService
    {
        Task<IEnumerable<BeerDTO>> Get();
        Task<BeerDTO> GetById(int id);
        Task<BeerDTO> Add(BeerInsertDTO beerInsertDTO);
        Task<BeerDTO> Update(int id, BeerUpdateDTO beerUpdateDTO);
        Task<BeerDTO> Delete(int id);
    }
}
