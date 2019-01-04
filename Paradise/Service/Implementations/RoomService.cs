using System.Collections.Generic;
using DAL.Database;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Entities;
using Service.Interfaces;

namespace Service.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService()
        {
            var context = new WpfAppContext();
            roomRepository = new RoomRepository(context);
        }

        public void AddRoom(Room room)
        {
            roomRepository.InsertRoom(room);
            roomRepository.Save();
        }

        public IEnumerable<Room> GetRooms()
        {
            return roomRepository.FindAllRooms();
        }

        public void RemoveRoom(Room room)
        {
            roomRepository.DeleteRoom(room.RoomId);
            roomRepository.Save();
        }

        public void UpdateRoom(Room room)
        {
            roomRepository.UpdateRoom(room);
            roomRepository.Save();
        }

        public void Dispose()
        {
            roomRepository.Dispose();
        }
    }
}
