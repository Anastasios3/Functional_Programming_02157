# 02157 Functional Programming, Week 2: Functions, Types, and Lists

Transcribed from `Lecture2-zeb.pdf`, 39 slides, one section per slide.

## Slide 1 of 39

**02157 Functional Programming**

**Week 2:**

**Functions, Types, and Lists**

Sebastian Mödersheim

Based on slides by Michael Reichhardt Hansen

September 11, 2026

## Slide 2 of 39: Outline

1. **Recap: What we have seen of F# so far**
2. Last Week's Exercises
3. Intro to Types
4. Intro to Higher-Order Functions
5. Lists
6. On functional decomposition
7. Exercises

## Slide 3 of 39: Syntax, Type Checking, and Semantics

* The *syntax* of a programming language describes what sequences of characters consitute a correctly formed program,
  * e.g. balancing of opening and closing parentheses.
* *Type checking* checks that all values (including functions) used in the program are indeed defined and used with the correct types,
  * e.g. a function that expects an int cannot be called with a string.
* *Semantics* says what a syntactically correct, well-typed program means.
  * e.g. `if x>0 then x else 2*x` with $[x \mapsto -3]$ evaluates to $-6$.
* In 02141 Computer Science Modelling you will learn how to formally describe syntax and semantics of programming languages.
* During the course, we will make such descriptions for reference, but not in all details formally. You will *not* be asked in the exam to describe syntax or semantics of F#.

## Slide 4 of 39: The Syntax unlocked so far (1/3):

### Constants

* `int` constants like $0, 1, -1, ...$
* `float` constants like $0.0, 3.14, ...$
* `string` constants like "*Hello*"
* `bool` constants *true* and *false*

### Identifiers

are programmer-chosen names for variables and functions, like `x7` or `exp`. They are sequences of alphanumberic characters (letters and digits), where the first must be a letter.

Keywords of F# like `let` also fulfill the definition of an identifier, but cannot be used as variable or function names, of course.

In compiler construction one typically formalizes concepts like constants and identifiers by *regular expressions* like `IDENT : [a-zA-Z][a-zA-Z0-9]*`

but we do not go into that in this course.

## Slide 5 of 39: The Syntax unlocked so far (2/3):

### Expressions

An *expression* can be any of the following:

* A constant
* An identifier
* If $e, e_1, \ldots e_n$ are *expressions* and $\oplus$ is an infix operator (like $+$, $\ast$, $<$, $=$,...), then also the following are *expressions*:
  * $e_1 \oplus e_2$
  * `if e then e1 else e2`
  * $(e)$
  * $e_1\ e_2$
  * $(e_1, \ldots, e_n)$

Examples:

* `3 * x + 7` This is equivalent to `(3 * x) + 7` (operator $\ast$ binds stronger than $+$)
* `sqrt 2` This is normal function application

  `sqrt(2)` is also correct, but not necessary.
* `sqrt 2 * sqrt 2` This is equivalent to `(sqrt 2) * (sqrt 2)` (standard function application binds stronger than infix operators)
* `x * if x > 0 then 3 else -1`

Note that this is an *inductive* definition:

* it defines some *atomic* expressions (constants, identifiers)
* and how larger expressions can be *composed from smaller ones*.

In compiler construction, one typically uses *context-free grammars* to express such inductive definitions, e.g.,

$\mathit{expr} ::= \mathit{CONST} \mid \mathit{IDENT} \mid \mathit{expr}\ \mathit{INFIXOP}\ \mathit{expr} \mid \texttt{if}\ \mathit{expr}\ \texttt{then}\ \mathit{expr}\ \texttt{else}\ \mathit{expr} \mid \ldots$

but we do not go into that in this course.

## Slide 6 of 39: The Syntax unlocked so far (3/3):

### Declarations

If $e$ is an expression and $f$ and $x_1, \ldots, x_n$ are identifiers, then the following are *declarations*:

* `let f = e`
* `let f (x1, ..., xn) = e`
* `let rec f = e`
* `let rec f (x1, ..., xn) = e`

Each of these define a function or value $f$ by the expression $e$ where

* Keyword `rec` must be used, if the definition is *recursive*, i.e., if $f$ occurs in $e$.
* In the cases with `(x1, ..., xn)`, $f$ is a function that takes an $n$-tuple as input and $e$ may contain the $x_i$.

