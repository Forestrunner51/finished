using System.Numerics;
using Raylib_cs;

const int ScreenWidth = 800;
const int ScreenHeight = 450;

Raylib.SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.Msaa4xHint);
Raylib.InitWindow(ScreenWidth, ScreenHeight, "finished");
Raylib.SetTargetFPS(60);

var camera = new Camera3D
{
    Position = new Vector3(0f, 10f, 10f),
    Target = Vector3.Zero,
    Up = Vector3.UnitY,
    FovY = 45f,
    Projection = CameraProjection.Perspective,
};

var position = new Vector3(0f, 1f, 0f);
const float Speed = 5f;

while (!Raylib.WindowShouldClose())
{
    float dt = Raylib.GetFrameTime();

    if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D)) position.X += Speed * dt;
    if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A)) position.X -= Speed * dt;
    if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S)) position.Z += Speed * dt;
    if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W)) position.Z -= Speed * dt;

    // Camera follows the cube from above and behind
    camera.Target = position;
    camera.Position = position + new Vector3(0f, 9f, 9f);

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);

    Raylib.BeginMode3D(camera);
    Raylib.DrawGrid(20, 1f);
    Raylib.DrawCube(position, 2f, 2f, 2f, Color.Maroon);
    Raylib.DrawCubeWires(position, 2f, 2f, 2f, Color.DarkGray);
    Raylib.EndMode3D();

    Raylib.DrawText("Hello from Raylib-cs 3D! Move with WASD / arrows", 10, 10, 20, Color.DarkGray);
    Raylib.DrawFPS(ScreenWidth - 90, 10);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();
