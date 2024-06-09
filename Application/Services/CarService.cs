using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDto>>(cars);
        }

        public async Task<CarDto> GetCarByIdAsync(Guid id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                throw new KeyNotFoundException("Car not found");
            }
            return _mapper.Map<CarDto>(car);
        }

        public async Task<CarDto> AddCarAsync(CarDto carDto)
        {
            var carEntity = _mapper.Map<Car>(carDto);
            carEntity.CarId = Guid.NewGuid();
            var car = await _carRepository.AddAsync(carEntity);
            return _mapper.Map<CarDto>(car);
        }

        public async Task<CarDto> UpdateCarAsync(CarDto carDto)
        {
            
            var carEntity = await _carRepository.GetByIdAsync(carDto.CarId);
            if (carEntity == null)
            {
                throw new KeyNotFoundException("Car not found");
            }

            _mapper.Map(carDto, carEntity);
            await _carRepository.UpdateAsync(carEntity);
            return _mapper.Map<CarDto>(carEntity);
        }

        public async Task DeleteCarAsync(Guid id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                throw new KeyNotFoundException("Car not found");
            }

            await _carRepository.DeleteAsync(id);
        }
    }
}
