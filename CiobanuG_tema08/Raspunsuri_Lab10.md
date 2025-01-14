
# Întrebări și Răspunsuri despre Texturare în OpenGL

## 1. Utilizați pentru texturare imagini cu transparență și fără. Ce observați?

**Imagini cu transparență**: Atunci când se utilizează imagini cu transparență (de exemplu, formate de imagine precum PNG sau TGA care includ un canal alpha), obiectele texturate vor respecta acea transparență. Aceasta înseamnă că anumite părți ale imaginii vor fi complet sau parțial transparente, permițând obiectelor de dedesubt să fie vizibile. Pentru a manipula transparența în OpenGL, se folosește blending-ul (amestecul), unde textele transparente sunt combinate cu fundalul în mod corect.

**Imagini fără transparență**: Dacă imaginea nu are transparență (de exemplu, JPG), întreaga imagine va fi complet vizibilă. Nu există zone transparente, iar obiectul texturat va acoperi complet alte obiecte sau fundalul, fără a permite vederii acestora din spate.

## 2. Ce formate de imagine pot fi aplicate în procesul de texturare în OpenGL?

OpenGL poate manipula o varietate de formate de imagini pentru texturare, printre care:
- **JPEG (JPG)**: Un format de imagine foarte utilizat pentru fotografii, care nu suportă transparență.
- **PNG**: Un format care suportă transparență prin canalul alpha.
- **TGA (Targa)**: Un format care poate include canal alpha pentru transparență și este adesea folosit pentru texturi.
- **BMP**: Un format de imagine mai puțin eficient, dar folosit în anumite cazuri.
- **GIF**: Deși OpenGL poate folosi fișiere GIF pentru texturare, acest format este mai puțin folosit în texturare din cauza dimensiunii mari a fișierelor și a limitărilor în ceea ce privește transparența (doar o singură culoare poate fi setată ca transparentă).
- **HDR (High Dynamic Range)**: Acest format este folosit pentru imagini cu o gamă dinamică mare și poate fi folosit în efecte de iluminare avansate (de obicei pentru medii și iluminare).

## 3. Specificați ce se întâmplă atunci când se modifică culoarea (prin manipularea canalelor RGB) obiectului texturat.

Când se manipulează culorile obiectului texturat prin ajustarea valorilor RGB, efectul depinde de modul în care se realizează texturarea și de modul de iluminare activat în scenă:
- **Modificarea valorilor RGB ale texturii**: Când manipulezi canalele RGB ale unei texturi, modifici culorile acelei texturi. De exemplu, creșterea valorii canalului R (roșu) va face ca textura să devină mai roșie, iar scăderea valorii canalului B (albastru) va face textura mai puțin albastră.
- **Modificarea valorilor RGB ale obiectului texturat**: Dacă schimbăm culoarea unui obiect texturat (de exemplu, prin aplicarea unui material colorat sau a unei iluminări colorate), obiectul se va înmuia într-o nuanță de culoare dorită, modificând percepția texturii, deși textura în sine rămâne neschimbată.

## 4. Ce deosebiri există între scena ce utilizează obiecte texturate în modul iluminare activat, respectiv dezactivat?

- **Iluminare activată**: Când iluminarea este activată, culoarea finală a unui obiect texturat depinde nu doar de textura aplicată, ci și de lumina din scenă. Lumina afectează percepția obiectului texturat, prin efecte cum ar fi iluminarea difuză, speculară și umbra. Textura poate părea diferită în funcție de unghiul și intensitatea luminii, creând un efect mai realist.
  
  - **Exemplu**: O textură aplicată pe un obiect rotund, cu iluminare activă, va părea să aibă colțuri și suprafețe mai luminoase sau mai întunecate, în funcție de cum interacționează cu sursele de lumină.

- **Iluminare dezactivată**: Când iluminarea este dezactivată, textura se aplică pe obiect fără a lua în considerare efectele luminii. În acest caz, imaginea texturată va apărea la fel indiferent de unghiul din care este privită, iar obiectul va părea plat, fără detalii de iluminare sau umbră pe obiect. 

  - **Exemplu**: O textură aplicată pe o sferă fără iluminare activă va arăta la fel indiferent de unghiul de vizualizare, fără efecte de lumină sau umbră pe obiect.
