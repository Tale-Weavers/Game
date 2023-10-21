# GDD

## Introducción

### Nombre del Juego

Como posibles nombres del juego se consideran:

- "_Whispers & Whiskers"_
- "_Noir Avian Heist"_
- "_Feather Noir Heist"_
- "_Noir Purr-suit"_
- "_Noir Heist"_
- "_Bird is the Word"_

### Resumen General

Juego single player de sigilo por turnos distribuido por casillas, similar a Hitman Go. El jugador debe avanzar por los diferentes niveles esquivando o neutralizando a los guardias que hay en el escenario, ayudándose de diversos elementos dispuestos en un tablero cuadriculado.

### Género y Plataforma

Sigilo por turnos. Navegador web, con posibilidad de ampliarse a otras plataformas como PC y móvil, respectivamente; Steam y App Store/Play Store en un futuro.

### Público Objetivo

Niños occidentales de entre 5 y 12 años y jugadores casuales occidentales de cualquier rango de edad. Según la clasificación europea "Pan European Game Information" (PEGI), estimamos que nuestro juego se calificaría con un PEGI 7, puesto que se verán escenas con violencia leve en contextos cómicos y se incluirán referencias al crimen organizado y a otros tipos de violencia implícita.

### Objetivos del Juego

El objetivo principal es completar los niveles sin ser atrapado por los enemigos en el mínimo número de movimientos.

Adicionalmente, existe un sistema de logros para que los jugadores completacionistas tengan la opción de conseguir superar una serie de retos.

### Experiencia del Jugador

Queremos ofrecer una experiencia de entretenimiento casual, retos intelectuales y comedia. También queremos fomentar el pensamiento computacional en los niños a través de las mecánicas disponibles en el juego. Pretendemos conseguir esto a través de un diseño de niveles intuitivo y sencillo, que invite al jugador a la exploración y a la experimentación con distintas herramientas y elementos.

### Alcance del Proyecto (Scope)

Como alcance inicial del proyecto, se van a desarrollar entre 10-15 niveles con posibilidad de ampliarlo a futuro. Para la fase de prototipado, se han diseñado 6 niveles de los cuales se han implementado 5 que son completamente jugables.

### Objetivos del Proyecto

El objetivo principal es que los niños aprendan pensamiento computacional a través de las mecánicas del juego.

Se quieren fomentar las siguientes áreas de aprendizaje en los niños:

