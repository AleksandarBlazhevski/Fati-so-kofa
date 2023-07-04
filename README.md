##Fati so kofa
---
Проект по Визуелно програмирање од: Александар Блажевски

##1. Опис
---
Едноставна игра во која играчот потребно е да ги фати соодветните кругови кои паѓаат вертикално.

##2. Упатство за играње
---
Играта има три прозори кои можат да му се прикажат на играчот.

###2.1 Мени форма
---
![Menu form image](https://github.com/AleksandarBlazhevski/Fati-so-kofa/blob/master/Fati-so-kofa/Fati-so-kofa/Preview/Menu%20Form.png?raw=true)<br/>
Слика 1<br/>
Во десниот долен агол има панел кој ги објаснува сите правила на играта.<br/>
Во десната страна од формата има табела која ги прикажува сите постигнати резулатит од предходните обиди сортирани во опаѓачки редослед.<br/>
Под табелата има друг панел кој на кратко ги објаснува контролите со кои играчој може да ја игра играта. <br/>
Во средината на формата има копче со кое се започнува играта.

###2.2 Форма за играње
---
![Game form image](https://github.com/AleksandarBlazhevski/Fati-so-kofa/blob/master/Fati-so-kofa/Fati-so-kofa/Preview/Game%20Form.png?raw=true)<br/>
Слика 2<br/>
Играчот го контролира движењето на квадратот во лево и во десно користејки ги стрелките на тастатурата. Исто така играчот може да ја смени бојата на квадратот со притисканје на копчето <i><b>v</b></i> од тастатурата.<br/><br/>
Играчот потребно е да ги фати круговите кои паѓаат надоле, но бојата на кругот кој е фатен мора да биде со иста боја како квадратот на играчот. Ако бојата на кругот и квадратот се различна боја, тогаш се одзема еден живот и еден поен.<br/><br/>
Секоја нова игра играчот започнува со три животи. Ако ги изгуби трите животи играта завршува. Исто така играта завшува ако играчот пропушти десет по ред кругови да поминат под квадратот на играчот и меѓу времено играчот не фати соодветен круг.<br/>
Со секој соодветно фатен круг игрчот е награден со поен. На секои 5 поени собрани, движењето на круговите се забрзува и на секои 10 поени собрани круговите се појавуваат на пократок интервал.<br/><br/>
Во долниот десен агол има панел кој ги прикажува преостанатите животи и бројот на пропуштени кругови.<br/>
Во горниот десен агол има друг панел кој ја по кажува моменталната брзина и интервалот на круговите, во текстуална форма и како <i>progress bar</i> кој кога ке се наполни ќе се зголеми вредонста на соодветното својсто.

###2.3 Форма за крај на играта
---
![Game over form image](https://github.com/AleksandarBlazhevski/Fati-so-kofa/blob/master/Fati-so-kofa/Fati-so-kofa/Preview/Game%20Over%20Form.png?raw=true)<br/>
Слика 3<br/>
Овој прозорец се појава одкако играта ќе завши и на играчот му се прикажува неговиот резултат и најдобриот до сега.<br/>
Играчот може да притисне на копчето <b>Play again</b> за да започне повторно или <b>Exit</b> за да излезе од играта.

##3 Решавање на проблемот
---
![Game structure](https://github.com/AleksandarBlazhevski/Fati-so-kofa/blob/master/Fati-so-kofa/Fati-so-kofa/Preview/Game%20structure.png?raw=true)<br/>
Од абстракната класа Shape наследува Circle и од неа наследуваат RedCircle, BlueCircle, GreenCricle.<br/>
Во класата Spawner се чува листа од Shape која е задолжена за додавање на нови случајно избрани облици во формата за играње. Истата е задолжена за цртанје, движење и уништување на облиците.<br/>
За справување на поените е задолжена класата ScoreManager. Во неа се чуваат поените и истите се прикажуваат кога ќе има промена. Кога поените ќе поминат одредена вредност, класата ги повикува методите за иземнување на својствата на облиците. <br/>
Сите својства и потези на играчот се наоѓјаат во класата Player.<br/><br/>
Во прозорецот GameForm се иницијализираат инстанци од класите Spawner, Player и ScoreManager. Исто така има две bool својства во кои се чува влезот од играчот.<br/>
Во прозорецот GameOverForm се пренесува најдобриот резултат и последниот резулат кој го постигнал играчот.<br/>
Во прозорецот MenuForm се пренесува листа од сите резултати која се користи за прикажување.<br/>
```c#
public abstract class Shape
    {
        /// <summary>
        /// Shape's center coordinate
        /// </summary>
        public Point Center{ get; set; }
        /// <summary>
        /// Shape's movement speed
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// Shape's width and height
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Shape's color
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// Shape's X coordinate where it does something
        /// </summary>
        public int RedLine { get; private set; }

        protected Shape(Point center, int speed, int size, int redLine)
        {
            Center = center;
            Speed = speed;
            Size = size;
            RedLine = redLine;
        }

        /// <summary>
        /// Changes the Center coordinates
        /// </summary>
        /// <param name="distance"></param>
        public abstract void Move(int distance);
        /// <summary>
        /// Draws the shape on the graphics
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);
        /// <summary>
        /// Checks for collision with the player
        /// </summary>
        /// <param name="playerCenter">Player posion</param>
        /// <param name="playerSize">Player widht and height</param>
        /// <returns>Returns true if collides with the player or false if not</returns>
        public abstract bool isHit(Point playerCenter, int playerSize);
    }
```
Секои тип на круг ги има имплементирано методите void Move(int distance), void Draw(Graphic g) и bool isHit(Point playerCenter, int playerSize).<br/><br/>
```c#
public override void Move(int distance)
        {
            //Blue ball is in middle and not blinked
            if(!blinked && Center.Y > RedLine && Center.X == 170)
            {
                //Blink forward
                Center = new Point(Center.X, Center.Y + 60);
                blinked = true;
            }
            //Blue ball is on the side and not bliked
            if(!blinked && Center.Y > RedLine && (Center.X == 30 || Center.X == 330))
            {
                //Blink in other side line
                Center = new Point(Center.X == 30? 330 : 30, Center.Y);
                blinked = true;
            }
            //Move forward
            Center = new Point(Center.X, Center.Y + distance);
        }
    }
```
Во следниов код е прикажана методата Move за плавиот круг. <br/><br/>
Плавиот круг има мутација што прави да може еднаш да скокне одкако ќе ја помине црвената линија.
Методата проверува дали еднаш има скокнато и после тоа проверува дали ја има поминато црвената линија.
Ако има скокнато или ја нема поминато црвента линија, кругот ке продолжи да се движи нормално. Но ако ја поминал црвената линија и нема скокнато, тогаш кругот ке скокне.
Насоката на скокот зависи од линијата во која се наоѓа.<br/>
- Ако е во средната линија, тогаш скока по напред.<br/>
- Ако е на крајните линии, тогаш скока во спротивната надворешна линија.<br/><br/>

Дали кругот има скокнато се чува во променливата blinked која е од тип bool.<br/>
Скокот е имплементиран со тоа што позицијата на кругот се менува во соодветно каде завршува скокот.<br/><br/>

За повеќје информации обрате се во кодот кој е целосно документиран.
