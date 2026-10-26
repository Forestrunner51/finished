#include "Player.h"

void Player::Update(float dt)
{
    if (IsKeyDown(KEY_RIGHT) || IsKeyDown(KEY_D)) position.x += Speed * dt;
    if (IsKeyDown(KEY_LEFT)  || IsKeyDown(KEY_A)) position.x -= Speed * dt;
    if (IsKeyDown(KEY_DOWN)  || IsKeyDown(KEY_S)) position.z += Speed * dt;
    if (IsKeyDown(KEY_UP)    || IsKeyDown(KEY_W)) position.z -= Speed * dt;
}

void Player::Draw() const
{
    DrawCube(position, 2.0f, 2.0f, 2.0f, MAROON);
    DrawCubeWires(position, 2.0f, 2.0f, 2.0f, DARKGRAY);
}