- Abstracción: Reconocer los elementos clave de un problema y reconocimiento de patrones. Esta área se desarrolla en varios niveles, como por ejemplo en el [tutorial 1](https://github.com/Tale-Weavers/Game#tutorial-1), donde se busca que el jugador sea capaz de identificar qué camino debe elegir y cómo gestionar la presencia del enemigo guardando la salida, o en el [tutorial 2](https://github.com/Tale-Weavers/Game#tutorial-2), donde se necesita que el jugador estudie los patrones de patrullaje de los enemigos y los aproveche para poder esconderse e ir avanzando.

- Descomposición: División de problemas en otros más pequeños y deducción. El refuerzo de esta área del pensamiento computacional se introduce en el [tutorial 3](https://github.com/Tale-Weavers/Game#tutorial-3), donde el jugador debe analizar los recursos disponibles para decidir cómo eliminará a los dos enemigos de la escena, requisito necesario para superar este nivel. Los dos enemigos de este nivel se encuentran en dos áreas diferentes y no deberían interactuar, por lo que el jugador debe enfrentar este nivel como dos problemas independientes más pequeños. Este área también se sigue entrenando en el [nivel 2](https://github.com/Tale-Weavers/Game#nivel-2) y en el [nivel 3](https://github.com/Tale-Weavers/Game#nivel-3-sin-implementar), donde los enemigos se configuran en varios grupos diferenciados, que suponen la división del problema principal (el nivel) en diferentes subproblemas, para los cuales el jugador debe gestionar los recursos disponibles

- Evaluación: Decidir sobre el buen uso de recursos, ajustar acciones según los objetivos y detección de errores. Este área se reforzará en niveles como el[tutorial 3](https://github.com/Tale-Weavers/Game#tutorial-3) y el [nivel 1](https://github.com/Tale-Weavers/Game#nivel-1), donde el jugador tendrá que gestionar los recursos que se encontrará en el escenario para completar el nivel. En el caso del [tutorial 3](https://github.com/Tale-Weavers/Game#tutorial-3), aunque es la introducción a los objetos consumibles, se muestra al jugador cómo usar los objetos que se encontrará a lo largo del juego y que deberá averiguar cómo usar correctamente. Por ejemplo, el jugador tendrá la opción de graznar donde quiera y tendrá que pensar cómo usarlo de la forma más eficiente posible (en este caso el graznido debe realizarse cerca del escondite para que el enemigo vaya a investigar y el jugador le noquee desde una posición segura). Posteriormente, en el [nivel 1](https://github.com/Tale-Weavers/Game#nivel-1), el jugador podrá usar los objetos de forma completamente libre, por tanto tendrá que valorar de forma correcta cómo usarlos para llegar a la salida en el menor número de movimientos posible.

- Generalización: Resolución de problemas basada en problemas anteriores, identificación de patrones, conexiones y similitudes. Este área se entrena a lo largo de prácticamente todo el juego. Durante los diferentes tutoriales y niveles se van introduciendo paulatinamente mecánicas con las que el jugador debe familiarizarse, y que más tarde debe volver a usar en niveles posteriores; así como el comportamiento de los enemigos, para ser capaz de predecirlos. Por ejemplo, en el [tutorial 2](https://github.com/Tale-Weavers/Game#tutorial-2) se introducen los escondites, que el jugador debe aprovechar para pasar desapercibido frente a los enemigos. Estos escondites vuelven a aparecer en numerosos niveles posteriores, por lo que el jugador se debe familiarizar con ellos y debe ser capaz de reconocerlos y saber utilizarlos para su ventaja.

Más adelante, en la sección de niveles de este documento, se explicará detalladamente cómo se mejorará cada área que afecta al pensamiento computacional con las mecánicas.

### Equipo de desarrollo

Tale Weavers es un grupo de alumnos de 4º de Diseño y Desarrollo de Videojuegos del campus de Quintana. Podéis encontrar nuestras redes sociales en [nuestro linktree](https://linktr.ee/TaleWeavers_).

El equipo de desarrollo se compone de 6 alumnos cuyos roles son:

- Gonzalo Barranco Castro: Game Designer, escritor.
- Pablo Conde López: Programador.
- Luis Morón Álvarez: Programador.
- Daniel Salguero Fernández: Game Designer, escritor y músico.
- Almudena Sánchez Encinas: Artista.
- Gloria Turati Domínguez: Artista y músico.

## Mecánicas

### Objetivos del Core Gameplay

El objetivo base de un nivel es acabar el mismo sin ser atrapado por el enemigo.

Para conseguir la máxima puntuación al final del nivel, el jugador tendrá que completar el mapa en el menor número de movimientos posibles, en el mínimo tiempo posible y sin ser detectado.

### Mecánicas de Juego Principales

El juego cuenta con un sistema de turnos donde primero actúa el jugador, pudiendo escoger entre moverse y realizar una acción o saltar su turno. Luego actuaría el resto del mundo, ya sean enemigos o las trampas que ha colocado el jugador en el escenario.

Como mecánicas principales del juego se implementarán desde el prototipo:

- **Movimiento:** El jugador verá un mapa dividido en casillas cuadradas. el movimiento puede darse en cuatro direcciones: Arriba, abajo, izquierda y derecha.
- **Movimiento guardias:** El juego contará con distintos movimientos según el tipo de guardia. Los dos tipos básicos de movimiento de guardia serán estático (no tiene movimiento) y patrullar (se ha implementado un sistema de waypoints que los guardias tienen que seguir, simulando una patrulla por el mapa)
- **Alerta de guardias:** En caso de que se detecte al jugador, los enemigos le perseguirán y buscarán por el mapa hasta atraparle o perderle.
- **Incapacitación de guardias:** Si el jugador encuentra un guardia en una casilla adyacente y no ha sido detectado, el jugador puede neutralizar al enemigo. Los guardias se quedarán en esa casilla incapacitados y si otro guardia encuentra al guardia incapacitado se alertará y dará la alarma a los demás guardias.
- **Distracción de guardias:** El jugador podrá usar diversos objetos para distraer a los guardias. Existirán distintos tipos de distracción, que harán que los enemigos se queden inoperativos o vayan a investigar a cierta zona del nivel.
- **Escondites:** El jugador podrá esconderse en el mapa para evitar a los guardias y no ser detectado. Desde los escondites podrá incapacitar a un guardia que se encuentre próximo al escondite.

### Mecánicas de Juego Futuribles

Se van a plantear las siguientes mecánicas como posibles implementaciones de cara al producto final:

- **Posibilidad de distracciones a distancia:** Se va a estudiar la posibilidad de distraer guardias a distancia con distintos objetos que se explorarán en la sección de Items.
- **Posibilidad de teletransporte:** Se va a estudiar la posibilidad de meter casillas que te teletransportan a otras casillas dentro del escenario.
- **Casillas que modifican el movimiento:** Charco de aceite que hace resbalar y envía al jugador a la siguiente casilla en la dirección que llevaba.
- **Diferentes tipos de enemigos:** Tanto variaciones del enemigo básico como nuevos tipos de gato con características diversas que se detallarán más adelante.

### Sistema de Control

El juego funciona como "point and click". El movimiento básico del personaje y la interacción con los objetos y los enemigos se realiza clicando en la casilla correspondiente para seleccionarla y con un segundo click como confirmación. Adicionalmente, para utilizar algunos objetos el jugador tendrá que hacer click en botones de la interfaz.

### Sistema de Cámara

El juego ofrecerá dos vistas de la cámara que el jugador podrá ir alternando: una vista de la cámara en perspectiva donde se verá el escenario desde un plano picado, que será la cámara por defecto del juego (ejemplo: Hitman Go) y una vista cenital donde se verá todo el escenario al completo (ejemplo: 12 minutes).

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image20.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image42.png)

### Progresión del Juego

A medida que se avance en los niveles del juego, el jugador irá encontrándose con nuevas mecánicas y niveles más complicados de resolver. Los primeros niveles contarán con poca dificultad, para ir introduciendo las mecánicas y que el jugador se familiarice con estas, y a medida que se vaya avanzando por los niveles, estos se irán complicando y el jugador se encontrará con distintos tipos de enemigos, que le supondrán mayor dificultad para completar un nivel.

### Feedback al Jugador

Queremos que el jugador sea consciente en todo momento de qué puede hacer y qué no puede hacer. Por ello, se incluirán sonidos que representen la interacción con el entorno y sus objetos. También, en el departamento visual, se destacarán los objetos consumibles para que el jugador reconozca de forma clara con qué elementos puede interactuar.

## Resumen de las opciones de juego

### Configuraciones del Juego

El menú de opciones del juego contará con los siguientes apartados:

- Volumen: mediante un toggle se puede subir o bajar el volumen al gusto del jugador.
- Idioma: existirá una opción en el menú de pausa para elegir el idioma del juego. Se podrá elegir entre las opciones de español, italiano e inglés.
- Ayuda: se contará con un botón de ayuda para que los jugadores consulten los controles del juego.

### Personalización de Personajes

Desde el menú de inicio se podrá acceder a un menú de personalización del personaje. Los cosméticos se adquirirán mediante pagos con dinero real.

En el menú se podrán elegir distintos cosméticos con una preview del personaje para que el jugador vea en tiempo real qué está cambiando.

### Guardado y Carga de Partidas

En el juego, el jugador contará con la opción guardar su progreso y sus estadísticas para los logros. El guardado se hará automáticamente después de salir de cada nivel (se debe definir exactamente cómo se guardarán los datos). Para el sistema de logros se guardarán las estadísticas siguiendo el siguiente [asset](https://assetstore.unity.com/packages/tools/game-toolkits/achievement-system-151624).

## Estados de Juego
### Diagrama de Flujo
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image29.png)

### Diagrama de Flujo de nivel
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image14.png)

## Interfaces

### Objetivos de la Interfaz de Usuario In-Game

La interfaz debe mostrarle al jugador información relevante para que complete el nivel. De este modo la interfaz solo mostrará:

- Número de movimientos del jugador: Aparecerá un pequeño contador del número de movimientos que se han realizado en ese intento del nivel. De este modo, los jugadores que quieran mejorar su desempeño en un determinado nivel podrán buscar estrategias para reducir el número de movimientos.
- Objetos disponibles: En un lado de la pantalla aparecerán los distintos objetos que el jugador lleva encima. De este modo tendrá la información de qué objetos puede usar y así podrán planificar sus acciones.
- Botones de acción: La interfaz mostrará botones de acción al jugador cuando se necesite. Por ejemplo, si el jugador se coloca al lado de un enemigo aparecerá el botón de acción para noquear a dicho enemigo.

Boceto de la interfaz In-Game:

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image41.png)

### Diseño de Pantallas Principales
El menú principal del juego contará con una imagen que introduzca al jugador al universo del juego, con el título del mismo y con los botones descritos en el diagrama de estados para poder navegar por los distintos menús.
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/UI-menu-principal.png)

### Diseño de Menús y Submenús
#### Inicio de sesion
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/InicioSesionStep0.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/InicioSesionStep1.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/InicioSesionStep2.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/InicioSesionStep3.png)

#### UI Menú principal
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/UI-opciones.png)

#### UI Tienda
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/UI-tienda.png)

#### Selector de Niveles
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/niveles-galeria.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/niveles-trayecto.png)

#### Menú de Pausa
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/UI-pausa.png)

#### UI Victoria
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/UI-victoria.png)

#### UI Derrota
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/UI/UI-derrota.png)

