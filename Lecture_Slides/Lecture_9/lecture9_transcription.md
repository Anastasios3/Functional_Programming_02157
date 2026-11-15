# 02157 Functional Programming, Week 9: Modules and Typing

Transcribed from `Lecture9-zeb.pdf`, 35 slides, one section per slide.

## Slide 1 of 35

**02157 Functional Programming**

**Week 9:**

**Modules and Typing**

Sebastian Mödersheim

Based on slides by Michael Reichhardt Hansen

November 6, 2026

## Slide 2 of 35: Overview

* On critical looks at programs
  * simplification for readability reasons
  * simplifications for computational reasons
* The Module System
* F# is integrated on .Net&emsp;&emsp;briefly
  * free, open source
  * cross platform for Linux, MacOS, Windows, ...
* A brief look at type inference

## Slide 3 of 35: Outline

1. **On critical looks at programs**
2. The Module System
3. On Type Inference

## Slide 4 of 35: On critical looks at programs

* Aim at succinct programs

  have a critical look at your own programs

* Correctness has top priority

  but have an eye to sensible use of resources

## Slide 5 of 35: Can we simplify?

Have a look at:

```fsharp
let f(x) = match (x) with
           |(a,z) -> if (not(a) = true) then true
                     else if (fst(z) = true) then snd(z)
                          else false;;
```

* What is the type of *f*?
* What is *f* computing?

Can we improve readability?

## Slide 6 of 35: Is a use of library functions adequate?

Have a look at

```fsharp
let h a xs = let xs1 = List.filter (fun (a',t) -> a=a') xs
             let xs2 = List.map (fun (a,t:int) -> t) xs1
             List.sum xs2
```

* Can this problem easily be solved in a less resource demanding manner?

## Slide 7 of 35: Resource sensible versions

Have a look at:

```fsharp
let rec h1 a =
   function
   | []                     -> 0
   | (a',t)::rest when a=a' -> t + h1 a rest
   | _::rest                -> h1 a rest;;

let rec h2 a xs =
  List.fold (fun s (a',t) -> if a=a' then s+t else s) 0 xs;;
```

Solutions are based on a simple algorithmic idea

* traverse the list *xs* one time and
* build up the result during the traversal

Correctness has top priority

– but have an eye to sensible use of resources

More when the topic: Tail recursion, is covered

## Slide 8 of 35: Outline

1. On critical looks at programs
2. **The Module System**
3. On Type Inference

## Slide 9 of 35: Overview

* Supports modular program design including
  * encapsulation
  * abstraction and
  * reuse of software components.
* A module is characterized by:
  * a *signature* – an interface specifications and
  * a matching *implementation* – containing declarations of the interface specifications.
* Example-based presentation to give the flavor

  incomplete – no object interface types, for example

Sources:

* Chapter 7: Modules. (A fast reading suffices.)

## Slide 10 of 35: Recall: Polynomial Exercise from Week 2

Consider multiplication of polynomials:

$$
\begin{aligned}
0 \cdot Q(x) &= 0\\
(a_0 + a_1 \cdot x + ... + a_n \cdot x^n) \cdot Q(x) &= a_0 \cdot Q(x) + x \cdot \big((a_1 + a_2 \cdot x + ... + a_n \cdot x^{n-1}) \cdot Q(x)\big)
\end{aligned}
$$

### Idea

Represent polynomes by a list of coefficients:

`type Poly = int list` defines a new type `Poly`

* $[1; 2; 3]$ represents $1 + 2x + 3x^2$
* $[2; 0; 0; 1]$ represents $2 + x^3$
* General: $[\mathtt{a_0}; \ldots; \mathtt{a_n}]$ for $a_0 + a_1x + a_2x^2 + \ldots + a_nx^n$

Invent suitable auxiliary functions

* `mulC: int -> Poly -> Poly` — for multiplying a polynome by a constant

  e.g. `mulC 3 [1;2;3] = [3;6;9]`

* `mulX: Poly -> Poly` — for multiplying a polynome $P(x)$ by its variable $x$

  e.g. `mulX [1;2;3] = [0;1;2;3]`

