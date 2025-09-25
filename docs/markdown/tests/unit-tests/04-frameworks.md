<!-- .slide: class="transition-bg-sfeir-2" -->

# Choix d'un framework

##==##

<!-- .slide: class="two-column" data-background="#2c3c4e"-->

# Les frameworks

- ![Logo NUnit](./assets/images/nunit-logo.png)
- ![Logo MsTest](./assets/images/mstest-logo.png)
    <!-- .element: class="list-fragment" -->

  ##--##
  <br><br><br>

- ![Logo xUnit](./assets/images/xunit-logo.png)
- ![Logo TUnit](./assets/images/tunit-logo.png)
<!-- .element: class="list-fragment" -->

<!--
Avis et retours personnels sur chacun des frameworks.

---
NUnit, ancien, directement inspiré du framework de Java.
La configuration par default peut rapidement amener à des résultats innatendus et il demande plus de connaissances et de rigueur pour avoir une suite de tests propre et efficace.

Choix : Déconséillé.

---
MSTest, directement proposé par Microsoft. Les premières versions étaient très limitées et peu performantes.
Aujourd'hui correct, il reste moins utilisé. Malgré une très bonne intégration aux outils Microsoft, il 'lag' souvent derrière les autres frameworks en terme de fonctionnalités.

Choix: Correct mais pas le meilleur. Le point fort est principalement l'intégration avec certains outils MS.

---
XUnit, est le plus utilisé et le plus simple pour les tests unitaires.
Rapide et léger. Sa philosophie le rend idéal pour les tests unitaires, mais il est moins adapté pour les tests d'intégration et fonctionnels.

Choix: le plus populaire. Parfait pour les tests unitaires, mais pas pour les tests d'intégration et fonctionnels.

---
Tunit est un tout nouveau framework. Il est tout aussi bon que xUnit, et propose en plus de très bonnes fonctionalités pour les tests d'intégration et fonctionnels, en plus de très bonnes performances.
Deux inconvénients: sa jeunesse, et le fait qu'il ne fonctionne qu'avec "Microsft Test Platform" et pas avec "VsTest".

Choix: probablement le meilleur, mais sa jeunesse le rend plus "risqué" sur le long terme.

-->

##==##

# Elements de comparaison

- Syntaxe : Mots clés utilisés pour les tests et pour les asserts
- Isolation et parallélisation
- Integrations aux outils MS / Extensions
  <!-- .element: class="list-fragment" -->

##==##

# Tableau comparatif de la syntaxe des framework de tests unitaires

<table style="font-size: 0.6em;">
  <thead>
    <tr>
      <th>Fonctionnalité</th>
      <th>NUnit</th>
      <th>MSTest</th>
      <th>xUnit</th>
      <th>TUnit</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><b>Classe de test</b></td>
      <td><code>[TestFixture]</code></td>
      <td><code>[TestClass]</code></td>
      <td>Non requis</td>
      <td><code>[TestClass]</code></td>
    </tr>
    <tr>
      <td><b>Méthode de test</b></td>
      <td><code>[Test]</code></td>
      <td><code>[TestMethod]</code></td>
      <td><code>[Fact]</code></td>
      <td><code>[Test]</code></td>
    </tr>
    <tr>
      <td><b>Tests paramétrés</b></td>
      <td><code>[TestCase(...)]</code></td>
      <td><code>[DataRow(...)]</code></td>
      <td><code>[Theory][InlineData(...)]</code></td>
      <td><code>[TestCase(...)]</code></td>
    </tr>
    <tr>
      <td><b>Init. classe</b></td>
      <td><code>[OneTimeSetUp]</code></td>
      <td><code>[ClassInitialize]</code></td>
      <td>Constructor</td>
      <td><code>[Before(Class)]</code></td>
    </tr>
    <tr>
      <td><b>Cleanup classe</b></td>
      <td><code>[OneTimeTearDown]</code></td>
      <td><code>[ClassCleanup]</code></td>
      <td><code>IDisposable.Dispose()</code></td>
      <td><code>[After(Class)]</code></td>
    </tr>
    <tr>
      <td><b>Init. test</b></td>
      <td><code>[SetUp]</code></td>
      <td><code>[TestInitialize]</code></td>
      <td>Constructor</td>
      <td><code>[Before(Test)]</code></td>
    </tr>
    <tr>
      <td><b>Cleanup test</b></td>
      <td><code>[TearDown]</code></td>
      <td><code>[TestCleanup]</code></td>
      <td><code>IDisposable.Dispose()</code></td>
      <td><code>[After(Test)]</code></td>
    </tr>
    <tr>
      <td><b>Ignorer test</b></td>
      <td><code>[Ignore("...")]</code></td>
      <td><code>[Ignore]</code></td>
      <td><code>[Fact(Skip="...")]</code></td>
      <td><code>[Skip("...")]</code></td>
    </tr>
    <tr>
      <td><b>Égalité</b></td>
      <td><code>Assert.That(a, Is.EqualTo(e))</code></td>
      <td><code>Assert.AreEqual(e, a)</code></td>
      <td><code>Assert.Equal(e, a)</code></td>
      <td><code>Assert.That(a).IsEqualTo(e)</code></td>
    </tr>
    <tr>
      <td><b>Vérité</b></td>
      <td><code>Assert.That(c, Is.True)</code></td>
      <td><code>Assert.IsTrue(c)</code></td>
      <td><code>Assert.True(c)</code></td>
      <td><code>Assert.That(c).IsTrue()</code></td>
    </tr>
    <tr>
      <td><b>Exception</b></td>
      <td><code>Assert.Throws&lt;E&gt;(() => {})</code></td>
      <td><code>[ExpectedException(typeof(E))]</code></td>
      <td><code>Assert.Throws&lt;E&gt;(() => {})</code></td>
      <td><code>Assert.That(() => {}).ThrowsException()</code></td>
    </tr>
    <tr>
      <td><b>Catégories</b></td>
      <td><code>[Category("cat")]</code></td>
      <td><code>[TestCategory("cat")]</code></td>
      <td><code>[Trait("Category", "cat")]</code></td>
      <td><code>[Category("cat")]</code></td>
    </tr>
  </tbody>
</table>

##==##

# Créer un nouveau projet de tests

Ici utilisation du Framework: xUnit v3

Avec Visual Studio
![new dotnet test project templates](./assets/images/new_test_project.png)

En ligne de commande

```bash
dotnet new list
dotnet new xunit3
# Remark : if xunit v3 templates are missing do
dotnet new install xunit.v3.templates
```