## Niveles

### Tutorial

#### Tutorial 1
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image31.jpg)

Tutorial 1 in-game
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image32.png)

**Explicación:** El camino esperado para el jugador es el marcado con la línea negra. El cuervo tendrá que moverse hacia el gato para noquearlo y posteriormente avanzar hasta la casilla de salida.

**Objetivo y mecánica introducida:** El objetivo de este nivel es introducir la mecánica del noqueo. La competencia entrenada en este nivel es Abstracción. Se busca que el jugador sea capaz de identificar qué camino debe elegir y cómo gestionar la presencia del gato guardando la salida.

#### Tutorial 2

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image13.jpg)

Tutorial 2 in-game
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image23.png)

**Explicación:** El camino superior se encuentra bloqueado por la presencia del gato número 1 que se encuentra vigilando siempre en la misma dirección.

El camino esperado para el jugador se marca con la línea negra, que contará con un gato patrullando. Según la ruta que toma el gato número 2, el jugador deberá seguir sus pasos y esconderse en el "arbusto" (será un tipo de escondite distinto in game) hasta que el enemigo esté adyacente para noquearlo y poder completar el nivel.

**Objetivo y mecánica introducida:** Dar a conocer al jugador la mecánica de los escondites (arbusto) y de esperar. Respecto al pensamiento computacional se espera que el jugador entrene su capacidad de Abstracción reconociendo que no puede ir por un camino y estudiando el patrón de la ruta del gato número 2, así como la Generalización recordando lo aprendido en el primer tutorial para volver a noquear al gato 2 y evitar el cono de visión del gato 1.

#### Tutorial 3
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image44.jpg)

Tutorial 3 in-game
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image49.png)

**Explicación:** El camino esperado por el jugador consiste en avanzar por arriba y recoger el ovillo. Posteriormente debe dejar el ovillo dentro del rango de visión del gato número 1 para que lo recoja y quede fuera de combate. Tras eso el jugador puede avanzar hasta interactuar con la fuente de agua que le permite soltar un graznido con el que atraer al gato número 2 y noquearlo. Con ambos gatos fuera de combate puede completar el nivel.

**Objetivo:** El objetivo de este nivel es introducir al jugador los distintos objetos consumibles que hay en el juego y que aprenda a usar el ovillo y la fuente de agua junto al graznido.

Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (los enemigos le cortan el paso a no ser que use los objetos); Descomposición, puesto que se tendrá que analizar el nivel como dos problemas más pequeños (cómo eliminar al gato 1 y cómo eliminar al gato 2); Evaluación, que se aplicará a cuando el jugador tenga que usar el graznido (deberá usarlo próximo al escondite para noquear al guardia); y Generalización, puesto que aplicará lo aprendido en los dos últimos tutoriales (noqueo, espera y escondites).

### Zona 1

#### Nivel 1

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image2.jpg)

Nivel 1 in-game
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image21.png)

**Explicación:** El jugador tendrá que hacer una gestión adecuada del ovillo y la fuente para terminar el nivel de forma adecuada. Como se puede observar, el nivel tiene varios caminos que se pueden tomar, aunque el más óptimo se encuentra pasando por la zona izquierda. Un ejemplo para completar el nivel sería distraer al gato número 2 con el ovillo y distraer al número 1 con la fuente para despejar el camino. Un camino óptimo se representa con la línea negra del diagrama del nivel.

**Objetivo:** No se introducen nuevas mecánicas en este nivel puesto que se quiere afianzar las mecánicas ya introducidas previamente. De este modo, se aplica el principio de generalización que hará que los jugadores apliquen los conocimientos previos para completar este nivel.

#### Nivel 2
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image16.jpg)

Nivel 2 in-game
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image28.png)

**Explicación:** El camino esperado por el jugador es esconderse del gato número 1 en el escondite para poder noquearlo y posteriormente pasar a la siguiente zona del nivel.

Una vez allí se encuentra con los gatos 2 y 3 vigilando todos los posibles caminos, por lo que el jugador debe avanzar, ser detectado, y esconderse sin ser visto en uno de los arbustos de abajo del nivel.

**Objetivo:** El objetivo de este nivel es introducir la mecánica de esconderse de los guardias cuando han detectado al jugador. Al esconderse sin ser visto por los guardias, éstos perderán al jugador y volverán a sus posiciones. Se espera mejorar la capacidad de generalización de los jugadores aplicando las mecánicas de los anteriores niveles.

#### Nivel 3 (Sin implementar)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image48.jpg)

**Explicación:** El jugador tendrá que coger la carta (láser dentro del juego) y lanzarla a través de la pared para distraer al guardia de más a la derecha. De este modo tendrá acceso a la linterna (la vela en el dibujo) que permitirá deslumbrar al guardia de más a la izquierda, permitiendo al jugador salir del nivel.

**Objetivo:** Introducir la mecánica de la linterna y el láser en este nivel. De nuevo, se reforzarán las capacidades de descomposición (dividir el nivel en 2 subproblemas) y evaluación (usar bien los recursos presentados)del pensamiento computacional.

## Historia

### Introducción al Mundo del Juego

Año 1920, la ciudad de Creatureville ha sufrido una gran expansión durante los últimos años con la promesa de unir a muchas de las especies de animales que habitan el mundo en una sola metrópolis.

La sobrepoblación ha causado la aparición de suburbios rodeando la ciudad y de mafias dispuestas a aprovecharse de las pobres gentes que lo habitan y llegan con deseos de comerse la ciudad.

### Historia del Juego

Los dos cuervos protagonistas, Feather Noir y Midnight Wing deciden dar el golpe final contra la mafia de Don Felino tras haber encontrado donde se esconde gran parte de su dinero.

Desgraciadamente, son descubiertos por la mafia Zarpazo Nueve Vidas que los capturan y encierran. Ahora es el trabajo de Feather Noir encontrar a su amigo Midnight Wing y finalizar de una vez la tiranía de Don Felino.

### Facciones o Grupos

**Zarpazos Nueve Vidas:** Esta facción es la principal facción enemiga. Está compuesta por numerosos tipos de gatos, cada tipo con sus habilidades especiales, que impedirán al jugador seguir avanzando.

Los Zarpazos Nueve Vidas se encargan de extorsionar y robar a los habitantes de los suburbios de Creatureville a cambio de "protección". La misión de Feather Noir y Midnight Wing es detenerles para siempre para que la ciudad pueda vivir en paz.

### Conflictos y Objetivos

El conflicto principal es la desaparición de Midnight Wing y la amenaza de la mafia Zarpazo Nueve Vidas.

Los objetivos del protagonista son:

- Encontrar y salvar a su amigo.
- Liberar a los suburbios de Don Felino.

### Storyboards

Storyboard de la cinemática inicial donde se introduce al jugador a la historia principal:
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image33.png)

## Personajes

### Personajes Relevantes

#### Feather Noir

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image36.png)

