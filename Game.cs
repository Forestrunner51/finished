using System.Numerics;
using Raylib_cs;

public class Game
{
    const int ScreenWidth = 800;
    const int ScreenHeight = 450;

    Player player = new Player();
    Camera3D camera;
    Vector3 shipPosition = new Vector3(0f, 1f, 0f);
    int hitCount = 0;
    bool holding = false;
    Vector3 holdOffset = new Vector3(0f, 1f, -3f);
    RayCollision hit;

    public void Run()
    {
        Init();

        while (!Raylib.WindowShouldClose())
        {
            Update(Raylib.GetFrameTime());
            Draw();
        }
    }
}
