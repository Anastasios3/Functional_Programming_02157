# 02157 Functional Programming, Week 7: Finite Trees (I)

Transcribed from `Lecture7zeb.pdf`, 25 slides, one section per slide.

## Slide 1 of 25

**02157 Functional Programming**

**Week 7:**

**Finite Trees (I)**

Sebastian Mödersheim

Based on slides by Michael Reichhardt Hansen

October 23, 2026

## Slide 2 of 25: Finite trees

A *finite tree* is a value containing sub-components of the *same type*

Example: A *binary tree*

```text
                       Br
          /            |            \
        Br             9             Br
     /   |   \                   /    |    \
   Br    7    Lf               Br     21     Br
  / | \                       / | \         / | \
Lf  2  Lf                   Lf 13  Lf     Lf 25  Lf
```

A tree is a connected, acyclic, undirected graph, where

* the top node (carrying value 9) is called the *root*
* a *branch node* has two *children* constructor *Br*
* a node without children is called a *leaf* constructor *Lf*

## Slide 3 of 25: Example: Binary Trees

Remember how we defined lists as algebraic data types...

We can use algebraic data types in a similar way to define trees:

```fsharp
type Tree = | Lf
            | Br of Tree*int*Tree;;
```

This is an inductive definition that could be written out as:

1. `Lf` is a `Tree`
2. if $t_1, t_2$ are `Tree`s and $n$ is an integer, then $\texttt{Br}(t_1, n, t_2)$ is a `Tree`.
3. nothing else.

The tags *Lf* and *Br* are called *constructors*:

```fsharp
Lf : Tree
Br : Tree * int * Tree -> Tree
```

## Slide 4 of 25: Example: Binary Trees

```text
                       Br
          /            |            \
        Br             9             Br
     /   |   \                   /    |    \
   Br    7    Lf               Br     21     Br
  / | \                       / | \         / | \
Lf  2  Lf                   Lf 13  Lf     Lf 25  Lf
```

Corresponding F#-value:

```fsharp
Br(Br(Br(Lf,2,Lf),7,Lf),
   9,
   Br(Br(Lf,13,Lf),21,Br(Lf,25,Lf)))
```

## Slide 5 of 25: Traversals of binary trees

* Pre-order traversal: First visit the root node, then traverse the left sub-tree in pre-order and finally traverse the right sub-tree in pre-order.
* *In-order traversal*: First traverse the left sub-tree in in-order, then visit the root node and finally traverse the right sub-tree in in-order.
* Post-order traversal: First traverse the left sub-tree in post-order, then traverse the right sub-tree in post-order and finally visit the root node.

## Slide 6 of 25: Binary *search* tree

*Condition:* for every node containing the value $x$: every value in the left subtree is smaller then $x$, and every value in the right subtree is greater than $x$.

Example: A *binary search tree*

```text
                       Br
          /            |            \
        Br             9             Br
     /   |   \                   /    |    \
   Br    7    Lf               Br     21     Br
  / | \                       / | \         / | \
Lf  2  Lf                   Lf 13  Lf     Lf 25  Lf
```

## Slide 7 of 25: Binary search trees: Insertion

* Recursion following the structure of trees
* Constructors `Lf` and `Br` are used in *patterns* to decompose a tree into its parts
* Constructors `Lf` and `Br` are used in *expressions* to construct a tree from its parts
* The search tree condition is an *invariant* for `insert`

Example:

```fsharp
let t1 = Br(Lf, 3, Br(Lf, 5, Lf));;
let t2 = insert 4 t1;;
val t2 : Tree = Br (Lf,3,Br (Br (Lf,4,Lf),5,Lf))
```

## Slide 8 of 25: Parameterize type declarations

The programs on search trees require only an ordering on elements – they no not need to be integers.

A polymorphic tree type is declared as follows:

```fsharp
type Tree<'a> = | Lf | Br of Tree<'a> * 'a * Tree<'a>;;
```

Program text is unchanged (though *polymorphic* now)

## Slide 9 of 25: So far

* Declaration of a recursive algebraic data type, that is, a type for a finite tree
* Meaning of the type declaration:
  * rules for generating values
* Archetypical functions on trees:
  * gathering information from a tree Example: *inOrder*
  * inspecting a tree Example: *contains*
  * construction of a new tree Example: *insert*

## Slide 10 of 25: Manipulation of arithmetical expressions

Consider $f(x)$:

$$
3 \cdot (x - 1) - 2 \cdot x
$$

We may be interested in

* computation of values, e.g. $f(2)$
* differentiation, e.g. $f'(x) = (3 \cdot 1 + 0 \cdot (x - 1)) - (2 \cdot 1 + 0 \cdot x)$
* simplification of the expressions, e.g. $f'(x) = 1$
* .....

We would like a suitable representation of such arithmetical expressions that supports the above manipulations

How would you visualize the expressions as a tree?

* root?
* leaves?
* branches?

## Slide 11 of 25: Example: Expression Trees

```fsharp
type Fexpr =
  | Const of float
  | X
  | Add of Fexpr * Fexpr
  | Sub of Fexpr * Fexpr
  | Mul of Fexpr * Fexpr
  | Div of Fexpr * Fexpr;;
```