* `add: Poly -> Poly -> Poly` — for adding two polynomes

  e.g. `add [1;2;3] [0;1] = [1;3;3]`

With these helpers define `mul: Poly -> Poly -> Poly` by the equation above.

e.g. `mul [2;3;0;1] [1;2;3]= [2;7;12;10;2;3]`

## Slide 11 of 35: Problem: Multiple Representations of the Same

### Multiple Representations

Several lists of co-efficients represent the same polynome:

$\texttt{[]} \approx \texttt{[0]} \approx \texttt{[0;0]} \ldots$

Where $\approx$ should express that these lists represent the same polynomes, but they are different lists, so:

$\texttt{[]} \neq \texttt{[0]} \neq \texttt{[0;0]} \ldots$

Such representation issues can cause trouble:

* Comparison does not behave as expected
* Hard-to-find bugs.

### Idea: Invariant

To solve this, define an invariant that guarantees a *unique representation*:

*For every polynome representation* $p = [a_0; ...; a_{n-1}]$

* either $n = 0$, i.e., $p = []$ or
* $a_{n-1} \neq 0$

i.e., the highest order co-efficient is never 0.

## Slide 12 of 35: On hiding: Polynomial program

An violation of a representation invariant&emsp;&emsp;*without hiding*

```fsharp
// A misuse: [0] is not legal polynomial
let p1 = mulX [0];;
// val p1 : int list = [0; 0]

// Pretty print
toString p1;;
// val it : string = "0"

let p2 = mulX [];;                  // [] is legal
// val p2 : int list = []

// Pretty print
toString p2;;
// val it : string = "0"

// But
p1 = p2;;
// val it : bool = false
```

* *may cause unpredictable results*

## Slide 13 of 35: Module Polynome

The idea of the Module system is that we define a *signature* that hides the implementation:

### Signature for Polynome Module

* *Abstract* data type `Polynome`
* *functions*:
  * `add : Polynome -> Polynome -> Polynome`
  * `mult : Polynome -> Polynome -> Polynome`
  * `ofList : int list -> Polynome`

* The signature does not say how we implement the data type or the functions.
* The implementation ensures that all Polynomes we ever create with the functions in the signature satisfy the invariant.
  * E.g. `add [3;3] [2;-3] = [5]`
* No user of the module can interfere with it: they can only use the defined functions.

*Exercise today: program signature and implementation.*

## Slide 14 of 35: Protection of a representation invariant

```fsharp
open Polynomial

let p1 = mulX (ofList [0]);;
// val p1 : Poly = 0         pretty print

let p2 = mulX (ofList []);;
// val p2 : Poly = 0         pretty print

p1 = p2;;
// val it : bool = true
```

* internal representation is hidden
* *ofList* gives legal representations

*Unpredictable results are prevented*

## Slide 15 of 35: Module

A *module* is a combination of a

* *signature*, which is a specification of an interface to the module (the user’s view), and an
* *implementation*, which provides declarations for the specifications in the signature.

## Slide 16 of 35: Geometric vectors: Signature

The signature specifies one type and several function values:

### Library.fsi

```fsharp
// Vector signature
module Vector
type Vector
val add : Vector * Vector -> Vector
val dotprod : Vector * Vector -> double
val scale : double * Vector -> Vector
val coord : Vector -> double * double
val norm : Vector -> double
val make : double * double -> Vector
```

*The specification ’Vector’ does not reveal the implementation*

* Why do we need *make* and *coord*?

## Slide 17 of 35: Geometric vectors (2): Simple implementation

An implementation must declare each specification of the signature:

### Vector.fs

```fsharp
// Vector implementation
module Vector
type Vector =
 |  V of (double*double)
 override p.ToString() =
   match p with V (a1,a2) -> "("+(string a1)+","+(string a2)+")"

let add (V (a1,a2),V (b1,b2)) = V(a1+b1,a2+b2)
let dotprod (V (a1,a2),V (b1,b2)) = a1*b1+a2*b2
let scale (c,(V (a1,a2))) = V (c*a1,c*a2)
let coord (V (a1,a2)) = (a1,a2)
let norm v = sqrt (dotprod (v,v))
let make (a1,a2) = V (a1,a2)
```

