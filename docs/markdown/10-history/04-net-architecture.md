<!-- .slide: class="transition-bg-sfeir-2" -->

# .NET internal architecture

##==##

# .NET

![center](./assets/10-history/dotnet_components.png)

ℹ️ [ECMA-335 - 6th edition 2012](https://ecma-international.org/wp-content/uploads/ECMA-335_6th_edition_june_2012.pdf)

##==##

<!-- .slide: class="two-column" -->

# ECMA-335 <!-- CLI = Common Language Infrastructure -->

Specification qui définit les éléments que les languages doivent respecter.

- Types:
  - **primitives**: `int`, `bool`, `string`, `float64`, ...
  - **genres**: `value types`, `reference types`
  - les **conversion** entre types
  - leur **contenu**: `fields`, `methods`, `static`
- Règles:
  - l'héritage
  - les operateurs
  - les exceptions
- etc.

##--##
<br><br><br><br>
![center](./assets/10-history/dotnet_components.png)

##==##

<!-- .slide: class="two-column" -->

# CLR (Common Language Runtime)

- Type Safety
- Exception Handling
- Memory Management
- Garbage Collector
- Security
- Just-In-Time Compiler
- Thread Management
- Debugging

##--##
<br><br><br><br>
![center](./assets/10-history/dotnet_components.png)
