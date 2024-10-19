# Răspunsuri

1. **Creați un proiect elementar. Urmăriți exemplul furnizat cu titlu de demonstrație - OpenTK_console_sample01 și OpenTK_console_sample02. Atenție la setarea viewport-ului. Modificați valoarea constantei „MatrixMode.Projection”. Ce observați?** 
   Modificarea valorii constantei `MatrixMode.Projection` din codul OpenGL va afecta modul în care scena 3D este percepută și redată pe ecran.

2. **Răspundeți la următoarele întrebări (utilizați ca referință și tutorialele OpenGL Nate Robbins încărcate în cadrul laboratorului 01):**

   - **Ce este un viewport?**  
     Un viewport este o regiune rectangulară din fereastra de redare în care OpenGL va desena conținutul grafic. Viewport-ul definește partea din fereastră care va afișa rezultatul randării.

   - **Ce reprezintă conceptul de frames per second din punctul de vedere al bibliotecii OpenGL?**  
     FPS este o măsură a numărului de cadre randate de OpenGL pe secundă. OpenGL nu garantează un anumit FPS, dar acesta este un indicator important al performanței aplicației grafice.

   - **Când este rulată metoda OnUpdateFrame()?**  
     Metoda `OnUpdateFrame()` este rulată la fiecare ciclu de actualizare al aplicației, care se întâmplă în mod constant, în funcție de ritmul specificat în metoda `Run()`.

   - **Ce este modul imediat de randare?**  
     Modul imediat de randare se referă la o tehnică de randare în care geometria și proprietățile vizuale ale obiectelor sunt specificate direct și imediat în cadrul codului. Fiecare obiect este randat pe rând, iar OpenGL tratează fiecare apel de randare pe măsură ce este primit.

   - **Care este ultima versiune de OpenGL care acceptă modul imediat?**  
     OpenGL 3.3 și versiunile ulterioare acceptă modul imediat.

   - **Când este rulată metoda OnRenderFrame()?**  
     Metoda `OnRenderFrame()` este rulată imediat după `OnUpdateFrame()`, și de obicei, la fiecare cadru de redare.

   - **De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?**  
     Metoda `OnResize()` este responsabilă pentru configurarea viewport-ului și a matricelor de proiecție în funcție de dimensiunile ferestrei. Aceasta asigură că scena este redată corect pe ecran și că aspectul și dimensiunile obiectelor sunt corecte.

   - **Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?**  
     `CreatePerspectiveFieldOfView(float fov, float aspect, float near, float far):`
     - `fov`: Câmpul de viziune (field of view) în radiani; de obicei, o valoare între 0 și π (180 de grade), unde valori mai mari reprezintă un unghi de vizibilitate mai larg.
     - `aspect`: Raportul de aspect al viewport-ului (lățime/înălțime); acesta trebuie să fie diferit de zero.
     - `near`: Distanța de clipping din față (near clipping plane); aceasta trebuie să fie un număr pozitiv mai mic decât `far`.
     - `far`: Distanța de clipping din spate (far clipping plane); aceasta trebuie să fie un număr pozitiv și mai mare decât `near`.

