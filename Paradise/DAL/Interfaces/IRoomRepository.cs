using System;
using System.Collections.Generic;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IRoomRepository : IDisposable
    {
        IEnumerable<Room> FindAllRooms();
        Room GetRoomById(int roomId);
        void InsertRoom(Room room);
        void DeleteRoom(int roomId);
        void UpdateRoom(Room room);
        void Save();
    }
}