### Example

```fsharp
let rec pow (x,n) = if n=0 then 1.0 else x * pow (x,n-1)
```

*That is the syntax we unlocked with the first example!*

This is already Turing complete (with unbounded memory).

## Slide 7 of 39: Patterns

We had also seen pattern matching as a way to describe case distinction nicely, for instance:

```fsharp
let rec power(x,n) =
   match (x,n) with
   | (_,0) -> 1.0               (* 1 *)
   | (x,n) -> x * power(x,n-1)   (* 2 *)
```

### Patterns

A pattern can be any of the following:

* A constant
* An identifier
* The wildcard `_`
* If $p_1, \ldots p_n$ are patterns, then also $(p_1, \ldots, p_n)$ is a pattern.

### Expressions

An expression can also be:

$$
\begin{array}{l}
\texttt{match}\ e\ \texttt{with} \\
\quad \mid p_1 \to e_1 \\
\quad \ldots \\
\quad \mid p_n \to e_n
\end{array}
$$

if $p_1, \ldots, p_n$ are patterns and $e, e_1, \ldots, e_n$ are expressions.

Unlocking: we will extend the concepts of expressions, patterns, and declarations, during the course with every feature we discuss.

## Slide 8 of 39: Outline

1. Recap: What we have seen of F# so far
2. **Last Week's Exercises**
3. Intro to Types
4. Intro to Higher-Order Functions
5. Lists
6. On functional decomposition
7. Exercises

## Slide 9 of 39: Exercises

Recursive Functions:

* Hansen and Rischel Book (HR):

  Exercise 1.4: Define a function $f$ with $f(n) = 1 + 2 + \ldots + n$.

  Exercise 1.6: Define a function $\mathit{sum}$ such that

  $\mathit{sum}(m, n) = m + (m + 1) + ... + (m + n - 1) + (m + n)$

  Exercise 2.8: Define $\binom{n}{k}$ where $0 \leq k \leq n$, according to the definition:

  $$
  \binom{n}{0} = \binom{n}{n} = 1 \qquad \binom{n}{k} = \binom{n-1}{k} + \binom{n-1}{k-1}
  $$

## Slide 10 of 39: Outline

1. Recap: What we have seen of F# so far
2. Last Week's Exercises
3. **Intro to Types**
4. Intro to Higher-Order Functions
5. Lists
6. On functional decomposition
7. Exercises

## Slide 11 of 39: Introduction to Types

F# is a *typed* language:

* Every value *is supposed to have* a type (like `int`).
* There are *typing rules* that specify what is a type-correct expression, declaration, or pattern.
  * This is a restriction on the *syntactically correct* expressions
  * e.g. `3*3.1` is syntactically correct, but a type error (multiplying an `int` with a `float`).
* You (normally) do not specify types, but the F# interpreter or compiler will try to *infer* them for you.
* When F# tools report a *type error*, it almost always represents a real problem in your program: you specified something you don't want.

## Slide 12 of 39: Types

### Types

A type can be any of the following:

* Basic types: `int`, `float`, `bool`, `string` ...
* Tuples: $\tau_1 \star \ldots \star \tau_n$ where the $\tau_i$ are already types
* Functions: $\tau_1 \to \tau_2$ where $\tau_1$ and $\tau_2$ are types
* Later we also have type variables and type constructors

For instance we have `power: float*int -> float`

Generally $e : \tau$ means expression $e$ is of type $\tau$.

## Slide 13 of 39: Basic Typing Rules

*N.B.: Defining a typing system is involved, we simplify matters here.*

### Constants

Constants have basic types that are recognized directly:

* e.g. `3:int`, `3.14:float`, `true:bool` ...

### Built-in Infix Functions

| if | then |
|---|---|
| `e1 : int` `e2 : int` | `e1 + e2 : int` |
| `e1 : float` `e2 : float` | `e1 + e2 : float` |
| $\ldots$ | |
| `e1 : int` `e2 : int` | `e1 = e2 : bool` |
| `e1 : int` `e2 : int` | `e1 < e2 : bool` |
| $\ldots$ | |

### Variables/Identifiers

Usually type not given. It is the task of *type inference* to figure out a type that fits.

E.g. in $x + 3.1$ we have that $3.1 : \mathit{float}$ and $+$ works only if both arguments have the same type, so $x : \mathit{float}$.

