
# Întrebări și Răspunsuri despre OpenGL

## 1. Care este rolul comenzilor GL.Push() și GL.Pop()? De ce este necesară utilizarea lor?

**Rolul comenzilor GL.Push() și GL.Pop():**

- **GL.Push()** salvează starea curentă a matricei de transformare într-o stivă. Aceasta permite păstrarea configurației actuale a transformărilor, astfel încât să poți face modificări temporare fără a afecta restul scenei.
- **GL.Pop()** restaurează ultima stare salvată a matricei din stivă. Astfel, modificările temporare sunt „anulate”, iar configurația inițială este restaurată.

**De ce este necesară utilizarea lor?**

Aceste comenzi sunt necesare pentru a permite lucrul cu ierarhii de obiecte în scene complexe, unde fiecare obiect poate avea propriile transformări (cum ar fi rotație, scalare, translație). Fără GL.Push() și GL.Pop(), transformările aplicate unui obiect ar afecta întregul rest al scenei, deoarece OpenGL folosește o matrice globală de transformare.

## 2. Explicați efectul rulării metodelor GL.Rotate(), GL.Translate() și GL.Scale(). Furnizați câte un exemplu comentat!

**GL.Rotate()**: Aplica o rotație în jurul unui anumit punct. Se specifică unghiul de rotație și axa pe care se efectuează rotația (x, y, z).
- **Exemplu:**
  ```cpp
  glRotatef(45.0f, 0.0f, 0.0f, 1.0f);  // Rotește scena cu 45 de grade în jurul axei Z
  ```
  În acest exemplu, întreaga scenă este rotită cu 45 de grade în jurul axei Z.

**GL.Translate()**: Aplica o translație (mutare) a obiectului sau scenei într-o anumită direcție pe axele X, Y și Z.
- **Exemplu:**
  ```cpp
  glTranslatef(2.0f, 0.0f, 0.0f);  // Translează scena cu 2 unități pe axa X
  ```
  În acest exemplu, scena este mutată cu 2 unități pe axa X.

**GL.Scale()**: Aplica o scalare (redimensionare) a obiectului sau scenei pe axele X, Y și Z.
- **Exemplu:**
  ```cpp
  glScalef(1.5f, 1.5f, 1.0f);  // Scalează scena cu 1.5 pe axele X și Y, iar pe Z nu există scalare
  ```
  În acest exemplu, obiectele din scenă sunt mărite de 1.5 ori pe axele X și Y, dar rămân la dimensiunea originală pe axa Z.

## 3. Câte nivele de manipulări ierarhice (folosindu-se GL.Push()/GL.Pop()) suportă o scenă OpenGL?

**Numărul de nivele de manipulări ierarhice:**

În OpenGL, nu există un număr fix de nivele de manipulări ierarhice impuse de GL.Push() și GL.Pop(). Aceste comenzi pot fi folosite la orice nivel și pot salva orice număr de stări, atâta timp cât hardware-ul și implementarea OpenGL permit acest lucru. În general, hardware-ul modern poate gestiona un număr foarte mare de nivele (de exemplu, mii de nivele), iar limita este, de obicei, determinată de memoria disponibilă și de implementarea specifică a driverului OpenGL.