Feather Noir es un cuervo originario de Creatureville que se dedica a robar a los malvados para repartirlo entre los pobres. Feather Noir es un pájaro oscuro de denso plumaje y estatura mediana (para un cuervo de Creatureville)

Desde que era un polluelo siempre le han desagradado las injusticias y siempre ha buscado hacer el bien. Cuando llegó a la adolescencia, tras perder a sus padres a manos de un gato mafioso, comenzó a ayudar a los vecinos de Creatureville junto con su amigo Midnight Wing. Juntos comenzaron a enfrentarse a la mafia del Zarpazo Nueve Vidas aprovechando sus capacidades de sigilo y su ingenio.

Feather Noir se especializa en la infiltración pero no es el cuchillo más afilado de la cocina y suele depender de Midnight Wing para planificar las cosas. Nuestros protagonistas planean acabar con la mafia del Zarpazo Nueve Vidas.

#### Midnight Wing

Midnight Wing es un cuervo originario de los suburbios de Creatureville, huérfano a los pocos años que se hizo así mismo dentro de bandas callejeras. Destaca no tanto por sus habilidades físicas sino su intelecto, capacidad de planear y resolución.

Su corazón siempre ha sido noble y destaca por ser alguien tan resolutivo como empático, le desagradan las injusticias sociales y quiere convertir a los suburbios en un lugar mejor. Su similitud en forma de pensar con Feather Noir les convirtió en amigos al poco de conocerse dentro de una banda de los suburbios a la que ambos pertenecían. A los pocos golpes decidieron huir y trabajar por su propia cuenta.

Comparte el objetivo de Feather Noir de acabar con la mafia del Zarpazo Nueve Vidas, sabe que es uno de los mayores males con los que acabar para construir una ciudad mejor.

#### Don Felino (The meowstermind)

Don Felino, conocido dentro de la mafia y en la ciudad como The Meowstermind, es un gato de origen desconocido. Todos saben por su acento que no es de Creaturville, pero nadie se atreve a preguntar su origen ni cómo llegó a la ciudad.

De personalidad seria y áspera y apariencia cuidada, Don Gato ascendió en la mafia gracias a ser un gato sin escrúpulos que primero muerde y luego pregunta. Don Gato es astuto, tenaz y carismático y ha conseguido amasar una gran cantidad de seguidores en su "hermandad felina" Zarpazo Nueve Vidas. Todo esto le ha llevado a ser uno de los animales más poderosos de Creatureville.

Don Felino solo se rodea de gatos de la mafia y tiene contactos por toda la ciudad incluidas las altas esferas de la política local, lo que le asegura un buen grado de impunidad. Su objetivo a corto plazo es hacerse con los suburbios de la ciudad y su objetivo a largo plazo es tomar toda Creatureville.

## Ítems, Interactuables y Enemigos

### Objetos interactuables

#### Fuente

Las fuentes estarán repartidas por los niveles y permitirán cargar al jugador sus graznidos, que permitirán distraer a los guardias cercanos desde cualquier posición del escenario.

Para poder interactuar con la fuente el jugador debe de estar en una casilla adyacente e interactuar con la fuente, lo que consume su acción. Cada fuente puede ofrecer un número restringido de recargas para el jugador. Un jugador no puede beber si ya tiene una carga del graznido.

Los graznidos atraen gatos en un radio circular de 3 casillas para que se muevan a la posición donde se ha realizado el graznido. Si el gato no ha encontrado al jugador y ha llegado a la casilla, termina la alerta para él y todos los enemigos afectados por el graznido. Cuando termina la alerta del graznido cada gato vuelve a su ruta normal.

Radio del graznido:

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image52.png)

#### Ovillo

El ovillo es un objeto que permitirá al jugador distraer a los guardias.

El jugador recoge el ovillo cuando pisa la casilla donde se encuentra. Una vez recogido, el jugador puede gastar la acción para dejar el ovillo en la casilla enfrente de él. El jugador puede volver a recoger un ovillo que está en el suelo si un enemigo no lo ha cogido.

Cuando un guardia vea el ovillo se acercará a él independientemente de su ruta. Cuando llegue a la casilla del ovillo se quedará jugando con él. Si un guardia ve a otro jugando con un ovillo se acercará a él, cuando esté en una casilla adyacente gasta su acción en darle un capón e indicarle que vuelva al trabajo. El jugador no puede pasar por la casilla donde esté jugando un gato. Cuando un guardia deja de estar jugando con el ovillo vuelve a su ruta normal y el ovillo se consume.

#### Láser

Funcionan como los ovillos pero son lanzables.

El jugador recoge el láser cuando pisa la casilla donde se encuentra. Una vez recogido, el jugador puede gastar la acción para dejar el láser en una casilla a una distancia de 2 o 3 casillas. El jugador puede volver a recoger un láser que está en el suelo.

Cuando un guardia vea el láser se acercará a él independientemente de su ruta. Cuando llegue a la casilla del láser se quedará jugando con él. Si un guardia ve a otro jugando con un láser se acercará a él, cuando esté en una casilla adyacente gasta su acción en darle un capón e indicarle que vuelva al trabajo. El jugador no puede pasar por la casilla donde esté jugando un gato. Cuando un guardia deja de estar jugando con el láser vuelve a su ruta normal y el láser se consume.

#### Escondites

Los escondites serán objetos fijos reutilizables repartidos por todo el mapa. Cuando el jugador entra en un escondite desaparece de la visión de un enemigo completamente. Si el enemigo mira cómo el jugador entra en un escondite, el enemigo irá a por él porque sabe que se encuentra ahí dentro.

#### Llaves y puertas

En ciertos niveles se introducirá una mecánica dónde la salida está bloqueada con una puerta que necesita una llave. En estos niveles el jugador tendrá que conseguir la llave que abra la puerta (también las llaves podrán aparecer en forma de interruptores) para poder salir del nivel.

#### Botones de alarma

En algunos niveles el jugador tendrá acceso a botones de alarma que harán que los guardias vayan a la alarma a ver qué ha pasado. Esto permitirá al jugador crear distracciones que pondrá a todos los guardias en alerta y durará hasta que un gato vea que no ha pasado nada y apague la alarma.

#### Alarmas Antiincendios

Cuando el jugador las active se encenderá una alarma antiincendios que hará saltar los aspersores de la sala. Como los gatos le tendrán miedo al agua, la alarma antiincendios impedirá a los gatos pasar por ciertas casillas afectadas por los aspersores.

#### Bombas de humo

El jugador podrá usar bombas de humo para escabullirse una vez le pillen los guardias. Las bombas de humo cubrirán 3 casillas en un radio circular alrededor del jugador de humo, que harán que los gatos se queden confusos durante 5 turnos. Cuando estén dentro del humo los gatos no podrán moverse ni hacer nada, pero el jugador sí que podrá escabullirse.

#### Linterna

Las linternas serán objetos que podrá usar el jugador una vez para deslumbrar a un guardia durante 3 turnos. En estos 3 turnos el guardia no podrá hacer nada y una vez termine el efecto de deslumbramiento el guardia pasará a volver a su rutina.

