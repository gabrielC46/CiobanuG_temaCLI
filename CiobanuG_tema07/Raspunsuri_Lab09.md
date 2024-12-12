# Întrebări și Răspunsuri: Iluminarea în OpenGL

### 1. Diferențele dintre iluminarea din lumea reală și modelul de iluminare OpenGL  
Iluminarea reală este complexă, incluzând reflexii, refracții și iluminare globală, pe când OpenGL folosește un model local simplificat (Phong/Blinn-Phong), fără reflexii indirecte și cu surse limitate.

---

### 2. Câte surse de lumină sunt suportate în implementarea curentă a OpenGL cu ajutorul framework-ului OpenTK?  
OpenGL suportă până la 8 surse de lumină implicite (`GL_LIGHT0`–`GL_LIGHT7`), iar în implementarea actuală sunt utilizate două (`GL_LIGHT0` și `GL_LIGHT1`).

---

### 3. Definiți iluminarea de material și specificați unde și când este utilizată aceasta.  
Iluminarea de material definește cum reflectă un obiect lumina (ambient, difuză, speculară) și este utilizată în OpenGL pentru a seta interacțiunea optic-materială a obiectelor într-o scenă 3D.

---

### 4. Care este efectul asupra diverselor obiecte la activarea unei surse de lumină secundare, comparativ cu utilizarea unei singure surse de lumină?  
Activarea unei surse de lumină secundare adaugă realism prin iluminare din mai multe direcții, reliefuri mai detaliate și efecte de suprapunere, față de umbre și iluminare uniforme cu o singură sursă.
