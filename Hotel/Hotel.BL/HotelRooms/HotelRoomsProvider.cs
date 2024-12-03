using AutoMapper;
using Hotel.BL.HotelRooms.Entities;
using Hotel.DataAccess.Entities;
using Hotel.DataAccess;

namespace Hotel.BL.HotelRooms
{
    public class HotelRoomsProvider : IHotelRoomsProvider
    {
        private readonly IRepository<HotelRoomEntity> _hotelRoomsRepository;
        private readonly IMapper _mapper;

        public HotelRoomsProvider(IRepository<HotelRoomEntity> hotelRoomsRepository, IMapper mapper)
        {
            _hotelRoomsRepository = hotelRoomsRepository;
            _mapper = mapper;
        }
        public HotelRoomModel GetHotelRoomInfo(Guid id)
        {
            var room = _hotelRoomsRepository.GetById(id);
            if (room is null)
                throw new ArgumentException("Hotel room not found.");

            return _mapper.Map<HotelRoomModel>(room);
        }

        public IEnumerable<HotelRoomModel> GetHotelRooms(HotelRoomModelFilter modelFilter = null)
        {
            var numberOfGuests = modelFilter?.NumberOfGuests;
            var minPrice = modelFilter?.MinPrice;
            var maxPrice = modelFilter?.MaxPrice;
          

            var rooms = _hotelRoomsRepository.GetAll(x => (
                numberOfGuests == null || numberOfGuests == x.NumberOfGuests ||
                minPrice == null || minPrice < x.Price ||
                maxPrice == null || maxPrice > x.Price ));

            return _mapper.Map<IEnumerable<HotelRoomModel>>(rooms);
        }
    }
}
