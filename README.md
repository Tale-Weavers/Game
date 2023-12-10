# GDD

## Introducción

### Nombre del Juego

_ **Whispers & Whiskers** _

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

Como alcance inicial del proyecto, se van a desarrollar entre 10-15 niveles con posibilidad de ampliarlo a futuro.

Para la fase de prototipado, se han diseñado 6 niveles de los cuales se han implementado 5 que son completamente jugables.

Para la fase de beta, en el juego se han desarrollado 21 niveles con posibilidad de ampliarse a 22 con un jefe final. De este modo, se ha logrado superar el alcance inicial del proyecto y se han hecho 6 niveles más de los previstos.

### Objetivos del Proyecto

El objetivo principal es que los niños aprendan pensamiento computacional a través de las mecánicas del juego.

Se quieren fomentar las siguientes áreas de aprendizaje en los niños:

- Abstracción: Reconocer los elementos clave de un problema y reconocimiento de patrones. Esta área se desarrolla en varios niveles, como por ejemplo en el [tutorial 1](#_kyzpz7ezrxzp), donde se busca que el jugador sea capaz de identificar qué camino debe elegir y cómo gestionar la presencia del enemigo guardando la salida, o en el [tutorial 2](#_hf175fta6aac), donde se necesita que el jugador estudie los patrones de patrullaje de los enemigos y los aproveche para poder esconderse e ir avanzando.
- Descomposición: División de problemas en otros más pequeños y deducción. El refuerzo de esta área del pensamiento computacional se introduce en el [tutorial 3](#_7ka8f6xzyden), donde el jugador debe analizar los recursos disponibles para decidir cómo eliminará a los dos enemigos de la escena, requisito necesario para superar este nivel. Los dos enemigos de este nivel se encuentran en dos áreas diferentes y no deberían interactuar, por lo que el jugador debe enfrentar este nivel como dos problemas independientes más pequeños. Este área también se sigue entrenando en el [nivel 2](#_vnuzg9mqv1sc) y en el [nivel 3](#_5yaj58b6g6xh), donde los enemigos se configuran en varios grupos diferenciados, que suponen la división del problema principal (el nivel) en diferentes subproblemas, para los cuales el jugador debe gestionar los recursos disponibles
- Evaluación: Decidir sobre el buen uso de recursos, ajustar acciones según los objetivos y detección de errores. Este área se reforzará en niveles como el[tutorial 3](#_7ka8f6xzyden) y el [nivel 1](#_kfz0e5paqu9z), donde el jugador tendrá que gestionar los recursos que se encontrará en el escenario para completar el nivel. En el caso del [tutorial 3](#_7ka8f6xzyden), aunque es la introducción a los objetos consumibles, se muestra al jugador cómo usar los objetos que se encontrará a lo largo del juego y que deberá averiguar cómo usar correctamente.

Por ejemplo, el jugador tendrá la opción de graznar donde quiera y tendrá que pensar cómo usarlo de la forma más eficiente posible (en este caso el graznido debe realizarse cerca del escondite para que el enemigo vaya a investigar y el jugador le noquee desde una posición segura). Posteriormente, en el [nivel 1](#_kfz0e5paqu9z), el jugador podrá usar los objetos de forma completamente libre, por tanto tendrá que valorar de forma correcta cómo usarlos para llegar a la salida en el menor número de movimientos posible.

- Generalización: Resolución de problemas basada en problemas anteriores, identificación de patrones, conexiones y similitudes. Este área se entrena a lo largo de prácticamente todo el juego. Durante los diferentes tutoriales y niveles se van introduciendo paulatinamente mecánicas con las que el jugador debe familiarizarse, y que más tarde debe volver a usar en niveles posteriores; así como el comportamiento de los enemigos, para ser capaz de predecirlos. Por ejemplo, en el [tutorial 2](#_hf175fta6aac) se introducen los escondites, que el jugador debe aprovechar para pasar desapercibido frente a los enemigos. Estos escondites vuelven a aparecer en numerosos niveles posteriores, por lo que el jugador se debe familiarizar con ellos y debe ser capaz de reconocerlos y saber utilizarlos para su ventaja.

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

El juego cuenta con un sistema de turnos donde primero actúa el jugador, pudiendo escoger a donde moverse (arriba, abajo, izquierda o derecha) y realizar una acción (atacar, colocar objeto, interactuar con objeto) o saltar el turno. Luego actuaría el resto del mundo, ya sean enemigos o las trampas que ha colocado el jugador en el escenario. Los enemigos también tendrán el mismo sistema de turnos que el jugador, es decir, moverse (donde incluimos la acción de girarse y cambiar de dirección) y hacer una acción (atacar al jugador, dar la voz de alarma…)

Como mecánicas principales del juego se implementará desde el prototipo:

- **Movimiento:** El jugador verá un mapa dividido en casillas cuadradas. El movimiento puede darse en cuatro direcciones: Arriba, abajo, izquierda y derecha.
- **Movimiento guardias:** El juego contará con distintos movimientos según el tipo de guardia. Los dos tipos básicos de movimiento de guardia serán estático (no tiene movimiento) y patrullar (se ha implementado un sistema de waypoints que los guardias tienen que seguir, simulando una patrulla por el mapa)
- **Alerta de guardias:** En caso de que se detecte al jugador, todos los enemigos entrarán en estado de alerta, conocerán la posición del jugador y le perseguirán y buscarán por el mapa hasta atraparle o perderle.
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

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image1.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image2.png)

### Progresión del Juego

A medida que se avance en los niveles del juego, el jugador irá encontrándose con nuevas mecánicas y niveles más complicados de resolver. Los primeros niveles contarán con poca dificultad, para ir introduciendo las mecánicas y que el jugador se familiarice con estas, y a medida que se vaya avanzando por los niveles, estos se irán complicando y el jugador se encontrará con distintos tipos de enemigos, que le supondrán mayor dificultad para completar un nivel.

### Feedback al Jugador

Queremos que el jugador sea consciente en todo momento de qué puede hacer y qué no puede hacer. Por ello, se incluirán sonidos que representan la interacción con el entorno y sus objetos. También, en el departamento visual, se destacarán los objetos consumibles para que el jugador reconozca de forma clara con qué elementos puede interactuar.

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

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image3.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image4.png)

## Interfaces

### Objetivos de la Interfaz de Usuario In-Game

La interfaz debe mostrarle al jugador información relevante para que complete el nivel. De este modo la interfaz solo mostrará:

- Número de movimientos del jugador: Aparecerá un pequeño contador del número de movimientos que se han realizado en ese intento del nivel. De este modo, los jugadores que quieran mejorar su desempeño en un determinado nivel podrán buscar estrategias para reducir el número de movimientos.
- Objetos disponibles: En un lado de la pantalla aparecerán los distintos objetos que el jugador lleva encima. De este modo tendrá la información de qué objetos puede usar y así podrán planificar sus acciones.
- Botones de acción: La interfaz mostrará botones de acción al jugador cuando se necesite. Por ejemplo, si el jugador se coloca al lado de un enemigo aparecerá el botón de acción para noquear a dicho enemigo.

Boceto de la interfaz In-Game:

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image5.png)

###


### Diseño de Pantallas Principales

El menú principal del juego contará con una imagen que introduzca al jugador al universo del juego, con el título del mismo y con los botones descritos en el diagrama de estados para poder navegar por los distintos menús.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image6.png)

### Diseño de Menús y Submenús

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image7.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image8.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image9.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image10.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image11.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image12.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image13.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image14.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image15.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image16.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image17.png)

