using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class RentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public RentalService(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RentalDto>> GetAllRentalsAsync()
        {
            var rentals = await _rentalRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RentalDto>>(rentals);
        }

        public async Task<RentalDto> GetRentalByIdAsync(Guid id)
        {
            var rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null)
            {
                throw new KeyNotFoundException("Rental not found");
            }
            return _mapper.Map<RentalDto>(rental);
        }

        public async Task<RentalDto> AddRentalAsync(RentalDto rentalDto)
        {
            var rentalEntity = _mapper.Map<Rental>(rentalDto);
            rentalEntity.RentalId = Guid.NewGuid();
            var rental = await _rentalRepository.AddAsync(rentalEntity);
            return _mapper.Map<RentalDto>(rental);
        }

        public async Task<RentalDto> UpdateRentalAsync(RentalDto rentalDto)
        {
            var rentalEntity = await _rentalRepository.GetByIdAsync(rentalDto.RentalId);
            if (rentalEntity == null)
            {
                throw new KeyNotFoundException("Rental not found");
            }

            _mapper.Map(rentalDto, rentalEntity);
            await _rentalRepository.UpdateAsync(rentalEntity);
            return _mapper.Map<RentalDto>(rentalEntity);
        }

        public async Task DeleteRentalAsync(Guid id)
        {
            var rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null)
            {
                throw new KeyNotFoundException("Rental not found");
            }

            await _rentalRepository.DeleteAsync(id);
        }
    }
}
