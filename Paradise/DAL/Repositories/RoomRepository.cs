using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Interfaces;
using DTO.Entities;
using DAL.Database;
using System.Linq;

namespace DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public RoomRepository(WpfAppContext context)
        {
            _context = context;
        }

        public void DeleteRoom(int roomId)
        {
            var room = _context.Rooms.Find(roomId);

            if (room == null)
                return;

            _context.Rooms.Remove(room);
        }

        public IEnumerable<Room> FindAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetRoomById(int roomId)
        {
            return _context.Rooms.Find(roomId);
        }

        public void InsertRoom(Room room)
        {
            _context.Rooms.Add(room);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