### Interfaces finales

#### Comienzo del juego

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image18.png)

#### Menú de opciones

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image19.png)

#### Selección de Tutoriales

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image20.png)

#### Selección de Niveles

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image21.png)

#### Ayuda: controles (distintos dispositivos), acciones y objetos

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image22.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image23.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image24.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image25.png)

#### Pantalla de Victoria

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image26.png)

#### Pantalla de Derrota

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image27.png)

#### Pantalla de Carga

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image28.png)

#### Créditos

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image29.png)

## Niveles

### Tutorial

#### Tutorial: Movimiento básico

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image30.png)

**Explicación:** El camino esperado para el jugador es el marcado con la línea negra. El cuervo tendrá que moverse hacia el gato para noquearlo y posteriormente avanzar hasta la casilla de salida.

**Objetivo y mecánica introducida:** El objetivo de este nivel es introducir la mecánica del noqueo. La competencia entrenada en este nivel es Abstracción. Se busca que el jugador sea capaz de identificar qué camino debe elegir y cómo gestionar la presencia del gato guardando la salida.

**Texto del tutorial:**

(Nada más entrar al nivel)

"Great, I'm out of my cell. Now, I have to go find Midnight Wing so that we can get out of here."

"Bien, he conseguido salir de la celda. Ahora tengo que encontrar a Midnight Wing y salir de aquí con él."

"Guards don't see anything outside their cone of vision, so as long as I stay out of it, I'm in the clear."

"Los guardias ven sólo en el cono rojo que sale de ellos, así que será mejor que evite entrar en su visión."

(Paneo de cámara al guardia que vigila la salida)

"Vaya, veo que hay un guardia mirando hacia el pasillo de la salida."

"Oh dear, that guard is looking right at the exit path."

"Tendré que buscar un camino alternativo y noquearlo si quiero pasar"

"I'll have to find my way around him and knock him out if I want to get out."

#### Tutorial: Esconderse y esperar 

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image31.png)

**Explicación:** El camino superior se encuentra bloqueado por la presencia del gato número 1 que se encuentra vigilando siempre en la misma dirección.

El camino esperado para el jugador se marca con la línea negra, que contará con un gato patrullando. Según la ruta que toma el gato número 2, el jugador deberá seguir sus pasos y esconderse en el "arbusto" (será un tipo de escondite distinto in game) hasta que el enemigo esté adyacente para noquearlo y poder completar el nivel.

**Objetivo y mecánica introducida:** Dar a conocer al jugador la mecánica de los escondites (arbusto) y de esperar. Respecto al pensamiento computacional se espera que el jugador entrene su capacidad de Abstracción reconociendo que no puede ir por un camino y estudiando el patrón de la ruta del gato número 2, así como la Generalización recordando lo aprendido en el primer tutorial para volver a noquear al gato 2 y evitar el cono de visión del gato 1.

**Texto del tutorial:**

(Nada más entrar al nivel)

"¡Vaya, aquí hay dos guardias patrullando!"

"Dash it all! There are two guards on patrol!"

"El de arriba parece que va a mirar hacia este pasillo todo el rato. Tendré que ir por abajo."

"It doesn't seem like this one is going to look away. I will have to go down the hallway."

"Si voy por abajo podré aprovechar ese escondite para noquear al guardia"

"That way I can use that hiding spot to ambush the guard."

"Tendré que esperar al momento oportuno para avanzar y colarme en el escondite"

"I must wait for the right time so that I can safely go to the hiding spot"

"Desde el escondite podré noquear al guardia sin que me vea nadie"

"From there I can strike the guard without arousing suspicion."

#### Tutorial: Bol de comida

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image32.png)

**Explicación:** El camino esperado por el jugador consiste en avanzar por arriba y recoger el bol de comida. Posteriormente debe dejar el bol de comida dentro del rango de visión del gato para que lo recoja y quede fuera de combate.

**Objetivo:** El objetivo de este nivel es introducir al jugador los distintos objetos consumibles que hay en el juego y que aprenda a usar el bol de comida.

Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (los enemigos le cortan el paso a no ser que use el objeto);

**Texto del tutorial:**

(Nada más entrar al nivel)

"Un bol de comida. Podré usarlo para distraer al guardia que me bloquea la salida"

"A food bowl. Maybe I can distract the guard blocking the exit with it."

"Tendré que cogerlo y ponerlo enfrente de él para que lo vea."

"I'll grab it and place it somewhere so he sees it."

#### Tutorial: Fuente

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image33.png)

**Explicación:** El jugador debe llegar a la fuente para atraer al guardia con el graznido. De este modo, podrá noquear al enemigo y completar el nivel.

**Objetivo:** El objetivo de este nivel es introducir al jugador los distintos objetos consumibles que hay en el juego y que aprenda a usar la fuente de agua junto al graznido.

Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (los enemigos le cortan el paso a no ser que use el objeto); Evaluación, porque debe pensar en cómo usar el graznido; y Generalización, puesto que aplica lo aprendido en el tutorial de los arbustos en este nivel para noquear de forma fácil al enemigo.

**Texto del tutorial:**

(Nada más entrar)

"Veo una fuente. Tengo la garganta un poco seca y no me vendría mal un trago."

"Is that a fountain? I am parched. I could use a drink."

"Si bebo agua podría graznar para atraer al guardia que bloquea la salida."

"Once I've had a drink I can squawk and attract the cat guarding the exit."

"Si grazno el guardia vendrá a mí posición, tendré que estar en una posición segura para noquearlo sin que me vea"

"If I squawk, he'll come to my position. I will have to be somewhere safe so that I can strike without being seen."

#### Tutorial: Ovillo

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image34.png)

**Explicación:** El jugador debe coger el ovillo para lanzarlo al guardia y que este comience a jugar. De este modo, podrá completar el nivel sin problemas.

**Objetivo:** El objetivo de este nivel es introducir al jugador los distintos objetos consumibles que hay en el juego y que aprenda a usar el ovillo.

Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (los enemigos le cortan el paso a no ser que use el objeto); y Evaluación, porque debe pensar en cómo usar el ovillo;

**Texto del tutorial:**

(Nada más entrar)

"Un ovillo. Si lo lanzo a través de los obstáculos seguro que distraigo al guardia que me bloquea el paso"

"A ball of yarn. I can throw this over obstacles, and the guard is sure to get distracted by it."

"Tendré que coger el ovillo y luego lanzarlo a un sitio que vea el guardia"

"I must grab it and throw it somewhere the guard will see it. "

#### Tutorial: Linterna

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image35.png)

**Explicación:** El jugador debe coger la linterna para usarla contra el guardia y que este se quede aturdido. De este modo, el jugador podrá atacar al guardia sin problema y podrá avanzar al siguiente nivel.

