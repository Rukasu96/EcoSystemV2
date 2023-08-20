
using EcoSystem_2._0;

Board board = new Board();
Spawner spawner = new Spawner(board.WidthSize, board.HeightSize);

while (true)
{
    //human.Move();
    TurnController.Instance.StartTurn();
}

