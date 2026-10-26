using System.Numerics;
using Raylib_cs;

public class Player
{

    public Vector3 Position= new Vector3(0f,1f,0f);
    const float Speed = 5f;

    public void Update(float dt)
    {
        if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D)) Position.X += Speed * dt;
        if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A)) Position.X += Speed * dt;
        if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S)) Position.X += Speed * dt;
        if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W)) Position.X += Speed * dt;

    }

    public void Draw()
    {
        Raylib.DrawCube(Position, 2f, 2f, 2f, Color.Maroon);
        Raylib.DrawCubeWires(Position, 2f, 2f, 2f, Color.DarkGray);
    }
}