## Slide 14 of 39: Basic Typing Rules

### Conditionals

The expression `if e0 then e1 else e2` is only type correct if:

* `e0 : bool`
* There is *some* type $\tau$ such that both $e_1 : \tau$ and $e_2 : \tau$

The expression has then type $\tau$.

Example: `if n>0 then 1.0 else x`

Is this type correct, and what types must `n` and `x` have?

### Tuples

For expressions $e_1 : \tau_1, \ldots, e_n : \tau_n$:

$(e_1, \ldots, e_n) : \tau_1 \star \ldots \star \tau_n$

## Slide 15 of 39: Basic Typing Rules

### Patterns

Typing of patterns works just like typing of expressions where a wildcard `_` is replaced with a fresh variable name.

### Pattern Matching

The expression

$$
\begin{array}{l}
\texttt{match}\ e\ \texttt{with} \\
\quad \mid p_1 \to e_1 \\
\quad \ldots \\
\quad \mid p_n \to e_n
\end{array}
$$

is type correct if the following holds:

* The expression $e$ must have the same type as the patterns:

  There is some type $\tau_0$ such that $e : \tau_0$ and $p_1 : \tau_0, \ldots p_n : \tau$
* All the results for each case must have the same type:

  There is some type $\tau$ such that $e_1 : \tau, \ldots, e_n : \tau$

The entire match expression has then type $\tau$.

## Slide 16 of 39: Basic Typing Rules

### Declarations

If $e : \tau$ for some type $\tau$, then the declaration

$$
\texttt{let rec}\ v = e
$$

implies that also $v : \tau$.

If $e : \tau$ for some type $\tau$ and $p : \tau_0$ then

$$
\texttt{let rec}\ f\ p = e
$$

implies that $f : \tau_0 \to \tau$

In recursive function declarations like `power`, the type inference has to figure out types $\tau$ and $\tau_0$ so that this rule is satisfied.

Example: Infer the type of power

```fsharp
let rec power (x,n) =
  match n with
  | 0 -> 1.0
  | _ -> x * power(x,n-1)
```

## Slide 17 of 39: Outline

1. Recap: What we have seen of F# so far
2. Last Week's Exercises
3. Intro to Types
4. **Intro to Higher-Order Functions**
5. Lists
6. On functional decomposition
7. Exercises

## Slide 18 of 39: Higher-Order Functions

### Idea

**Functions are values**

* In conventional languages, often only *data* can be argument or result of a function (e.g., `int`, or `int-array`).
* In functional languages, also functions (computations) can be argument or result of a function.
* We call a function *higher-order*, if it has a function as argument or result.

## Slide 19 of 39: `fun`

### Function Expressions

Let $x$ be a variable of type $\tau_0$ and $e$ be an expression of type $\tau$. Then also

$$
\texttt{fun}\ x\ \texttt{->}\ e
$$

is an expression that defines a function that takes an $x$ and returns $e$. Thus, the resulting expression is of type $\tau_0 \to \tau$.

Example: what is the type of this?

```fsharp
let rec powerC =
  fun x ->
    fun n ->
      match n with
      | 0 -> 1.0
      | _ -> x * ( powerC x (n-1) )
```

For comparison:

```fsharp
let rec power (x,n) =
  match n with
  | 0 -> 1.0
  | _ -> x * power(x,n-1)
```

```fsharp
power  : float *  int -> float
powerC : float -> int -> float
```

## Slide 20 of 39: Some Syntactic Sugar

Since we often need this we have some *syntactic sugar*, i.e., abbreviating notation:

### Function Declaration

$$
\texttt{let rec}\ f\ p_1\ \ldots\ p_n = e
$$

is an abbreviation for:

$$
\texttt{let rec}\ f = \texttt{fun}\ p_1\ \texttt{->}\ \ldots\ \texttt{fun}\ p_n\ \texttt{->}\ e
$$

Thus we can simply write

```fsharp
let rec powerC x n =
   match n with
   | 0 -> 1.0
   | _ -> x * ( powerC x (n-1) )
```

For comparison:

```fsharp
let rec power (x,n) =
  match n with
  | 0 -> 1.0
  | _ -> x * power(x,n-1)
```

```fsharp
power  : float *  int -> float
powerC : float -> int -> float
```

But what's the advantage of this?

## Slide 21 of 39: Comparison: tuple vs. higher-order function