**Objetivo:** El objetivo de este nivel es introducir al jugador los distintos objetos consumibles que hay en el juego y que aprenda a usar la linterna.

Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (los enemigos le cortan el paso a no ser que use el objeto); y Evaluación, porque debe pensar en cómo usar la linterna;

**Texto del tutorial:**

(Nada más entrar)

"\*Suspira\* Perfecto, ese guardia bloquea el pasillo completo… Espera, ¿eso es una linterna?"

"\*Sighs\* Perfect, that guard is completely blocking that hallway… Wait, is that a torch?"

"Si cojo la linterna y la uso contra el guardia podré noquearlo si corro hacia él"

"If I take the torch and shine it on the guard's face I can reach him and knock him out before he sees me."

(Al salir)

"No creo que las siguientes salas sean igual de sencillas que estas. Tendré que aplicar lo aprendido para seguir avanzando."

"I don't think the next rooms will be quite as easy as these. I will have to keep what I have learnt here in mind to make my way forward."

"Siempre puedo volver a hacer estas salas si salgo al Menú Principal desde el Menú de Pausa"

"Well, I can always come back by going to the Main Menu from the Pause Menu."

### Niveles

#### Nivel 1 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image36.png)

**Explicación:** El jugador tendrá que hacer una gestión adecuada del bol de comida y la fuente para terminar el nivel de forma adecuada. Como se puede observar, el nivel tiene varios caminos que se pueden tomar, aunque el más óptimo se encuentra pasando por la zona izquierda. Un ejemplo para completar el nivel sería distraer al gato número 2 con el bol de comida y distraer al número 1 con la fuente para despejar el camino. Un camino óptimo se representa con la línea negra del diagrama del nivel.

**Objetivo:** No se introducen nuevas mecánicas en este nivel puesto que se quiere afianzar las mecánicas ya introducidas previamente. De este modo, se aplica el principio de generalización que hará que los jugadores apliquen los conocimientos previos para completar este nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en 18 turnos o menos.

3ª Estrella = Completar el nivel matando a un enemigo o menos y usando 14 turnos o menos

#### Nivel 2 (Zona 1) 
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image37.png)

**Explicación:** El camino esperado por el jugador es esconderse del gato número 1 en el escondite para poder noquearlo y posteriormente pasar a la siguiente zona del nivel.

Una vez allí se encuentra con los gatos 2 y 3 vigilando todos los posibles caminos, por lo que el jugador debe avanzar, ser detectado, y esconderse sin ser visto en uno de los arbustos de abajo del nivel.

**Objetivo:** El objetivo de este nivel es introducir la mecánica de esconderse de los guardias cuando han detectado al jugador. Al esconderse sin ser visto por los guardias, éstos perderán al jugador y volverán a sus posiciones. Se espera mejorar la capacidad de generalización de los jugadores aplicando las mecánicas de los anteriores niveles.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel con menos de 28 turnos

3ª Estrella = Completar el nivel con menos de 24 turnos y sin matar enemigos

#### Nivel 3 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image38.png)

**Explicación:** En este nivel el jugador debe utilizar los charcos de aceite para evitar la primera del primer gato, noquearlo y conseguir el bol de comida. Con el bol de comida debe distraer al segundo gato y salir del nivel corriendo más que el tercero y llegando a la salida.

**Objetivo:** El objetivo es enseñar al jugador la mecánica de los charcos de aceite y sus posibles utilidades de cara a futuros niveles. Se espera que el jugador desarrolle su Evaluación, porque tendrá que gestionar correctamente los charcos de aceite por primera vez; Abstracción, porque el jugador tendrá que reconocer la clave de dónde usar el bol de comida; y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles.

**Texto del tutorial:**

(Nada más entrar)

"Vaya, un charco de aceite. Si lo piso me desplazaría a la siguiente casilla en la dirección en la que me mueva. Tendré que tener cuidado"

"Blast! a puddle of oil. If I step on it I will slide to the next square in that direction. I must be careful."

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel con menos de 28 turnos

3ª Estrella = Completar el nivel con menos de 22 turnos y matando 2 enemigos o menos

#### Nivel 4 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image39.png)

**Explicación:** El jugador debe beber de la fuente para atraer al primer gato y noquearlo, luego llegar a por el siguiente en su ruta y noquearlo para obtener el bol de comida para apartar al tercer gato del camino y poder terminar el nivel.

**Objetivo:** El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (La forma de eliminar al gato 1 y 3); Evaluación, porque tendrá que pensar en cómo usar correctamente los recursos del escenario noquear a los gatos; Descomposición, para deshacer el nivel en problemas más pequeños (Pasar a por el bol de comida que permite resolver el nivel); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 35 turnos

3ª Estrella = Completar el nivel en menos de 30 turnos y matando a 1 enemigos o menos

#### Nivel 5 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image40.png)

**Explicación:** El jugador debe ir a por la fuente para atraer al gato 2 y conseguir el bol de comida para distraer al gato 4 y abrirse paso. Para ello tiene que utilizar los escondites para esconderse de la atención del gato 4, atraer al gato 2, luego en la zona inferior debe recoger el bol de comida y noquear al gato 3. Gracias a los chanchos de aceite el jugador puede finalmente distraer al gato 4 con el bol de comida y terminar el nivel.

**Objetivo:** El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional y reforzar lo aprendido con los charcos de aceite. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Los gatos 2 y 4); Evaluación, porque tendrá que pensar en cómo usar los charcos de aceite para avanzar correctamente y los objetos para encargarse de los gatos que le tapan la salida; y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 35 turnos

3ª Estrella = Completar el nivel en menos de 20 turnos y sin matar enemigos

#### Nivel 6 (Zona 2)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image41.png)

**Explicación:** En este nivel el jugador debe beber de la fuente para deshacerse del gato numero 2, esquivando al gato numero 1 y luego pasando de largo del gato 3 para terminar el nivel. Hay un bol de comida adicional que no hace falta usar para engañar al jugador.

**Objetivo:** El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Evaluación, porque tendrá que pensar en cómo completar correctamente el puzzle y darse cuenta de que no hace falta el bol de comida para pasarse el nivel; Descomposición, para deshacer el nivel en problemas más pequeños (beber de la fuente); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = 30

3ª Estrella = 24 turnos matando 1 enemigo

#### Nivel 7 (Zona 2)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image42.png)

**Explicación:** En este nivel hay dos posibles caminos que llevan a conseguir un bol de comida para abrirse camino por el gato protegiendo la salida. La más óptima es la inferior donde hay que distraer al gato 1 con un graznido dentro del escondite y noquearlo. Una vez noqueado hay que coger el bol de comida y repetir lo mismo con el gato número 2, luego solo queda distraer al gato 5 y salir.

**Objetivo:** El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Distraer al gato de la salida con comida); Evaluación, porque hay que descubrir cuál es el camino más óptimo; y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 35 turno

3ª Estrella = Completar el nivel con menos de 22 turnos y sin usar boles de comida

#### Nivel 8 (Zona 2)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image43.png)

**Explicación:** En este nivel el jugador debe coger la linterna para deshacerse del guardia que vigila la salida. La ruta más segura consistirá en coger el ovillo que guarda el guardia de más a la derecha y usarlo contra el guardia que vigila la salida.

