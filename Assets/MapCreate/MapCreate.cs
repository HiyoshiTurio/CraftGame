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
    [SerializeField] private int randomNumRange = 2; //エリア生成する際にランダム決める数の幅
    [SerializeField] private float prefabSize = 1; //生成するタイルの大きさ
    private int _areaWidth = 30;
    private int _areaHeight = 30;

    private void Start()
    {
        CreateMap();
    }

    void CreateMap()
    {
        Area area1 = new Area();
        Area area2 = new Area();
        int x;
        int y;
        (area1, area2, x, y) = DivideArea(areaData.area);
        
        InstanceArea(area1);
        InstanceArea(area2);
        Room room1 = CreateRoomByArea(area1);
        Room room2 = CreateRoomByArea(area2);
        InstanceRoom(room1);
        InstanceRoom(room2);
        
        if (x != 0)
        {
            int x1 = GetRandomNumByRoomHorizontal(room1); //未完成
        }
        else
        {
            
        }
    }

    void InstanceArea(Area area)
    {
        for (int i = 0; i < area.width; i++)
        {
            for (int j = 0; j < area.height; j++)
            {
                GameObject tile = Instantiate(_tilePrefab, new Vector3((area.x + i) * prefabSize, (area.y + j) * prefabSize, 0), Quaternion.identity);
                Vector3 tileSize = tile.transform.localScale;
                tileSize *= prefabSize;
                tile.transform.localScale = tileSize;
                
                SpriteRenderer renderer =  tile.GetComponent<SpriteRenderer>();
                renderer.color = Color.black;
                renderer.renderingLayerMask = 0;
            }
        }
    }

    void InstanceRoom(Room room)
    {
        for (int i = 0; i < room.width; i++)
        {
            for (int j = 0; j < room.height; j++)
            {
                GameObject tile =  Instantiate(_tilePrefab, new Vector3((room.x + i) * prefabSize, (room.y + j) * prefabSize, 0), Quaternion.identity);
                Vector3 tileSize = tile.transform.localScale;
                tileSize *= prefabSize;
                tile.transform.localScale = tileSize;
            }
        }
    }

    void InstanceRoad(Vector2 pivot, int x, int y)
    {
        if (x != 0)
        {
            for (int i = 0; i < x; i++)
            {
                GameObject tile = Instantiate(_tilePrefab, new Vector3((pivot.x + i) * prefabSize, pivot.y * prefabSize), Quaternion.identity);
                Vector3 tileSize = tile.transform.localScale;
                tileSize *= prefabSize;
                tile.transform.localScale = tileSize;
            }
        }
        else
        {
            for (int i = 0; i < y; i++)
            {
                GameObject tile = Instantiate(_tilePrefab, new Vector3(pivot.x * prefabSize, (pivot.y + i) * prefabSize), Quaternion.identity);
                Vector3 tileSize = tile.transform.localScale;
                tileSize *= prefabSize;
                tile.transform.localScale = tileSize;
            }
        }
    }
    
    void InstanceRoad(Road road)
    {
        for (int i = 0; i < road.width; i++)
        {
            for (int j = 0; j < road.height; j++)
            {
                Instantiate(_tilePrefab, new Vector3(road.x + i, road.y + j, 0), Quaternion.identity);
            }
        }
    }
    Room CreateRoomByArea(Area area)
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
        
        return room;
    }

    bool CheckSizesForDividedAreas(Area area, int size) //room(調べたいエリア) size(エリアの最小サイズ)
    {
        if (area.width / 3 > size && area.height / 3 > size)
        {
            return true;
        }
        return false;
    }
    //引数Areaは分けたAreaのデータ
    (Area,Area,int,int) DivideArea(Area area) //room(分けたいエリア)
    {
        Area area1 = new Area();
        Area area2 = new Area();
        Random random = new Random();
        int x = 0;
        int y = 0;
        int randomNum = random.Next(-randomNumRange, randomNumRange);
        if (area.width > area.height) //横長のエリアだった場合縦に切る(area1が左、area2が右)
        {
            area1.x = area.x;
            area1.width = area.width / 2 + randomNum;
            area1.y = area.y;
            area1.height = area.height;
            
            area2.x = area.x + area1.width;
            area2.width = area.width - area1.width;
            area2.y = area.y;
            area2.height = area.height;
            
            x = area1.width;
        }
        else //縦長のエリアだった場合横に切る(area1が下、area2が上)
        {
            area1.x = area.x;
            area1.width = area.width;
            area1.y = area.y;
            area1.height = area.height / 2 + randomNum;
            
            area2.x = area.x;
            area2.width = area.width;
            area2.y = area.y + area1.height;
            area2.height = area.height - area1.height;

            y = area1.height;
        }
        return (area1, area2, x, y);
    }

    void CreateRoad(Room room1, Room room2)
    {
        
    }

    int GetRandomNumByRoomVertical(Room room) //渡されたRoomの水平面の範囲からランダムな値を返す
    {
        int x;
        Random random = new Random();
        x = random.Next(room.x, room.width + 1);
        return x;
    }

    int GetRandomNumByRoomHorizontal(Room room) //渡されたRoomの垂直面の範囲からランダムな値を返す
    {
        int y;
        Random random = new Random();
        y = random.Next(room.y, room.height + 1);
        return y;
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

[Serializable]
public struct Road
{
    public int x;
    public int y;
}
