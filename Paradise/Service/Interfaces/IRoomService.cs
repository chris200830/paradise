using System.Collections.Generic;
using DTO.Entities;

namespace Service.Interfaces
{
    public interface IRoomService
    {
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void RemoveRoom(Room room);
        void Dispose();
        IEnumerable<Room> GetRooms();
    }
}