```fsharp
// powerC: float ->  (int -> float)
let rec powerC x n =
  match n with
  | 0 -> 1.0
  | _ -> x * ( powerC x (n-1) )
```

* the argument of powerC is the base $x$
* and `powerC x` is the function that maps exponent $n$ to $x^n$

The function may be evaluated in *stages*:

```fsharp
let pow2 = powerC 2.0;;
pow2 3;;
val it : float = 8.0
pow2 4;;
val it : float = 16.0
```

## Slide 22 of 39: Higher-Order Functions

### General Idea

* Instead of a function that takes an $n$-tuple of arguments

  $$
  f : \tau_1 \star \ldots \tau_n \to \tau
  $$

* you can have a higher-order function that evaluates in $n$ stages of one argument:

  $$
  fC : \tau_1 \to \tau_2 \to \ldots \tau_n \to \tau
  $$

* Idea due to Moses Schönfinkel and Haskell Curry
  * Hence they are called *schönfinkeled* or *curried* functions.

This allows often for very elegant programs, so typically people define functions curried in functional languages.

Example:

```fsharp
let cube x = powerC x 3
```

## Slide 23 of 39: Outline

1. Recap: What we have seen of F# so far
2. Last Week's Exercises
3. Intro to Types
4. Intro to Higher-Order Functions
5. **Lists**
6. On functional decomposition
7. Exercises

## Slide 24 of 39: Lists

A list is a finite sequence of elements having the same type:

$[v_1; \ldots; v_n]$ ([] is called the empty list)

```fsharp
[2;3;6];;
val it : int list = [2; 3; 6]

["a"; "ab"; "abc"; ""];;
val it : string list = ["a"; "ab"; "abc"; ""]

[sin; cos];;
val it : (float->float) list = [<fun:...>; <fun:...>]

[(1,true); (3,true)];;
val it : (int * bool) list = [(1, true); (3, true)]

[[]; [1]; [1;2]];;
val it : int list list = [[]; [1]; [1; 2]]
```

## Slide 25 of 39: List constructors

*The formal definition of lists:*

### Lists

A list (*with elements of type* $\tau$) can be **constructed** as follows:

* [] (the empty list)
* If $e$ is an expression (*of type* $\tau$) and $l$ is a list (with elements of type $\tau$), then also

  $e :: l$ is a list *with elements of type* $\tau$ .

Lists are also expressions.

Lists are *homogenous*, i.e., all elements are of the same (arbitrary) type $\tau$.

The list type is thus called *$\tau$-list*.

The notation $[x_1; x_2; \ldots; x_n]$ is just a *syntactic sugar* for $x_1::x_2::\ldots::x_n::[]$.

The *constructor* $::$ is pronounced *cons*

For a non-empty list $[x_1; x_2; \ldots; x_n]$, $n \geq 1$, we call

* $x_1$ the *head* and
* $[x_2; \ldots; x_n]$ the *tail*.

There are library functions `List.head` and `List.tail`.

## Slide 26 of 39: Lists for Pattern Matching

### Pattern matching (for Lists)

Let $p_1$ and $p_2$ be patterns, then also the following are patterns:

* []

  matching only the empty list
* `p1 :: p2`

  matching only a list with at least one element, where
  * the head matches $p_1$ (of some type $\tau$)
  * and the tail matches $p_2$ (of type $\tau$ *list*)

## Slide 27 of 39: Recursion on lists – a simple example

$$
\texttt{suml}\ [x_1;x_2;\ldots;x_n] = \sum_{i=1}^{n} x_i = x_1 + x_2 + \cdots + x_n = x_1 + \sum_{i=2}^{n} x_i
$$

*Constructors are used in list patterns*

```fsharp
let rec suml xs =
  match xs with
  | [] -> 0
  | x::tail -> x + suml tail

val suml : int list -> int
```

$$
\begin{array}{lll}
 & \texttt{suml [1;2]} & \\
\rightsquigarrow & \texttt{1 + suml [2]} & (\texttt{x} \mapsto \texttt{1}\ \text{and}\ \texttt{tail} \mapsto \texttt{[2]}) \\
\rightsquigarrow & \texttt{1 + (2 + suml [])} & (\texttt{x} \mapsto \texttt{2}\ \text{and}\ \texttt{tail} \mapsto \texttt{[]}) \\
\rightsquigarrow & \texttt{1 + (2 + 0)} & (\text{the pattern}\ \texttt{[]}\ \text{matches the value}\ \texttt{[]}) \\
\rightsquigarrow & \texttt{1 + 2} & \\
\rightsquigarrow & \texttt{3} &
\end{array}
$$