* Since the representation of ’Vector’ is *hidden in the signature*, the type must be *implemented by either a tagged value or a record*.

## Slide 18 of 35: Geometric vectors (3): Using in an Application

### Program.fs

```fsharp
open Vector
[<EntryPoint>]
let main argv =
   let v1 = make (3.0,2.0)
   let v2 = make (1.0,-1.0)
   printfn "v1=%s v2=%s" (string v1) (string v2)
   printfn "v1+v2=%s" (string (add (v1,v2)))
   printfn "v1*v2=%s" (string (dotprod (v1,v2)))
   0 // return an integer exit code
```

* How to set it all up in your favorite IDE differs.
* For the examples here we provide small archives with templates that work with the CLI dotnet and visual studio code.
* For setting up your own projects using the Command Line Interface (CLI) tool:

  https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-command-line

  https://docs.microsoft.com/en-us/dotnet/core/tools

* In the exam
  * we will not ask you to set up project files, CLI (all tasks can be done on paper);
  * however you must understand how signatures/modules work,

    i.e., what we discuss on the slides.

## Slide 19 of 35: Type augmentation

A *type augmentation*

* adds declarations to the definition of a tagged type or a record type
* allows declaration of (overloaded) operators.

In the ’Vector’ module we would like to

* overload `+`, `-` and `*` to also denote *Vector* operations.
* overload `*` to denote *two* different operations on vectors.

## Slide 20 of 35: Type augmentation – signature

```fsharp
module Vector

[<Sealed>]
type vector =
  static member ( + )  : vector * vector -> vector
  static member ( * )  : double  * vector -> vector
  static member ( * )  : vector * vector -> double
val make : double * double -> vector
val coord: vector -> double * double
val norm : vector -> double
```

* The *attribute* `[<Sealed>]` is mandatory when a type augmentation is used. It protects the library against unintentional use in the OO-world.
* The “`member`” specification and declaration of an infix operator (e.g. `+`) correspond to a type of form `type1 * type2 -> type3`
* The operators can still be used on numbers.

## Slide 21 of 35: Type augmentation – implementation and use

```fsharp
module Vector
type vector =
  | V of double * double
  static member (+) (V(x1,y1),V(x2,y2)) = V(x1+x2,y1+y2)
  static member (*) (a, V(x,y))         = V(a*x,a*y)
  static member (*) (V(x1,y1),V(x2,y2)) = x1*x2 + y1*y2
let make (x,y)     = V(x,y)
let coord (V(x,y)) = (x,y)
let norm (V(x,y))  = sqrt(x*x + y*y)
```

The operators `+`, `-`, `*` are available on vectors even without opening:

```fsharp
let a = Vector.make(1.0,-2.0);;
val a : Vector.vector

let b = Vector.make(3.0,4.0);;
val b : Vector.vector

let c = 2.0 * a + b;;
val c : Vector.vector

Vector.coord c ;;
val it : double * double = (4.0, 0.0)
```

## Slide 22 of 35: Customizing the string function

```fsharp
module Vector
type vector =
   | V of float * float
   override v.ToString() =
           match v with | V(x,y) -> string(x,y)

let make (x,y)     = V(x,y)
   ...
```

* The default ToString function that does not reveal a meaningful value is overridden to give a string for the pair of coordinates.
* A type extension is used.

Example:

```fsharp
let a = Vector.make(1.0,2.0);;
val a : Vector.vector = (1, 2)

string(a+a);;
val it : string = "(2, 4)"
```

## Slide 23 of 35: Summary

Modular program development

* program libraries using signatures and structures
* type augmentation, overloaded operators, customizing string (and other) functions
* Encapsulation, abstraction, reuse of components, division of concerns, ...
* ...

## Slide 24 of 35: Outline

1. On critical looks at programs
2. The Module System
3. **On Type Inference**

## Slide 25 of 35: Type inference

Automated generation of the (most general) type for a program that do not contain type annotations.

* Avoid cluttering beautiful programs with type annotations while
* Preserving static type safety

