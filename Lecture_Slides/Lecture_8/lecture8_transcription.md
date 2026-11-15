# 02157 Functional Programming, Week 8: Finite Trees (II)

Transcribed from `Lecture8-zeb.pdf`, 18 slides, one section per slide.

## Slide 1 of 18

**02157 Functional Programming**

**Week 8:**

**Finite Trees (II)**

Sebastian Mödersheim

Based on slides by Michael Reichhardt Hansen

October 30, 2026

## Slide 2 of 18: Overview

Finite trees: Two examples

* An interpreter for a simple expression language
* An interpreter for a simple while-language

## Slide 3 of 18: Interpreters for two simple languages — Purpose

To show the power of a functional programming language, we present a prototype for interpreters for a simple expression language with local declarations and a simple WHILE language.

* Concrete syntax: defined by a contextfree grammar
* Abstract syntax (parse trees): defined by algebraic datatypes
* Semantics, i.e. meaning of programs: inductively defined following the structure of the abstract syntax

*succinct programs, fast prototyping*

The interpreter for the simple expression language is a higher-order function:

$$
\mathit{eval} : \mathit{Program} \to \mathit{State} \to \mathit{Value}
$$

The interpreter for a simple imperative programming language is a higher-order function:

$$
I : \mathit{Program} \to \mathit{State} \to \mathit{State}
$$

## Slide 4 of 18: Expressions with local declarations

Concrete syntax:

```text
a * (-3 + (let x = 5 in x + a))
```

The *abstract syntax* is defined by an algebraic datatype:

```fsharp
type ExprTree = | Const of int
                | Ident of string
                | Minus of ExprTree
                | Sum   of ExprTree * ExprTree
                | Diff  of ExprTree * ExprTree
                | Prod  of ExprTree * ExprTree
                | Let of string * ExprTree * ExprTree;;
```

Example:

```fsharp
let et =
  Prod(Ident "a",
       Sum(Minus (Const 3),
           Let("x", Const 5, Sum(Ident "x", Ident "a"))));;
```

## Slide 5 of 18: Evaluation in Environments

An *state* (aka *environment*) contains *bindings* of identifiers to values.

A tree `Let(s,t1,t2)` is evaluated in an environment *env*:

1. Evaluate $t_1$ to value $v_1$ in environment *env*.
2. Evaluate $t_2$ in *env* *extended with the binding of $s$ to $v_1$*.

An evaluation function

```fsharp
eval: ExprTree -> Map<string,int> -> int
```

is defined as follows:

```fsharp
let rec eval t env =
  match t with
  | Const n -> n
  | Ident s -> Map.find s env
  | Minus t -> - (eval t env)
  | Sum(t1,t2) -> eval t1 env + eval t2 env
  | Diff(t1,t2) -> eval t1 env - eval t2 env
  | Prod(t1,t2) -> eval t1 env * eval t2 env
  | Let(s,t1,t2) ->
      let v1 = eval t1 env
      let env1 = Map.add s v1 env
      eval t2 env1;;
```

## Slide 6 of 18: Example

Concrete syntax:

```text
a * (-3 + (let x = 5 in x + a))
```

```fsharp
let et =
  Prod(Ident "a",
       Sum(Minus (Const 3),
           Let("x", Const 5, Sum(Ident "x", Ident "a"))));;
```

```fsharp
let env = Map.add "a" -7 Map.empty;;
eval et env;;
val it : int = 35
```

## Slide 7 of 18: Example: Imperative Factorial program

An example of concrete syntax for a factorial program:

```text
y:=1 ;
while !(x=0)
do (y:= y*x;x:=x-1)
```

Typical ingredients

