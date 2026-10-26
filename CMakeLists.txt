cmake_minimum_required(VERSION 3.16)
project(finished CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_EXPORT_COMPILE_COMMANDS ON)

# raylib installed via Homebrew (brew install raylib)
find_package(raylib REQUIRED)

add_executable(finished main.cpp Game.cpp Player.cpp)
target_link_libraries(finished PRIVATE raylib)

if(APPLE)
    target_link_libraries(finished PRIVATE "-framework IOKit" "-framework Cocoa" "-framework OpenGL")
endif()