#### Charco de Aceite

Cuando un personaje pase por una casilla de aceite se resbala y avanza 1 casilla extra en la dirección por la que venía. Se pueden encadenar múltiples charcos de aceite.

### Enemigos

#### Gato Naranja

El enemigo más básico de todos, su comportamiento se define de la siguiente forma:

- Su rango de visión es de 3 casillas. G - - -
- Pueden girarse y cambiar la dirección en la que están mirando.
- Pueden o no moverse. En caso de que se muevan no pueden avanzar más de 1 casilla al mismo tiempo.
- Un gato solo puede hacer 1 acción en el turno ya sea: moverse, girarse o esperar.

#### Gato Persa (Futurible)

El segundo enemigo que se presenta en el juego:

- Su rango de visión es de 3 casillas. G - - -
- Pueden girarse y cambiar la dirección en la que están mirando.
- Pueden o no moverse. En caso de que se muevan no pueden avanzar más de 1 casilla al mismo tiempo.
- Un gato solo puede hacer 1 acción en el turno ya sea: moverse, girarse o esperar.
- El Gato Persa ignora la primera distracción que detecta incluyendo: Graznido, Ovillo, Láser, Linterna, Botones de Alarma, Alarma Antiincendios.

#### Accesorios en los Gatos (Futurible)

Los gatos pueden llegar a tener 1 objeto equipado, lo que le permite protegerse contra ciertas acciones del jugador.

- **Casco Protector:** El gato no puede ser noqueado
- **Orejeras/Tapones:** El gato no se ve afectado por cualquier sonido, lo que incluye: La Alerta Colectiva, Graznido y Alarma Antiincendios.
- **Gafas:** El rango de visión del gato aumenta 2 casillas.
- **Gafas de sol:** El enemigo es inmune a los objetos: láser y linterna.

## Arte Conceptual

### Estilo Artístico

El estilo visual es simple y amigable, orientado a una audiencia joven y cuidado para que sea atractivo y satisfactorio. Va a usar formas geométricas básicas y los modelos de personajes serán de baja poligonización.

Se usarán colores neutros para el entorno con colores vivos o fuertes para elementos importantes como personajes, objetos, campos de visión etc.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image35.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image26.jpg)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image25.jpg)

### Paleta de Colores

El cuervo utilizará tonos azulados para crear la ilusión de la oscuridad de su plumaje sin recurrir directamente al color negro puro y dar tambien así el efecto de los reflejos metálicos típicos de los córvidos.
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image24.png)

Los gatos base serán de color naranja, pero los diferentes tipos de enemigo vendrán diferenciados por color. Todos estarán inspirados en el pelaje de tipos reales de gatos.
Los componentes de gángster de su diseño irán en escala de grises u otros colores oscuros y neutros.
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image1.png)

Habrá diferentes tipos de escenarios según avanza la aventura, los cuales se diferenciarán principalmente por sus colores, que deben permitir el contraste tanto con el cuervo como con los gatos.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image18.png)

### Diseño de Personajes

Los personajes deben ser antropomórficos pero no demasiado, de la misma manera deben ser visualmente atractivos para los jugadores más pequeños sin perder el encanto para jugadores más mayores.

En este aspecto hemos tomado como referencia animales de cómic y personajes de Disney para elaborar bocetos de personajes atractivos.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image30.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image34.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image5.png)

### Diseño de Entornos

Para mayor claridad y que el entorno no distraiga del puzle que conforman las mecánicas del juego, se ha decidido utilizar un estilo que, mientras que sea simple sin dejar de aportar cierto interés visual.

Un ejemplo e inspiración en este aspecto es el juego Monument Valley.
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image4.jpg)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image47.jpg)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image19.jpg)

A pesar de su relativa simpleza, los escenarios son memorables y cautivadores, a la vez que dejan claro al jugador de una mirada su objetivo, el camino a seguir, y los recursos en su mano.

Mientras que en nuestro juego el ambiente no tiene tanto peso como en este, tomaremos inspiración en lo que a estilo se refiere. Queremos capturar la misma limpieza y estilización de la arquitectura.
Al haberse ambientado el juego en un mundo de gangsters reminiscente de la época de los speakeasy, contemporánea al art deco y a la bauhaus, ambos movimientos de gran inspiración geométrica, hemos decidido apoyarnos en estos para decorar los escenarios.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image15.jpg)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image27.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image17.png)

La idea es utilizar motivos geométricos y principios racionalistas para diseñar los entornos, aprovechando los mismos para guiar la mirada del jugador y hacer el juego más intuitivo, usando el entorno como apoyo o acompañamiento a la interfaz.
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image51.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image50.jpg)

La idea es que el fondo sea relativamente neutro en cuanto a paleta y de esta manera ayude a personaje, enemigos y objetos a destacar por color. En principio nos apoyaremos en la iluminación para aumentar este efecto como en estos escenarios de Eddy Loukil:
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image6.jpg)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image45.jpg)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image39.jpg)

### Diseño de Objetos y Requisitos Gráficos

Los objetos han de ser fácilmente identificables y deben destacar en el entorno esto se logrará con una combinación de los colores usados para el fondo y los objetos y la iluminación.

Se ha tomado como referencia la estética de mobiliario y piezas Art Dèco conforme a la estética del juego.

Los objetos estarán modelados en Low Poly y serán visibles en el escenario y fáciles de identificar por el jugador. Seguirán la estética gráfica de los personajes y el ambiente descrita anteriormente.

#### Llaves
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image3.png)

#### Fuente
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image12.png)

#### Ovillo de lana
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image40.png)

#### Botón
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image8.png)

#### Bomba de Humo
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image46.png)

#### Láser
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image37.png)

#### Linterna
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image38.png)

#### Escondite
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image10.png)

### Efectos Visuales (VFX)
El juego contará con diversos efectos visuales para aprovechar las capacidades de Unity y WebGL. Se tendrá en cuenta las limitaciones que ofrece WebGL a la hora de crear dichos shaders. Se desarrollarán los siguientes efectos visuales para darle un toque más especial al juego:
- Humo: Cuando el jugador lance una bomba de humo se generará una cortina de humo.
- Agua de las fuentes: Las fuentes están llenas de agua para que el jugador la consuma. Se realizará un shader para el agua.
- Shader de escondite: si el jugador se esconde en un escondite, puede ver a través de las paredes del escondite.

### Animaciones
Al ser un cuervo, el movimiento estará muy inspirado en el movimiento de un cuervo real, pero este estará exagerado en beneficio del estilo cartoon. A continuación se presentan algunas de las animaciones que tendrá el cuervo:
- Saltitos para el movimiento entre casillas.
- Saltar para esconderse.
- Alarmarse cuando le ven.
- Beber en fuentes.
- Graznar.
- Coger objetos.