Defines 6 *constructors*:

* `Const: float -> Fexpr`
* `X : Fexpr`
* `Add: Fexpr * Fexpr -> Fexpr`
* `Sub: Fexpr * Fexpr -> Fexpr`
* `Mul: Fexpr * Fexpr -> Fexpr`
* `Div: Fexpr * Fexpr -> Fexpr`

* Can you write 3 values of type Fexpr?
* Drawings of trees?

## Slide 12 of 25: Expressions: Computation of values

Given a value (a float) for `X`, then every expression denote a float.

```fsharp
compute : float -> Fexpr -> float
```

Example:

```fsharp
compute 4.0 (Mul(X, Add(Const 2.0, X)));;
val it : float = 24.0
```

## Slide 13 of 25: Blackboard exercise: Substitution

```fsharp
type Fexpr = | Const of float
             | X
             | Add of Fexpr * Fexpr
             | Sub of Fexpr * Fexpr
             | Mul of Fexpr * Fexpr
             | Div of Fexpr * Fexpr;;
```

Declare a function

```fsharp
substX: Fexpr -> Fexpr -> Fexpr
```

so that $\texttt{substX}\ e'\ e$ is the expression obtained from $e$ by substituting every occurrence of `X` with $e'$

For example:

```fsharp
let ex = Add(Sub(X, Const 2.0), Mul(Const 4.0, X));;

substX (Div(X,X)) ex;;
val it : Fexpr =
   Add(Sub(Div(X,X), Const 2.0), Mul(Const 4.0, Div(X,X)))
```

## Slide 14 of 25: Symbolic Differentiation `D: Fexpr -> Fexpr`

A classic example in functional programming: given a function as an expression, symbolically compute the derivative.

For example:

```fsharp
D(Add(Mul(Const 3.0, X), Mul(X, X)));;
val it : Fexpr =
  Add
    (Add (Mul (Const 0.0,X),Mul (Const 3.0,Const 1.0)),
     Add (Mul (Const 1.0,X),Mul (X,Const 1.0)))
```

## Slide 15 of 25: Trees with a variable number of sub-trees

An archetypical declaration:

```fsharp
type ListTree<'a> = Node of 'a * (ListTree<'a> list)
```

* `Node(x,[])` represents a leaf tree containing the value $x$
* $\texttt{Node}(x,[t_0;\ldots;t_{n-1}])$ represents a tree with value $x$ in the root and with $n$ sub-trees represented by the values $t_0, \ldots, t_{n-1}$

```text
       1
     / | \
    2  3  4
    |    / \
    5   6   7
```

It is represented by the value `t1` where

```fsharp
let t7 = Node(7,[]);;    let t6 = Node(6,[]);;
let t5 = Node(5,[]);;    let t3 = Node(3,[]);;
let t2 = Node(2,[t5]);;  let t4 = Node(4,[t6; t7]);;
let t1 = Node(1,[t2; t3; t4]);;
```

## Slide 16 of 25: Depth-first traversal of a ListTree

```text
       1
     / | \
    2  3  4
    |    / \
    5   6   7
```

Corresponds to the following order of the elements: 1, 2, 5, 3, 4, 6, 7

Invent *a more general function* traversing a list of List trees:

```fsharp
let rec depthFirstList =
   function
   | [] -> []
   | Node(n,ts)::trest -> n::depthFirstList(ts @ trest)
depthFirstList : ListTree<'a> list -> 'a list

let depthFirst t = depthFirstList [t]
 depthFirst1 : t:ListTree<'a> -> 'a list

depthFirst t1;;
val it : int list = [1; 2; 5; 3; 4; 6; 7]
```

## Slide 17 of 25: Mutual recursion. Example: File system

```text
                     d1
                     |
+--------------------+--------------------+
|   a1         d2          a4         d3  |
               |                      |
          +----+-----+             +--+--+
          | a2    d3 |             |  a5 |
                  |
               +--+--+
               |  a3 |
```

* A *file system* is a list of *elements*
* an *element* is a file or a directory, which is a named *file system*

*We focus on structure now – not on file content*

## Slide 18 of 25: Mutually recursive type declarations

* are combined using *and*

```fsharp
type FileSys = Element list
and Element =
  | File of string
  | Dir of string * FileSys

let d1 =
  Dir("d1",[File "a1";
            Dir("d2", [File "a2";
                       Dir("d3", [File "a3"])]);
            File "a4";
            Dir("d3", [File "a5"])
           ])
```

*The type of d1 is ?*

## Slide 19 of 25: Mutually recursive function declarations

* are combined using *and*

Example: extract the names occurring in file systems and elements.

```fsharp
let rec namesFileSys =
  function
  | []    -> []
  | e::es -> (namesElement e) @ (namesFileSys es)
and namesElement =
  function
  | File s    -> [s]
  | Dir(s,fs) -> s :: (namesFileSys fs) ;;
val namesFileSys : Element list -> string list
val namesElement : Element -> string list

namesElement d1 ;;
val it : string list = ["d1"; "a1"; "d2"; "a2";
                        "d3"; "a3"; "a4"; "d3"; "a5"]
```

