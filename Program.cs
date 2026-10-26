using System.Numerics;
using Raylib_cs;
using System;

public static class Program{
const int ScreenWidth = 800;
const int ScreenHeight = 450;

Raylib.SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.Msaa4xHint);
Raylib.InitWindow(ScreenWidth, ScreenHeight, "finished");
Raylib.SetTargetFPS(60);
var position = new Vector3(0f, 1f, 0f);
var cameraPosition = new Vector3(5f, 50f, 0f);
var camera = new Camera3D
public void Init()
{

    Position = new Vector3(0.0f, 2.0f, 4.0f),
    Target = new Vector3(0.0f, 2.0f, 0.0f),
    Up = new Vector3(0.0f, 1.0f, 0.0f),
    FovY = 60f,
    Projection = CameraProjection.Perspective,


var rap = new Vector2(0, 0);
    var shipPosition = new Vector3(0f, 1f, 0f);
    var raycenter = new Vector3(10f, 5f, 0f);
    const float Speed = 5f;
    int hitCount = 0;
    bool holding = false;
    var holdOffset = new Vector3(0f, 1f, -3f);
}
while (!Raylib.WindowShouldClose())
{
    float dt = Raylib.GetFrameTime();

    if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D)) position.X += Speed * dt;
    if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A)) position.X -= Speed * dt;
    if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S)) position.Z += Speed * dt;
    if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W)) position.Z -= Speed * dt;


    // Camera follows the cube from above and behind
    camera.Target = position;


    // Ray goes from the mouse into the 3D world
    Ray ray = Raylib.GetScreenToWorldRay(Raylib.GetMousePosition(), camera);
    var box = new BoundingBox(shipPosition - Vector3.One, shipPosition + Vector3.One);
    RayCollision hit = Raylib.GetRayCollisionBox(ray, box);

    // Press E while the mouse is over the ship
    if (Raylib.IsKeyPressed(KeyboardKey.E) && hit.Hit)
    {
        holding = true;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.T))
    {
        holding = false;
        shipPosition.Y = 1f;
    }

    if (holding){
        shipPosition = position + holdOffset;
    }

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);

    Raylib.BeginMode3D(camera);
    Raylib.DrawGrid(20, 1f);
    Raylib.DrawCube(position, 2f, 2f, 2f, Color.Maroon);
    Raylib.DrawCube(shipPosition, 2f, 2f ,2f, hit.Hit ? Color.Yellow : Color.Green);
    if (hit.Hit) Raylib.DrawSphere(hit.Point, 0.15f, Color.Red);
    Raylib.DrawCubeWires(position, 2f, 2f, 2f, Color.DarkGray);
    Raylib.EndMode3D();

    Raylib.DrawText("Hello from Raylib-cs 3D! Move with WASD / arrows", 10, 10, 20, Color.DarkGray);
    Raylib.DrawText($"Ship hits: {hitCount}", 10, 40, 20, Color.DarkGreen);
    Raylib.DrawFPS(ScreenWidth - 90, 10);
Raylib.EndDrawing();
}


Raylib.CloseWindow();
