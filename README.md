# GTA Mini (Unity) - Starter Scaffold

Este repositorio contiene una base inicial para comenzar un juego estilo **GTA mini** en Unity.

## Estructura

- `Assets/Scripts/Core`: gestión global del juego.
- `Assets/Scripts/Player`: movimiento de jugador en tercera persona.
- `Assets/Scripts/Vehicles`: control simple de vehículo.
- `Assets/Scripts/Interactions`: interacción con objetos/NPCs.
- `Assets/Scripts/Missions`: sistema básico de misiones por estados.
- `Docs/`: documentación de roadmap y siguientes pasos.

## Flujo recomendado en Unity

1. Crea un proyecto Unity LTS (URP).
2. Copia esta carpeta `Assets/Scripts` dentro del proyecto.
3. Asigna los componentes en la escena:
   - `GameManager` en un objeto global.
   - `PlayerController` en el jugador.
   - `VehicleController` en cada coche.
   - `InteractionSystem` en el jugador/cámara.
   - `MissionManager` en un objeto global.
4. Crea prefabs y conecta referencias desde el Inspector.

## Estado actual

Esta base es un **MVP técnico**: define clases y flujos iniciales para iterar rápido.
No incluye arte final ni una escena completa.
