# Breakdance Duel Arena (Unity) - Starter Scaffold

Este repositorio ahora contiene una base inicial para comenzar un juego de **duelos de breakdance** en Unity.

## Estructura

- `Assets/Scripts/Core`: gestión global de hype y victorias.
- `Assets/Scripts/Player`: movimiento del bailarín y lectura de combos.
- `Assets/Scripts/Vehicles`: rival interactuable para iniciar duelos (mantiene el archivo por compatibilidad).
- `Assets/Scripts/Interactions`: interacción con rivales en la pista.
- `Assets/Scripts/Missions`: sistema de duelos por rondas y puntuación de estilo.
- `Docs/`: documentación de roadmap y siguientes pasos.

## Flujo recomendado en Unity

1. Crea un proyecto Unity LTS (URP).
2. Copia esta carpeta `Assets/Scripts` dentro del proyecto.
3. Asigna los componentes en la escena:
   - `GameManager` en un objeto global.
   - `PlayerController` en el bailarín principal.
   - `InteractionSystem` en el jugador/cámara.
   - `MissionManager` en un objeto global y enlaza la referencia a `PlayerController`.
   - `VehicleController` en cada rival para iniciar su duelo.
4. Configura duelos en `MissionManager` (meta de puntos y recompensa de hype).

## Loop actual de gameplay

- Te acercas a un rival y presionas **F** para iniciar duelo.
- Ejecutas combinaciones con flechas direccionales:
  - `UDLR` => Windmill
  - `LLRR` => Toprock
  - `DULR` => Headspin
- Cada combo suma puntos de estilo.
- Al alcanzar la meta del duelo, ganas hype y se desbloquea el siguiente rival.

## Estado actual

Esta base es un **MVP técnico**: define clases y flujos para iterar rápido en duelos de danza.
No incluye arte final ni una escena completa.