**Objetivo:** El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Distraer al gato de la salida con comida); Evaluación, porque tendrá que pensar en cómo completar correctamente el puzzle; Descomposición, para deshacer el nivel en problemas más pequeños (ir avanzando por el nivel); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 30 turnos.

3ª Estrella = Completar el nivel en menos de 25 turnos y sin matar ningún enemigo.

#### Nivel 9 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image44.png)

**Explicación:** El jugador tendrá que coger las dos linternas del nivel para eliminar a los guardias que vigilan la puerta. Primero tendrá que deslumbrar a uno y eliminarle y posteriormente tendrá que ir a por el otro. El órden de eliminación de los guardias será relevante para conseguir el mínimo número de pasos.

**Objetivo:** El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Evaluación, porque tendrá que pensar en cómo completar correctamente el puzzle; Descomposición, para deshacer el nivel en problemas más pequeños (ir avanzando por el nivel); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en 50 turnos

3ª Estrella = Completar el nivel en 45 turnos y matando 2 enemigos o menos

#### Nivel 10 (Zona 2)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image45.png)

**Explicación:** El jugador tendrá que coger el ovillo o el bol de comida para distraer al primer guardia que le bloquea la salida. Posteriormente tendrá que usar el graznido para eliminar al guardia que vigila la salida.

**Objetivo:** El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Evaluación, porque tendrá que pensar en cómo completar correctamente el puzzle; Descomposición, para deshacer el nivel en problemas más pequeños (ir avanzando por el nivel); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 50 movimientos

3ª Estrella = Completar el nivel en menos de 35 turnos y matando a 2 enemigos o menos

#### Nivel 11 (Zona 2)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image46.png)

**Explicación:** El jugador tendrá que usar los boles de comida para eliminar a los guardias que vigilan la palanca que abre la puerta. Una vez abierta la puerta, podrá abandonar el nivel de forma rápida.

**Objetivo:** El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Evaluación, porque tendrá que pensar en cómo completar correctamente el puzzle; Descomposición, para deshacer el nivel en problemas más pequeños (ir avanzando por el nivel); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Texto del tutorial:**

(Nada más entrar)

"Vaya, parece que han bloqueado la salida. Tendré que buscar un botón que la abra"

"Uh-oh, the exit seems to have been blocked. I'll have to look for a button to open it."

"Tendré que pisar el botón del color que corresponda a la puerta"

"The colour of the button must match the colour of the gate."

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel 60

3ª Estrella = Completar el nivel en menos de 45 y matando a 4 enemigos o menos

#### Nivel 12 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image47.png)

**Explicación:** En este nivel el jugador tendrá que usar el ovillo para tener el acceso a la fuente. Posteriormente, la fuente le permitirá noquear al gato que vigila el botón que abre la puerta. Una vez pulsado el botón, el jugador tendrá que hacer el mini puzzle de los charcos de aceite para salir del nivel.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Acceder al botón para abrir la puerta); Evaluación, porque tendrá que pensar en cómo usar correctamente los recursos del escenario; Descomposición, para deshacer el nivel en problemas más pequeños; y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 100 turnos

3ª Estrella = Completar el nivel en menos de 75 turnos y sin usar la linterna

#### Nivel 13 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image48.png)

**Explicación:** Este nivel trata de darle un poco de variedad a los demás niveles del juego. Concretamente, presentando un nivel rápido donde hay que aplicar la lógica para llegar a la salida.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Descomposición, para deshacer el nivel en problemas más pequeños; y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en 30 turnos o menos

3ª Estrella = Completar el nivel en 20 turnos o menos

#### Nivel 14 (Zona 2)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image49.png)

**Explicación:** El jugador debe eliminar a los guardias que vigilan la salida. Para ellos tendrá múltiples formas de hacerlo con los distintos objetos que hay en el mapa. Para completar el nivel solo es necesario usar la fuente y el ovillo que hay en la parte inferior izquierda del mapa, pero se pueden usar más objetos para facilitar el camino a la salida.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Eliminar a los gatos que bloquean la salida); Evaluación, porque tendrá que pensar en cómo usar correctamente los recursos del escenario; Descomposición, para deshacer el nivel en problemas más pequeños (Eliminación de los gatos de la salida y cómo llegar a los distintos objetos); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 50

3ª Estrella = Completar el nivel en menos de 36, sin usar la linterna y matando a 2 enemigos o menos

#### Nivel 15 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image50.png)

**Explicación:** Para completar este nivel, el jugador tendrá que usar las herramientas del escenario para desbloquear la puerta que bloquea el paso a la linterna. Para ello, tendrá que usar el graznido, el ovillo y el bol de comida para acceder al botón. Finalmente terminará el nivel aturdiendo al enemigo con el flash de la linterna.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Eliminar con la linterna al gato que bloquean la salida; Desbloquear la linterna); Evaluación, porque tendrá que pensar en cómo usar correctamente los recursos del escenario para acceder al botón; Descomposición, para deshacer el nivel en problemas más pequeños (Eliminar gato de la salida; Pulsar el botón de la puerta a la linterna); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 100 turnos

3ª Estrella = Completar el nivel en 80 turnos o menos, matando y distrayendo a 3 gatos o menos

#### Nivel 16 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image51.png)

**Explicación:** Este nivel es similar al nivel 13, ofreciendo dos caminos posibles para completar el nivel. El jugador tendrá que escoger el camino correcto para no toparse con los enemigos.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Descomposición, para deshacer el nivel en problemas más pequeños; y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en 30 turnos o menos

3ª Estrella = Completar el nivel en 16 turnos

#### Nivel 17 (Zona 2)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image52.png)

**Explicación:** En este nivel el jugador tendrá que abrir 2 puertas para conseguir los objetos clave que necesita para pasarse el nivel. Tendrá que usar el ovillo para eliminar al primer guardia del pasillo y la linterna para eliminar al segundo. De este modo, tendrá acceso a la salida.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Eliminar a los gatos que bloquean la salida; Desbloquear la linterna y el ovillo); Evaluación, porque tendrá que pensar en cómo usar correctamente los recursos del escenario para acceder al botón; Descomposición, para deshacer el nivel en problemas más pequeños (Eliminar gatos de la salida; Pulsar el botón de la puerta a la linterna y del ovillo); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 150 turnos

3ª Estrella = Completar el nivel usando 100 turnos o menos, matando y distrayendo a 3 gatos o menos

#### Nivel 18 (Zona 2)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image53.png)

**Explicación:** De forma similar al anterior nivel, el jugador tendrá que abrir puertas para conseguir objetos y acceder a la salida.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Eliminar gatos en la salida); Evaluación, porque tendrá que pensar en cómo usar correctamente los recursos del escenario para acceder al botón; Descomposición, para deshacer el nivel en problemas más pequeños (Desbloquear puertas y poder acceder a la salida); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 150 turnos

3ª Estrella = Completar el nivel en menos de 85 turnos, matando y distrayendo a 4 enemigos o menos

#### Nivel 19 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image54.png)

**Explicación:** Este nivel es similar a los niveles 13 y 16. En este caso, el jugador tendrá que usar un objeto para eliminar al gato que bloquea su camino. De nuevo, habrá que usar la lógica para completar el puzzle del nivel.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Evaluación, porque tendrá que pensar en cómo completar correctamente el puzzle; Descomposición, para deshacer el nivel en problemas más pequeños (ir avanzando por el nivel); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 40 turnos

