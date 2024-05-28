using UnityEngine;
using UnityEngine.UI;

public class TreasureTile : MonoBehaviour, IGridTilePosition, ITreasureOpen
{
    TilePosition tile_Position;
    private bool isOpened = false;
    private TreasureStatus treasureStatus = TreasureStatus.NONE;



    public TilePosition GetTilePosition()
    {
        return tile_Position;
    }

    public void TilePosition(TilePosition tileposition)
    {
        tile_Position = tileposition;
    }

    #region Open Treasure

    public void OpenTreasure()
    {
        if (treasureStatus == TreasureStatus.READY)
        {
            // open the treasure 
            // show the reward

        }
        else
            if (treasureStatus == TreasureStatus.NONE)
        {
            // play animation
        }


    }
    public void ResetTreasure()
    {

    }

    #endregion
}





interface IGridTilePosition
{
    void TilePosition(TilePosition tileposition);
    TilePosition GetTilePosition();
}
interface ITreasureReward
{
    public void Reward(int quantity, Image image);

    public int Quantity { get; set; }
    public Image Image { get; set; }
}

interface ITreasureOpen
{
    public void OpenTreasure();
    public void ResetTreasure();
}


public struct TilePosition
{
    public int x;
    public int y;
}
public enum TreasureStatus { NONE = 0, READY = 1, OPENED = 1 }
