using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public enum RoomType
    {
        EMPTY = 0,
        COMBAT = 1,
        ELITE = 2,
        EVENT = 3,
        MERCHANT = 4,
        BOSS = 5,
        CHEST = 6,
        FIREPLACE = 7
    }
    public RoomType type = RoomType.EMPTY;

    public List<Room> nextRooms;
    public List<Room> prevRooms;

    public int x;
    public int y;

    public bool accessible = false;

    public Room(int x, int y)
    {
        nextRooms = new List<Room>();
        prevRooms = new List<Room>();

        this.x = x;
        this.y = y;
    }

    public void Connect(Room prev, Room next)
    {
        prev.nextRooms.Add(next);
        next.prevRooms.Add(prev);
    }

    public bool isAlone()
    {
        return this.nextRooms.Count + this.prevRooms.Count <= 0;
    }

    public bool Equals(Room room)
    {
        if (x == room.x && y == room.y && type == room.type && accessible == room.accessible)
            return true;
        else
            return false;
    }

}