Los gatos tendrán un movimiento ligeramente distinto al que tienen en la vida real, pero conservarán muchos de sus manierismos. Algunas de las animaciones de los gatos serán:
- Caminar en dos patas.
- Darse cuenta de que el cuervo está ahí
- Lanzarse a por un ovillo.
- Atacar al cuervo.
- Estar noqueado.

Las animaciones de escenario serán simples, puertas que se abren, láseres que se activan, etcétera.

### Cinemáticas y Cutscenes
Las cinemáticas y cutscenes consistirán en imágenes o viñetas estáticas (o de movimiento sutil) que se suceden para claridad y simplificación del proceso.
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image22.png)

Se mantendrá el estilo antropomórfico amigable y estarán - en apariencia - inspirados por webcomics. Utilizarán trazo claro y coloreado sólido, y los personajes tendrán un poco más de detalle que sus modelos in-game.

## Música y sonido
### Estilo Musical
El estilo músical elegido será el Jazz clásico puesto que queremos evocar a la época de los años 20. La música se producirá utilizando el DAW FL Studio.
Referencias de la música: [Persona 5 Royal](https://www.youtube.com/watch?v=dlZz50FA4y8), música de los 40-50 (Frank Sinatra, the ink spots….).

### Música Ambiental
La música ambiental para los niveles será una melodía tranquila de jazz que irá variando a medida que el jugador avance por los distintos niveles. Empezaremos con una melodía de jazz apacible que irá aumentando la intensidad a lo largo de las distintas zonas del juego.

### Efectos de Sonido (SFX)

En el juego encontraremos gran variedad de efectos sonoros, que incluirán acciones del jugador, interacciones con el mapa y otros efectos dinámicos:
- Sonido de pasos
- Sonido de pasos enemigos
- Sonido de noquear
- Sonido de distraer
- Sonido de pulsar un interruptor/tirar de una palanca
- Sonido de esconderse
- Sonido al completar un nivel
- Sonido de alerta de los enemigos

### Diseño de Sonido
Los sonidos tendrán un estilo cartoon que no resulten muy agresivos al jugador. Se pretende que los niveles se jueguen tranquilamente en sesiones cortas, por ello, no se abrumará al jugador con sonidos demasiado estridentes o fuertes.

### Doblaje
El juego como tal no tendrá doblaje, pero sí se incluirán sonidos durante los diálogos al estilo de Animal Crossing. La forma de crear estos sonidos se estudiará más adelante cuando el juego esté más desarrollado.

## Logros

1. **Amigo rescatado:** Completar todos los niveles
2. **Cuervo discreto:** Completar un nivel sin ser detectado
3. **Cuervo sigiloso:** Completar un nivel sin ser detectado y sin noquear
4. **Sombra corvina:** Completar todo el juego sin ser detectado
5. **El cuervo más sigiloso de toda Creatureville:** Completar todo el juego sin ser detectado y sin noquear
6. **Infiltrado novato:** Conseguir un total de 150 estrellas
7. **Infiltrado cauto:** Conseguir un total de 200 estrellas
8. **Maestro de la infiltración:** Conseguir un total de 250 estrellas
9. **No molestes al cuervo:** Noquear a 50 guardias
10. **Sin testigos:** Noquear a 100 guardias
11. **Cría cuervos y te sacarán los ojos:** Noquear a 200 guardias
12. **Perfección:** Conseguir todas las estrellas de un nivel
13. **No deja títere sin cabeza:** Conseguir todas las estrellas del juego
14. **Solo me hacen falta mis plumas:** Completar un nivel sin usar objetos
15. **Cuervo hidratado:** Beber de 10 fuentes
16. **Los favoritos de mi abuela:** Usar 5 ovillos para distraer a 5 guardias
17. **Dropping flash(bang):** Deslumbrar 10 veces a 10 enemigos con la linterna
18. **El especial Gonso:** Escabullirse con una bomba de humo
19. **Aquí hay cuervo encerrado:** Usar 50 escondites
20. **Kamikaze:** Activar a propósito 3 alarmas
21. **Por las plumas:** Cubrir tu salida con un aspersor anti incendios cuando huyas de un guardia
22. **Ábrete sésamo:** Recoger 10 llaves para abrir puertas
23. **Siesta forzosa:** Eliminar a 15 guardias desde un escondite
24. **Experto felino:** Noquear al menos 1 vez a cada tipo enemigo
25. **Fin del terror de Don Felino** : Acabar con Don Felino
26. **Compañero emplumado** : Rescatar a Midnight Wing
27. **No sin mi antifaz:** Completar el tutorial
28. **Buscando recovecos:** Encontrar un camino alternativo en un nivel
29. **Física de partículas:** Teletransportarse por primera vez en un nivel
30. **Física de partículas aplicada:** Usar el teletransporte para perder a un guardia

## Referencias y autoría

Fishtrouts. (s.f.). _Crows and Dragons._ Tallin.

Games, U. (s.f.). _Monument Valley._ Oval, South London.

Howard, B. (s.f.). _Zootopia concept art._ Disney.

Kahl, M. E. (s.f.). Gato Jazz. _Aristocats._ Disney.

Kahl, M. E. (s.f.). White Cat. _Robin Hood._ Disney.

Kurzgesagt. (s.f.). _bird avatars._ Kurzgesagt, Munich.

Loukil, E. (s.f.). _Perspectio._ Montreal.

Wood, Z. M. (s.f.). _Art Deco Environment Hotel._ Chicago.

# **Modelo de negocio**

Se va a desarrollar un modelo de negocio para estudiar la viabilidad comercial de nuestro proyecto. En este escrito se van a analizar diversas áreas de nuestro proyecto para ver qué cosas nos faltan por definir o mejorar. El objetivo es crear un videojuego que enseñe pensamiento computacional a niños pequeños.

##
# Equipo

El grupo está compuesto por 6 miembros, cada uno con sus especialidades. Por tanto, nos vamos a repartir el trabajo del proyecto de la siguiente forma:

- Gonzalo Barranco Castro: Game Designer y escritor.
- Pablo Conde López: Programador y Game Designer.
- Luis Morón Álvarez: Jefe de programación
- Daniel Salguero Fernández: Game Designer, escritor y artista técnico.
- Almudena Sanchez Encinas: Artista
- Gloria Turati Domínguez: Artista y música.

##
# Financiación

La financiación inicial del proyecto se conseguirá a través de ahorros propios con posibilidad de habilitar un crowdfunding en caso de lograr gran visibilidad del proyecto. Como todos los miembros del equipo cuentan con equipo propio, no se tendrá que invertir dinero en esta primera fase inicial si no se tienen en cuenta gastos energéticos y licencias. Todo el dinero necesario para las licencias se aportará de manera equitativa entre los miembros del equipo. De esta forma, se conseguiría llevar a cabo el proyecto completo, con posibilidad de ampliarlo con paquetes de niveles nuevos.

Para la financiación inicial se necesitará:

- Coste de Personal: 0€; No vamos a cobrar por el desarrollo del juego
- Coste de Software y licencias: 1000€; Licencia de Unity, Photoshop, 3Ds Max, Substance, Steam y App Store.
- Costes de Hardware: 0€; Se van a usar los equipos de los que disponemos
- Coste de Marketing y Producción: 100-200€ Participación en ferias de videojuegos y promoción por redes sociales.
- Costes de suministros: 600€ de electricidad por persona en los 6 meses.

**Coste total: 1700-1800€**

Por otro lado, vamos a detallar cómo obtener dinero y nuestra propuesta de valor en los siguientes apartados, donde haremos un análisis del mercado objetivo a través de conocer a nuestros usuarios.

##
# Información sobre el usuario

**Usuario 1: Niños de 5 a 14 años**

**¿Quién es?**

Niños y niñas de 5 a 14 años de edad principalmente occidentales, es decir, niños de Europa, América, Australia, Nueva Zelanda… Por tanto todos los usuarios finales tendrán una cultura occidental con dichos códigos culturales sin muchas diferencias notables.

Estos niños jugarán en los dispositivos móviles de sus padres (o sus propios dispositivos móviles) o en los ordenadores de las aulas.

**¿Situación?**

Etapas de desarrollo escolar con ligeros conocimientos de pensamiento computacional.

**¿Cómo es?**

Curiosos, juguetones, enérgicos, sociables….

**¿Aficiones?**

Jugar videojuegos. Los puzzles. Juegos de mesa. Las matemáticas.

Los niños tienden a querer juegos rápidos con estímulos constantes, de tipo arcade. Un niño siempre va a preferir aprender con un juego dinámico a aprender con algo que le recuerde a las clases normales.

**¿Actividad?**

Estudiantes

**¿Qué necesita?**

Entretenimiento. Aprender pensamiento computacional.

La forma de conseguir que aprenda pensamiento computacional será a través de reformar su capacidad de Abstracción (Reconocer los elementos clave de un problema y reconocimiento de patrones), Descomposición (Descomposición de problemas en otro más pequeño y deducción), Evaluación (Decidir sobre el buen uso de recursos, ajustar acciones según los objetivos y detección de errores ) y Generalización (Resolución de problemas basada en problemas anteriores, identificación de patrones, conexiones y similitudes)

**¿Qué quiere el usuario?**

Entretenimiento. Pasarlo bien. Jugar. Retos personales y ser completistas.

Es importante recalcar que los padres de los niños tienen gran influencia en las decisiones de los niños, por tanto estos no pueden hacer todo lo que ellos quieran.

**Usuario 2: Jugadores casuals**

**¿Quién es?**

Personas aficionadas a juegos de puzzles, que juegan en tiempos cortos, que buscan un reto. Perfil occidental, de 15 años en adelante. Se tendrán en cuenta las diferencias generacionales dentro de este perfil. El juego tendrá que apelar a todos los públicos. De nuevo, igual que en los niños, no se tendrán en cuenta grandes diferencias culturales.

**¿Situación?**

Diversas. Pueden ser estudiantes, trabajadores….

**¿Cómo es?**

Relajados. Jugadores ocasionales. Buscan entretenimiento rápido. No son expertos en videojuegos. No están dispuestos a gastar mucho dinero y/o tiempo en un videojuego.

Por ello hay que ofrecer niveles que duren unos pocos minutos (no más de 10 minutos en resolver un determinado nivel). También tendremos en cuenta que los usuarios no querrán gastar mucho dinero en el juego de una vez. Por tanto, ofrecerán varios packs de niveles a precios bajos para que los usuarios consuman.

**¿Aficiones?**

Videojuegos. Puzzles. Juegos de mesa

**¿Actividad?**

Variada. Pueden trabajar y/o estudiar.

**¿Qué necesita?**

Entretenimiento. Un reto corto. Despejar la mente.

**¿Qué quiere el usuario?**

Descansar un rato corto. Entretenimiento en pequeñas dosis.

**Usuario 3: Instituciones educativas**

**¿Quién es?**

Instituciones educativas de diversos puntos de España y/o otros países occidentales. Instituciones tanto privadas como públicas. Principalmente nos centraremos en las instituciones educativas de primaria puesto que nuestro juego servirá para mejorar el pensamiento computacional en jóvenes.

**¿Situación?**

En busca de digitalizar las aulas y las actividades educativas. En busca de gamificar el estudio y favorecer el pensamiento computacional. Estas instituciones quieren aumentar el interés de los alumnos a la hora de estudiar y quieren aumentar sus capacidades de pensamiento computacional.

**¿Cómo es?**

Profesionales de la educación. Con ganas de innovar. Pedagogos. Dichos profesionales quieren profundizar en cómo mejorar el aprendizaje para así ganar prestigio en la comunidad educativa.

**¿Actividad?**

Preparación de clases. Enseñar. Orientación de alumnos.

**¿Qué necesita?**

Medios para enseñar. Herramientas educativas para enseñar pensamiento computacional.

**¿Qué quiere el usuario?**

Quiere mejorar sus competencias educativas invirtiendo el mínimo dinero posible.

##
# Mapa de empatía

**Usuario 1: Niños de 5 a 14 años**
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image43.png)