3ª Estrella = Completar el nivel en 25 turnos o menos y sin matar enemigos

#### Nivel 20 (Zona 1)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image55.png)

**Explicación:** El nivel se divide en dos áreas. En la primera, el jugador tendrá que abrir la puerta pulsando el botón vigilado por los 3 gatos. Para ello, tendrá que emplear los objetos del escenario para eliminarlos de forma óptima. Dentro de la segunda área habrá que hacer lo mismo, desbloquear la puerta para acceder a la salida.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Abrir las distintas puertas que hay, eliminando a los gatos que vigilan los botones); Evaluación, porque tendrá que pensar en cómo usar correctamente los recursos del escenario para acceder a los botones de las puertas; Descomposición, para deshacer el nivel en problemas más pequeños (el nivel se divide en dos áreas, cada área será un problema independiente del otro); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 120 turnos

3ª Estrella = Completar el nivel en menos de 100 turnos

#### Nivel 21 (Zona 2)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image56.png)

**Explicación:** El nivel se divide en dos áreas. En la primera, el jugador tendrá que abrir la puerta pulsando el botón vigilado por los 3 gatos. Para ello, tendrá que emplear los objetos del escenario para eliminarlos de forma óptima. Dentro de la segunda área habrá que hacer lo mismo, desbloquear la puerta para acceder a la salida.

**Objetivo:**

El objetivo de este nivel es mejorar distintas áreas del pensamiento computacional. Las áreas del pensamiento computacional a explorar en este nivel son Abstracción, porque el jugador tendrá que reconocer la clave del problema (Abrir las distintas puertas que hay, eliminando a los gatos que vigilan los botones); Evaluación, porque tendrá que pensar en cómo usar correctamente los recursos del escenario para acceder a los botones de las puertas; Descomposición, para deshacer el nivel en problemas más pequeños (el nivel se divide en dos áreas, cada área será un problema independiente del otro); y Generalización, porque tendrá que aplicar lo aprendido en los anteriores niveles para completar el nivel.

**Sistema de estrellas:**

1ª Estrella = Completar el nivel

2ª Estrella = Completar el nivel en menos de 120 turnos

3ª Estrella = Completar el nivel en menos de 65 turnos, sin usar ovillos o boles de comida y matando a 4 enemigos o menos

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

#### Storyboard pantalla inicial:

Storyboard de la cinemática inicial donde se introduce al jugador a la historia principal:

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image57.png)

####


#### Storyboard nivel 21:

Plano 1: Plano entero de Feather Noir abriendo una puerta de una patada.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image58.png)

Plano 2: Plano general de dos gatos matones (de espaldas) llevando a Midnight Wing a un ascensor. Los gatos se alejan en dirección a un ascensor junto a un tercer gato (Don Felino) que aparece desenfocado.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image59.png)

Plano 3: Mismo plano que el anterior pero los gatos se dan cuenta de que Feather Noir ha entrado en la sala y se alertan.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image60.png)

Plano 4: Plano medio de uno de los matones subiéndose las mangas mirando enfadado a Feather Noir.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image61.png)

Plano 5: Mismo plano, pero se ve la mano (o pata) de Don Felino, indicando al gato que se quede quieto.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image62.png)

Plano 6: Primer plano de Don Felino sonriendo malévolamente. Don Felino se encuentra justo enfrente del ascensor.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image63.png)

Plano 7: Mismo plano pero la puerta del ascensor se abre.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image64.png)

Plano 8: Plano contrapicado. En el plano tiene que aparecer Don Felino en el centro del plano y del ascensor tienen que salir varios tipos de gato (para introducir nuevos enemigos, gato forzudo, gato con la percepción de la realidad completamente alterada, gato persa…)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image65.png)

Plano 9: Plano americano de Feather Noir, mirando decidido hacia los gatos. El plano cierra con un "continuará".

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image66.png)

## Personajes

### Personajes Relevantes

#### Feather Noir ![](RackMultipart20231210-1-lgkrgl_html_9dea85db638dd753.png)

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

El jugador puede llevar un objeto de cada tipo al mismo tiempo, lo que significa que puede llevar un ovillo, puede graznar una vez, puede llevar un ovillo, puede llevar una linterna y una bomba de humo todo el mismo tiempo. Lo que no puede hacer es llevar dos ovillos, dos linternas… Cómo usar un objeto supone gastar la acción del jugador, solo podrá poner el ovillo o graznar o usar la linterna….

Los enemigos no pueden interactuar con ningún objeto. El ovillo y el bol de comida serán la excepción puesto que cuando un enemigo los vea irá a jugar con ellos.

#### Fuente

Las fuentes estarán repartidas por los niveles y permitirán cargar al jugador sus graznidos, que permitirán distraer a los guardias cercanos desde cualquier posición del escenario.

Para poder interactuar con la fuente el jugador debe de estar en una casilla adyacente e interactuar con la fuente, lo que consume su acción. Cada fuente puede ofrecer un número restringido de recargas para el jugador. Un jugador no puede beber si ya tiene una carga del graznido.

Un jugador no podrá beber y graznar en el mismo turno porque habrá gastado su acción. Tampoco podrá graznar y luego beber porque estaríamos en la misma situación.

Los graznidos atraen gatos en un radio circular de 3 casillas para que se muevan a la posición donde se ha realizado el graznido. Si el gato no ha encontrado al jugador y ha llegado a la casilla, termina la alerta para él y todos los enemigos afectados por el graznido. Cuando termina la alerta del graznido cada gato vuelve a su ruta normal.

Radio del graznido:

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image68.png)

#### Bol de comida

El bol de comida es un objeto que permitirá al jugador distraer a los guardias.

El jugador recoge el bol de comida cuando pisa la casilla donde se encuentra. Una vez recogido, el jugador puede gastar la acción para dejar el bol de comida en una casilla adyacente a sí mismo. El jugador puede volver a recoger el bol de comida que está en el suelo si un enemigo no lo ha cogido.

Cuando un guardia vea el bol de comida se acercará a él independientemente de su ruta. Cuando llegue a la casilla del bol de comida se quedará jugando con él. Si un guardia ve a otro jugando con un bol de comida se acercará a él (salvo que el guardia vea también al jugador, que entonces tendrá prioridad alertar y luego despertar al gato jugando), cuando esté en una casilla adyacente gasta su acción en darle un golpe e indicarle que vuelva al trabajo. El jugador no puede pasar por la casilla donde esté jugando un gato. Cuando un guardia deja de estar jugando con el bol de comida vuelve a su ruta normal y el bol de comida se consume.

#### Ovillo

Funcionan como los boles de comida pero son lanzables.

El jugador recoge el ovillo cuando pisa la casilla donde se encuentra. Una vez recogido, el jugador puede gastar la acción para dejar el ovillo en una casilla a una distancia de 3 casillas. El jugador puede lanzar el ovillo a través de los obstáculos del escenario. El jugador puede volver a recoger un ovillo que está en el suelo.