*Recursion follows the structure of lists*

## Slide 28 of 39: A *polymorphic* list function (I)

The function *remove y xs* gives the list obtained from *xs* by deleting every occurrence of $y$, e.g. `remove 2 [1; 2; 0; 2; 7] = [1; 0; 7]`.

Recursion is following the structure of the list:

```fsharp
let rec remove y xs =
  match xs with
  | [] -> []
  | x::tail when x=y -> remove y tail
  | x::tail -> x::remove y tail
```

List elements can be of *any type* that supports *equality*

```fsharp
remove :  'a -> 'a list    -> 'a list when 'a : equality
```

* `'a` is a *type variable*. I usually prefer to write $\alpha, \tau, \ldots$
* *'a : equality* is a type constraint
  * we can only apply `remove` to $\alpha$ lists, if equality is defined on $\alpha$, e.g. $\mathit{int}, \mathit{string}, \ldots$ but *not functions*.

The F# system infers the *most general type* for *remove*

## Slide 29 of 39: A *polymorphic* list function (II)

* A type containing type variables is called a *polymorphic type*
* The remove function is called a *polymorphic function*.

  ```fsharp
  remove : 'a -> 'a list -> 'a list when 'a : equality
  ```

The function has *many forms*, one for each instantiation of *'a*:

Instantiating `'a` with `int`:

```fsharp
remove 2 [1; 2; 0; 2; 7];;
val it : int list = [1; 0; 7]
```

Instantiating `'a` with `int list`:

```fsharp
remove [2] [[2;1]; [2]; [0;1]; [2]; [5;6;7]];;
val it : int list list = [[2; 1]; [0; 1]; [5; 6; 7]]
```

Notice that `->` *associates to the right*:

```fsharp
'a -> 'a list -> 'a list  means 'a -> ('a list -> 'a list)
```

## Slide 30 of 39: Exploiting *structured* patterns: the *isPrefix* function

The function `isPrefix xs ys` tests whether the list $xs$ is a prefix of the list $ys$, for example:

$$
\begin{aligned}
\texttt{isPrefix}\ [1;2;3]\ [1;2;3;8;9] &= \mathrm{true} \\
\texttt{isPrefix}\ [1;2;3]\ [1;2;8;3;9] &= \mathrm{false}
\end{aligned}
$$

The function is declared as follows:

```fsharp
let rec isPrefix xs ys =    // Each clause expresses
  match (xs,ys) with        // a natural property:
  | ([],_) -> true          // [] is prefix of any list
  | (_,[]) -> false         // non-empty list is not prefix of []
  | (x::xtail,y::ytail) ->  // non-empty is prefix of non-empty
      x=y &&                // if first element equal and
      isPrefix xtail ytail  // rests are in prefix relation

isPrefix [1;2;3] [1;2];;
val it : bool = false
```

## Slide 31 of 39: Summary

* Lists
* Polymorphism
* Constructors (:: and [] for lists)
* Patterns
* Recursion on the structure of lists
* Constructors used in *patterns* to *decompose* structured values
* Constructors used in *expressions* to *compose* structured values

## Slide 32 of 39: Outline

1. Recap: What we have seen of F# so far
2. Last Week's Exercises
3. Intro to Types
4. Intro to Higher-Order Functions
5. Lists
6. **On functional decomposition**
7. Exercises

## Slide 33 of 39: Functional decomposition

A simple technique when solving a complex problem is

* to partition it into smaller well-defined parts and, thereafter,
* to compose these parts to solve the original problem.

The main goal is that a program is constructed by

* combining simple well-understood pieces

*Invent useful helper functions*

## Slide 34 of 39: Functional decomposition: Example 1

Sorting a list: `sort: 'a list -> 'a list when 'a : comparison`.

Insertion in an ordered list is easy:

```fsharp
(* insert:'a -> 'a list -> 'a list when 'a : comparison *)

let rec insert x ys =
  match ys with
  | [] -> [x]
  | y::_ when x <= y -> x::ys
  | y::ytail -> y::insert x ytail
```