## Slide 20 of 25: Summary

Finite Trees

* recursive declarations of algebraic types
* meaning of type declarations: rules generating values
* typical recursions following the structure of trees
* trees with a fixed branching structure
* trees with a variable number of sub-trees including two techniques *Tree list* $\to \ldots$
  * use of mutually recursive function declarations
  * use of a more general helper function

  to handle the arbitrary branching
* illustrative examples

Mutually recursive type and function declarations

## Slide 21 of 25: Mini-Project: Simple Compiler

* Many compilers translate a high-level language to an intermediate language.
  * E.g. Java to Java Byte Code,
  * F#, C#, ... to CRL (Common Language Runtime)
  * LLVM project (many GNU compilers)
* Advantages of an intermediate language:
  * Independent from CPU/OS. For each CPU/OS to support, just write an interpreter/compiler for the intermediate language.
  * There can be specialized compilers from intermediate language to machine code of a given CPU. The developer of the compiler from high-level to intermediate format does not need to worry about it. Future CPUs are supported by just a new “backend” for the intermediate language.
* In part 1, we define a simple expression language as the “high-level” language and an interpreter on this high-level language.
* In part 2, we define an abstract stack-based machine as intermediate language and how this machine processes an instruction.
* Next week we translate from high-level to stack-based machine.
* The purposes of this mini-project are:
  * to exercise functional programming concepts on finite trees
  * to introduce techniques that are based on the treatment of programs as data, and
  * to provide an appetizer for a following course: Computer Science Modelling.

## Slide 22 of 25: Mini-Project: Simple Compiler

*Part 1: Expression Language*

Similar to the examples from the lecture, make a type declaration for expressions that can be any of the following

* integer constants (constructor `C`), e.g., `C 3`
* variables (constructor `V`), e.g., `V "x"`
* operations for addition of two expression (constructor `Add`), e.g. `Add (C 3, V "x")`
* subtraction of two expressions (constructor `Sub`), e.g. `Sub (C 3, V "x")`
* change sign of an expression (constructor Minus), e.g. `Minus (V "x")`
* and absolute value of an expression (constructor Abs), e.g. `Abs (V "x")`

Thus declare a type `Exp` that can hold such expressions. This is the (abstract) *syntax* of our language.

## Slide 23 of 25: Mini-Project: Simple Compiler

*Part 1: Expression Language*

To explain the *semantics* (i.e. meaning) of the language, we first need an *environment* that says for each variable what integer value it has:

```fsharp
Type Environment = Map<string,int>
```

For instance:

```fsharp
let env = Map.ofList [("x",3);("y",-3)]
let example = Add(Abs(Minus(C 7)), Sub(V "x", Minus(Add(C 2, V "y"))))
```

The example expression would in standard notation be writte as $|-7| + (x - \textcolor{blue}{(-}(2 + y)\textcolor{blue}{)})$ and under $x = 3$ and $y = -3$ we get 9.

*In a previous version of the slides, there was a mistake omitting the blue-marked negation.*

Define a function `sem : Environment -> Exp -> int` that computes in this way the resulting integer from an expression. The function stops with an error if the expression contains a variable that is not defined in the environment.

## Slide 24 of 25: Mini-Project: Simple Compiler

*Part 2: Abstract Stack Machine*

We consider a simple abstract stack machine with instructions for addition, subtraction, change sign and absolute value, and an instruction for pushing an integer to the top of the stack.

The instruction set of this stack machine is modelled by the following F# type:

```fsharp
type Instruction = | ADD | SUB | SIGN | ABS | PUSH of int
type Stack = int list
```

The execution of an instruction maps a stack to a new stack:

* The execution of ADD with stack $\boxed{a\ b\ c\ \cdots}$ yields a new stack: $\boxed{(b + a)\ c\ \cdots}$, where the top two elements $a$ and $b$ on the stack have been replaced by the single element $(b + a)$.
* Similarly with regard to the instruction SUB.
* The execution of SIGN with stack $\boxed{a\ b\ \cdots}$ yields a new stack: $\boxed{(-a)\ b\ \cdots}$, where the top element $a$ on the stack has been replaced by the single element $-a$
* Similarly with regard to the instruction ABS.
* The execution of PUSH r with the stack $\boxed{a\ b\ c\ \cdots}$ pushes $r$ on top of the stack, the new stack is: $\boxed{r\ a\ b\ c\ \cdots}$

Declare an F# function to interpret the execution of a single instruction:

```fsharp
intpInstr: Instruction -> Stack -> Stack
```

## Slide 25 of 25: Exercises

From the 2022 summer exam https://www.imm.dtu.dk/ mire/FSharpBook/OldExams/02157-2022summer.pdf consider Problem 1, task 1-3 with the following modification:

* Define `type Shelf` as a search tree as shown in the lecture, i.e., each branch node contains a string $s$ and the left subtree contains only strings smaller than $s$ and the right subtree contains only strings larger than $s$.
* If you have time, also tasks 4-6 are a good exercise (you may consider also a search tree for the loans).