*Some of the following slides contain advanced material, denoted with a red $\star$. This advanced material not expected in the exam.*

## Slide 26 of 35: Type inference: Examples

For the two functions:

```fsharp
let f x y = 2 * x + y;;

let rec append xs ys = match xs with
                       | []      -> ys
                       | x::rest -> x::append rest ys;;
```

the F# compiler infers the types:

```fsharp
f: int -> int -> int
append: 'a list -> 'a list -> 'a list
```

The F# type inference includes

* *Overloading*

  Functions with different types and implementations can share name, e.g. `+`

* *Parametric polymorphism*

  A single implementation of a function works for type-consistent input data, , e.g. `append`

## Slide 27 of 35: $\star$ Simply Typed Lambda Calculus

### Idea for Typing (Church, Curry,...)

* The function $\lambda x.e$ has a type $\tau_1 \to \tau_2$, if
  * $x$ has type $\tau_1$ and
  * $e$ has type $\tau_2$.
* The function application $e_1\ e_2$ has type $\tau_2$, if
  * $e_1$ has type $\tau_1 \to \tau_2$ and
  * $e_2$ has type $\tau_1$.

Here $\tau_1$ and $\tau_2$ can be arbitrary types.

* One can make formulate this as a calculus (shown in the lecture).
* From this calculus, one can derive algorithms for automatically
  * infering the *principal (i.e., most general)* type
  * or detecting a type error.

## Slide 28 of 35: $\star$ Type inference: Background

* Hindley type-schema for Combinatory Logic 1969
* Milner ML-style type inference with algorithm W 1978
* Damas-Milner 1982: correctness of type inference algorithm W
* ... SML ... OCAML ... Haskell ... F# ...

Type inference in SML, ...F#, ... allows *let-polymorphism*; where, for example,

```fsharp
let rec map f xs = match xs with
                   | []    -> []
                   | x::xs -> f x :: map f xs
```

is typable $\texttt{map} : \forall\alpha, \beta.(\alpha \to \beta) \to \alpha\ \texttt{list} \to \beta\ \texttt{list}$

The following program is *NOT typable*:

```fsharp
let f g = (g 1, g true) in f id
```

as it would require two different instantiations of argument `g`’s type

*such extra power makes type inference problem undecidable*

## Slide 29 of 35: $\star$ About type rules and inference algorithm

The type-inference problem is specified using a few rules like:

$$
\frac{\rho[x \mapsto t_x, f \mapsto t_x \to t_r] \vdash e_r : t_r \quad \rho[f \mapsto \forall\alpha_1, \ldots, \alpha_n.t_x \to t_r] \vdash e_b : t}{\rho \vdash \mathrm{let}\ f\ x\ =\ e_r\ \mathrm{in}\ e_b\ \mathrm{end} : t}\;\begin{array}{l}\text{rule 8 out of 9}\\ \text{(Sestoft2012)}\end{array}
$$

where $\alpha_1, \ldots, \alpha_n$ are not free in $\rho$.&emsp;&emsp;*don’t worry*

The identity function: `let id x = x` has infinitely many types

```fsharp
'a->'a   int list->int list   int list list->int list list
```

including a *most general (or principal)* type `'a -> 'a`

*having all other types of `id` as instances*

The step from a rule-based formulation to an algorithm is huge.

* rules and algorithm by Milner in 1978
* correctness proof of algorithm by Damas-Milner in 1982
* ML typability is complete for DEXPTIME by Mairson and Kfoury-Tiuryn-Urzyczyn in 1990

Nice presentations in

* Sestoft: Programming language concepts, Springer 2012 (Ch 6)
* Schwartzbach: Polymorphic type inference, BRICS LS 95-3

## Slide 30 of 35: $\star$ A program with a complex type: Sestoft 2012

```fsharp
let pair x y p = p x y;;

let p1 p = pair id id p;;
let p2 p = pair p1 p1 p;;
let p3 p = pair p2 p2 p;;
let p4 p = pair p3 p3 p;;
let p5 p = pair p4 p4 p;;
```

