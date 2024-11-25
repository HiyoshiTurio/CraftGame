using System;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    [SerializeField] private TestRoomData _roomData;
    [SerializeField] private GameObject _tilePrefab;
    private int _mapWidth = 30;
    private int _mapHeight = 30;

    private void Start()
    {
        CreateRoom(_roomData.room);
    }


    void CreateRoom(Room room)
    {
        for (int i = 0; i < room.width; i++)
        {
            for (int j = 0; j < room.height; j++)
            {
                Instantiate(_tilePrefab, new Vector3(room.x + i, room.y + j, 0), Quaternion.identity);
            }
        }
    }

    bool CheckRoomSizesForDividedRoom(Room room, int size) //room(調べたい部屋) size(部屋の最小サイズ)
    {
        if (room.width / 3 > size && room.height / 3 > size)
        {
            return true;
        }
        return false;
    }
    (Room,Room) DivideRoom(Room room) //room(分けたい部屋)
    {
        Room room1 = new Room();
        Room room2 = new Room();
        if (room.width > room.height) //横長の部屋だった場合縦に切る
        {
            
        }
        else //縦長の部屋だった場合横に切る
        {
            
        }
        
        return (room1, room2);
    }
}
[Serializable]
public struct Room
{
    public int x;
    public int y;
    public int width;
    public int height;
}