Cuando un guardia vea el ovillo se acercará a él independientemente de su ruta. Cuando llegue a la casilla del ovillo se quedará jugando con él. Si un guardia ve a otro jugando con un ovillo se acercará a él, cuando esté en una casilla adyacente gasta su acción en darle un capón e indicarle que vuelva al trabajo. El jugador no puede pasar por la casilla donde esté jugando un gato. Cuando un guardia deja de estar jugando con el ovillo vuelve a su ruta normal y el ovillo se consume.

#### Escondites

Los escondites serán objetos fijos reutilizables repartidos por todo el mapa. Cuando el jugador entra en un escondite desaparece de la visión de un enemigo completamente. Si el jugador grazna desde dentro del escondite, el guardia irá a investigar dentro del escondite, lo que quiere decir que primero llegará al escondite (donde el jugador tendrá oportunidad de gastar su acción para eliminarle) y posteriormente mirará dentro del escondite (si el jugador no ha matado al enemigo, será instakill del enemigo porque gastará su acción en matar al jugador.) Si el enemigo mira cómo el jugador entra en un escondite, el enemigo irá a por él porque sabe que se encuentra ahí dentro.

#### Llaves y puertas

En ciertos niveles se introducirá una mecánica dónde la salida está bloqueada con una puerta que necesita una llave. En estos niveles el jugador tendrá que conseguir la llave que abra la puerta (también las llaves podrán aparecer en forma de interruptores) para poder salir del nivel.

#### Botones de alarma

En algunos niveles el jugador tendrá acceso a botones de alarma que harán que los guardias vayan a la alarma a ver qué ha pasado. Esto permitirá al jugador crear distracciones que pondrá a todos los guardias en alerta y durará hasta que un gato vea que no ha pasado nada y apague la alarma.

#### Alarmas Antiincendios

Cuando el jugador las active se encenderá una alarma antiincendios que hará saltar los aspersores de la sala. Como los gatos le tendrán miedo al agua, la alarma antiincendios impedirá a los gatos pasar por ciertas casillas afectadas por los aspersores.

#### Bombas de humo

El jugador podrá usar bombas de humo para escabullirse una vez le pillen los guardias. Las bombas de humo cubrirán 3 casillas en un radio circular alrededor del jugador de humo, que harán que los gatos se queden confusos durante 5 turnos. Cuando estén dentro del humo los gatos no podrán moverse ni hacer nada, pero el jugador sí que podrá escabullirse.

#### Linterna

Las linternas serán objetos que podrá usar el jugador una vez para deslumbrar a un guardia durante 3 turnos. El objeto se usará pulsando su botón correspondiente en la interfaz, lo cual activará la linterna desde la posición del jugador y lanzará un flash de luz en línea recta hasta que choque contra una pared. En estos 3 turnos el guardia no podrá hacer nada y una vez termine el efecto de deslumbramiento el guardia pasará a volver a su rutina.

#### Charco de Aceite

Cuando un personaje pase por una casilla de aceite se resbala y avanza 1 casilla extra en la dirección por la que venía. Se pueden encadenar múltiples charcos de aceite.

### Enemigos

#### Gato Naranja

El enemigo más básico de todos, su comportamiento se define de la siguiente forma:

- Su rango de visión es de 3 casillas. G - - -
- Pueden girarse y cambiar la dirección en la que están mirando. Girarse consume el movimiento del turno.
- Pueden o no moverse. En caso de que se muevan no pueden avanzar más de 1 casilla al mismo tiempo.
- En su turno pueden moverse y hacer una acción. (En cualquier combinación de orden)

A continuación, presentamos el Árbol de Comportamiento de los enemigos básicos:

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image69.png)

#### Gato con la percepción de la realidad completamente alterada

Este tipo de gato no podrá matar al jugador, pero tendrá la capacidad de perseguir al jugador más rápido que otros gatos. El punto de este gato es que se moverá dos casillas por turno en lugar de una y el jugador tendrá que noquearlo para poder esconderse (si hay un gato viéndole no puede esconderse, por tanto hay que eliminar a este gato si el jugador pretende zafarse de los enemigos).

- Este gato se mueve dos casillas con su movimiento.
- Su rango de visión es de 3 casillas.
- Pueden girarse para cambiar la dirección en la que están mirando. Esto gasta todo el movimiento del gato.
- Siempre se tienen que mover, no puede haber un gato de este tipo estático.
- En su turno pueden moverse y hacer una acción. (En cualquier combinación de orden)

#### Gato Persa (Futurible)

El segundo enemigo que se presenta en el juego:

- Su rango de visión es de 3 casillas.
- Pueden girarse y cambiar la dirección en la que están mirando.
- Pueden o no moverse. En caso de que se muevan no pueden avanzar más de 1 casilla al mismo tiempo.
- Un gato solo puede hacer 1 acción en el turno ya sea: moverse, girarse o esperar.
- El Gato Persa ignora la primera distracción que detecta incluyendo: Graznido, Ovillo, ovillo, Linterna, Botones de Alarma, Alarma Antiincendios.

#### Accesorios en los Gatos (Futurible)

Los gatos pueden llegar a tener 1 objeto equipado, lo que le permite protegerse contra ciertas acciones del jugador.

- **Casco Protector:** El gato no puede ser noqueado
- **Orejeras/Tapones:** El gato no se ve afectado por cualquier sonido, lo que incluye: La Alerta Colectiva, Graznido y Alarma Antiincendios. t
- **Gafas:** El rango de visión del gato aumenta 2 casillas.
- **Gafas de sol:** El enemigo es inmune a los objetos: ovillo y linterna.

#


## Arte Conceptual

### Estilo Artístico

El estilo visual es simple y amigable, orientado a una audiencia joven y cuidado para que sea atractivo y satisfactorio. Va a usar formas geométricas básicas y los modelos de personajes serán de baja poligonización.

Se usarán colores neutros para el entorno con colores vivos o fuertes para elementos importantes como personajes, objetos, campos de visión etc.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image70.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image71.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image72.png)

### Paleta de Colores

El cuervo utilizará tonos azulados para crear la ilusión de la oscuridad de su plumaje sin recurrir directamente al color negro puro y dar tambien así el efecto de los reflejos metálicos típicos de los córvidos.

Los gatos base serán de color naranja, pero los diferentes tipos de enemigo vendrán diferenciados por color. Todos estarán inspirados en el pelaje de tipos reales de gatos. 

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image74.png)

Los componentes de gángster de su diseño irán en escala de grises u otros colores oscuros y neutros.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image73.png)

Habrá diferentes tipos de escenarios según avanza la aventura, los cuales se diferenciarán principalmente por sus colores, que deben permitir el contraste tanto con el cuervo como con los gatos.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image75.png)

### Diseño de Personajes

Los personajes deben ser antropomórficos pero no demasiado, de la misma manera deben ser visualmente atractivos para los jugadores más pequeños sin perder el encanto para jugadores más mayores.

En este aspecto hemos tomado como referencia animales de cómic y personajes de Disney para elaborar bocetos de personajes atractivos.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image76.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image78.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image79.png)

### Diseño de Entornos

Para mayor claridad y que el entorno no distraiga del puzle que conforman las mecánicas del juego, se ha decidido utilizar un estilo que, mientras que sea simple sin dejar de aportar cierto interés visual.