**¿Qué piensa y siente?**

Aspiran a completar un reto impuesto y les inquieta continuar con el próximo nivel.

**¿Qué oye?**

Oyen a otros amigos jugar al juego y conseguir más niveles o más puntuación. También escucha a los mayores instándolos a jugarlo por su factor educativo.

**¿Qué ve?**

Ven a otros amigos jugarlo y posibles promociones en redes.

**¿Qué dice y hace?**

Compartir consejos y estrategias con sus amigos, hablar con entusiasmo de los niveles que han conseguido completar y su puntuación.

**Esfuerzo medios**

Aspecto visual agradable, asegurar que cumple con los requisitos clave y entregar un producto que favorezca el pensamiento computacional mientras continúa siendo un juego entretenido por sí solo.

**Resultados beneficios**

Que los niños mejoren sus habilidades de pensamiento computacional y resolución de problemas, que el juego les resulte entretenido y que lo recomienden a sus amigos.

**Usuario 2: Jugadores casuales**

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image9.png)

**¿Qué piensa y siente?**

Piensan en jugar a algo en su descanso para ser capaz de despejar la mente. El videojuego puede hacerles sentir emoción y satisfacción al completar un nivel. También puede generar frustración si se atascan en algún nivel y no son capaces de terminarlo en su breve periodo de juego.

**¿Qué oye?**

Pueden escuchar del juego a través de sus amigos y las recomendaciones de otros usuarios en la tienda de aplicaciones.

**¿Qué ves?**

Pueden ver a través de anuncios breves en plataformas móviles, redes sociales o webs de juegos.

**¿Qué dice y hace?**

Conversar sobre el juego junto a sus compañeros o amigos en el descanso, despejar su mente tras completar unos cuantos niveles.

**Esfuerzo medios**

Aspecto visual agradable con mecánicas y controles lo más simples posibles para adaptarse al público casual. Niveles cortos con posibles pistas para evitar frustraciones. Actualizar el juego con constancia.