Insertion sort can now easily be implemented:

```fsharp
let rec sort xs =
  match xs with
  | [] -> []
  | x::xtail -> insert x (sort xtail)
```

* small comprehensible programs

Notice: *there are better sorting algorithms than insertion sort*

## Slide 35 of 39: Idea: mergesort

Idea mergesort:

* Use recursion for sorting.
* To sort a list, one could split it into two smaller parts of half the size and sort the parts recursively.
* Then we just need to merge the two sorted parts into one sorted list.
* What is the base case of the recursion, i.e., where no further recursion is necessary?
* What's the runtime of mergesort?

## Slide 36 of 39: Functional decomposition: Example 2

Consider multiplication of polynomials:

$$
\begin{aligned}
0 \cdot Q(x) &= 0 \\
(a_0 + a_1 \cdot x + ... + a_n \cdot x^n) \cdot Q(x) &= a_0 \cdot Q(x) + x \cdot \big((a_1 + a_2 \cdot x + ... + a_n \cdot x^{n-1}) \cdot Q(x)\big)
\end{aligned}
$$

### Idea

Represent polynomes by a list of coefficients:

`type Poly = int list` defines a new type `Poly`

* `[1; 2; 3]` represents $1 + 2x + 3x^2$
* `[2; 0; 0; 1]` represents $2 + x^3$
* General: `[a0; ...; an]` for $a_0 + a_1x + a_2x^2 + \ldots + a_nx^n$

Invent suitable auxiliary functions

* `mulC: int -> Poly -> Poly` — for multiplying a polynome by a constant

  e.g. `mulC 3 [1;2;3] = [3;6;9]`
* `mulX: Poly -> Poly` — for multiplying a polynome $P(x)$ by its variable $x$

  e.g. `mulX [1;2;3] = [0;1;2;3]`
* `add: Poly -> Poly -> Poly` — for adding two polynomes

  e.g. `add [1;2;3] [0;1] = [1;3;3]`

With these helpers define `mul: Poly -> Poly -> Poly` by the equation above.

e.g. `mul [2;3;0;1] [1;2;3]= [2;7;12;10;2;3]`

## Slide 37 of 39: Invent helper function(s): Blackboard exercise

Declare a function `sumProd: int list -> int*int`:

$$
\begin{array}{l}
\texttt{sumProd [}x_0\texttt{;}x_1\texttt{;}\ \ldots\texttt{;}x_{n-1}\texttt{]} \\
\phantom{\texttt{sumProd []}}\quad = \quad \texttt{(}\ x_0\ \texttt{+}\ x_1\ \texttt{+}\ \ldots\ \texttt{+}\ x_{n-1}\ \texttt{,}\ x_0\ \texttt{*}\ x_1\ \texttt{*}\ \ldots\ \texttt{*}\ x_{n-1}\ \texttt{)} \\
\texttt{sumProd []}\quad = \quad \texttt{(0,1)}
\end{array}
$$

## Slide 38 of 39: Outline

1. Recap: What we have seen of F# so far
2. Last Week's Exercises
3. Intro to Types
4. Intro to Higher-Order Functions
5. Lists
6. On functional decomposition
7. **Exercises**

## Slide 39 of 39: Exercises

* HR 1.5: the Fibonacci numbers

  $$
  \begin{aligned}
  F_0 &= 0 \\
  F_1 &= 1 \\
  F_n &= F_{n-1} + F_{n-2}\ \text{for}\ n > 1
  \end{aligned}
  $$

* HR 2.2: $\texttt{pow}(\texttt{s},\texttt{n}) = \underbrace{s \cdot s \cdot \ldots \cdot s}_{n}$ for string $s$ and int $n$.
* HR 4.7: `multiplicity x xs` – compute the number of times `x` occurs in `xs`.
* Polynome exercise from slide 36 ($\approx$ HR 4.22).
* Merge sort: idea explained in class on blackbord

  Define helper functions (they are all in the List library, but easy to write yourself):
  * `length: 'a list->int` length of a list

    e.g. `length [1;2;3] = 3`
  * `split: int->'a list->('a list,'a list)` split a list into two after a given number of elements

    e.g. `split 2 [1;2;3;4;5] = ([1;2],[3;4;5])`
  * `merge: ('a list,'a list) -> 'a list` merge a pair of sorted lists into one sorted list.

  Put it together into mergesort.
