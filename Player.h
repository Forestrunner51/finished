#pragma once
#include "raylib.h"

class Player
{
public:
    Vector3 position = {0.0f, 1.0f, 0.0f};

    void Update(float dt);
    void Draw() const;

private:
    static constexpr float Speed = 5.0f;
};