**Resultados beneficios**

Compras dentro del juego siguiendo un modelo freemium, obtener una base de jugadores leales y satisfechos que aporten feedback, reconocimiento del estudio y el juego dentro de la industria.

**Usuario 3: Instituciones educativas**
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image7.png)

**¿Qué piensa y siente?**

Pueden estar preocupados por el equilibrio entre enseñanza y videojuegos, también pueden sentir satisfacción con los resultados finales de los alumnos.

**¿Qué oye?**

Pueden escuchar sobre las iniciativas y la necesidad de aplicar nuevas formas de enseñanza más interactivas. También pueden escuchar a través de los padres que han visto a sus hijos jugarlo u otras escuelas que ya lo hayan podido utilizar.

**¿Qué ves?**

Una escuela puede ver a otra aplicando este método de aprendizaje con buenos resultados.

**¿Qué dice y hace?**

Utilizar el juego como modo de aprendizaje novedoso y entretenido. Pueden incentivar a padres a comprar videojuegos educativos a sus hijos para continuar desde casa.

**Esfuerzo medios**

Invertir tiempo en asegurarse que el juego estimula el pensamiento computacional e implementar alguna forma de medir y hacer un seguimiento del progreso de los niños que jugarán al videojuego.

**Resultados beneficios**

Una forma entretenida de aprender permitiendo una enseñanza más atractiva y efectiva. Buen nombre entre instituciones e internacionalización al resto de países occidentales.

##
# Canvas

**Socios clave:** Instituciones educativas, inversores y publishers. No tenemos relación con ninguna institución educativa concreta ni con ninguna entidad de gobierno, por tanto, habría que trabajar en ese aspecto.

**Actividades clave:** Desarrollo de videojuegos y soporte de los mismos tras un previo análisis del mercado actual del videojuego casual.

**Recursos clave:** Oficinas, equipos informáticos aptos para el diseño y desarrollo, integrantes de la empresa con conocimientos sobre desarrollo de videojuegos y la capacidad de enseñar pensamiento computacional. En caso de sacar el juego al mercado se tendrá que considerar contratar un equipo de marketing para gestionar toda la publicidad y difusión.

**Estructura de costes:** Licencias de programas de desarrollo (unity, photoshop), costes de electricidad, licencias de steam y app store, salarios de los empleados, pagos a empresas externas de marketing y asesoramiento legal….

**Propuesta de valor:** Enseñar pensamiento computacional a niños (nicho de mercado, mar azul). Mercado casual (mar rojo).

Con nuestro juego se conseguirá mejorar las siguientes competencias del pensamiento computacional:

- Abstracción: Reconocer los elementos clave de un problema y reconocimiento de patrones
- Descomposición: Descomposición de problemas en otro más pequeño y deducción
- Evaluación: Decidir sobre el buen uso de recursos, ajustar acciones según los objetivos y detección de errores
- Generalización: Resolución de problemas basada en problemas anteriores, identificación de patrones, conexiones y similitudes

**Relación con el consumidor:** El modelo de enseñanza y aprendizaje actualizados a los tiempos modernos. Ofrecemos un producto y damos servicios de mantenimiento. Mantendremos a nuestros consumidores sacando expansiones del juego

**Canales:** Itch.io, Steam, App Store. Se comprarán las licencias necesarias para la publicación del videojuego en estas plataformas.

**Mercado meta:** Instituciones educativas de primaria que busquen innovar en el aprendizaje, niños occidentales (entre 5 y 12 años), principalmente europeos y americanos, jugadores casuales, inversores, profesores.

**Flujo de ingresos:** freemium del producto, expansiones del producto (más niveles por precios bajos), venta de licencias, micropago, posibilidad de anuncios.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/imagen53.png)

##
# Toolbox
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image11.png)

# **Viabilidad a 2 años**

Dadas las métricas anteriormente vistas, vamos a proceder a estudiar la viabilidad del proyecto a 2 años.

Una vez sacado nuestro videojuego vía web, se estudiará su portabilidad a otras plataformas (Steam y App Store) para aumentar la base de público con la que contamos. No sólo queremos apelar a las instituciones educativas y a los niños si no también al público casual una vez el proyecto finalice.

Cuando se haya llevado el juego a otras plataformas, la forma que se usará para conseguir dinero con el proyecto serán las descritas en el canvas.

El juego contará con un modelo de negocio freemium, es decir, todos los usuarios tendrán acceso a una parte del juego y si quieren completarlo al 100% tendrán que comprar las expansiones de los niveles. Por tanto se conseguirá dinero de las siguientes formas:

- **Expansiones del producto:** Se irán sacando paquetes de niveles de forma regular para así mantener el flujo de los jugadores y el flujo de ingresos. Aproximadamente se sacarán unos 16 paquetes de expansión de 5 niveles cada uno para conformar un total de 100 niveles en el juego. Por cada paquete se estima que se emplearán unas 4 semanas de trabajo a jornada completa, es decir, unas 850 man hours para completar un paquete de expansión. En total, para llevar a cabo todos los paquetes harían falta 16 meses de trabajo o 13600 man hours.

- **Venta de licencias:** Otro modo de ganar dinero será a través de la venta de licencias a centros educativos. Dado que no tenemos contacto directo con ninguna institución educativa tendríamos que comenzar participando en concursos públicos de la CAM o bien ir a instituciones educativas privadas a ofrecer nuestro producto.

Dada la naturaleza burocrática de estos procesos, donde hay que aportar documentación específica y hay que realizar diversos trámites, calculamos que, entre conseguir la información necesaria, aportar la documentación a la institución responsable y esperar a la salida de los resultados del concurso público, se emplearán unas 115 man hours en el supuesto de conseguir toda la documentación en 2 semanas.

- **Micropagos:** El juego implementará un sistema de micropagos para cosméticos que no afectarán al flujo del juego. En principio se mantendrán los micropagos en cosméticos para el personaje y los enemigos pero se estudiará más adelante el meter micropagos con otros impactos.

Dado que la naturaleza de nuestros micropagos será puramente estética, se tendrán que realizar distintos modelados tanto de escenarios como de enemigos por cada paquete de cosméticos. Aproximadamente por cada paquete de cosméticos, que incluirán diversos cambios visuales, se estima una semana de trabajo de nuestras dos artistas, es decir, unas 100 manhours.

- **Posibilidad de anuncios:** Se va a plantear la posibilidad de introducir anuncios en el juego. En caso de hacerlo, se pondrán anuncios cortos en momentos y puntos muy concretos (por ejemplo, después de completar 3 niveles, un pequeño banner de anuncio en el menú principal o el selector de niveles….). Queremos mantener el flujo del juego constante y sin interrupciones.

Para llevar a cabo la implementación de anuncios tendríamos que buscar información acerca de cómo incluirlos y adaptar la build del juego para implementarlos. Se calcula que se puede implementar esta funcionalidad en unos 5 días de trabajo de una persona, es decir, unas 40 manhours.