Un ejemplo e inspiración en este aspecto es el juego Monument Valley. 
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image80.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image81.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image82.png)

A pesar de su relativa simpleza, los escenarios son memorables y cautivadores, a la vez que dejan claro al jugador de una mirada su objetivo, el camino a seguir, y los recursos en su mano.

Mientras que en nuestro juego el ambiente no tiene tanto peso como en este, tomaremos inspiración en lo que a estilo se refiere. Queremos capturar la misma limpieza y estilización de la arquitectura.

Al haberse ambientado el juego en un mundo de gangsters reminiscente de la época de los speakeasy, contemporánea al art deco y a la bauhaus, ambos movimientos de gran inspiración geométrica, hemos decidido apoyarnos en estos para decorar los escenarios.

La idea es utilizar motivos geométricos y principios racionalistas para diseñar los entornos, aprovechando los mismos para guiar la mirada del jugador y hacer el juego más intuitivo, usando el entorno como apoyo o acompañamiento a la interfaz. 
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image83.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image84.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image85.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image86.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image87.png)

La idea es que el fondo sea relativamente neutro en cuanto a paleta y de esta manera ayude a personaje, enemigos y objetos a destacar por color. En principio nos apoyaremos en la iluminación para aumentar este efecto como en estos escenarios de Eddy Loukil:

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image88.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image89.png)
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image90.png)

### Diseño de Objetos y Requisitos Gráficos

Los objetos han de ser fácilmente identificables y deben destacar en el entorno esto se logrará con una combinación de los colores usados para el fondo y los objetos y la iluminación.

Se ha tomado como referencia la estética de mobiliario y piezas Art Dèco conforme a la estética del juego.

Los objetos estarán modelados en Low Poly y serán visibles en el escenario y fáciles de identificar por el jugador. Seguirán la estética gráfica de los personajes y el ambiente descrita anteriormente.

#### Llaves

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image91.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image92.png)

#### Fuente

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image93.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image94.png)

#### Ovillo de lana

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image95.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image96.png)

#### Botón

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image97.png)

Por motivos de diseño se cambió el botón por unas palancas.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image98.png)

#### Bomba de Humo

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image99.png)

#### Bol de comida

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image100.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image101.png)

#### Linterna

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image102.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image103.png)

#### Escondite

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image104.png)

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image105.png)

### Efectos Visuales (VFX)

El juego contará con diversos efectos visuales para aprovechar las capacidades de Unity y WebGL. Se tendrá en cuenta las limitaciones que ofrece WebGL a la hora de crear dichos shaders. Se desarrollarán los siguientes efectos visuales para darle un toque más especial al juego:

- Humo: Cuando el jugador lance una bomba de humo se generará una cortina de humo.
- Agua de las fuentes: Las fuentes están llenas de agua para que el jugador la consuma. Se realizará un shader para el agua.
- Shader de escondite: si el jugador se esconde en un escondite, puede ver a través de las paredes del escondite.

También, para la beta, se han desarrollado efectos visuales adicionales:

- Post Procesado: Se ha creado a través de Shader Graph de Unity un shader de post procesado que añade un delineado a los personajes para que parezcan dibujados a mano.
- Toon Shader: Se ha creado un shader a través de Shader Graph de Unity. Se ha programado un shader para hacer un estilo de iluminación Cell Shading para el juego.

### Animaciones

Al ser un cuervo, el movimiento estará muy inspirado en el movimiento de un cuervo real, pero este estará exagerado en beneficio del estilo cartoon. A continuación se presentan algunas de las animaciones que tendrá el cuervo:

- Saltitos para el movimiento entre casillas.
- Saltar para esconderse.
- Alarmarse cuando le ven.
- Beber en fuentes.
- Graznar.
- Coger objetos.

Los gatos tendrán un movimiento ligeramente distinto al que tienen en la vida real, pero conservarán muchos de sus manierismos. Algunas de las animaciones de los gatos serán:

- Caminar sobre dos patas.
- Darse cuenta de la presencia del cuervo.
- Lanzarse a por un ovillo.
- Atacar al cuervo.
- Sernoqueado.

Las animaciones de escenario serán simples, puertas que se abren, láseres que se activan, etcétera.

### Cinemáticas y Cutscenes

Las cinemáticas y cutscenes consistirán en imágenes o viñetas estáticas (o de movimiento sutil) que se suceden para claridad y simplificación del proceso.

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image106.png)

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

Textura de suelo utilizada para los niveles modificada de: https://2minutetabletop.com/product/grass-road-assets/

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

#


##
# Mapa de empatía

**Usuario 1: Niños de 5 a 14 años**

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image107.png)

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

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image108.png)

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

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image109.png)

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

#


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

**Flujo de ingresos:** freemium del producto, expansiones del producto (más niveles por precios bajos), venta de licencias, micropago, posibilidad de anuncio

![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image110.png)

