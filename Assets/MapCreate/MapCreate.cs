using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class MapCreate : MonoBehaviour
{
    [SerializeField] private TestRoomData roomData;
    [SerializeField] private TestAreaData areaData;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private int _roomRandomX = 3;
    [SerializeField] private int _roomRandomY = 3;
    [SerializeField] private int _roomMinSize = 5;
    private int _areaWidth = 30;
    private int _areaHeight = 30;

    private void Start()
    {
        createArea(areaData.area);
        CreateRoomByArea(areaData.area);
    }

    void createArea(Area area)
    {
        for (int i = 0; i < area.width; i++)
        {
            for (int j = 0; j < area.height; j++)
            {
                GameObject tile = Instantiate(_tilePrefab, new Vector3(area.x + i, area.y + j, 0), Quaternion.identity);
                SpriteRenderer renderer =  tile.GetComponent<SpriteRenderer>();
                renderer.color = Color.black;
                renderer.renderingLayerMask = 0;
            }
        }
    }
    void CreateRoomByArea(Area area)
    {
        Room room = new Room();
        Random random = new Random();
        
        //Areaの座標をもとに部屋の座標を作成
        int roomX = random.Next(1, _roomRandomX);
        int roomY = random.Next(1, _roomRandomY);
        room.x = roomX + area.x;
        room.y = roomY + area.y;
        
        //部屋のサイズを決定（このとき部屋の座標とAreaの座標を上のコードでずらしてあるのでそれを考慮してサイズを決定する）
        int roomWidth = random.Next(_roomMinSize,area.width - roomX);
        int roomHeight = random.Next(_roomMinSize,area.height - roomY);
        room.width = roomWidth;
        room.height = roomHeight;
        
        for (int i = 0; i < room.width; i++)
        {
            for (int j = 0; j < room.height; j++)
            {
                Instantiate(_tilePrefab, new Vector3(room.x + i, room.y + j, 0), Quaternion.identity);
            }
        }
    }

    bool CheckSizesForDividedAreas(Area area, int size) //room(調べたい部屋) size(部屋の最小サイズ)
    {
        if (area.width / 3 > size && area.height / 3 > size)
        {
            return true;
        }
        return false;
    }
    (Area,Area) DivideArea(Area room) //room(分けたい部屋)
    {
        Area area1 = new Area();
        Area area2 = new Area();
        if (room.width > room.height) //横長の部屋だった場合縦に切る
        {
            
        }
        else //縦長の部屋だった場合横に切る
        {
            
        }
        return (area1, area2);
    }
}
//AreaとRoomの構造体
//Area: 全体の座標とサイズ
[Serializable]
public struct Room
{
    public int x;
    public int y;
    public int width;
    public int height;
}

//Room: 部屋の座標とサイズ
[Serializable]
public struct Area
{
    public int x;
    public int y;
    public int width;
    public int height;
}
