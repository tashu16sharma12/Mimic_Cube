# Mimic Cube

## 🎮 Game Concept

**Mimic Cube** is a fast-paced, hyper-casual runner game developed in Unity. The player controls a glowing cube that moves forward automatically on the right side of the screen. The left side features a ghost player that mirrors the player's real-time movements with simulated network syncing. The goal is to avoid obstacles, collect glowing orbs, and score as high as possible before crashing.

This game is a local simulation of multiplayer synchronization, testing real-time state syncing, shaders, effects, and performance optimization — all without an actual multiplayer server.

---

## 🧠 Core Gameplay Mechanics

- The player-controlled cube auto-moves on the **right side** of the screen.
- **Tap to Jump** to avoid obstacles and collect orbs.
- The **left side** features a ghost cube that mirrors the player’s actions in **real time**, with:
  - Optional configurable delay (to simulate real network lag).
  - Smoothing and interpolation for seamless playback.
- Game speed gradually increases over time.
- Score system based on **distance traveled** and **orbs collected**.

---

## 🔄 Real-Time State Syncing

- Local structures like **queues/ring buffers** are used to simulate multiplayer syncing.
- Ghost player mimics the player’s:
  - Movement
  - Jumps
  - Orb collection
  - Collisions
- Syncing includes:
  - Configurable lag (to simulate real-world latency)
  - Smoothing/interpolation to avoid jitter

---

## 🧩 UI & Game Flow

- **Main Menu**: Start & Exit buttons.
- **Game UI**: Live score displayed at the top.
- **Game Over Screen**: Options to Restart or go to Main Menu.
- Subtle **motion blur shader** added as speed increases.

---

## ⚙️ Performance Optimizations

- **Object Pooling** used for obstacles and orbs.
- Optimized syncing logic to minimize lag and frame drops.
- Total build size kept under **50MB** for mobile compatibility.

---

## ✨ Visual Effects & Shaders

- Glowing shader for the player cube.
- Dissolve shader for obstacles when hit.
- Particle burst effect when collecting orbs.
- Post-processing effects on crash:
  - Chromatic aberration
  - Screen shake
  - Ripple distortion

---

## 📦 Build Compatibility

- Developed in **Unity 2021 or later**
- Optimized for Android builds (`.apk` provided)

---

## 🎥 Demo Video

👉 [Insert link to your gameplay video or GIF here]

---

## 🚀 Getting Started

1. Clone the repo:
   ```bash
   git clone https://github.com/tashu16sharma12/Mimic_Cube.git
