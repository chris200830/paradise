using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Interfaces;
using DTO.Entities;
using DAL.Database;
using System.Linq;

namespace DAL.Repositories
{
    internal class RoomRepository : IRoomRepository
    {
        private bool disposed;

        private readonly WpfAppContext context;

        public RoomRepository(WpfAppContext context)
        {
            this.context = context;
        }

        public void DeleteRoom(int roomId)
        {
            var room = context.Rooms.Find(roomId);

            if (room == null)
                return;

            context.Rooms.Remove(room);
        }

        public IEnumerable<Room> FindAllRooms()
        {
            return context.Rooms.Include(r => r.RoomInteractiveObjects).ToList();
        }

        public Room GetRoomById(int roomId)
        {
            return context.Rooms.Include(r => r.RoomInteractiveObjects).ToList().Find(r => r.Id == roomId);
        }

        public void InsertRoom(Room room)
        {
            context.Rooms.Add(room);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            context.Entry(room).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
