#pragma once
#include "raylib.h"
#include "Player.h"

class Game
{
public:
    void Run();

private:
    static constexpr int ScreenWidth = 800;
    static constexpr int ScreenHeight = 450;

    Player player;
    Camera3D camera = {};
    Vector3 shipPosition = {0.0f, 1.0f, 0.0f};
    int hitCount = 0;
    bool holding = false;
    Vector3 holdOffset = {0.0f, 1.0f, -3.0f};
    RayCollision hit = {};

    void Init();
    void Update(float dt);
    void Draw();
};
