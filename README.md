# ChickensShallPrevail

## Descripción
Chickens Shall Prevail es un juego de estrategia y accion en tiempo real.

El objetivo del juego es evitar que las oleadas de enemigos lleguen hasta nuestros pollitos y los maten.

En el juego controlamos en tercera persona a Sir Pipo, un perro leal.
Este tiene la capacidad de dejar magos-torretas para defender su granja, y de dificultar el avance de los enemigos interponiendose en su camino.

Los enemigos no solo estaran buscando llegar a nuestra granja para lastimarla, sino que destruiran cualquier torreta que se encuentren en su camino.

Los enemigos se mueven en carriles fijos, similar a juegos como Plants vs Zombies.

Los magos solo nos ayudaran si les pagamos suficientes huevos, los cuales nuestros pollitos generan.
Tambien podremos generar nuevos pollitos a partir de sus huevos, para acelerar la generacion de recursos.
Sir Pipo recolectara estos huevos automaticamente al tocarlos.

Si logramos sobrevivir a la oleada de enemigos habremos ganado el juego, si por el contrario la vida de nuestra granja llega a cero, habremos perdido.

## Controles

### Movimiento
El juego posee controles de movimiento de tipo tanque:
- `W`: Avanzar hacia delante
- `S`: Avanzar hacia atras
- `A`: Rotar hacia la izquierda
- `D`: Rotar hacia la derecha

### Colocacion de torretas y pollitos
Con las teclas numericas podemos seleccionar que entidad vamos a colocar en el escenario, ya sea el tipo de torreta o un pollito nuevo.
Una vez seleccionado podremos ver su coste de huevos, junto con la cantidad de huevos que poseemos actualmente.

En caso de que tengamos huevos suficientes, con la tecla `E` generaremos la entidad en frente nuestro, apuntando hacia adelante.
Asegurate de que las torretas apunten hacia los enemigos! Una vez generada la entidad no podremos removerla del mapa.

Las entidades disponibles actualmente son:
- `1`: Un pollito para aumentar nuestra produccion de huevos.
- `2`: Torreta Rapida. Dispara linealmente hacia delante a una alta velocidad.
- `3`: Torreta Teledirigida. Sus balas persiguen al enemigo mas cercano.
- `9`: Torreta de Balas Explosivas. Cuando estas balas desaparecen, dejan en su lugar 2 balas nuevas, generando un area de accion.

### Debug
Con fines de testeo del juego, se incluye la opcion de ganar y perder automaticamente, mediante las teclas `V` y `L`, respectivamente.
