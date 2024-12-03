using AutoMapper;
using Hotel.WebAPI.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;
using Hotel.BL.HotelRooms;
using Hotel.BL.HotelRooms.Entities;

namespace Hotel.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoomsProvider _hotelRoomsProvider;
        private readonly IHotelRoomsManager _hotelRoomsManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public HotelRoomsController(IHotelRoomsProvider hotelRoomsProvider, IHotelRoomsManager hotelRoomsManager, IMapper mapper,
            ILogger logger)
        {
            _hotelRoomsManager = hotelRoomsManager;
            _hotelRoomsProvider = hotelRoomsProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet] 
        public IActionResult GetAllHotelRooms()
        {
            var rooms = _hotelRoomsProvider.GetHotelRooms();
            return Ok(new HotelRoomsListResponse()
            {
                HotelRooms = rooms.ToList()
            });
        }

        [HttpGet]
        [Route("filter")] 
        public IActionResult GetFilteredHotelRooms([FromQuery] HotelRoomsFilter filter)
        {
            var rooms = _hotelRoomsProvider.GetHotelRooms(_mapper.Map<HotelRoomModelFilter>(filter));
            return Ok(new HotelRoomsListResponse()
            {
                HotelRooms = rooms.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetHotelRoomInfo([FromRoute] Guid id)
        {
            try
            {
                var room = _hotelRoomsProvider.GetHotelRoomInfo(id);
                return Ok(room);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateHotelRoom([FromBody] CreateHotelRoomsRequest request)
        {
            try
            {
                var room = _hotelRoomsManager.CreateHotelRoom(_mapper.Map<CreateHotelRoomModel>(request));
                return Ok(room);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateHotelRoomInfo([FromRoute] Guid id, UpdateHotelRoomRequest request)
        {

            try
            {
                var room = _hotelRoomsManager.UpdateHotelRoom(id, _mapper.Map<UpdateHotelRoomModel>(request));
                return Ok(room);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHotelRoom([FromRoute] Guid id)
        {
            try
            {
                _hotelRoomsManager.DeleteHotelRoom(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);

            }
        }
    }
}