##
# Toolbox
![](https://raw.githubusercontent.com/Tale-Weavers/Game/master/GDD-Images/Imagenes_GDD_Completo/image111.png)

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

# Análisis MDA

Whispers & Whiskers es un juego de puzles/estrategia por turnos en el que el jugador, que controla a un cuervo, debe usar los recursos a su disposición para escapar de una serie de salas protegidas por gatos matones mafiosos. De esta forma, su **estética** se centra en las siguientes claves:

- **Desafío** : Los diferentes niveles que el juego propone ofrecen un desafío intelectual al jugador. El jugador debe ser capaz de identificar los recursos de los que dispone y trazar un plan para usarlos de la forma más eficiente posible. Además, el sistema de puntuación del juego (un sistema de 3 estrellas, que premia al jugador con más estrellas cuantos más retos dentro del nivel haya logrado completar) fomenta la rejugabilidad y el replanteamiento por parte del jugador de los diferentes niveles
- **Coleccionismo** : El sistema de 3 estrellas posibles para cada nivel fomenta la rejugabilidad de los niveles y el espíritu de completacionismo del juego por parte del jugador, fomentando que complete el mayor número posible de niveles con la puntuación máxima. En adición a esto, el sistema de logros (por el que se premia al jugador por diferentes tareas, desde tareas triviales y de repetición como knockear a cierto número de enemigos, hasta tareas más complejas o incluso _easter eggs_.

De forma secundaria, también tendríamos otros elementos a tener en cuenta para la **estética** :

- **Sensación** : El juego está ambientado en un mundo dominado por animales en el equivalente a nuestros años 20. Se quieren evocar ciertas sensaciones a los jugadores a través de la estética del juego y de su banda sonora. El estilo cartoon del juego mezclado con un jazz clásico en la banda sonora nos permitirá evocar estas sensaciones en los jugadores.
- **Descubrimiento** : Si bien nuestro juego no ofrece una gran cantidad de niveles, cada uno de ellos permiten diversas formas de completarlo usando los objetos disponibles en distintos órdenes y de diversas maneras. El juego ofrece un nuevo reto a cada nivel y permite a los jugadores explorar las distintas posibilidades para así sacar el mayor número de estrellas posibles.

Las reglas de Whispers & Whiskers son simples: los enemigos tratan de encontrar al jugador, vigilando en puntos estáticos o recorriendo rutas de vigilancia. Cuando algún enemigo encuentra al jugador, todos tratan de buscarle. Además el jugador dispone de objetos y habilidades que puede usar de distracciones. Esto genera **dinámicas** relativamente simples, pero que ofrecen un gran abanico de posibilidades para el jugador en cada nivel. Las reglas simples y los comportamientos sencillos y predecibles, junto con el diferente número de objetos a disposición del jugador permiten que un nivel tenga una serie de rutas posibles para completar cada nivel, lo que fomenta la creatividad y el ingenio del jugador.

De esta forma, nuestras estéticas principales, desafío y coleccionismo, se ven respaldadas en las dinámicas que se generan durante el juego, concretamente, por el sistema de estrellas. Por otro lado, las estéticas secundarias, descubrimiento y sensación, vendrán dadas por las dinámicas del sistema de estrellas y por los distintos cambios en la música respectivamente.

Las **mecánicas** , por último, son muy sencillas de forma intencional. La accesibilidad del juego al público general y no muy familiarizado con el mundo de los videojuegos es fundamental. Los controles por tanto, son simples y con el fin principal de que sean intuitivos y comprensibles de un vistazo. Además, ya que el juego está pensado tanto para ordenador como para dispositivos móviles, se puede jugar únicamente con una mano, ya sea con el ratón en el ordenador, o en el móvil. Todo esto, sumado a las partidas cortas (los niveles se resuelven en un periodo estimado de entre 5 y 10 minutos) y la estética amigable y juguetona, contribuyen a la atracción del público casual por parte del juego.

# Post-mortem

## POST-MORTEM Individual

**Gonzalo Barranco Castro**

Que ha ido bien:

- La idea ha sido suficientemente pequeña y contenida para poder desarrollar el juego en el tiempo previsto.
- Hemos dividido bien el trabajo de cada persona
- He intentado ser proactivo y hacer tareas que faltasen.
- Hacer un calendario de subidas en redes sociales ha sido muy útil.

¿Qué cosas habría que mejorar?

- La comunicación entre el equipo de diseño de arte y arte técnico no ha sido la mejor.
- Necesitamos dejar más claro qué tareas están hechas y faltan por hacer dentro del equipo de arte.
- Dejar las cosas bien escritas referentes a lo que es la clave del juego. Todo el equipo tiene que tener bien claro cómo es el GDD y si hay alguna duda preguntar.

**Daniel Salguero Fernández:**

Que ha ido bien

- Hemos logrado hacer un juego desde 0
- Hemos conseguido sacar adelante un proyecto de un género que no habíamos hecho antes
- La estética del juego es muy adecuada para el juego
- El juego tiene una dificultad progresiva y va mostrando las mecánicas poco a poco
- Buen rendimiento en todas las plataformas
- Buen acabado gráfico
- Buenas interfaces
- Hemos desarrollado música bastante buena para el juego

¿Qué cosas habría que mejorar?

- Comunicación entre el equipo
- Gestión del proyecto en trello (a nivel personal sobretodo pero también a nivel del equipo)
- Podría haber planteado mejor los niveles a nivel organizativo y de diseño
- RRSS abandonadas durante la mayor parte del desarrollo hasta la release de la beta
- Mejor gestión de los prefabs en cuanto al Game Design

**Pablo Conde López** :

Que ha ido bien

- Hemos sido capaces de establecer un pipeline de trabajo semi-funcional
- Hemos coordinando de manera satisfactoria el trabajo (al menos en el apartado de programación)
- Hemos sacado el juego adelante que no es poco
- Hemos tenido un sistema donde quedaba constancia de que paquetes de trabajo corresponden a cada persona

¿Qué cosas habría que mejorar?

- Necesitamos mejorar el flujo de comunicación entre el equipo, en especial entre diferentes partes (arte/game-design/programación)
- Necesitamos establecer de manera más clara las prioridades de los paquetes a desarrollar
- Necesitamos establecer de manera más clara los plazos en los que se van a realizar, de manera estimada, los paquetes de trabajo

**Luis** :

Que ha ido bien

- He conseguido programar de forma más legible y sin #terrorismo
- He programado UI de forma muchas más eficiente para implementar
- Programación más eficiente
- Hemos entregado con tiempo de sobra sin el asfixiados
- Se ha implementado la mayoría de las cosas que queríamos implementar

¿Qué cosas habría que mejorar?

- REALIZAR PREFABS LO PRIMERO
- No dejar cosas para los últimos días que son tediosas de implementar
- Usar mejor nomenclatura de variables, principalmente de privadas y públicas
- Mejor organización de carpetas

_ **Gloria** _

Que ha ido bien

- Se han usado muchos de los objetos
- Se han usado los iconos de la ui
- La música no ha quedado mal

¿Qué cosas habría que mejorar?

- Saber qué hay que hacer desde el principio
- Muchos modelos y objetos al final no se han utilizado
- Que me digan antes lo que hay que hacer en vez de que me lo vayan diciendo según surge
- Música mejor

**Almudena**

Que ha ido bien

- Aprender sobre Blender
- Animaciones resultonas (que han servido para varias cosas)
- Buenas ilustraciones que han servido para varias cosas
- Modularización del escenario
- Publicaciones respaldadas con nuestras otras cuentas

¿Qué cosas habría que mejorar?

- Blender daba bastantes problemas en cuanto a hacer curvas
- Hice las paredes 3 veces distintas (problemas míos de planteamiento + poco feedback)
- Riggeé al cuervo dos veces por no plantear correctamente los huesos y aun así la solución no era la más eficiente y tiene sus problemas aunque los haya escondido
- Aprender de Blender sobre la marcha (derivando en problemas varios)
- Gestión de tiempo y prioridades mejorable (en el futuro animación lo antes posible)
- Poco tiempo dedicado a redes
- Loop de animación mejorable (idle)
- Baldosas aun no son propias

## Post Mortem

### ¿Qué ha ido bien?

- _ **Hemos tenido un buen scope dentro del proyecto** _
- _ **Hemos entregado con calma** _
- _ **Buena división de trabajo** _
- _ **Teníamos claro que juego estábamos haciendo** _
- _ **Buena estética y bien desarrollada** _
- _ **Cumplido objetivos de la beta** _
- _ **Hemos establecido un buen flujo de trabajo entre las partes del equipo** _
- _ **Buena y eficiente resolución de los problemas que iban surgiendo** _

### ¿Qué se puede mejorar?

- _ **Comunicación** _
  - _ **Qué está en proceso de desarrollo y qué no** _
  - _ **Definir mejor el orden de prioridad de los paquetes de trabajo** _

- _**Hacer un uso más completo de SCRUM(o la técnica que decidamos)**_
  - _ **Definir tiempos estimados de realización en las tareas** _

- _ **Mejor uso de carpetas en Unity** _
- _ **Usar prefabs en Unity para objetos que vayan a ser recurrentes en las escenas** _
- _ **Mantener las redes sociales más actualizadas.** _
- _ **PROHIBIDO TOCAR ESCENAS VARIAS PERSONAS A LA VEZ. Cada vez que alguna persona vaya a tocar alguna escena, asegurarse de que nadie la está tocando.** _
- _ **Hacer builds en WebGL de manera más frecuente** _
