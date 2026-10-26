#include "Game.h"
#include "raymath.h"

void Game::Run()
{
    Init();

    while (!WindowShouldClose())
    {
        Update(GetFrameTime());
        Draw();
    }

    CloseWindow();
}

void Game::Init()
{
    SetConfigFlags(FLAG_VSYNC_HINT | FLAG_MSAA_4X_HINT);
    InitWindow(ScreenWidth, ScreenHeight, "finished");
    SetTargetFPS(60);

    camera.position = {0.0f, 2.0f, 4.0f};
    camera.target = {0.0f, 2.0f, 0.0f};
    camera.up = {0.0f, 1.0f, 0.0f};
    camera.fovy = 60.0f;
    camera.projection = CAMERA_PERSPECTIVE;
}

void Game::Update(float dt)
{
    player.Update(dt);

    camera.target = player.position;

    // Ray goes from the mouse into the 3D world
    Ray ray = GetScreenToWorldRay(GetMousePosition(), camera);
    BoundingBox box = {shipPosition - Vector3One(), shipPosition + Vector3One()};
    hit = GetRayCollisionBox(ray, box);

    // Press E while the mouse is over the ship
    if (IsKeyPressed(KEY_E) && hit.hit)
    {
        holding = true;
    }

    if (IsKeyPressed(KEY_T))
    {
        holding = false;
        shipPosition.y = 1.0f;
    }

    if (holding)
    {
        shipPosition = player.position + holdOffset;
    }
}

void Game::Draw()
{
    BeginDrawing();
    ClearBackground(RAYWHITE);

    BeginMode3D(camera);
    DrawGrid(20, 1.0f);
    player.Draw();
    DrawCube(shipPosition, 2.0f, 2.0f, 2.0f, hit.hit ? YELLOW : GREEN);
    if (hit.hit) DrawSphere(hit.point, 0.15f, RED);
    EndMode3D();

    DrawText("Hello from raylib C++ 3D! Move with WASD / arrows", 10, 10, 20, DARKGRAY);
    DrawText(TextFormat("Ship hits: %i", hitCount), 10, 40, 20, DARKGREEN);
    DrawFPS(ScreenWidth - 90, 10);

    EndDrawing();
}
