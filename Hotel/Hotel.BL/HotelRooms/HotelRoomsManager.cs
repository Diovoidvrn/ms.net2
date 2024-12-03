using AutoMapper;
using Hotel.BL.HotelRooms.Entities;
using Hotel.DataAccess.Entities;
using Hotel.DataAccess;

namespace Hotel.BL.HotelRooms
{
    public class HotelRoomsManager : IHotelRoomsManager
    {
        private readonly IRepository<HotelRoomEntity> _hotelRoomsRepository;
        private readonly IMapper _mapper;

        public HotelRoomsManager(IRepository<HotelRoomEntity> hotelRoomsRepository, IMapper mapper)
        {
            _hotelRoomsRepository = hotelRoomsRepository;
            _mapper = mapper;
        }
        public HotelRoomModel CreateHotelRoom(CreateHotelRoomModel model)
        {
            var entity = _mapper.Map<HotelRoomEntity>(model);

            _hotelRoomsRepository.Save(entity);

            return _mapper.Map<HotelRoomModel>(entity);
        }

        public void DeleteHotelRoom(Guid id)
        {
            var entity = _hotelRoomsRepository.GetById(id);

            if (entity == null)
                throw new ArgumentException("Hotel room not found");

            _hotelRoomsRepository.Delete(entity);
        }

        public HotelRoomModel UpdateHotelRoom(Guid id, UpdateHotelRoomModel model)
        {
            var entity = _hotelRoomsRepository.GetById(id);

            if (entity == null)
                throw new ArgumentException("Hotel room not found");

            entity.Description = model.Description;
            entity.NumberOfGuests = model.NumberOfGuests;
            entity.Price = model.Price; 

            _hotelRoomsRepository.Save(entity);

            return _mapper.Map<HotelRoomModel>(entity);
        }
    }
}