* `p1`’s type contains 3 type variables
* `p2`’s type contains 7 type variables
* `p3`’s type contains 15 type variables
* ...

Observe

* a doubling of the number of type variables from $\texttt{p}_i$ to $\texttt{p}_{i+1}$
* the number of type variable is exponential in the program size
* programmers rarely make programs having such complex types
* type checking appears to be efficient in practice

## Slide 31 of 35: An informal approach to type inference

Here is a general strategy to quickly compute the type of an expression

— or find a type error:

* Use *fresh type variables* to all identifiers of an expression or declaration.
  * It represents that this can (as far as we know at this point) be *any* type.
  * For simplicity, let us assume here that variables with different scopes and types have different names, e.g. in

    `let f x = x || (let x = 3 in x*x>0)`

    we should rename the different x’es apart:

    `let f x = x || (let y = 3 in y*y>0)`

  * So, we may have start here with $f : \tau_1, x : \tau_2, y : \tau_3$
* Step by step we look at all parts of the expression and get *constraints* on the type variables:
  * $f$ must be a function that takes $x$ as an argument, so

    $\tau_1 = \tau_2 \to \tau_4$ for *some* type $\tau_4$. (We don’t know yet.)

  * The right-hand side `x||...` must be of type $\tau_4$
  * We know $|| : \texttt{bool} \to \texttt{bool} \to \texttt{bool}$, thus:
    * `x : bool`, thus $\tau_2 = \mathit{bool}$
    * `let y=3 in y*y>0:bool`, ...
    * $\tau_4 = \texttt{bool}$.
* Either the constraints are at some point unsatisfiable,

  or we obtain the *principal type*

  * In the example: $f : \texttt{bool} \to \texttt{bool}$

## Slide 32 of 35: An informal approach to type inference

Given a declaration

```fsharp
let rec f x y ... = e
```

and knowing typing and rules for “bits and pieces”.

* Choose two fresh type variables for the unknown types of the arguments $x, y, \ldots$
* Analyse $e$ adding new fresh type variables and constrains as needed when typing the parts of $e$

Two possibilities:

* An inconsistency is detected and the program cannot be typed.
* A most general type can be establish as constraints on the introduced type variables arise from the program only.

## Slide 33 of 35: An example of an informal type inference

```fsharp
let rec map f xs = match xs with
                   | []      -> []                 (1)
                   | x::tail -> f x :: map f tail  (2)
```

* Let `'a` and `'b` be fresh type variables so that `f:'a` and `xs:'b`.
* Since `xs` is matched with pattern `[]` in (1), xs must have type `'c list` ( `'c` fresh) and `'b = 'c list`
* The value of the function must have type `'d list` ( `'d` fresh) due to the expression `[]` in (1)
* Since `xs:'c list` is matched with pattern `x::tail` in (2), we have `x:'c` and `tail:'c list` due to the type of cons `::`.
* Since the value of the function has type `'d list`, we have that `f x::map f tail:'d list` and hence `f x:'d`, `map f tail:'d list` and `f:'c->'d` because `x:'c`. Therefore, `'a = 'c->'d`.

There are no further constraints and the most general type of `map` is

```fsharp
('c -> 'd) -> 'c list -> 'd list
```

Due to implicit universal quantification, the type can be renamed to

```fsharp
('a -> 'b) -> 'a list -> 'b list
```

## Slide 34 of 35: An even more informal approach

Explain in your own words .....

Explanation must

* justify that every sub-expression is well-typed and
* that the establish type is the most general one.

An explanation concerning the type of `map` should address:

* the arguments `f` and `xs`,
* the patterns `[]` and `x::tail`,
* the expressions `[]` and `f x :: map f tail`,
* the sub-expressions `f x` and `map f tail`, and
* the type of cons `::`.

## Slide 35 of 35: Exercises

* Polynome module:
  * Define a library for polynomes and application; you can take the vector example from the lecture as a template.
  * Implement polynomes in a way that the invariant is always preserved (see slide 24 - the page number in the pdf)
* Typing: exam fall 2015, problem 2, first task.

  Old exams: https://www.imm.dtu.dk/ mire/FSharpBook/oldExams.html