* Arithmetical expressions
* Boolean expressions
* Statements (assignments, sequential composition, loops, $\ldots$

## Slide 8 of 18: Arithmetic Expressions

* A type for the abstract syntax for Arithmetical Expressions

```fsharp
type AExp =      (* Arithmetical expressions *)
   | N  of int             (* numbers        *)
   | V  of string          (* variables      *)
   | Add of AExp * AExp    (* addition       *)
   | Mul of AExp * AExp    (* multiplication *)
   | Sub of AExp * AExp;;  (* subtraction    *)
```

You do not need parenthesis, precedence rules, etc. in the *abstract syntax*

*you work directly on trees*.

## Slide 9 of 18: Semantics of Arithmetic Expressions

* A *state* maps variables to integers

```fsharp
type State = Map<string,int>;;
```

* The meaning of an expression is a function:

```fsharp
A: AExp -> State -> int
```

defined inductively on the structure of arithmetic expressions

```fsharp
let rec A a s      =
   match a with
    | N n         -> n
    | V x         -> Map.find x s
    | Add(a1, a2) -> A a1 s + A a2 s
    | Mul(a1, a2) -> A a1 s * A a2 s
    | Sub(a1, a2) -> A a1 s - A a2 s;;
```

## Slide 10 of 18: Boolean Expressions

* Abstract syntax

```fsharp
type BExp =          (* Boolean expressions *)
   | TT                     (* true         *)
   | FF                     (* false        *)
   | Eq of ....             (* equality     *)
   | Lt of ....             (* less than    *)
   | Neg of ....            (* negation     *)
   | Con of ....       ;;   (* conjunction  *)
```

* Semantics $\text{B} : \text{BExp} \to \text{State} \to \text{bool}$

```fsharp
let rec B b s =
   match b with
   | TT       -> true
   | ....
```

## Slide 11 of 18: Statements: Abstract Syntax

```fsharp
type Stm  =                     (* statements             *)
   | Assign of string * AExp    (* assignment             *)
   | Seq  of Stm list           (* sequential composition *)
   | ITE   of BExp * Stm * Stm  (* if-then-else           *)
   | While of BExp * Stm;;      (* while                  *)
```

Example of concrete syntax:

```text
y:=1 ; while not(x=0) do (y:= y*x ; x:=x-1)
```

Abstract syntax *?*

## Slide 12 of 18: Update of states

An imperative program performs a sequence of *state updates*.

* The expression

  `update y v s`

  is the state that is as $s$ except that $y$ is mapped to $v$.

* Update is a synonym for `Map.add`:

```fsharp
let update x v s = Map.add x v s;;
```

## Slide 13 of 18: Interpreter for Statements

* The meaning of statements is a function

$$
I : \mathit{Stm} \to \mathit{State} \to \mathit{State}
$$

that is defined by recursion on the structure of statements:

```fsharp
let rec I stm s =
    match stm with
    | Assign(x,a)      -> update x ( ... ) s
    | Seq stms         -> ...
    | ITE(b,stm1,stm2) -> ...
    | While(b, stm)    -> ... ;;
```

## Slide 14 of 18: Example: Factorial function

```fsharp
(*
      y:=1 ; while !(x=0) do (y:= y*x;x:=x-1)
*)
```

```fsharp
let fac = Seq [Assign("y", N 1);
               While(Neg(Eq(V "x", N 0)),
                    Seq [Assign("y", Mul(V "x", V "y")) ;
                         Assign("x", Sub(V "x", N 1)) ])];;
```

```fsharp
(* Define an initial state                           *)
let s0 = Map.ofList [("x",4)];;
val s0 : Map<string,int> = map [("x", 4)]
```

```fsharp
(* Interpret the program                             *)
let s1 = I fac s0;;
val s1 : Map<string,int> = map [("x", 0); ("y", 24)]
```

## Slide 15 of 18

Interpreter will be available on Learn.

* You may add the statements *skip*, *if-then* and *repeat-until*.
* Suppose that an expression of the form $\mathit{inc}(x)$ is added. It adds one to the value of $x$ in the current state, and the value of the expression is this new value of $x$.

  How would you refine the interpreter to cope with this construct?

  * Analyse the problem and state the types for the refined interpretation functions

## Slide 16 of 18: Compiler Mini-Project

*Code Generation*

Recall we had defined (example solution on Learn):

* Source language: a simple expression language
  * Data type `Exp` the abstract syntax of the source language
  * `sem : Environment -> Exp -> int` the semantics of the source language, where the `Environment` is a `Map` from variable names to `ints`.
* Target language: The stack machine
  * `Stack`: a list of integers
  * `Instruction`: an instruction for the stack machine
  * `intpInstr: Instruction -> Stack -> Stack`: how executing an instruction modifies the stack.
  * TODO: `exec: Intruction list -> int` executing a list of instructions, starting from the empty stack

### Today

```fsharp
compile : Environment -> Exp -> Instruction list
```

Translator from source to target language such that for every expression e and environment env:

```fsharp
exec (compile env e) = sem env e
```

## Slide 17 of 18: Compiler Mini-Project

*Code Generation Idea: Postfix*

### Postfix (aka Reverse Polish Notation)

Write every operator *after* its arguments, e.g., $(3 + 7) + (4 - 5)$ has postfix form $3\ 7 + 4\ 5 - +$

One never needs parentheses in postfix form.

The postfix form corresponds exactly to how the stack machine should compute an expression:

| Postfix | 3 | 7 | $+$ | 4 | 5 | $-$ | $+$ |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Corresponds to | `PUSH 3` | `PUSH 7` | `ADD` | `PUSH 4` | `PUSH 5` | `MINUS` | `ADD` |

## Slide 18 of 18: Compiler Mini-Project

*Code Generation: Optimization*

* For better performance, compilers usually perform a variety of optimizations.
* We look here at so-called *constant propagation*:

### Constant-propagation

```text
Add(C i, C j)  -> C(i + j)
Add(e, C 0)    -> e
Add(C 0, e)    -> e
Sub(C i, C j)  -> C(i-j)
Sub(e, C 0)    -> e
Sub(C 0, e)    -> Minus e
Minus(C i)     -> C(-i)
Minus(Minus e) -> e
Abs(C i)       -> C(abs(i))
Abs(Minus e)   -> Abs e
Abs(Abs e)     -> Abs e
```

* We want a reduction procedure `red: Exp -> Exp` that finds all reductions, i.e., the resulting expression is *normalized* with respect to these reduction rules.
* We expect that `sem env (red e) = sem env e` for any expression `e` and `Environment env`, i.e., the optimization is *semantically correct*.
