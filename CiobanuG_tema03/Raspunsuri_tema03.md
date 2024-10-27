# CiobanuG_tema03

## 1. Care este ordinea de desenare a vertexurilor pentru aceste metode (orar sau anti-orar)?

Ordinea vertexurilor pentru primitivele geometrice în OpenGL poate fi orară sau anti-orară, în funcție de tipul primitivei și de ordinea specificării vertexurilor.  
Pentru a desena axele de coordonate folosind un singur apel `GL.Begin()` în template-ul furnizat, putem specifica toate liniile axelor într-o singură secvență de vertexuri, fără a închide blocul `GL.Begin()` între fiecare linie.

## 2. Ce este anti-aliasing? Prezentați această tehnică pe scurt.

Anti-aliasing este o tehnică folosită pentru a reduce efectele de „aliasing” (marginile zimțate) care apar la redarea graficelor pe ecran. Aceasta se realizează prin intermediul unei tranziții graduale de culori între marginile obiectelor și fundal, oferind o redare mai fină și mai plăcută vizual. OpenGL permite activarea anti-aliasing-ului prin `GL.Enable(EnableCap.LineSmooth)` și alte setări specifice.

## 3. Care este efectul rulării comenzii `GL.LineWidth(float)`? Dar pentru `GL.PointSize(float)`? Funcționează în interiorul unei zone `GL.Begin()`?

`GL.LineWidth(float)` modifică grosimea liniilor desenate. `GL.PointSize(float)` schimbă dimensiunea punctelor.  
Ambele comenzi funcționează în afara și în interiorul unei zone `GL.Begin()`, dar setarea lor trebuie realizată înainte de specificarea vertexurilor pentru a fi aplicată liniilor sau punctelor respective.

## 4. Răspundeți la următoarele întrebări (utilizați ca referință eventual și tutorii OpenGL Nate Robbins):

- **Care este efectul utilizării directivei `LineLoop` atunci când desenate segmente de dreaptă multiple în OpenGL?**  
  `LineLoop`: Crează o serie de segmente de dreaptă conectate și închide bucla, conectând ultimul vertex la primul.

- **Care este efectul utilizării directivei `LineStrip` atunci când desenate segmente de dreaptă multiple în OpenGL?**  
  `LineStrip`: Desenează o serie de segmente de dreaptă conectate, dar fără a conecta ultimul vertex la primul, deci rămâne deschisă.

- **Care este efectul utilizării directivei `TriangleFan` atunci când desenate segmente de dreaptă multiple în OpenGL?**  
  `TriangleFan`: Formează o serie de triunghiuri care au toate un vertex comun (primul specificat), facilitând desenarea poligoanelor în formă de ventilator.

- **Care este efectul utilizării directivei `TriangleStrip` atunci când desenate segmente de dreaptă multiple în OpenGL?**  
  `TriangleStrip`: Crează o serie de triunghiuri conectate între ele, unde fiecare triunghi, după primul, împarte două vertexuri cu triunghiul precedent, ideal pentru suprafețe continue și eficiente ca performanță.

## 6. Urmăriți aplicația „shapes.exe” din tutorii OpenGL Nate Robbins. De ce este importantă utilizarea de culori diferite (în gradient sau culori selectate per suprafață) în desenarea obiectelor 3D? Care este avantajul?

Folosirea culorilor diferite pe suprafețe permite crearea de efecte vizuale mai plăcute, cum ar fi gradienții și umbrele. Acest lucru ajută la evidențierea adâncimii și formelor obiectelor, oferind o iluzie de tridimensionalitate.

## 7. Ce reprezintă un gradient de culoare? Cum se obține acesta în OpenGL?

Un gradient este o tranziție lină de culoare între două sau mai multe culori. În OpenGL, acesta se poate obține specificând culori diferite pentru fiecare vertex dintr-o primitivă, iar OpenGL va interpola culorile între vertexuri pentru a crea efectul de gradient.

## 8. Ce efect va apărea la utilizarea canalului de transparență?

Utilizarea canalului de transparență va permite ajustarea opacității triunghiului, de la complet transparent la complet opac.

## 10. Ce efect are utilizarea unei culori diferite pentru fiecare vertex atunci când desenați o linie sau un triunghi în modul strip?

Atunci când fiecare vertex are o culoare diferită într-o linie sau un triunghi desenat în modul strip, OpenGL va interpola culorile între vertexuri, generând un gradient lin pe toată lungimea liniei sau suprafața triunghiului.
